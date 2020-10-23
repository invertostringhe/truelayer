using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TrueLayer.WebApi.Interfaces;
using TrueLayer.WebApi.Models;

namespace TrueLayer.WebApi.Controllers
{
    public class PokemonController : ControllerBase
    {
        private readonly IRepository<Pokemon> _pokemonRepository;
        private readonly ITranslationService _translationService;

        public PokemonController(IRepository<Pokemon> pokemonRepository, ITranslationService translationService)
        {
            _pokemonRepository = pokemonRepository;
            _translationService = translationService;
        }

        [HttpGet]
        [Route("/pokemon/{name}")]
        public async Task<IActionResult> GetShakespeareanPokemon(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest();
            }

            var pokemon = await _pokemonRepository.GetByName(name);

            var translatedDescription = await _translationService.Translate(pokemon.Description);

            var translatedPokemon = new Pokemon
            {
                Name = pokemon.Name,
                Description = translatedDescription
            };

            return Ok(translatedPokemon);
        }
    }
}
