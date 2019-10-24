using ClassLibraryManageit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manageit.Services
{
    public interface IProjectService
    {
        public IList<ProjectModel> GetProjectDetails(int employeeId);
    }
}
