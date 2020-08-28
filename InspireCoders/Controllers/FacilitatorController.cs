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

        [HasPermission(PermEnums.CreateFacilitator)]
        [HttpPost]
        public async Task<IActionResult> Post(Facilitator data)
        {
            var result = await _repo.insertAsync(data);
            return Ok(result);
        }

        [HasPermission(PermEnums.ReadFacilitator)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _repo.getAllAsync();
            return Ok(result);
        }

        [HasPermission(PermEnums.ReadFacilitator)]
        [HttpGet("{code}")]
        public async Task<IActionResult> Get(string code)
        {
            var result = await _repo.getByCodeAsync(code);
            return Ok(result);
        }

        [HasPermission(PermEnums.ReadFacilitator)]
        [HttpGet("GetByName/{nickName}")]
        public async Task<IActionResult> GetByName(string nickName)
        {
            var result = await _repo.getByNameAsync(nickName);
            return Ok(result);
        }

        [HasPermission(PermEnums.UpdateFacilitator)]
        [HttpPatch]
        public async Task<IActionResult> Patch(Facilitator data)
        {
            await _repo.updateAsync(data);
            return Ok();
        }

        [HasPermission(PermEnums.DeleteStudent)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int ID)
        {
            await _repo.deleteAsync(ID);
            return Ok();
        }

    }
}
