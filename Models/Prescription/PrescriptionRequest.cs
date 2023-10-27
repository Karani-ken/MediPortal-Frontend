using System.ComponentModel.DataAnnotations;

namespace MediPortal_Client.Models.Prescription
{
    public class PrescriptionRequest
    {
        [Required]
        public Guid AppointmentId { get; set; }
        [Required]
        public string Diagnosis { get; set; } = string.Empty;

        [Required]
        public string Medication { get; set; } = string.Empty;

        public double? Charges { get; set; }
    }
}
