using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PoECommerce.PathOfExile.Extensions.Internal
{
    internal static class HttpResponseMessageExtensions
    {
        public static async Task<T> DeserializeResponseBody<T>(this HttpResponseMessage response, JsonSerializerOptions jsonSerializerOptions = null)
        {
            try
            {
                Stream responseBody = await response.Content.ReadAsStreamAsync();

                T result = jsonSerializerOptions != null
                    ? await JsonSerializer.DeserializeAsync<T>(responseBody, jsonSerializerOptions)
                    : await JsonSerializer.DeserializeAsync<T>(responseBody);

                return result;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}