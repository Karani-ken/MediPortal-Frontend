namespace MediPortal_Client.Models
{
    public class ResponseDto
    {
        public object? obj { get; set; }

        public bool IsSuccess { get; set; } = true;

        public string Message { get; set; } = string.Empty;
    }
}
