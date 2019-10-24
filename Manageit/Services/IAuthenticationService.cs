using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibraryManageit.Models;

namespace Manageit.Services
{
    public interface IAuthenticationService
    {
        public int Authenticate(LoginDetails loginDetails);
    }
}
