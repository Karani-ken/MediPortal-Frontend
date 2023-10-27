namespace MediPortal_Client.Models.History
{
    public class AddHistoryRequest
    {
        public string PatientName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }

        public List<string> Allergies { get; set; } = new List<string>();
        public List<string> ChronicConditions { get; set; } = new List<string>();
        public List<string> Medications { get; set; } = new List<string>();
        public List<MedicalProcedure> MedicalProcedures { get; set; } = new List<MedicalProcedure>();
    }
    public class MedicalProcedure
    {
        public string ProcedureName { get; set; }
        public DateTime DatePerformed { get; set; }
        public string Notes { get; set; }
    }
}
