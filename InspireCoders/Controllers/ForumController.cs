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
    public class ForumController : ControllerBase
    {
        private readonly IRepo<Forum> _repo;

        public ForumController(IRepo<Forum> repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Forum data)
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

        [HttpPatch]
        public async Task<IActionResult> Patch(Forum data)
        {
            await _repo.updateAsync(data);
            return Ok();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int ID)
        {
            await _repo.deleteAsync(ID);
            return Ok();

        }


    }
}
