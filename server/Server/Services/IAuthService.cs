using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services
{
    public interface IAuthService
    {
        Task<List<User>> GetAllUsers();
        Task<User> CreateUser(string username, string password);
        Task<string?> Login(string username, string password);
    }
}
