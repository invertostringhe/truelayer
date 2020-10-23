using System.Text.Json.Serialization;

namespace TrueLayer.WebApi.Models.FunTranslations
{
    public class TranslateRequest
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }

        public TranslateRequest(string text)
        {
            this.Text = text;
        }
    }
}
