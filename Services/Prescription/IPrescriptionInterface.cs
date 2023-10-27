using MediPortal_Client.Models;
using MediPortal_Client.Models.Prescription;

namespace MediPortal_Client.Services.Prescription
{
    public interface IPrescriptionInterface
    {
        Task<ResponseDto> AddPrescription(PrescriptionRequest prescription);
        Task<List<PrescriptionDto>> GetPrescriptions();
    }
}
