using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InspireCoders.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InspireCoders.Presentation.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IRepo<Facilitator> _repo;

        public InstructorController(IRepo<Facilitator> repo)
        {
            _repo = repo;
        }

        [HttpPost("SaveInstructor")]
        public async Task<IActionResult> SaveInstructor(Facilitator data)
        {
            var result = await _repo.insertAsync(data);
            return Ok(result);
        }

        [HttpGet("GetAllInstructors")]
        public async Task<IActionResult> GetAllInstructors()
        {
            var result = await _repo.getAllAsync();
            return Ok(result);
        }

    }
}
