using System.Text.Json.Serialization;

namespace PoECommerce.PathOfExile.Models
{
    public class ResponseResult<T>
    {
        [JsonPropertyName("result")]
        public virtual T Result { get; set; }
    }
}