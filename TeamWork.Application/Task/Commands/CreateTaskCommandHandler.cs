using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamWork.Application.Interfaces;
using TeamWork.Domain.Entities;
using TeamWork.Domain.Entities.Enums;

namespace TeamWork.Application.Task.Commands
{
    public record CreateTaskCommand : IRequest<Guid>
    {
        [Required]
        public string Title { get; init; } = null!;
        public string? Description { get; init; }
        public string? Status { get; init; }
        public string? Priority { get; init; }
        public DateTime? DueDate { get; init; }
        public Guid? AssignedToUserId { get; init; }
        public Guid AuthorId { get; init; }
    }

    public class CreateTaskCommandHandler(ITasksDbContext tasksDbContext) : IRequestHandler<CreateTaskCommand, Guid>
    {
        public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {

            var taskItem = new TaskItem
            {
                Title = request.Title,
                Description = request.Description,      // nullable 
                Status = Enum.TryParse<TaskEnums.Status>(request.Status, true, out var status) ? status : TaskEnums.Status.Open,
                Priority = Enum.TryParse<TaskEnums.Priority>(request.Priority, true, out var priority) ? priority : TaskEnums.Priority.Medium,
                DueDate = request.DueDate,              // nullable 
                AssignedToUserId = request.AssignedToUserId,
                AuthorId = request.AuthorId,
                CreatedAt = DateTime.UtcNow
            };

            tasksDbContext.Tasks.Add(taskItem);
            await tasksDbContext.SaveChangesAsync(cancellationToken);

            return taskItem.Id;
        }
    }
}
