using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Services
{
    public interface IAuthService
    {
        Task<User> CreateUser(string username, string password);
        Task<User?> Login(string username, string password);
    }
}
