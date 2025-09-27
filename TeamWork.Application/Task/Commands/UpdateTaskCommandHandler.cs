using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TeamWork.Application.Interfaces;
using TeamWork.Domain.Entities.Enums;
using TeamWork.Application.Common.Exceptions;

namespace TeamWork.Application.Task.Commands
{
    public record UpdateTaskCommand : IRequest<Guid>
    {
        public Guid Id { get; init; }
        public string? Title { get; init; }
        public string? Description { get; init; }
        public string? Status { get; set; }
        public string? Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public Guid? AssignedToUserId { get; set; }
    }

    public class UpdateTaskCommandHandler(ITasksDbContext tasksDbContext) : IRequestHandler<UpdateTaskCommand, Guid>
    {
        public async Task<Guid> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var entity = tasksDbContext.Tasks.FirstOrDefault(t => t.Id == request.Id);
            if (entity is null)
            {
                throw new NotFoundException(nameof(entity), request.Id);
            }
            
            entity.Title = request.Title ?? entity.Title;
            entity.Description = request.Description ?? entity.Description;
            entity.Status = request.Status is not null && Enum.TryParse<TaskEnums.Status>(request.Status, true, out var status) ? status : entity.Status;
            entity.Priority = request.Priority is not null && Enum.TryParse<TaskEnums.Priority>(request.Priority, true, out var priority) ? priority : entity.Priority;
            entity.DueDate = request.DueDate ?? entity.DueDate;
            entity.AssignedToUserId = request.AssignedToUserId ?? entity.AssignedToUserId;
            await tasksDbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
