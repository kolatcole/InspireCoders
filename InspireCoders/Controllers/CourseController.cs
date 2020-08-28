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
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _service;

        public CourseController(ICourseService service)
        {
            _service = service;
        }


        [HasPermission(PermEnums.CreateCourse)]
        [HttpPost("")]
        public async Task<IActionResult> Post(Course data)
        {
            var result = await _service.SaveCourseWithFacilitator(data);
            return Ok(result);
        }

        [HasPermission(PermEnums.ReadCourse)]
        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var result = await _service.getAllCourses();
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HasPermission(PermEnums.ReadCourse)]
        [HttpGet("{code}")]
        public async Task<IActionResult> Get(string code)
        {
            var result = await _service.getCourseByCode(code);
            return Ok(result);
        }

        [HasPermission(PermEnums.ReadCourse)]
        [HttpGet("GetByName/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var result = await _service.getCourseByName(name);
            return Ok(result);
        }


        [HasPermission(PermEnums.UpdateCourse)]
        [HttpPatch]
        public async Task<IActionResult> Patch(Course data)
        {
            await _service.UpdateCourse(data);
            return Ok();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HasPermission(PermEnums.DeleteCourse)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int ID)
        {
            await _service.DeleteCourse(ID);
            return Ok();

        }


    }
}
