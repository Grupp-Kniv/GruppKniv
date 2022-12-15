using AutoMapper;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using FakeItEasy;
using FluentAssertions;
using GruppKniv.Services.ProductsAPI.Controllers;
using GruppKniv.Services.ProductsAPI.DbContexts;
using GruppKniv.Services.ProductsAPI.Models;
using GruppKniv.Services.ProductsAPI.Models.Dto;
using GruppKniv.Services.ProductsAPI.Repository;
using Microsoft.AspNetCore.Mvc;


namespace Products.Tests.Controller
{
    public class ProductAPIControllerTest
    {
        private readonly IProductRepository _productRepository;
        private readonly ResponseDto _response;
        private readonly IMapper _mapper;
       
        public ProductAPIControllerTest()
        {
            _productRepository = A.Fake<IProductRepository>();
            _mapper = A.Fake<IMapper>();
            _response = A.Fake<ResponseDto>();
        }

        [Fact]
        public void ProductAPIController_GetProducts_ReturnTrue()
        {
            //Arrange
            var products = A.Fake<ICollection<ProductDto>>();
            var productList = A.Fake<List<ProductDto>>();
            A.CallTo(() => _mapper.Map<List<ProductDto>>(products)).Returns(productList);
            var controller = new ProductAPIController(_productRepository);
            //Act
            var result = controller.Get();
            //Assert
            Assert.True(_response.IsSuccess);
            Assert.NotNull(result);
        }

        [Fact]
        public void ProductAPIController_GetProductsById_ReturnTrue()
        {
            //Arrange

            
            var productController = new ProductAPIController(_productRepository);

            //Act
            var result = productController.Get(12);

            //Assert
            Assert.True(_response.IsSuccess);
            Assert.NotNull(result.Result.Equals(true));
            Assert.InRange(result.Id,1,100);
        }
        [Fact]
        public void ProductAPIController_PostProduct_ReturnTrue()
        {
            //Arrange
            var product = A.Fake<Product>();
            var productCreate = A.Fake<ProductDto>();
            var productList = A.Fake<IList<ProductDto>>();
            A.CallTo(() => _mapper.Map<Product>(productCreate)).Returns(product);
            A.CallTo(() => _mapper.Map<Product>(productList)).Returns(product);
            A.CallTo(() => _productRepository.CreateUpdateProduct(productCreate)).Returns(productCreate);
            
            
            var controller = new ProductAPIController(_productRepository);

            //Act
            var result = controller.Post(productCreate);

            //Assert
            Assert.True(_response.IsSuccess);
            Assert.NotNull(result.Result);
            result.Should().NotBeNull();
        }
        [Fact]
        public void ProductAPIController_PutProduct_ReturnNotNull()
        {
            //Arrange
            var product = A.Fake<Product>();
            var productCreate = A.Fake<ProductDto>();
            var productList = A.Fake<IList<ProductDto>>();
            A.CallTo(() => _mapper.Map<Product>(productCreate)).Returns(product);
            A.CallTo(() => _mapper.Map<Product>(productList)).Returns(product);
            A.CallTo(() => _productRepository.CreateUpdateProduct(productCreate)).Returns(productCreate);


            var controller = new ProductAPIController(_productRepository);

            //Act
            var result = controller.Put(productCreate);

            //Assert
            Assert.NotNull(result.Result);
            result.Should().NotBeNull();
            Assert.True(_response.IsSuccess);
        }
        [Fact]
        public void ProductAPIController_DeleteProduct_ReturnTrue()
        {
            //Arrange
            int id = 12;
            var productController = new ProductAPIController(_productRepository);

            //Act
            var result = productController.Delete(id);

            //Assert
            Assert.True(_response.IsSuccess);
            Assert.NotNull(result.Result.Equals(true));
       
        }
    }

    
}