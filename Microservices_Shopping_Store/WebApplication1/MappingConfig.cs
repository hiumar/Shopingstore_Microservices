using AutoMapper;
using Mano.Services.Coupan.Model;
using Mano.Services.Coupan.Model.DTO;

namespace Mano.Services.Coupan
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMAp()
        {
            var mapingConf = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDTO, Coupon>();
                config.CreateMap<Coupon,CouponDTO>();

            });
            
            return mapingConf;

        }
    }
}
