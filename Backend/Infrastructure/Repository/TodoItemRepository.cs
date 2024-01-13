using Backend.Infrastructure.Context;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Repository
{
    public class TodoItemRepository: IRepository<TodoItemDTO>
    {
        private readonly TodoItemContext _context;
        public TodoItemRepository(TodoItemContext context)
        {
            _context = context;
        }
        public async Task<TodoItemDTO?> GetByIdAsync(long id)
        {
            if (_context.TodoItems == null) return null;
            var item = await _context.TodoItems.FindAsync(id);
            return item is null ? null : ModelToDTO(item);
        }
        public async Task<List<TodoItemDTO>?> ListAsync()
        {
            if (_context.TodoItems is null)
            {
                return null;
            }
            else
            {
                return await _context.TodoItems.Select(x => ModelToDTO(x)).ToListAsync();
            }
        }
        public Task AddAsync(TodoItemDTO itemDTO)
        {
            var item = DTOToModel(itemDTO);
            _context.TodoItems.Add(item);
            return _context.SaveChangesAsync();

        }
        public Task UpdateAsync(TodoItemDTO itemDTO)
        {
            var item = DTOToModel(itemDTO);
            _context.Entry(item).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }
        public Task DeleteAsync(TodoItemDTO itemDTO)
        {
            var item = DTOToModel(itemDTO);
            _context.TodoItems.Remove(item);
            return _context.SaveChangesAsync();
        }
        public bool Exist(long id)
        {
            return (_context.TodoItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        private static TodoItemDTO ModelToDTO(TodoItem item) =>
            new TodoItemDTO
            {
                Id = item.Id,
                Name = item.Name,
                IsComplete = item.IsComplete,
            };
        private static TodoItem DTOToModel(TodoItemDTO itemDTO) =>
            new TodoItem
            {   
                Id = itemDTO.Id,
                Name = itemDTO.Name,
                IsComplete = itemDTO.IsComplete,
            };
    }
}
