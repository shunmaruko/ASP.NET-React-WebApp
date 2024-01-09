using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class User
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;
  
        public string MailAdress { get; set; } = string.Empty;
        public string? Password { get; set; }
    }
    public class UserDTO
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "MailAdress is required.")]
        public string MailAdress { get; set; } = string.Empty;
    }
}
