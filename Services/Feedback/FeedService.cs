using MediPortal_Client.Models;
using MediPortal_Client.Models.Appointment;
using MediPortal_Client.Models.Feedback;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace MediPortal_Client.Services.Feedback
{
    public class FeedService : IFeedbackInterface
    {
        private readonly HttpClient _httpClient;
        private string BASEURL = "https://mediportalfeedback.azurewebsites.net";
        public FeedService(HttpClient client)
        {
            _httpClient = client; 
        }
        public async Task<ResponseDto> AddFeedback(FeedbackRequestDto feedback)
        {
            try
            {
                var request = JsonConvert.SerializeObject(feedback);
                var bodyContent = new StringContent(request, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{BASEURL}/api/Feedback", bodyContent);
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

        public async Task<List<FeedbackDto>> GetAllFeedbacks()
        {
            try
            {

                var response = await _httpClient.GetAsync($"{BASEURL}/api/Feedback/AllFeedback");
                var content = await response.Content.ReadAsStringAsync();
                var results = JsonConvert.DeserializeObject<ResponseDto>(content);
                Console.Write(results.IsSuccess);
                if (results.IsSuccess)
                {

                    return JsonConvert.DeserializeObject<List<FeedbackDto>>(results?.obj.ToString());

                }
                return new List<FeedbackDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return new List<FeedbackDto>();
            }
        }

        public async Task<List<FeedbackDto>> GetFeedbacks(Guid id)
        {
            try
            {

                var response = await _httpClient.GetAsync($"{BASEURL}/api/Appointment/DoctorFeedback?id={id}");
                var content = await response.Content.ReadAsStringAsync();
                var results = JsonConvert.DeserializeObject<ResponseDto>(content);
                if (results.IsSuccess)
                {

                    return JsonConvert.DeserializeObject<List<FeedbackDto>>(results.obj.ToString());

                }
                return new List<FeedbackDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return new List<FeedbackDto>();
            }
        }
    }
}
