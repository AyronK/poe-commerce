using System.Text.Json.Serialization;

namespace PoECommerce.TradeService.Models.TradeAPI
{
    public class FetchResult
    {
        [JsonPropertyName("result")]
        public FetchResultItem[] Result { get; set; }
    }
}