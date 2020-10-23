using Microsoft.AspNetCore.Mvc;
using Moq;
using TrueLayer.WebApi.Interfaces;
using TrueLayer.WebApi.Models;
using TrueLayer.WebApi.Controllers;
using Xunit;

namespace TrueLayer.Tests.Controllers
{
    public class PokemonControllerTests
    {
        [Fact]
        public async void AssertTranslationIsDone()
        {
            var mockRepository = new Mock<IRepository<Pokemon>>();
            var mockTranslator = new Mock<ITranslationService>();

            var fixedDescription = "lorem ipsum";
            
            var pokemonName = "oddish";
            var translation = "LOREM IPSUM";

            mockRepository.Setup(_ => _.GetByName(It.IsAny<string>()))
                .ReturnsAsync((string name) => new Pokemon { Name = name, Description = fixedDescription });

            mockTranslator.Setup(_ => _.Translate(It.IsAny<string>()))
                          .ReturnsAsync((string inputText) => inputText.ToUpperInvariant());

            var controller = new PokemonController(mockRepository.Object, mockTranslator.Object);

            var result = (OkObjectResult)await controller.GetShakespeareanPokemon(pokemonName);

            var parsedResult = (Pokemon)result.Value;

            Assert.Equal(translation, parsedResult.Description);
        }
    }
}