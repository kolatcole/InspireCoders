using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using InspireCoders.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InspireCoders.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IAccountService _accountsService;

        public RoleController(IAccountService accountsService)
        {
            _accountsService = accountsService;
        }

        [HasPermission(PermEnums.ReadRole)]
        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var roles = await _accountsService.GetAllRoles();

                return StatusCode((int)HttpStatusCode.OK, roles);
            }
            catch (Exception ex) { return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message); }
        }

        
        [HttpGet("GetByID/{id}")]
        public async Task<ActionResult<Role>> GetByID(Guid id)
        {
            try
            {
                //if (string.IsNullOrWhiteSpace(id))
                //{
                //    return StatusCode((int)HttpStatusCode.BadRequest, string.Format("Please enter a valid name", name));
                //}

                var role = await _accountsService.GetRoleByIdAsync(id);

                if (role == null)
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, string.Format("{0}  does not exist", id));
                }

                return StatusCode((int)HttpStatusCode.OK, role);
            }
            catch (Exception ex) { return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message); }
        }


        [HasPermission(PermEnums.CreateRole)]
        [HttpPost("")]
        public async Task<ActionResult> PostAsync([FromBody] Role role)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(role.Name))
                { return StatusCode((int)HttpStatusCode.PreconditionFailed, "Please enter a valid name"); }

                if (await _accountsService.GetRoleByNameAsync(role.Name) != null)
                { return StatusCode((int)HttpStatusCode.Conflict, string.Format("{0} already exists", role.Name)); }

                role.DateModified = DateTime.Now;
                role.DateCreated = DateTime.Now;

                await _accountsService.AddRoleAsync(role);

                return StatusCode((int)HttpStatusCode.Created, "Role created successfully !!!");
            }

            //catch (Exception ex) { return this.custom_error(ex); } // TODO
            catch (Exception ex) { return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message); }
        }

        [HasPermission(PermEnums.ReadRole)]
        [HttpGet("{name}")]
        public async Task<ActionResult<Role>> Get(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, string.Format("Please enter a valid name", name));
                }

                var role = await _accountsService.GetRoleByNameAsync(name);

                if (role == null)
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, string.Format("{0}  does not exist", name));
                }

                return StatusCode((int)HttpStatusCode.OK, role);
            }
            catch (Exception ex) { return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message); }
        }
    }
}
