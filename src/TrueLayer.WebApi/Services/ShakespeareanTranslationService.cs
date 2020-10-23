using System;
using System.Threading.Tasks;
using TrueLayer.WebApi.Interfaces;
using TrueLayer.WebApi.Models.FunTranslations;

namespace TrueLayer.WebApi.Services
{
    public class ShakespeareanTranslationService : ITranslationService
    {
        private readonly INetworkService _networkService;

        private const string FunTranslationsUrl = "https://api.funtranslations.com/translate/shakespeare.json";

        public ShakespeareanTranslationService(INetworkService networkService)
        {
            _networkService = networkService;
        }

        public async Task<string> Translate(string inputText)
        {
            var requestObject = new TranslateRequest(inputText);

            var result = await _networkService.PostData<TranslateResponse>(FunTranslationsUrl, requestObject);

            if (result.Success is null)
            {
                throw new NullReferenceException(nameof(result.Success));
            }

            return result.Contents.Translated;
        }
    }
}
