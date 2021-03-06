﻿using System;
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
    public class ApplicantController : ControllerBase
    {
        private readonly IRepo<Applicant> _repo;

        public ApplicantController(IRepo<Applicant> repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Applicant data)
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

        //[HttpPatch]
        //public async Task<IActionResult> Patch(Applicant data)
        //{
        //    await _repo.updateAsync(data);
        //    return Ok();

        //}

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
