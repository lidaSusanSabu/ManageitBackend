using System;
using System.Collections.Generic;

namespace Manageit.Entities
{
    public partial class Authentications
    {
        public int AuthId { get; set; }
        public int? EmpId { get; set; }
        public string EmpPassword { get; set; }

        public virtual EmployeeDetails Emp { get; set; }
    }
}
