using MediPortal_Client.Models;
using MediPortal_Client.Models.Payment;

namespace MediPortal_Client.Services.Payment
{
    public interface IPaymentInterface
    {
        Task<ResponseDto> AddPayment(PaymentRequest paymentRequest);
        Task<StripeRequestDto> StripePayment(StripeRequestDto stripeRequestDto);
        Task<bool> ValidPayment(Guid PaymentId);
        Task<List<PaymentDto>> GetPayments();
    }
}
