using MediPortal_Client.Models;
using MediPortal_Client.Models.Appointment;
using MediPortal_Client.Models.Payment;
using Newtonsoft.Json;
using System.Text;

namespace MediPortal_Client.Services.Payment
{
    public class PaymentService:IPaymentInterface
    {
        private readonly HttpClient _httpClient;
        private readonly string BASEURL = "https://mediportalpayments.azurewebsites.net";
        public PaymentService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<ResponseDto> AddPayment(PaymentRequest paymentRequest)
        {
            try
            {
                var request = JsonConvert.SerializeObject(paymentRequest);
                var bodyContent = new StringContent(request, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{BASEURL}/api/Payment", bodyContent);
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

        public async Task<List<PaymentDto>> GetPayments()
        {
            try
            {

                var response = await _httpClient.GetAsync($"{BASEURL}/api/Payment");
                var content = await response.Content.ReadAsStringAsync();
                var results = JsonConvert.DeserializeObject<ResponseDto>(content);
                if (results.IsSuccess)
                {

                    return JsonConvert.DeserializeObject<List<PaymentDto>>(results.obj.ToString());

                }
                return new List<PaymentDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return new List<PaymentDto>();
            }
        }

        public async Task<StripeRequestDto> StripePayment(StripeRequestDto stripeRequestDto)
        {
            try
            {
                var request = JsonConvert.SerializeObject(stripeRequestDto);
                var bodyContent = new StringContent(request, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{BASEURL}/api/Payment/StripePayment", bodyContent);
                var content = await response.Content.ReadAsStringAsync();
                var results = JsonConvert.DeserializeObject<ResponseDto>(content);
                Console.WriteLine(results.IsSuccess);
                if (results.IsSuccess)
                {

                    return  JsonConvert.DeserializeObject<StripeRequestDto>(results.obj.ToString());

                }

                return new StripeRequestDto();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new StripeRequestDto();
            }
        }

        public async Task<bool> ValidPayment(Guid PaymentId)
        {
            try
            {
                

                var response = await _httpClient.PostAsync($"{BASEURL}/api/Payment/ValidatePayment?PaymentId={PaymentId}", null);
                var content = await response.Content.ReadAsStringAsync();
                var results = JsonConvert.DeserializeObject<ResponseDto>(content);
                Console.WriteLine(results.IsSuccess);
                if (results.IsSuccess)
                {

                    return true;

                }

                return false;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
