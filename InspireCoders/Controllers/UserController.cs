using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using InspireCoders.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InspireCoders.Presentation.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAccountService _accountsService;

        public UserController(IAccountService accountsService)
        {
            _accountsService = accountsService;
        }

        [HasPermission(PermEnums.ReadUser)]
        [HttpGet("")]
        public IActionResult Get()
        {
            try
            {
                var users = _accountsService.GetAllUsers();

               return StatusCode((int)HttpStatusCode.OK, users);
            }
            catch (Exception ex) { return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message); }
        }

        [HttpPost()]
        public async Task<IActionResult> Post(User data)
        {


            try
            {
                var status =await _accountsService.AddUserAsync(data);

                return StatusCode((int)HttpStatusCode.OK, status);
            }
            catch (Exception ex) { return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message); }
            // await _accountsService.SeedAsync();
           // return Ok();

        }
    }
}
