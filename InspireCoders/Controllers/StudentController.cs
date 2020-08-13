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

        [HttpPost("SaveStudent")]
        public async Task<IActionResult> SaveStudent(Student data)
        {
            var result = await _repo.insertAsync(data);
            return Ok(result);
        }

        [HttpGet("GetAllStudents")]
        public async Task<IActionResult> GetAllStudents()
        {
            var result = await _repo.getAllAsync();
            return Ok(result);
        }


    }
}
