using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Moq.Protected;
using PoECommerce.TradeService.PathOfExile;

namespace PoECommerce.TradeService.Tests.Utility
{
    public class HttpClientTestBase
    {
        private static readonly Uri TestBaseAddress = PathOfExileConfiguration.BaseAddress;
        protected Mock<IHttpClientFactory> HttpClientFactory;
        protected Mock<HttpMessageHandler> HttpHandlerMock;
        protected HttpRequestMessage SentRequest;
        protected string ReturnedJson { get; private set; }

        public void With_Response(string json)
        {
            ReturnedJson = json;
        }

        public void With_HttpClient()
        {
            HttpHandlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);

            HttpHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .Callback((HttpRequestMessage h, CancellationToken _) => SentRequest = h)
                .ReturnsAsync(new HttpResponseMessage {StatusCode = HttpStatusCode.OK, Content = new StringContent(ReturnedJson)});

            HttpClient httpClient = new HttpClient(HttpHandlerMock.Object)
            {
                BaseAddress = TestBaseAddress
            };

            HttpClientFactory = new Mock<IHttpClientFactory>();
            HttpClientFactory.Setup(c => c.CreateClient(PathOfExileConfiguration.HttpClientName)).Returns(httpClient);
        }

        protected void Then_HttpMethod(HttpMethod httpMethod)
        {
            SentRequest.Method.Should().Be(httpMethod);
        }

        protected void Then_Url(string endpoint)
        {
            SentRequest.RequestUri.AbsoluteUri.Should().Be(TestBaseAddress + endpoint);
        }

        protected void Then_RequestBodyJson(string json)
        {
            SentRequest.Content.ReadAsStringAsync().Result.Should().Be(json);
        }
    }
}