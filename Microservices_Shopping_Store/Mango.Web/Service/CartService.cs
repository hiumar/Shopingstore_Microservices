using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;

namespace Mango.Web.Service
{
    public class CartService : ICartService
    {
        private readonly IBaseService _baseService;
        public CartService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDTO?> ApplyCouponAsync(CartDto cartDto)
        {
            return await _baseService.SendResponseAsyn(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDto,
                URL= SD.ShoppingCartAPIBase + "/api/cart/ApplyCoupon"
            });
        }

        public async Task<ResponseDTO?> EmailCart(CartDto cartDto)
        {
            return await _baseService.SendResponseAsyn(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDto,
                URL = SD.ShoppingCartAPIBase + "/api/cart/EmailCartRequest"
            });
        }

        public async Task<ResponseDTO?> GetCartByUserIdAsnyc(string userId)
        {
            return await _baseService.SendResponseAsyn(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                URL = SD.ShoppingCartAPIBase + "/api/cart/GetCart/"+ userId
            });
        }

        
        public async Task<ResponseDTO?> RemoveFromCartAsync(int cartDetailsId)
        {
            return await _baseService.SendResponseAsyn(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDetailsId,
                URL = SD.ShoppingCartAPIBase + "/api/cart/RemoveCart"
            });
        }

      
        public async Task<ResponseDTO?> UpsertCartAsync(CartDto cartDto)
        {
            return await _baseService.SendResponseAsyn(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDto,
                URL = SD.ShoppingCartAPIBase + "/api/cart/CartUpsert"
            });
        }
    }
}
