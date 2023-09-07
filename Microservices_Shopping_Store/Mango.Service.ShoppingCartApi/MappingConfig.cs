using AutoMapper;
using Mango.Service.ShoppingCartAPi.Models;
using Mango.Service.ShoppingCartAPi.Models.Dto;

namespace Mango.Service.ShoppingCartAPi
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
                config.CreateMap<CartDetails, CartDetailsDto>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
