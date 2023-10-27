namespace MediPortal_Client.Models.Feedback
{
    public class FeedbackRequestDto
    {
        public int rating { get; set; }
        public string Message { get; set; } = string.Empty;
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
    }
}
