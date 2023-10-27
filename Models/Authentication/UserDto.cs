using System.ComponentModel.DataAnnotations;

namespace MediPortal_Client.Models.Authentication
{
    public class UserDto
    {
       public Guid Id { get; set; }
        public string firstname { get; set; } = string.Empty;      
        
       
        public string surname { get; set; } = string.Empty;
       
        public string email { get; set; } = string.Empty;

        public string HospitalName { get; set; }= string.Empty;

        public string speciality { get; set; } = string.Empty;
        public string LicenseUrl { get; set;} = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
