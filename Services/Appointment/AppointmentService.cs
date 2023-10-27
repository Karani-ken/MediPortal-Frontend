using MediPortal_Client.Models;
using MediPortal_Client.Models.Appointment;
using MediPortal_Client.Models.Authentication;
using Newtonsoft.Json;
using System.Text;

namespace MediPortal_Client.Services.Appointment
{
    public class AppointmentService : IAppointmentInterface
    {
        private readonly HttpClient _httpClient;
        private readonly string BASEURL = "https://mediportalappointment.azurewebsites.net";

        public AppointmentService(HttpClient client)
        {
            _httpClient = client;
        }
        public async Task<ResponseDto> AddAppointment(AppointmentRequestDto appointmentRequestDto)
        {
            try
            {
                var request = JsonConvert.SerializeObject(appointmentRequestDto);
                var bodyContent = new StringContent(request, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{BASEURL}/api/Appointment", bodyContent);
                var content = await response.Content.ReadAsStringAsync();
                var results = JsonConvert.DeserializeObject<ResponseDto>(content);
                Console.WriteLine(results.IsSuccess);
                if (results.IsSuccess)
                {

                    return results;

                }

                return new ResponseDto();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ResponseDto();
            }
        }

        public async Task<List<AppointmentRequestDto>> GetAllAppointments()
        {
            try
            {

                var response = await _httpClient.GetAsync($"{BASEURL}/api/Appointment");
                var content = await response.Content.ReadAsStringAsync();
                var results = JsonConvert.DeserializeObject<ResponseDto>(content);
                if (results.IsSuccess)
                {

                    return JsonConvert.DeserializeObject<List<AppointmentRequestDto>>(results.obj.ToString());

                }
                return new List<AppointmentRequestDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return new List<AppointmentRequestDto>();
            }
        }

        public async Task<List<AppointmentDto>> GetAppointments()
        {
            try
            {

                var response = await _httpClient.GetAsync($"{BASEURL}/api/Appointment/GetAppointments");
                var content = await response.Content.ReadAsStringAsync();
                var results = JsonConvert.DeserializeObject<ResponseDto>(content);
                if (results.IsSuccess)
                {

                    return JsonConvert.DeserializeObject<List<AppointmentDto>>(results.obj.ToString());

                }
                return new List<AppointmentDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return new List<AppointmentDto>();
            }
        }

        public async Task<ResponseDto> UpdateAppointment(Guid Id, AppointmentRequestDto appointment)
        {
            try
            {
                var request = JsonConvert.SerializeObject(appointment);
                var bodyContent = new StringContent(request, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"{BASEURL}/api/Appointment?Id={Id}", bodyContent);
                var content = await response.Content.ReadAsStringAsync();
                var results = JsonConvert.DeserializeObject<ResponseDto>(content);
                Console.WriteLine(results.IsSuccess);
                if (results.IsSuccess)
                {

                    return results;

                }

                return new ResponseDto();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ResponseDto();
            }
        }
    }
}
