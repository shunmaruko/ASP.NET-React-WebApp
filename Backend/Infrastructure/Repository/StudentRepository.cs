using Backend.Models;
using Backend.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Repository
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly SchoolContext _context;
        public StudentRepository(SchoolContext context)
        {
            _context = context;
        }
        public async Task<Student?> GetByIdAsync(long id) {
            if (_context.Students == null) return null;
            var student = await _context.Students
            .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);
            return student;
        }
        public async Task<List<Student>?> ListAsync()
        {
            if (_context.Students is null)
            {
                return null;
            }
            else
            {
                return await _context.Students.ToListAsync();
            }
        }
        public Task AddAsync(Student student)
        {
            _context.Students.Add(student);
            return _context.SaveChangesAsync();
        }
        public Task UpdateAsync(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }
        public Task DeleteAsync(Student student)
        {
            _context.Students.Remove(student);
            return _context.SaveChangesAsync();

        }
        public bool Exist(long id)
        {
            return (_context.Students?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
