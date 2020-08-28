using InspireCoders.Presentation;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspireCoders.Domain
{
    public class AccountService: IAccountService
    {
        private readonly TokensSettings _tokensSettings;
        private readonly IAccountRepo _accountsRepository;

        public AccountService(IOptions<TokensSettings> tokensSettings, IAccountRepo accountsRepository)
        {
            _tokensSettings = tokensSettings.Value;
            _accountsRepository = accountsRepository;
        }

        public List<User> GetAllUsers()
        {
            return _accountsRepository.GetAllUsers().ToList();
        }

        public async Task<bool> AddUserAsync(User newUser)
        {
            _accountsRepository.AddEntity(newUser);

            // attach basic roleID as default, if it has no role object

            //if (newUser.Role == null)
            //{
            //    Guid.TryParse("8E4094AF-20C7-4105-93F9-6C1B5D71684F", out Guid id);
            //    newUser.RoleId = id;
            //}
                 


            var result = Task.Run(() => _accountsRepository.SaveAll());
            return await result;
        }

        public User GetUserById(Guid id)
        {
            return _accountsRepository.GetUserById(id);
        }

        public User GetUserByUsername(string username)
        {
            return _accountsRepository.GetUserByUsername(username);
        }

        public User GetUserByEmail(string email)
        {
            return _accountsRepository.GetUserByEmail(email);
        }

        public User GetUserByPhone(string phone)
        {
            return _accountsRepository.GetUserByPhone(phone);
        }

        public async Task<bool> CheckPasswordAsync(string password, string passwordHash, string passwordSalt)
        {
            var result = Task.Run(() => CryptoHandler.GetHash(password, passwordSalt) == passwordHash);
            return await result;
        }

        public TokensSettings GetTokensSettings()
        {
            return _tokensSettings;
        }

        public async Task<List<Role>> GetAllRoles()
        {
            return await _accountsRepository.GetAllRoles();
        }

        public async Task<bool> AddRoleAsync(Role newRole)
        {
            newRole.Id = new Guid();
            await _accountsRepository.AddEntity(newRole);
            var result = Task.Run(() => _accountsRepository.SaveAll());
            return await result;
        }

        public async Task<Role> GetRoleByIdAsync(Guid id)
        {
            var role = Task.Run(() => _accountsRepository.GetRoleById(id));
            return await role;
        }

        public async Task<Role> GetRoleByNameAsync(string name)
        {
            var role = Task.Run(() => _accountsRepository.GetRoleByName(name));
            return await role;
        }

        public async Task SeedAsync()
        {
            // Get permissions for admin role
            var assignedPermissions = new List<PermEnums> {

                PermEnums.CreateUser,
                PermEnums.ReadUser,
                PermEnums.UpdateUser,
                PermEnums.DeleteUser,

                PermEnums.CreateRole,
                PermEnums.ReadRole,
                PermEnums.UpdateRole,
                PermEnums.DeleteRole,

                PermEnums.CreateCourse,
                PermEnums.ReadCourse,
                PermEnums.UpdateCourse,
                PermEnums.DeleteCourse,

                PermEnums.CreateFacilitator,
                PermEnums.ReadFacilitator,
                PermEnums.UpdateFacilitator,
                PermEnums.DeleteFacilitator,

                PermEnums.CreateForum,
                PermEnums.ReadForum,
                PermEnums.UpdateForum,
                PermEnums.DeleteForum,

                PermEnums.CreateStudent,
                PermEnums.ReadStudent,
                PermEnums.UpdateStudent,
                PermEnums.DeleteStudent,

                PermEnums.ReadApplicant

            };

            var permissions = assignedPermissions.Select(c => ((int)c).ToString()).ToList();

            // Seed the Admin Role
            var name = "Administrators";
            var role = await GetRoleByNameAsync(name);
            if (role == null)
            {
                role = new Role
                {
                    Description = "Admin Role",
                    Name = name,
                    Permissions = string.Join(",", permissions)
                };
                await AddRoleAsync(role);
            }

            // Seed the Admin User
            var email = "admin@inspirecoders.com";
            var user = GetUserByEmail(email);
            if (user == null)
            {
                var salt = CryptoHandler.GenerateSalt();
                user = new User
                {
                    LastName = "Site",
                    FirstName = "Admin",
                    Email = "admin@inspirecoders.com",
                    Username = "admin",
                    PasswordSalt = salt,
                    PasswordHash = CryptoHandler.GetHash("P@ssw0rd!", salt),
                    RoleId = role.Id,
                    // RegistrationIP = new NetworkHandler().GetIPAddress(HttpContext),
                    DateModified = DateTime.Now,
                    DateCreated = DateTime.Now,
                    IsDeleted = false,
                    IsDisabled = false
                };

                var result = await AddUserAsync(user);
                if (!result)
                {
                    throw new InvalidOperationException("Could not create user in Seeding");
                }
            }
        }
    }
}
