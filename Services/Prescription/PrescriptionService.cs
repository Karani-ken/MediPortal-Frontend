using MediPortal_Client.Models;
using MediPortal_Client.Models.Appointment;
using MediPortal_Client.Models.Prescription;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MediPortal_Client.Services.Prescription
{
    public class PrescriptionService : IPrescriptionInterface
    {
        private readonly HttpClient _httpClient;
        private readonly string BASEURL = "https://mediportalprescriptions.azurewebsites.net";

        public PrescriptionService(HttpClient client)
        {
            _httpClient = client;
        }
        public async Task<ResponseDto> AddPrescription(PrescriptionRequest prescription)
        {
            try
            {
                var request = JsonConvert.SerializeObject(prescription);
                var bodyContent = new StringContent(request, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{BASEURL}/api/Prescription", bodyContent);
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

        public async Task<List<PrescriptionDto>> GetPrescriptions()
        {
            try
            {

                var response = await _httpClient.GetAsync($"{BASEURL}/api/Prescription");
                var content = await response.Content.ReadAsStringAsync();
                var results = JsonConvert.DeserializeObject<ResponseDto>(content);
                if (results.IsSuccess)
                {

                    return JsonConvert.DeserializeObject<List<PrescriptionDto>>(results.obj.ToString());

                }
                return new List<PrescriptionDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return new List<PrescriptionDto>();
            }
        }
    }
}
