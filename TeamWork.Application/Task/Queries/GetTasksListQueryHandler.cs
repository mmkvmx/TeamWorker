using AutoMapper;
using MediatR;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamWork.Application.Interfaces;
using TeamWork.Application.Task.Models;

namespace TeamWork.Application.Task.Queries
{
    public record GetTasksQuery : IRequest<TasksList> { }

    public class GetTasksQueryHandler(ITasksDbContext tasksDbContext, IMapper mapper) 
    { 
        public async Task<TasksList> Handle(GetTaskQuery query, CancellationToken cancellationToken)
        {
            var tasks = await tasksDbContext.Tasks
            .ProjectTo<TaskItemDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        }
    }
}
