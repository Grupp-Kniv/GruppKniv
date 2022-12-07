using AutoMapper;
using GruppKniv.Services.ProductsAPI.DbContexts;
using GruppKniv.Services.ProductsAPI.Models.Dto;
using GruppKniv.Services.ProductsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GruppKniv.Services.ProductsAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            //create a product and convert Product Dto to a Product Model using mapper
            //and assign that to "product"
            Product product = _mapper.Map<ProductDto, Product>(productDto);
            //if product ID > 0 then update product
            if (product.ProductId > 0)
            {
                _db.Products.Update(product);
            }
            //else product ID < 0 then create product
            else
            {
                _db.Products.Add(product);
            }
            await _db.SaveChangesAsync();
            //return the updated/created product using mapper.
            return _mapper.Map<Product, ProductDto>(product);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Product product = await _db.Products.FirstOrDefaultAsync(u => u.ProductId == productId);
                if (product == null)
                {
                    return false;
                }
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            Product product = await _db.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<Product> productList = await _db.Products.ToListAsync();
            //converts the product list to a productDto
            return _mapper.Map<List<ProductDto>>(productList);
        }
    }
}
