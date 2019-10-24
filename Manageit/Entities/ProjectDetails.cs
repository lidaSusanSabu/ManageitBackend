using System;
using System.Collections.Generic;

namespace Manageit.Entities
{
    public partial class ProjectDetails
    {
        public ProjectDetails()
        {
            ProjectAssignment = new HashSet<ProjectAssignment>();
            TaskAssignment = new HashSet<TaskAssignment>();
        }

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }

        public virtual ICollection<ProjectAssignment> ProjectAssignment { get; set; }
        public virtual ICollection<TaskAssignment> TaskAssignment { get; set; }
    }
}
