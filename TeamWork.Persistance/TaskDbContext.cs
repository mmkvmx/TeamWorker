using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamWork.Application.Interfaces;
using TeamWork.Persistence.EntityTypeConfigurations;
using TeamWork.Domain.Entities;
namespace TeamWork.Persistence
{
    public class TaskDbContext : DbContext, ITasksDbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {
        }
        public DbSet<TaskItem> Tasks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaskConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
