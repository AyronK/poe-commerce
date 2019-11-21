using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using PoECommerce.TradeService.Models.TradeAPI;

namespace PoECommerce.TradeService.Tests
{
    [TestFixture]
    public class OfficialPoETradeServiceTest
    {
        private const string TestBaseAddress = "http://test.com";
        protected string ReturnedJson { get; private set; }
        protected string League { get; private set; }

        private OfficialPoETradeService _tradeService;
        private Mock<HttpMessageHandler> _httpHandlerMock;
        private HttpRequestMessage _sentRequest;

        public void With_Response(string json)
        {
            ReturnedJson = json;
        }

        public void With_League(string league)
        {
            League = league;
        }

        public void With_HttpClient()
        {
            _httpHandlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);

            _httpHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .Callback((HttpRequestMessage h, CancellationToken _) => _sentRequest = h)
                .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent(ReturnedJson) });

            HttpClient httpClient = new HttpClient(_httpHandlerMock.Object)
            {
                BaseAddress = new Uri(TestBaseAddress)
            };

            Mock<IHttpClientFactory> httpClientFactory = new Mock<IHttpClientFactory>();
            httpClientFactory.Setup(c => c.CreateClient(OfficialPoETradeService.HttpClientName)).Returns(httpClient);

            _tradeService = new OfficialPoETradeService(httpClientFactory.Object, League);
        }

        [Test]
        public async Task When_Fetch_And_CorrectUrl()
        {
            // Given
            With_Response("{\"result\":[]}");
            With_League("Delve");
            With_HttpClient();

            string queryId = "queryId";
            string[] ids = Enumerable.Range(1, 3).Select(c => c.ToString()).ToArray();

            string expectedUrl = $"/api/trade/fetch/{string.Join(',', ids)}?query={queryId}";

            // When
            FetchResult result = await _tradeService.Fetch(queryId, ids);

            // Then
            Then_HttpMethod(HttpMethod.Get);
            Then_Url(expectedUrl);

            result.Result.Should().BeEmpty();
        }

        [Test]
        public async Task When_Search_And_CorrectUrl()
        {
            // Given
            Query query = new Query { Name = "Name", Type = "Type" };

            With_Response("{\"id\":\"queryId\",\"total\":0,\"result\":[]}");
            With_League("Delve");
            With_HttpClient();

            string expectedUrl = $"/api/trade/search/{League}";

            // When
            QueryResult result = await _tradeService.Search(query);

            // Then;
            Then_HttpMethod(HttpMethod.Post);
            Then_Url(expectedUrl);
            Then_BodyJson("{\"query\":{\"name\":\"Name\",\"type\":\"Type\"}}");

            result.Id.Should().Be("queryId");
            result.Total.Should().Be(0);
            result.Result.Should().BeEmpty();
        }

        private void Then_HttpMethod(HttpMethod httpMethod)
        {
            _sentRequest.Method.Should().Be(httpMethod);
        }

        private void Then_Url(string endpoint)
        {
            _sentRequest.RequestUri.AbsoluteUri.Should().Be(TestBaseAddress + endpoint);
        }

        private void Then_BodyJson(string json)
        {
            _sentRequest.Content.ReadAsStringAsync().Result.Should().Be(json);
        }
    }
}