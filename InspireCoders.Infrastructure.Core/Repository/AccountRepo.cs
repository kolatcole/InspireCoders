using InspireCoders.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspireCoders.Infrastructure
{
    public class AccountRepo : IAccountRepo
    {
        private readonly TContext _ctx;

        public AccountRepo(TContext ctx)
        {
            _ctx = ctx;
        }

        public async Task AddEntity(object model)
        {
            await _ctx.AddAsync(model);
        }

        public IEnumerable<User> GetAllUsers()
        {
            try
            {
                return _ctx.Users.Include(u => u.Role)
                           .OrderByDescending(p => p.DateCreated)
                           .ToList();
            }
            catch
            {
                return null;
            }
        }

        public User GetUserById(Guid id)
        {
            try
            {
                return GetAllUsers().FirstOrDefault(u => u.Id == id);
            }
            catch
            {
                return null;
            }
        }

        public User GetUserByUsername(string username)
        {
            try
            {
                return GetAllUsers().FirstOrDefault(u => u.Username == username);
            }
            catch
            {
                return null;
            }
        }

        public User GetUserByEmail(string email)
        {
            try
            {
                return GetAllUsers().FirstOrDefault(u => u.Email == email);
            }
            catch
            {
                return null;
            }
        }

        public User GetUserByPhone(string phone)
        {
            try
            {
                return GetAllUsers().FirstOrDefault(u => u.Phone == phone);
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<Role>> GetAllRoles()
        {
            try
            {
                return await _ctx.Roles
                           .OrderByDescending(p => p.DateCreated)
                           .ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<Role> GetRoleById(Guid id)
        {
            try
            {
                return await _ctx.Roles.FirstOrDefaultAsync(u => u.Id == id);
            }
            catch
            {
                return null;
            }
        }

        public async Task<Role> GetRoleByName(string name)
        {
            try
            {
                return await _ctx.Roles.FirstOrDefaultAsync(u => u.Name == name);
            }
            catch
            {
                return null;
            }
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
