using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamWork.Domain.Entities.Enums
{
    public class TaskEnums
    {
        public enum Status
        {
            Open,
            InProgress,
            Done,
            Blocked
        }
        public enum Priority
        {
            Low,
            Medium,
            High,
            Critical
        }
    }
}
