using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Backend.Infrastructure.Repository;
using Microsoft.AspNetCore.Authorization;

namespace Backend.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class UserController : ControllerBase
    {
        private readonly IRepository<UserDTO> _repository;

        public UserController(IRepository<UserDTO> repository)
        {
            _repository = repository;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var users = await _repository.ListAsync();
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(long id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            } else
            {
                return user;
            }
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(long id, UserDTO userDTO)
        {
            if (id != userDTO.Id)
            {
                return BadRequest();
            }

            var user = await _repository.GetByIdAsync(id);
            if (user == null) return NotFound();
            try
            {
                await _repository.UpdateAsync(user);
            }
            catch (DbUpdateConcurrencyException) when(!_repository.Exist(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserDTO>> PostUser(UserDTO userDTO)
        {
            if (_repository.Exist(userDTO.Id)) return BadRequest($"User{userDTO.Id} already exists.");
            await _repository.AddAsync(userDTO);
            return CreatedAtAction(nameof(GetUser), new { id = userDTO.Id }, userDTO);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            var userDTO = await _repository.GetByIdAsync(id);
            if (userDTO == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(userDTO);

            return NoContent();
        }
    }
}
