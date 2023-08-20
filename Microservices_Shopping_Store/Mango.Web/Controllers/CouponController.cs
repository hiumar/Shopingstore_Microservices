using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mano.Services.Coupan.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;
        public CouponController(ICouponService couponService)
        {
                _couponService = couponService;
        }
        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDTO>? couponDTOs = new List<CouponDTO>();
            ResponsetDTO response=await _couponService.GetAllCouponAsync();
            if(response != null&& response.IsSuccess)
            {
                couponDTOs = JsonConvert.DeserializeObject<List<CouponDTO>>(Convert.ToString(response.Result));

            }
            return View(couponDTOs);
        }
    }
}
