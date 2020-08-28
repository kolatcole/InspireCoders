using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InspireCoders.Domain
{
    public interface IAccountRepo
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(Guid id);
        User GetUserByUsername(string username);
        User GetUserByEmail(string email);
        User GetUserByPhone(string phone);
        Task<List<Role>> GetAllRoles();
        Task<Role> GetRoleById(Guid id);
        Task<Role> GetRoleByName(string name);
        bool SaveAll();
        Task AddEntity(object model);
    }
}
