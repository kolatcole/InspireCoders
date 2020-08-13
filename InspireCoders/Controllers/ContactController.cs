using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InspireCoders.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InspireCoders.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IRepo<Contact> _repo;

        public ContactController(IRepo<Contact> repo)
        {
            _repo = repo;
        }

        [HttpPost("SaveContact")]
        public async Task<IActionResult> SaveContact(Contact data)
        {
            var result = await _repo.insertAsync(data);
            return Ok(result);
        }

        [HttpGet("GetAllContacts")]
        public async Task<IActionResult> GetAllContacts()
        {
            var result = await _repo.getAllAsync();
            return Ok(result);
        }


    }
}
