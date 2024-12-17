using Bussiness.Abstarct;
using Entitiy.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bysAPI.Controllers
{
    //h ttps://localhost:7164/api/Instructors
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        private readonly IInstructorService _instructorService;

        public InstructorsController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        // GET: api/instructors
        [HttpGet]
        public IActionResult GetAllInstructors()
        {
            var instructors = _instructorService.TGetAll();
            return Ok(instructors); // 200 OK ve tüm eğitmenleri döner
        }

        // GET: api/instructors/5
        [HttpGet("{id}")]
        public IActionResult GetInstructorById(int id)
        {
            var instructor = _instructorService.TGetById(id);
            if (instructor == null)
            {
                return NotFound(); // 404 Not Found
            }
            return Ok(instructor); // 200 OK ve eğitmeni döner
        }

        // POST: api/instructors
        [HttpPost]
        public IActionResult AddInstructor([FromBody] Instructor instructor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Bad Request
            }

            _instructorService.TAdd(instructor);
            return CreatedAtAction(nameof(GetInstructorById), new { id = instructor.InstructorId }, instructor); // 201 Created
        }

        // PUT: api/instructors/5
        [HttpPut("{id}")]
        public IActionResult UpdateInstructor(int id, [FromBody] Instructor instructor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Bad Request
            }

            var existingInstructor = _instructorService.TGetById(id);
            if (existingInstructor == null)
            {
                return NotFound(); // 404 Not Found
            }

            // Güncelleme işlemi
            instructor.InstructorId = id; // ID'nin değişmediğinden emin olun
            _instructorService.TUpdate(instructor);
            return NoContent(); // 204 No Content
        }

        // DELETE: api/instructors/5
        [HttpDelete("{id}")]
        public IActionResult DeleteInstructor(int id)
        {
            var instructor = _instructorService.TGetById(id);
            if (instructor == null)
            {
                return NotFound(); // 404 Not Found
            }

            _instructorService.TDelete(instructor);
            return NoContent(); // 204 No Contennt


        }
    }
}
