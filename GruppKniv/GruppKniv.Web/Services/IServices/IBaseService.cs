using GruppKniv.Web.Models;

namespace GruppKniv.Web.Services.IServices
{
    public interface IBaseService: IDisposable

    {
        ResponseDto responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apirequest);

    }
}
