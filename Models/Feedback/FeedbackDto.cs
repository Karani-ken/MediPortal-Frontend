namespace MediPortal_Client.Models.Feedback
{
    public class FeedbackDto
    {
        public Guid FeedbackId { get; set; }

        public string Message { get; set; } = string.Empty;

        public int rating { get; set; }

        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
    }
}
