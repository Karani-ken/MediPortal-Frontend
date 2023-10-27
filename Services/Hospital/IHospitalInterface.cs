using MediPortal_Client.Models;
using MediPortal_Client.Models.Hospital;

namespace MediPortal_Client.Services.Hospital
{
    public interface IHospitalInterface
    {
        Task<ResponseDto> AddHospital(HospitalRequest hospitalRequest);
        Task<ResponseDto> DeleteHospital(Guid id);

        Task<ResponseDto> GetHospitalById(Guid Id);
        Task<List<HospitalDto>> GetHospitals();

        Task<ResponseDto> UpdateHospital(Guid Id, HospitalRequest hospital);
    }
}
