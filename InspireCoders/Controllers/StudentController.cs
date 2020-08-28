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
    public class StudentController : ControllerBase
    {
        private readonly IRepo<Student> _repo;

        public StudentController(IRepo<Student> repo)
        {
            _repo = repo;
        }

        [HasPermission(PermEnums.CreateStudent)]
        [HttpPost]
        public async Task<IActionResult> Post(Student data)
        {
            var result = await _repo.insertAsync(data);
            return Ok(result);
        }

        [HasPermission(PermEnums.ReadStudent)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _repo.getAllAsync();
            return Ok(result);
        }

        [HasPermission(PermEnums.ReadStudent)]
        [HttpGet("{code}")]
        public async Task<IActionResult> Get(string code)
        {
            var result = await _repo.getByCodeAsync(code);
            return Ok(result);
        }

        [HasPermission(PermEnums.ReadStudent)]
        [HttpGet("GetByName/{nickName}")]
        public async Task<IActionResult> GetByName(string nickName)
        {
            var result = await _repo.getByNameAsync(nickName);
            return Ok(result);
        }

        [HasPermission(PermEnums.UpdateStudent)]
        [HttpPatch]
        public async Task<IActionResult> Patch(Student data)
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
