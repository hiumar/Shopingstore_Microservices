using Mango.Web.Models;
using Mano.Services.Coupan.Model.DTO;

namespace Mango.Web.Service.IService
{
    public interface ICouponService
    {
        Task<ResponsetDTO?> GetCouponAsync(string couponCode);
        Task<ResponsetDTO?> GetAllCouponAsync();
        Task<ResponsetDTO?> GetCouponById(int couponId);
        Task<ResponsetDTO?> CreateCoupon(CouponDTO coupon);
        Task<ResponsetDTO?> UpdateCoupon(CouponDTO coupon);
        Task<ResponsetDTO?> DeleteCouponById(int couponId);
    }
}
