using System.Threading.Tasks;

namespace TrueLayer.WebApi.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> GetByName(string name);
    }
}