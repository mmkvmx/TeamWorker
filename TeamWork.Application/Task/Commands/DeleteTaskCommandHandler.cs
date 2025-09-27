using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamWork.Application.Common.Exceptions;
using TeamWork.Application.Interfaces;

namespace TeamWork.Application.Task.Commands
{
    public record DeleteTaskCommand : IRequest<Unit>
    {
        public Guid Id { get; init; }
    }

    public class DeleteTaskCommandHandler(ITasksDbContext tasksDbContext) : IRequestHandler<DeleteTaskCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var entity = await tasksDbContext.Tasks.FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);
            if (entity is null)
                throw new NotFoundException(nameof(entity), request.Id);

            tasksDbContext.Tasks.Remove(entity);
            await tasksDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}
