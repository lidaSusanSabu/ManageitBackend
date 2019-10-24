using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manageit.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Manageit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private IProjectService _ProjectService;
        public ProjectController(IProjectService ProjectService)
        {
            _ProjectService = ProjectService;
        }
        [HttpGet("{employeeId}")]
       
        public IActionResult GetProjects(int employeeId)
        {

            var projects= _ProjectService.GetProjectDetails(employeeId);

            return Ok(projects);
        }
    }
}