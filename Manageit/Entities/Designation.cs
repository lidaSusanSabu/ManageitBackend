using System;
using System.Collections.Generic;

namespace Manageit.Entities
{
    public partial class Designation
    {
        public Designation()
        {
            EmployeeDetails = new HashSet<EmployeeDetails>();
        }

        public int DesignationId { get; set; }
        public string Designation1 { get; set; }

        public virtual ICollection<EmployeeDetails> EmployeeDetails { get; set; }
    }
}
