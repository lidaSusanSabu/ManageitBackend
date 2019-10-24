﻿using System;
using System.Collections.Generic;

namespace Manageit.Entities
{
    public partial class Gender
    {
        public Gender()
        {
            EmployeeDetails = new HashSet<EmployeeDetails>();
        }

        public int GenderId { get; set; }
        public string Gender1 { get; set; }

        public virtual ICollection<EmployeeDetails> EmployeeDetails { get; set; }
    }
}
