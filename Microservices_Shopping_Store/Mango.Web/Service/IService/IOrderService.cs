using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface IOrderService
    {
        Task<ResponseDTO?> CreateOrder(CartDto cartDto);
        Task<ResponseDTO?> CreateStripeSession(StripeRequestDto stripeRequestDto);
        Task<ResponseDTO?> ValidateStripeSession(int orderHeaderId);
        Task<ResponseDTO?> GetAllOrder(string? userId);
        Task<ResponseDTO?> GetOrder(int orderId);
        Task<ResponseDTO?> UpdateOrderStatus(int orderId, string newStatus);
    }
}
