using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;

namespace Mango.Web.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;
        public CouponService(IBaseService baseService)
        {
                _baseService = baseService;
        }
        public async Task<ResponseDTO?> CreateCouponAsyc(CouponDTO coupon)
        {

          return await  _baseService.SendResponseAsyn(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Data=coupon,
                Url = SD.CouponBaseApi + "/api/coupon/"
            });
            
        }

        public async Task<ResponseDTO?> DeleteCouponById(int couponId)
        {
            return await _baseService.SendResponseAsyn(new RequestDTO()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.CouponBaseApi + "/api/coupon/"+ couponId
            });
         
        }

        public async Task<ResponseDTO?> GetAllCouponAsync()
        {
            return await _baseService.SendResponseAsyn(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponBaseApi + "/api/Coupon/"
            });
           
        }

        public async Task<ResponseDTO?> GetCouponAsync(string couponCode)
        {
           return await _baseService.SendResponseAsyn(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponBaseApi + "/api/getByCode/"+couponCode
            });
         
        }

        public async Task<ResponseDTO?> GetCouponById(int couponId)
        {
           return await _baseService.SendResponseAsyn(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
               Url = SD.CouponBaseApi + "/api/Coupon/" + couponId
            });
        
        }

        public async Task<ResponseDTO?> UpdateCoupon(CouponDTO coupon)
        {
           return await _baseService.SendResponseAsyn(new RequestDTO()
            {
                ApiType = SD.ApiType.PUT,
                Data=coupon,
               Url = SD.CouponBaseApi + "/api/Coupon/" + coupon
            });
        }

  

    }
}
