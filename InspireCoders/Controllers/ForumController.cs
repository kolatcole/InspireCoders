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

        [HttpPost]
        public async Task<IActionResult> Post(Forum data)
        {
            var result = await _service.CreateForum(data);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetForums();
            return Ok(result);
        }

        [HttpPatch("AddStudent")]
        public async Task<IActionResult> AddStudent(int forumID, string StudentIDs)
        {
            var result = await _service.AddStudent(forumID, StudentIDs);
            return Ok(result);
        }

        [HttpGet("ForumsByStudent/{studentID}")]
        public async Task<IActionResult> ForumsByStudent(int studentID)
        {
            var result = await _service.getForumsByStudentID(studentID);
            return Ok(result);
        }


        //[HttpPatch]
        //public async Task<IActionResult> Patch(Forum data)
        //{
        //    await _repo.updateAsync(data);
        //    return Ok();

        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        //[HttpDelete]
        //public async Task<IActionResult> Delete(int ID)
        //{
        //    await _repo.deleteAsync(ID);
        //    return Ok();

        //}


    }
}
