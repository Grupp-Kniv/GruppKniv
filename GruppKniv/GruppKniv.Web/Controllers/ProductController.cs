using GruppKniv.Web.Models;
using GruppKniv.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;


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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> IndexProduct()
        {
            List<ProductDto> list = new();
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            //call for responseDto because inside our API we are returning that object
            var response = await _productService.GetAllProductsAsync<ResponseDto>(accessToken);
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
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(ProductDto model)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                //call for responseDto because inside our API we are returning that object
                var response = await _productService.CreateProductAsync<ResponseDto>(model, accessToken);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexProduct));
                }
            }
            return View(model);

        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateProduct(int productId)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _productService.GetProductByIdAsync<ResponseDto>(productId, accessToken);
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
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                //call for responseDto because inside our API we are returning that object
                var response = await _productService.UpdateProductAsync<ResponseDto>(model, accessToken);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexProduct));
                }
            }
            return View(model);

        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _productService.GetProductByIdAsync<ResponseDto>(productId, accessToken);
            if (response != null && response.IsSuccess)
            {
                ProductDto model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProduct(ProductDto model)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var response = await _productService.DeleteProductAsync<ResponseDto>(model.ProductId, accessToken);
                if (response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexProduct));
                }
            }
            return View(model);
        }

    }

}
