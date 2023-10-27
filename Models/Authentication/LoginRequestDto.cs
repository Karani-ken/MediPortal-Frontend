using System.ComponentModel.DataAnnotations;

namespace MediPortal_Client.Models.Authentication
{
    public class LoginRequestDto
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string password { get; set; } = string.Empty;
    }
}
