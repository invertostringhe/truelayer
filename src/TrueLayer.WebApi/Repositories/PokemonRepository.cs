using System;
using System.Linq;
using System.Threading.Tasks;
using TrueLayer.WebApi.Exceptions;
using TrueLayer.WebApi.Interfaces;
using TrueLayer.WebApi.Models;
using TrueLayer.WebApi.Models.PokeApi;

namespace TrueLayer.WebApi.Repositories
{
    public class PokemonRepository : IRepository<Pokemon>
    {
        private readonly INetworkService _networkService;

        private const string PokemonApiUrl = "https://pokeapi.co/api/v2/pokemon-species";

        public PokemonRepository(INetworkService networkService)
        {
            _networkService = networkService;
        }

        public async Task<Pokemon> GetByName(string input)
        {
            var name = input.ToLower();

            var pokemonDescriptions = await _networkService.GetData<PokemonSpeciesResponse>($"{PokemonApiUrl}/{name}");

            if (pokemonDescriptions.FlavorTextEntries is null)
            {
                throw new NullReferenceException(nameof(pokemonDescriptions.FlavorTextEntries));
            }
                
            if (pokemonDescriptions.FlavorTextEntries.Count == 0)
            {
                throw new EmptyListException(nameof(pokemonDescriptions.FlavorTextEntries));
            }

            var lastFlavorItem = pokemonDescriptions.FlavorTextEntries.LastOrDefault(GetEnglishFlavorTextEntry);

            if (lastFlavorItem is null)
            {
                throw new NullReferenceException(nameof(lastFlavorItem));
            }

            return new Pokemon
            {
                Name = pokemonDescriptions.Name,
                Description = lastFlavorItem.FlavorText,
            };
        }

        private bool GetEnglishFlavorTextEntry(FlavorTextEntry flavorTextEntry)
        {
            if (flavorTextEntry is null)
            {
                return false;
            }

            if (flavorTextEntry.Language is null)
            {
                return false;
            }

            return flavorTextEntry.Language.Name == "en";
        }
    }
}
