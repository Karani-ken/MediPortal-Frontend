using MediPortal_Client.Models.Authentication;
using MediPortal_Client.Models.Hospital;

namespace MediPortal_Client.Models.Appointment
{
    public class AppointmentDto
    {
        public Guid AppointmentId { get; set; }

        public UserDto? Patient { get; set; } 
        public UserDto? Doctor { get; set; }
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; } 

        public string AppointmentStatus { get; set; } = string.Empty;
        public string AppointmentType { get; set; } = string.Empty;
        public HospitalDto? Hospital { get; set; }
        public Guid HospitalId { get; set; }
        public string Slot { get; set; } = string.Empty;
        public string Symptoms { get; set; } = string.Empty;
    }
}
