using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Context
{
    public class TodoItemContext : DbContext
    {
        public TodoItemContext(DbContextOptions<TodoItemContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; } = null!;
    }
}
