﻿using Microsoft.AspNetCore.Mvc;
using SportClubs.Interfaces;

namespace SportClubs.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(_teacherService.GetTeachers());
        }

        [HttpGet]
        public async Task<ActionResult> GetAllFree()
        {
            return Ok(_teacherService.GetFreeTeachers());
        }

        [HttpDelete("{teacherId}")]
        public async Task<ActionResult> Delete(int teacherId)
        {
            return Ok(_teacherService.DeleteTeacher(teacherId));
        }
    }
}
