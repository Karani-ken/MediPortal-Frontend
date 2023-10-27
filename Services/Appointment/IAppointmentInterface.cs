using MediPortal_Client.Models;
using MediPortal_Client.Models.Appointment;

namespace MediPortal_Client.Services.Appointment
{
    public interface IAppointmentInterface
    {
        Task<ResponseDto> AddAppointment(AppointmentRequestDto appointmentRequestDto);
        Task<List<AppointmentDto>> GetAppointments();
        Task<ResponseDto> UpdateAppointment(Guid Id,AppointmentRequestDto appointment);
        Task<List<AppointmentRequestDto>> GetAllAppointments();

    }
}
