using Bussiness.Abstarct;
using Entitiy.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bysAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //h ttps://localhost:7164/api/Students
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/students
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = _studentService.TGetAll();
            return Ok(students); // 200 OK ve tüm öğrencileri döner
        }

        // GET: api/students/5
        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _studentService.TGetById(id);
            if (student == null)
            {
                return NotFound(); // 404 Not Found
            }
            return Ok(student); // 200 OK ve öğrenciyi döner
        }

        // POST: api/students
        [HttpPost]
        public IActionResult AddStudent([FromBody] Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Bad Request
            }

            _studentService.TAdd(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = student.StudentId }, student); // 201 Created
        }

        // PUT: api/students/5
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Bad Request
            }

            var existingStudent = _studentService.TGetById(id);
            if (existingStudent == null)
            {
                return NotFound(); // 404 Not Found
            }

            student.StudentId = id; // ID'nin değişmediğinden emin olun
            _studentService.TUpdate(student);
            return NoContent(); // 204 No Content
        }

        // DELETE: api/students/5
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _studentService.TGetById(id);
            if (student == null)
            {
                return NotFound(); // 404 Not Found
            }

            _studentService.TDelete(student);
            return NoContent(); // 204 No Content
        }
    }

 }
