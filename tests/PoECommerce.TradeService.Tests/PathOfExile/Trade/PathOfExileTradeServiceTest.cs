using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.PathOfExile.Models.Search;
using PoECommerce.PathOfExile.Models.Trade;
using PoECommerce.PathOfExile.Tests.Utility;
using PoECommerce.PathOfExile.Web.Trade;

namespace PoECommerce.PathOfExile.Tests.PathOfExile.Trade
{
    [TestFixture]
    public class PathOfExileTradeServiceTest : HttpClientTestBase
    {
        private PathOfExileTradeService _tradeService;

        public void With_Service()
        {
            _tradeService = new PathOfExileTradeService(HttpClientFactory.Object);
        }

        [Test]
        public async Task When_Fetch_And_CorrectUrl()
        {
            // Given
            With_Response("{\"result\":[]}");
            With_HttpClient();
            With_Service();

            string queryId = "queryId";
            string[] ids = Enumerable.Range(1, 3).Select(c => c.ToString()).ToArray();

            string expectedUrl = $"api/trade/fetch/{string.Join(',', ids)}?query={queryId}";

            // When
            ListedItem[] result = await _tradeService.Fetch(queryId, ids);

            // Then
            Then_HttpMethod(HttpMethod.Get);
            Then_Url(expectedUrl);

            result.Should().BeEmpty();
        }

        [Test]
        public async Task When_Search_And_CorrectUrl()
        {
            // Given
            Query query = new Query {Name = "Name", Type = "Type"};

            With_Response("{\"id\":\"queryId\",\"total\":0,\"result\":[]}");
            With_HttpClient();
            With_Service();

            string expectedUrl = $"api/trade/search/Delve";

            // When
            QueryResult result = await _tradeService.Search(query, null, "Delve");

            // Then;
            Then_HttpMethod(HttpMethod.Post);
            Then_Url(expectedUrl);
            Then_RequestBodyJson("{\"query\":{\"name\":\"Name\",\"type\":\"Type\"}}");

            result.Id.Should().Be("queryId");
            result.Total.Should().Be(0);
            result.Result.Should().BeEmpty();
        }
    }
}