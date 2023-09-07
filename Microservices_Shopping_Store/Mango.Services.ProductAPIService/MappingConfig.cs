using AutoMapper;
using Mango.Services.ProductAPIService;

namespace Mano.Services.ProductAPIService
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMAp()
        {

            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>().ReverseMap();
            });

            return mappingConfig;

        }
    }
}
