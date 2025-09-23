using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TeamWork.Domain.Entities.Enums;

namespace TeamWork.Domain.Entities
{
    public class TaskItem : EntityBase
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public TaskEnums.Status Status { get; set; }
        public TaskEnums.Priority Priority { get; set; }
        public DateTime DueDate { get; set; }
        public Guid AssignedToUserId { get; set; }
    }
}
