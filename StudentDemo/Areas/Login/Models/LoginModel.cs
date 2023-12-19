using System.ComponentModel.DataAnnotations;

namespace StudentDemo.Areas.Login.Models
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Role { get; set; }
        public IFormFile? File { get; set; }

        public string PhotoPath { get; set; }
    }
}
