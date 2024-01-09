using Backend.Infrastructure.Context;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Repository
{
    public class UserRepository : IRepository<UserDTO>
    {
        private readonly UserContext _context;
        public UserRepository(UserContext userContext)
        {
            _context = userContext;
        }
        public async Task<UserDTO?> GetByIdAsync(long id)
        {
            if (_context.Users == null) return null;
            var user = await _context.Users.FindAsync(id);
            return user is null ? null : UserToDTO(user);
        }
        public async Task<List<UserDTO>?> ListAsync()
        {
            if (_context.Users is null)
            {
                return null;
            }
            else
            {
                return await _context.Users.Select(x => UserToDTO(x)).ToListAsync();
            }
        }
        public Task AddAsync(UserDTO userDTO)
        {
            var user = new User
            {
                Id = userDTO.Id,
                Name = userDTO.Name,
                MailAdress = userDTO.MailAdress,
            };
            _context.Users.Add(user);
            return _context.SaveChangesAsync();

        }
        public Task UpdateAsync(UserDTO userDTO)
        {
            var user = new User
            {
                Id = userDTO.Id,
                Name = userDTO.Name,
                MailAdress = userDTO.MailAdress,
            };
            _context.Entry(user).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }
        public Task DeleteAsync(UserDTO userDTO)
        {
            var user = DTOToUser(userDTO);
            _context.Users.Remove(user);
            return _context.SaveChangesAsync();
        }
        public bool Exist(long id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        private static UserDTO UserToDTO(User user) =>
            new UserDTO
            {
                Id = user.Id,
                MailAdress = user.MailAdress,
                Name = user.Name,
            };
        private static User DTOToUser(UserDTO userDTO) =>
            new User
            {
                Id = userDTO.Id,
                MailAdress = userDTO.MailAdress,
                Name = userDTO.Name,
            };
    }
}
