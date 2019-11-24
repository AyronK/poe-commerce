using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.PathOfExile.Models.Data;
using PoECommerce.PathOfExile.Models.Enums;
using PoECommerce.PathOfExile.PathOfExile.Data;
using PoECommerce.PathOfExile.Tests.Utility;

namespace PoECommerce.PathOfExile.Tests.PathOfExile.Data
{
    [TestFixture]
    public class PathOfExileDataServiceTest : HttpClientTestBase
    {
        private PathOfExileDataService _dataService;

        public void With_Service()
        {
            _dataService = new PathOfExileDataService(HttpClientFactory.Object);
        }

        [Test]
        public async Task When_GetItems_And_CorrectUrl()
        {
            // Given
            With_Response("{\"result\":[]}");
            With_HttpClient();
            With_Service();

            string expectedUrl = "api/trade/data/items";

            // When
            IReadOnlyDictionary<ItemCategory, Item[]> result = await _dataService.GetItems();

            // Then
            Then_HttpMethod(HttpMethod.Get);
            Then_Url(expectedUrl);

            result.Should().BeEmpty();
        }

        [Test]
        public async Task When_GetLeagues_And_CorrectUrl()
        {
            // Given
            With_Response("{\"result\":[]}");
            With_HttpClient();
            With_Service();

            string expectedUrl = "api/trade/data/leagues";

            // When
            League[] result = await _dataService.GetLeagues();

            // Then
            Then_HttpMethod(HttpMethod.Get);
            Then_Url(expectedUrl);

            result.Should().BeEmpty();
        }

        [Test]
        public async Task When_GetModifiers_And_CorrectUrl()
        {
            // Given
            With_Response("{\"result\":[]}");
            With_HttpClient();
            With_Service();

            string expectedUrl = "api/trade/data/stats";

            // When
            IReadOnlyDictionary<ModifierType, Modifier[]> result = await _dataService.GetModifiers();

            // Then
            Then_HttpMethod(HttpMethod.Get);
            Then_Url(expectedUrl);

            result.Should().BeEmpty();
        }

        [Test]
        public async Task When_GetStaticData_And_CorrectUrl()
        {
            // Given
            With_Response("{\"result\":{}}");
            With_HttpClient();
            With_Service();

            string expectedUrl = "api/trade/data/static";

            // When
            IReadOnlyDictionary<ItemCategory, StaticData[]> result = await _dataService.GetStaticData();

            // Then
            Then_HttpMethod(HttpMethod.Get);
            Then_Url(expectedUrl);

            result.Should().BeEmpty();
        }

        [Test]
        public async Task When_GetStaticData_And_DataUrlsHasBaseAddress()
        {
            // Given
            With_Response("{\"result\":{\"Armour\":[{\"id\":\"idTest\",\"text\":\"textTest\",\"image\":\"/img/1\"}]}}");
            With_HttpClient();
            With_Service();

            string expectedUrl = "api/trade/data/static";

            // When
            IReadOnlyDictionary<ItemCategory, StaticData[]> result = await _dataService.GetStaticData();

            // Then
            Then_HttpMethod(HttpMethod.Get);
            Then_Url(expectedUrl);

            result[ItemCategory.Armour][0].Image.Should().Be("https://www.pathofexile.com/img/1");
        }
    }
}