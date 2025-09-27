using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamWork.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TeamWork.Application.Common.Exceptions;
using AutoMapper;

namespace TeamWork.Application.Task.Queries
{
    public record GetTaskQuery : IRequest<TaskItemDto>
    {
        public Guid Id { get; init; }
    }
    public class GetTaskQueryHandler(ITasksDbContext tasksDbContext, IMapper mapper) : IRequestHandler<GetTaskQuery, TaskItemDto>
    {
        public async Task<TaskItemDto> Handle(GetTaskQuery request, CancellationToken cancellationToken)
        {
            var entity = await tasksDbContext.Tasks.FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(entity), request.Id);
            }

            var response = mapper.Map<TaskItemDto>(entity);

            return response;
        }
    }
}
