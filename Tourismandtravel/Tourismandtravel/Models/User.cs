using System.ComponentModel.DataAnnotations;

namespace Tourismandtravel.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        [Required]
        public string? UserEmail { get; set; }
        [Required]
        public string? Userpassword { get; set; }
    }
}
