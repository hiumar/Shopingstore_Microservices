using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;

namespace Mango.Web.Service
{
    public class OrderService : IOrderService
    {
        private readonly IBaseService _baseService;
        public OrderService(IBaseService baseService)
        {
            _baseService = baseService;
        }

       

        public async Task<ResponseDTO?> CreateOrder(CartDto cartDto)
        {
            return await _baseService.SendResponseAsyn(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDto,
                URL = SD.OrderAPIBase + "/api/order/CreateOrder"
            });
        }

        public async Task<ResponseDTO?> CreateStripeSession(StripeRequestDto stripeRequestDto)
        {
            return await _baseService.SendResponseAsyn(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Data = stripeRequestDto,
                URL = SD.OrderAPIBase + "/api/order/CreateStripeSession"
            });
        }

        public async Task<ResponseDTO?> GetAllOrder(string? userId)
        {
            return await _baseService.SendResponseAsyn(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                URL = SD.OrderAPIBase + "/api/order/GetOrders?userId=" + userId
            });
        }

        public async Task<ResponseDTO?> GetOrder(int orderId)
        {
            return await _baseService.SendResponseAsyn(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                URL = SD.OrderAPIBase + "/api/order/GetOrder/" + orderId
            });
        }

        public async Task<ResponseDTO?> UpdateOrderStatus(int orderId, string newStatus)
        {
            return await _baseService.SendResponseAsyn(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Data = newStatus,
                URL = SD.OrderAPIBase + "/api/order/UpdateOrderStatus/"+orderId
            });
        }

        public async Task<ResponseDTO?> ValidateStripeSession(int orderHeaderId)
        {
            return await _baseService.SendResponseAsyn(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Data = orderHeaderId,
                URL = SD.OrderAPIBase + "/api/order/ValidateStripeSession"
            });
        }
    }
}
