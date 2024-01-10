using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Backend.Infrastructure.Repository;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class TodoItemController : ControllerBase
    {
        private readonly IRepository<TodoItemDTO> _repository;

        public TodoItemController(IRepository<TodoItemDTO> repository)
        {
            _repository = repository;
        }

        // GET: api/TodoItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDTO>>> GetTodoItems()
        {
            var items = await _repository.ListAsync();
            if (items == null)
            {
                return NotFound();
            }
            return items;
        }

        // GET: api/TodoItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDTO>> GetTodoItem(long id)
        {
            var todoItem = await _repository.GetByIdAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        // PUT: api/TodoItem/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, TodoItemDTO todoItemDTO)
        {
            if (id != todoItemDTO.Id)
            {
                return BadRequest();
            }
            var currentTodoItemDTO = await _repository.GetByIdAsync(id);
            if (currentTodoItemDTO == null)
            {
                return NotFound();
            }
            try
            {
                await _repository.UpdateAsync(todoItemDTO);
            }
            catch (DbUpdateConcurrencyException) when(!_repository.Exist(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/TodoItem
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoItemDTO>> PostTodoItem(TodoItemDTO todoItemDTO)
        {
            if (_repository.Exist(todoItemDTO.Id)) return BadRequest($"User{todoItemDTO.Id} already exists.");
            await _repository.AddAsync(todoItemDTO);
            return CreatedAtAction(nameof(GetTodoItem), new { id = todoItemDTO.Id }, todoItemDTO);
        }

        // DELETE: api/TodoItem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var todoItemDTO = await _repository.GetByIdAsync(id);
            if (todoItemDTO == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(todoItemDTO);

            return NoContent();
        }
    }
}
