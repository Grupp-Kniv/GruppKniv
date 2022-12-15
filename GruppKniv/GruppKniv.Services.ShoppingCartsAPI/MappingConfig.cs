using AutoMapper;
using GruppKniv.Services.ShoppingCartsAPI.Models;
using GruppKniv.Services.ShoppingCartsAPI.Models.DTO;

namespace GruppKniv.Services.ShoppingCartsAPI;

public class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<ShoppingCart, ShoppingCartDto>().ReverseMap();
            config.CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
            config.CreateMap<CartDetails, CartDetailsDto>().ReverseMap();
            config.CreateMap<Product, ProductDto>().ReverseMap();
        });

        return mappingConfig;
    }
}
