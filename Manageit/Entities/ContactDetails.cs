using System;
using System.Collections.Generic;

namespace Manageit.Entities
{
    public partial class ContactDetails
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public string MobileNumber { get; set; }

        public virtual EmployeeDetails Emp { get; set; }
    }
}
