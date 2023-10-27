using MediPortal_Client.Models;
using MediPortal_Client.Models.Authentication;

namespace MediPortal_Client.Services.Authentication
{
    public interface IAuthInterface
    {
        Task<ResponseDto> RegisterUser(RegistrationRequestDto registrationRequest);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);

        Task<ResponseDto> ApproveDoctor(Guid Id,string role);

        Task<List<UserDto>> GetDoctors();
    }
}
