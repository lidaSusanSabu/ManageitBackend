using ClassLibraryManageit.Models;
using Manageit.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manageit.Services
{
    public class AuthenticationService:IAuthenticationService
    {
        private manageitDBContext _manageitContext;
        public AuthenticationService(manageitDBContext manageitContext)
        {
            _manageitContext = manageitContext;
        }
        public int Authenticate(LoginDetails loginDetails)
        {
            var password = _manageitContext.Authentications.Where(p => p.EmpId == loginDetails.empId).FirstOrDefault();
            if (password == null)
                return 0;
            if(password.EmpPassword == loginDetails.password)
                return loginDetails.empId;
            return 0;
        }
    }
}
