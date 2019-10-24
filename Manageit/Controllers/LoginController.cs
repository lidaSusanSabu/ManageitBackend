using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibraryManageit.Models;
using Manageit.Entities;
using Manageit.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Manageit.Controllers
{
    [Route("api")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class LoginController : ControllerBase
    {
        private IAuthenticationService _authenticationService;
        public LoginController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost("login")]
        public IActionResult loginAuthentication([FromBody]LoginDetails loginDetails)
        {
            var actionPerformed = _authenticationService.Authenticate(loginDetails);
            


            return Ok(actionPerformed);
        }
    }
}