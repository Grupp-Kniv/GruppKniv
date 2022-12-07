using AutoMapper;
using GruppKniv.Services.ProductsAPI.Models;
using GruppKniv.Services.ProductsAPI.Models.Dto;
using PizzaResturante.Services.ProductsAPI.Models;
using PizzaResturante.Services.ProductsAPI.Models.Dto;

namespace GruppKniv.Services.ProductsAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                //Mapping ProductDto to Product, and reverse(Product to ProductDto)
                //This converts product dto to product, and product to productDto
                //Properties needs to be the same in Model and dto
                config.CreateMap<ProductDto, Product>().ReverseMap();

            })
            {
               
            };
            return mappingConfig;
        }
    }
}
