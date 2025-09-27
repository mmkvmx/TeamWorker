using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamWork.Domain.Entities;

namespace TeamWork.Application.Interfaces
{
    public interface ITasksDbContext
    {
        DbSet<TaskItem> Tasks { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
