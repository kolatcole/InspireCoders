using InspireCoders.Presentation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InspireCoders.Domain
{
    public interface IAccountService
    {
        List<User> GetAllUsers();
        Task<bool> AddUserAsync(User user);
        User GetUserById(Guid id);
        User GetUserByUsername(string username);
        User GetUserByEmail(string email);
        User GetUserByPhone(string phone);
        Task<bool> CheckPasswordAsync(string password, string passwordHash, string passwordSalt);
        TokensSettings GetTokensSettings();
        Task<List<Role>> GetAllRoles();
        Task<bool> AddRoleAsync(Role role);
        Task<Role> GetRoleByIdAsync(Guid id);
        Task<Role> GetRoleByNameAsync(string name);
        Task SeedAsync();
    }
}
