using AutoMapper;
using GruppKniv.Services.OrdersAPI.Models;
using GruppKniv.Services.OrdersAPI.Models.Dto;

namespace GruppKniv.Services.OrdersAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Order, OrderDto>().ReverseMap();
                config.CreateMap<Product, ProductDto>().ReverseMap();
                config.CreateMap<User, UserDto>().ReverseMap();

            });

            return mappingConfig;
        }
    }
}
