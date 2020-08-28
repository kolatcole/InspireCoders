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
        private readonly IForumService _service;

        public ForumController(IForumService service)
        {
            _service = service;
        }

        [HasPermission(PermEnums.CreateForum)]
        [HttpPost]
        public async Task<IActionResult> Post(Forum data)
        {
            var result = await _service.CreateForum(data);
            return Ok(result);
        }

        [HasPermission(PermEnums.ReadForum)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetForums();
            return Ok(result);
        }

        [HasPermission(PermEnums.CreateStudent)]
        [HttpPatch("AddStudent")]
        public async Task<IActionResult> AddStudent(int forumID, string StudentIDs)
        {
            var result = await _service.AddStudent(forumID, StudentIDs);
            return Ok(result);
        }

        [HasPermission(PermEnums.ReadForum)]
        [HttpGet("{studentID}")]
        public async Task<IActionResult> ForumsByStudent(int studentID)
        {
            var result = await _service.getForumsByStudentID(studentID);
            return Ok(result);
        }


        [HasPermission(PermEnums.ReadForum)]
        [HttpGet("{code}")]
        public async Task<IActionResult> Get(string code)
        {
            var result = await _service.GetForumByCode(code);
            return Ok(result);
        }

        [HasPermission(PermEnums.ReadForum)]
        [HttpGet("GetByName/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var result = await _service.GetForumByName(name);
            return Ok(result);
        }

        [HasPermission(PermEnums.UpdateForum)]
        [HttpPatch]
        public async Task<IActionResult> Patch(Forum data)
        {
            await _service.UpdateForum(data);
            return Ok();
        }

        [HasPermission(PermEnums.DeleteForum)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int ID)
        {
            await _service.DeleteForum(ID);
            return Ok();
        }


    }
}
