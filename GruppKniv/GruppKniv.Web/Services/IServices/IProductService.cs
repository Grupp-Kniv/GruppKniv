using System.Threading.Tasks;
using GruppKniv.Web.Models;

namespace GruppKniv.Web.Services.IServices
{
    //here we will have all the methods to do crud operations on products
    public interface IProductService : IBaseService
    {
        Task<T> GetAllProductsAsync<T>(string token);
        Task<T> GetProductByIdAsync<T>(int id,string token);
        //need product dto
        Task<T> CreateProductAsync<T>(ProductDto productDto, string token);
        //need product dto
        Task<T> UpdateProductAsync<T>(ProductDto productDto, string token);
        Task<T> DeleteProductAsync<T>(int id, string token);
    }
}
