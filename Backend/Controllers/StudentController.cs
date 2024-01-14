using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Infrastructure.Repository;
using Backend.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class StudentController : ControllerBase
    {
        private readonly IRepository<Student> _repository;
        private readonly ILogger<StudentController> _logger;

        public StudentController(IRepository<Student> repository, ILogger<StudentController> logger)
        {

            _repository = repository;
            _logger = logger;
            _logger.LogWarning("logger passed ");
        }

        // GET: api/Student
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            _logger.LogWarning("start get request");
            var students = await _repository.ListAsync();
            if (students == null)
          {
              return NotFound();
          }
            return Ok(students);
        }

        // GET: api/Student/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _repository.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        // PUT: api/Student/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.ID)
            {
                return BadRequest();
            }
            try
            {
                await _repository.UpdateAsync(student);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_repository.Exist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Student
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent([Bind("EnrollementDate,FirstName,LastName")] Student student) //
        {
            _logger.LogWarning("start post request");
            try
            {
                if (ModelState.IsValid) // if inputted student is valid
                {
                    await _repository.AddAsync(student);
                }
            } catch (DbUpdateException /* ex */)
            {
            //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
                return BadRequest("Failure to update.");
            }
            //return NoContent();
            return CreatedAtAction(nameof(GetStudent), new { id = student.ID }, student);
        }

        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _repository.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            await _repository.DeleteAsync(student);
            return NoContent();
        }
    }
}
