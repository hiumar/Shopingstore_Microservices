using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;
using Mano.Services.Coupan.Model.DTO;

namespace Mango.Web.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;
        public CouponService(IBaseService baseService)
        {
                _baseService = baseService;
        }
        public async Task<ResponsetDTO?> CreateCoupon(CouponDTO coupon)
        {

          return await  _baseService.SendResponseAsyn(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Data=coupon,
                URL = SD.CouponBaseApi + "/api/Coupon/"+ coupon
            });
            
        }

        public async Task<ResponsetDTO?> DeleteCouponById(int couponId)
        {
            return await _baseService.SendResponseAsyn(new RequestDTO()
            {
                ApiType = SD.ApiType.DELETE,
                URL = SD.CouponBaseApi + "/api/Coupon/"+ couponId
            });
         
        }

        public async Task<ResponsetDTO?> GetAllCouponAsync()
        {
            return await _baseService.SendResponseAsyn(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                URL = SD.CouponBaseApi + "/api/Coupon/"
            });
           
        }

        public async Task<ResponsetDTO?> GetCouponAsync(string couponCode)
        {
           return await _baseService.SendResponseAsyn(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                URL = SD.CouponBaseApi + "/api/getByCode/"+couponCode
            });
         
        }

        public async Task<ResponsetDTO?> GetCouponById(int couponId)
        {
           return await _baseService.SendResponseAsyn(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                URL = SD.CouponBaseApi + "/api/Coupon/" + couponId
            });
        
        }

        public async Task<ResponsetDTO?> UpdateCoupon(CouponDTO coupon)
        {
           return await _baseService.SendResponseAsyn(new RequestDTO()
            {
                ApiType = SD.ApiType.PUT,
                Data=coupon,
                URL = SD.CouponBaseApi + "/api/Coupon/" + coupon
            });
        }
    }
}
