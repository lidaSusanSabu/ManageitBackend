using System;
using System.Collections.Generic;

namespace Manageit.Entities
{
    public partial class ProjectAssignment
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public int? ProjectId { get; set; }
        public DateTime? StartPeriod { get; set; }
        public DateTime? EndPeriod { get; set; }

        public virtual EmployeeDetails Emp { get; set; }
        public virtual ProjectDetails Project { get; set; }
    }
}
