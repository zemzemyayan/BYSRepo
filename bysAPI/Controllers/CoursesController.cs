using Bussiness.Abstarct;
using Entitiy.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bysAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        //h ttps://localhost:7164/api/Courses
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // GET: api/courses   ***sorunsuz çalışıyor
        [HttpGet]
        public IActionResult GetAllCourses()
        {
            var courses = _courseService.TGetAll();
            return Ok(courses); // 200 OK ve tüm kursları döner
        }

        // GET: api/courses/5  **** sorunsuz çalışıyor
        [HttpGet("{id}")]
        public IActionResult GetCourseById(int id)
        {
            var course = _courseService.TGetById(id);
            if (course == null)
            {
                return NotFound(); // 404 Not Found
            }
            return Ok(course); // 200 OK ve kursu döner
        }

        // POST: api/courses
        [HttpPost]
        public IActionResult AddCourse([FromBody] Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Bad Request
            }

            _courseService.TAdd(course);
            return CreatedAtAction(nameof(GetCourseById), new { id = course.CourseId }, course); // 201 Created
        }

        // PUT: api/courses/5
        [HttpPut("{id}")]
        public IActionResult UpdateCourse(int id, [FromBody] Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Bad Request
            }

            var existingCourse = _courseService.TGetById(id);
            if (existingCourse == null)
            {
                return NotFound(); // 404 Not Found
            }

            // Güncelleme işlemi
            course.CourseId = id; // ID'nin değişmediğinden emin olun
            _courseService.TUpdate(course);
            return NoContent(); // 204 No Content
        }

        // DELETE: api/courses/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            var course = _courseService.TGetById(id);
            if (course == null)
            {
                return NotFound(); // 404 Not Found
            }

            _courseService.TDelete(course);
            return NoContent(); // 204 No Content

        }

    }
}
