using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface ICouponService
    {
        Task<ResponseDTO?> GetCouponAsync(string couponCode);
        Task<ResponseDTO?> GetAllCouponAsync();
        Task<ResponseDTO?> GetCouponById(int couponId);
        Task<ResponseDTO?> CreateCouponAsyc(CouponDTO coupon);
        Task<ResponseDTO?> UpdateCoupon(CouponDTO coupon);
        Task<ResponseDTO?> DeleteCouponById(int couponId);
    }
}
