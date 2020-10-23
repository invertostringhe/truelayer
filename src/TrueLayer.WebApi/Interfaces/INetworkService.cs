using System.Threading.Tasks;

namespace TrueLayer.WebApi.Interfaces
{
    public interface INetworkService
    {
        Task<T> GetData<T>(string input);

        Task<T> PostData<T>(string input, object data);
    }
}
