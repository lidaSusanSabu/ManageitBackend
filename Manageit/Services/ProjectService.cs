using Manageit.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibraryManageit.Models;

namespace Manageit.Services
{
    public class ProjectService: IProjectService
    {
        private manageitDBContext _manageitContext;
        public ProjectService(manageitDBContext manageitContext)
        {
            _manageitContext = manageitContext;
        }
        public IList<ProjectModel> GetProjectDetails(int employeeId)
        {
            var outputList = new List<ProjectModel>();
            var projects = _manageitContext.ProjectAssignment.Where(p => p.EmpId == employeeId).Select(p => p.ProjectId);


            foreach (var  project in projects)
                {
                if (project != null)
                {
                    var ProjectItem = _manageitContext.ProjectDetails.Where(p => p.ProjectId == project).FirstOrDefault();
                    var eachProject = new ProjectModel();
                    eachProject.ProjectName = ProjectItem.ProjectName;
                    eachProject.ProjectId = project.Value;
                    eachProject.ProjectDescription = ProjectItem.ProjectDescription;

                    outputList.Add(eachProject);

                }
                    
                
                    

                }
            

            return outputList;
        }
    }
}
