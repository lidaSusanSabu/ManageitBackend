using System;
using System.Collections.Generic;

namespace Manageit.Entities
{
    public partial class TaskDetails
    {
        public TaskDetails()
        {
            TaskAssignment = new HashSet<TaskAssignment>();
        }

        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskDetails1 { get; set; }
        public string TaskStatus { get; set; }
        public DateTime? Deadline { get; set; }

        public virtual ICollection<TaskAssignment> TaskAssignment { get; set; }
    }
}
