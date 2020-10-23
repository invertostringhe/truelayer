using System.Threading.Tasks;

namespace TrueLayer.WebApi.Interfaces
{
    public interface ITranslationService
    {
        Task<string> Translate(string inputText);
    }
}
