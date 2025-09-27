using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamWork.Application.Common.Mappings;
using TeamWork.Domain.Entities;
using TeamWork.Domain.Entities.Enums;
using AutoMapper;

namespace TeamWork.Application.Task
{
    public class TaskItemDto : IMapWith<TaskItem>
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public TaskEnums.Status? Status { get; set; }
        public TaskEnums.Priority? Priority { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DueDate { get; set; }
        public Guid AuthorId { get; set; }
        public Guid? AssignedToUserId { get; set; }

        // Реализация метода маппинга
        public void Mapping(Profile profile)
        {
            profile.CreateMap<TaskItem, TaskItemDto>();
        }
    }
}
