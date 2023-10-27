using MediPortal_Client.Models;
using MediPortal_Client.Models.Authentication;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace MediPortal_Client.Services.Authentication
{
    public class AuthService : IAuthInterface
    {
        private readonly HttpClient _httpClient;
        private readonly string BASEURL = "https://mediportalauthservice.azurewebsites.net";

        public AuthService(HttpClient client)
        {
            _httpClient = client;      
        }
        public async Task<ResponseDto> ApproveDoctor(Guid Id,string role)
        {
            try
            {
                var requestData = new
                {
                    
                    Role = role
                };
                var request = JsonConvert.SerializeObject(requestData);
                var bodyContent = new StringContent(request, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{BASEURL}/api/User/AssigningRole?UserId={Id}&Role={role}",bodyContent);
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

        public async Task<List<UserDto>> GetDoctors()
        {
            try
            {

                var response = await _httpClient.GetAsync($"{BASEURL}/api/User");
                var content = await response.Content.ReadAsStringAsync();
                var results = JsonConvert.DeserializeObject<ResponseDto>(content);
                if (results.IsSuccess)
                {

                    return JsonConvert.DeserializeObject<List<UserDto>>(results.obj.ToString());

                }
                return new List<UserDto>();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                  return new List<UserDto>();
            }
        }
        
          
           

        public async  Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            try
            {
                var request = JsonConvert.SerializeObject(loginRequestDto);
                var bodyContent = new StringContent(request, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{BASEURL}/api/User/login", bodyContent);
                var content = await response.Content.ReadAsStringAsync();
                var results = JsonConvert.DeserializeObject<ResponseDto>(content);
                Console.WriteLine(results.IsSuccess);
                if (results.IsSuccess)
                {

                    return JsonConvert.DeserializeObject<LoginResponseDto>(results.obj.ToString());

                }

                return new LoginResponseDto();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new LoginResponseDto();
            }
           
        }

        public async Task<ResponseDto> RegisterUser(RegistrationRequestDto registrationRequest)
        {
            try
            {
                //var formData = new MultipartFormDataContent();

                //// Add form fields
                //formData.Add(new StringContent(registrationRequest.firstname), "firstname");
                //formData.Add(new StringContent(registrationRequest.lastname), "lastname");
                //formData.Add(new StringContent(registrationRequest.surname), "surname");
                //formData.Add(new StringContent(registrationRequest.speciality), "speciality");
                //formData.Add(new StringContent(registrationRequest.Email), "email");
                //formData.Add(new StringContent(registrationRequest.Password), "password");
                //formData.Add(new StringContent(registrationRequest.HospitalName), "hospitalName");

                //// Add file data
                //if (registrationRequest.License != null)
                //{
                //    using (var fileContent = new StreamContent(registrationRequest.License.OpenReadStream()))
                //    {
                //        formData.Add(fileContent, "license", registrationRequest.License.FileName);
                //    };               
                //}
                  var request = JsonConvert.SerializeObject(registrationRequest);
                var bodyContent = new StringContent(request, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"{BASEURL}/api/User/Register", bodyContent);
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResponseDto>(content);
                if (result.IsSuccess)
                {
                    return result;
                }
                return new ResponseDto();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ResponseDto();
            }
           
        }
    }
}
