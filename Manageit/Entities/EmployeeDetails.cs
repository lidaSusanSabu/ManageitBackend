using System;
using System.Collections.Generic;

namespace Manageit.Entities
{
    public partial class EmployeeDetails
    {
        public EmployeeDetails()
        {
            Authentications = new HashSet<Authentications>();
            ContactDetails = new HashSet<ContactDetails>();
            ProjectAssignment = new HashSet<ProjectAssignment>();
            TaskAssignment = new HashSet<TaskAssignment>();
        }

        public int EmpId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public int? GenderId { get; set; }
        public int? DesignationId { get; set; }

        public virtual Designation Designation { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual ICollection<Authentications> Authentications { get; set; }
        public virtual ICollection<ContactDetails> ContactDetails { get; set; }
        public virtual ICollection<ProjectAssignment> ProjectAssignment { get; set; }
        public virtual ICollection<TaskAssignment> TaskAssignment { get; set; }
    }
}
