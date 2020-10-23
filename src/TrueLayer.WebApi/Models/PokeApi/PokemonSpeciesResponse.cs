using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TrueLayer.WebApi.Models.PokeApi
{
    // Light version of the returned object with just the informations that I really need

    public class PokemonSpeciesResponse
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("flavor_text_entries")]
        public IList<FlavorTextEntry> FlavorTextEntries { get; set; }
    }

    public class FlavorTextEntry
    {
        [JsonPropertyName("flavor_text")]
        public string FlavorText { get; set; }

        [JsonPropertyName("language")]
        public ChildItem Language { get; set; }

        [JsonPropertyName("version")]
        public ChildItem Version { get; set; }
    }

    public class ChildItem
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}

