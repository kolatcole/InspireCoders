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
    public class FacilitatorController : ControllerBase
    {
        private readonly IRepo<Facilitator> _repo;

        public FacilitatorController(IRepo<Facilitator> repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Facilitator data)
        {
            var result = await _repo.insertAsync(data);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _repo.getAllAsync();
            return Ok(result);
        }

    }
}
