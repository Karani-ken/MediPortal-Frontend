using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MediPortal_Client.Models.Authentication
{
    public class RegistrationRequestDto
    {
        [Required]
        public string firstname { get; set; } = string.Empty;
        [Required]
        public string lastname { get; set; } = string.Empty;
        [Required]
        public string surname { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        public string Password { get; set; } = string.Empty;
        public string? HospitalName { get; set; } = string.Empty;
        public string? speciality { get; set; } = string.Empty;
        public string LicenseUrl { get; set; } = string.Empty;
        //public IFormFile? License { get; set; }

    }
}
