using GruppKniv.Services.ProductsAPI.Models.Dto;
using GruppKniv.Services.ProductsAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GruppKniv.Services.ProductsAPI.Controllers
{
    //Adding a global Route
    [Route("api/products")]
    public class ProductAPIController : ControllerBase
    {
        protected ResponseDto _response;
        private IProductRepository _productRepository;

        public ProductAPIController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            this._response = new ResponseDto();
        }
        
        [HttpGet]
        //Generic(object
        public async Task<object> Get()
        {
            try
            {
                //gets products
                IEnumerable<ProductDto> productDto = await _productRepository.GetProducts();
                //populates _response.Result to productDtos
                //isSuccess is true from default 
                _response.Result = productDto;
            }
            catch (Exception e)
            {
                //error message if no products shows up
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { e.ToString() };
            }

            return _response;
        }

        [HttpGet]
        [Route("{id}")]
        //Generic(object
        public async Task<object> Get(int id)
        {
            try
            {
                //gets products
                ProductDto productDto = await _productRepository.GetProductById(id);
                //populates _response.Result to productDtos
                //isSuccess is true from default 
                _response.Result = productDto;
            }
            catch (Exception e)
            {
                //error message if no products shows up
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { e.ToString() };
            }

            return _response;
        }

        [HttpPost]
        [Authorize]

        //Generic(object
        public async Task<object> Post([FromBody] ProductDto productDto)
        {
            try
            {
                //gets products
                ProductDto model = await _productRepository.CreateUpdateProduct(productDto);
                //populates _response.Result to productDtos
                //isSuccess is true from default 
                _response.Result = model;
            }
            catch (Exception e)
            {
                //error message if no products shows up
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { e.ToString() };
            }

            return _response;
        }

        [HttpPut]
        [Authorize]

        //Generic(object
        public async Task<object> Put([FromBody] ProductDto productDto)
        {
            try
            {
                //gets products
                ProductDto model = await _productRepository.CreateUpdateProduct(productDto);
                //populates _response.Result to productDtos
                //isSuccess is true from default 
                _response.Result = model;
            }
            catch (Exception e)
            {
                //error message if no products shows up
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { e.ToString() };
            }

            return _response;
        }
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                //gets products
                bool isSuccess = await _productRepository.DeleteProduct(id);
                //populates _response.Result to productDtos
                //isSuccess is true from default 
                _response.Result = isSuccess;
            }
            catch (Exception e)
            {
                //error message if no products shows up
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { e.ToString() };
            }

            return _response;
        }


    }
}

