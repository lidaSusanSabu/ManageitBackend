using System;
using System.Collections.Generic;

namespace Manageit.Entities
{
    public partial class TaskAssignment
    {
        public int Id { get; set; }
        public int? TaskId { get; set; }
        public int? EmpId { get; set; }
        public int? ProjectId { get; set; }

        public virtual EmployeeDetails Emp { get; set; }
        public virtual ProjectDetails Project { get; set; }
        public virtual TaskDetails Task { get; set; }
    }
}
