using GruppKniv.Web.Models;
using GruppKniv.Web.Services;
using GruppKniv.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection;

namespace GruppKniv.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        //dependency injection
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> IndexProduct()
        {
            List<ProductDto> list = new();
            //call for responseDto because inside our API we are returning that object
            var response = await _productService.GetAllProductsAsync<ResponseDto>();
            if (response != null && response.IsSuccess)
            {
                //To populate the list we need to use deserializing 
                //where to output will be an list of ProductDto and Convert it to string 
                //(response.result) so we can return that list of productds
                list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
        public async Task<IActionResult> CreateProduct()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(ProductDto model)
        {
            if(ModelState.IsValid)
            {
                //call for responseDto because inside our API we are returning that object
                var response = await _productService.CreateProductAsync<ResponseDto>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexProduct));
                }
            }
            return View(model);

        }
        public async Task<IActionResult> UpdateProduct(int productId)
        {
            
            var response = await _productService.GetProductByIdAsync<ResponseDto>(productId);
            if (response != null && response.IsSuccess)
            {
                ProductDto model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProduct(ProductDto model)
        {
            if (ModelState.IsValid)
            {
                //call for responseDto because inside our API we are returning that object
                var response = await _productService.UpdateProductAsync<ResponseDto>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexProduct));
                }
            }
            return View(model);

        }
            public async Task<IActionResult> DeleteProduct(int productId)
        {
            
            var response = await _productService.GetProductByIdAsync<ResponseDto>(productId);
            if (response != null && response.IsSuccess)
            {
                ProductDto model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteProduct(ProductDto model)
            {
                if (ModelState.IsValid)
                {
                    var response = await _productService.DeleteProductAsync<ResponseDto>(model.ProductId);
                    if (response.IsSuccess)
                    {
                        return RedirectToAction(nameof(IndexProduct));
                    }
                }
                return View(model);
            }

    }
   
}
