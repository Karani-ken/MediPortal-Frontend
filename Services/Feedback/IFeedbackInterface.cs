using MediPortal_Client.Models;
using MediPortal_Client.Models.Feedback;

namespace MediPortal_Client.Services.Feedback
{
    public interface IFeedbackInterface
    {
        Task<ResponseDto> AddFeedback(FeedbackRequestDto feedback);      
        Task<List<FeedbackDto>> GetFeedbacks(Guid id);//get doctors feedback
        Task<List<FeedbackDto>> GetAllFeedbacks();//get all feedbacks
    }
}
