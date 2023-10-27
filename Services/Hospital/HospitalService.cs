using MediPortal_Client.Models;
using MediPortal_Client.Models.Authentication;
using MediPortal_Client.Models.Hospital;
using Newtonsoft.Json;
using System.Text;

namespace MediPortal_Client.Services.Hospital
{
    public class HospitalService : IHospitalInterface
    {
        private readonly HttpClient _httpClient;
        private readonly string BASEURL = "https://mediportalhospital.azurewebsites.net";

        public HospitalService(HttpClient client)
        {
            _httpClient = client;
        }
        public async Task<ResponseDto> AddHospital(HospitalRequest hospitalRequest)
        {
            try
            {
                var request = JsonConvert.SerializeObject(hospitalRequest);
                var bodyContent = new StringContent(request, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{BASEURL}/api/Hospital", bodyContent);
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

        public async  Task<ResponseDto> DeleteHospital(Guid id)
        {
            try
            {

                var response = await _httpClient.DeleteAsync($"{BASEURL}/api/Hospital?id={id}");
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

        public async Task<ResponseDto> GetHospitalById(Guid Id)
        {
            try
            {

                var response = await _httpClient.GetAsync($"{BASEURL}/api/Hospital/{Id}");
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

        public async Task<List<HospitalDto>> GetHospitals()
        {
            try
            {

                var response = await _httpClient.GetAsync($"{BASEURL}/api/Hospital");
                var content = await response.Content.ReadAsStringAsync();
                var results = JsonConvert.DeserializeObject<ResponseDto>(content);
                Console.WriteLine(results.IsSuccess);
                if (results.IsSuccess)
                {

                    return JsonConvert.DeserializeObject<List<HospitalDto>>(results.obj.ToString());

                }

                return new List<HospitalDto>();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<HospitalDto>();
            }
        }

        public async Task<ResponseDto> UpdateHospital(Guid Id ,HospitalRequest hospital)
        {

            try
            {
                var request = JsonConvert.SerializeObject(hospital);
                var bodyContent = new StringContent(request, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"{BASEURL}/api/Hospital?id={Id}", bodyContent);
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
