using MediPortal_Client.Models.Appointment;
using MediPortal_Client.Models.Prescription;

namespace MediPortal_Client.Models.Payment
{
    public class PaymentRequest
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public double? TotalCharges { get; set; }
        public string? PaymentStatus { get; set; } = string.Empty;
        public Guid? AppointmentId { get; set; }
        public string? PaymentIntentId { get; set; }

        public string? StripeSessionId { get; set; }

        public AppointmentDto? Appointment { get; set; }

        public PrescriptionDto? Prescription { get; set; }
    }
}
