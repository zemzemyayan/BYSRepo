using Bussiness.Abstarct;
using Entitiy.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bysAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCoursesController : ControllerBase
    {
        // https://localhost:7164/api/StudentCourses

        private readonly IStudentCourseService _studentCourseService;

        public StudentCoursesController(IStudentCourseService studentCourseService)
        {
            _studentCourseService = studentCourseService;
        }

        // POST: api/studentcourses
        [HttpPost]
        public IActionResult AddStudentCourse([FromBody] StudentCourse studentCourse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Bad Request
            }

            _studentCourseService.TAdd(studentCourse);
            return Ok(studentCourse); // 200 OK
        }

        // DELETE: api/studentcourses
        [HttpDelete]
        public IActionResult DeleteStudentCourse([FromBody] StudentCourse studentCourse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Bad Request
            }

            _studentCourseService.TDelete(studentCourse);
            return NoContent(); // 204 No Content
        }

        /*

        // GET: api/studentcourses/students/5
        [HttpGet("students/{studentId}")]
        public IActionResult GetCoursesByStudentId(int studentId)
        {
            var courses = _studentCourseService.GetCoursesByStudentId(studentId);
            if (courses == null || courses.Count == 0)
            {
                return NotFound(); // 404 Not Found
            }
            return Ok(courses); // 200 OK
        }
        */

        /*
        // GET: api/studentcourses/courses/5
        [HttpGet("courses/{courseId}")]
        public IActionResult GetStudentsByCourseId(int courseId)
        {
            var students = _studentCourseService.GetStudentsByCourseId(courseId);
            if (students == null || students.Count == 0)
            {
                return NotFound(); // 404 Not Found
            }
            return Ok(students); // 200 OK
        

        }
        */
    }
}
