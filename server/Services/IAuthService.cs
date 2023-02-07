using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Services
{
    public interface IAuthService
    {
        void CreateUser(string email, string password);
    }
}
