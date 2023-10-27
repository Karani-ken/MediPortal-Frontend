namespace MediPortal_Client.Models.Hospital
{
    public class HospitalDto
    {
        public Guid HospitalId { get; set; }
        public string Hospitalname { get; set; } = string.Empty;


        public string Location { get; set; } = string.Empty;
    }
}
