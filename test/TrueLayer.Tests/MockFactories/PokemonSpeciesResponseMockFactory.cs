using System.Collections.Generic;
using TrueLayer.WebApi.Models.PokeApi;

namespace TrueLayer.Tests.MockFactories
{
    public static class PokemonSpeciesResponseMockFactory
    {
        public static PokemonSpeciesResponse WithFlavorTextEntriesNull()
        {
            return new PokemonSpeciesResponse
            {
                Name = "oddish"
            };
        }

        public static PokemonSpeciesResponse WithFlavorTextEntriesEmpty()
        {
            return new PokemonSpeciesResponse
            {
                Name = "oddish",
                FlavorTextEntries = new List<FlavorTextEntry>(),
            };
        }

        public static PokemonSpeciesResponse WithNoMatchingFlavorTextEntries()
        {
            var language = new ChildItem
            {
                Name = "latin",
            };

            var version = new ChildItem
            {
                Name = "1",
            };

            var flavorTextEntry = new FlavorTextEntry
            {
                FlavorText = "Lorem ipsum dolor sit amet",
                Language = language,
                Version = version,
            };

            return new PokemonSpeciesResponse
            {
                Name = "oddish",
                FlavorTextEntries = new List<FlavorTextEntry> { flavorTextEntry },
            };
        }
    }
}
