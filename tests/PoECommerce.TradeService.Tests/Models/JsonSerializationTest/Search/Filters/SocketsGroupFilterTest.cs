using System.Text.Encodings.Web;
using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.TradeService.Models.Search.Filters;
using PoECommerce.TradeService.Tests.Utility;

namespace PoECommerce.TradeService.Tests.Models.JsonSerializationTest.Search.Filters
{
    [TestFixture]
    public class SocketsGroupFilterTest
    {
        public static ModelToJsonTestCase<SocketsGroupFilter>[] TestCases =
        {
            new ModelToJsonTestCase<SocketsGroupFilter>
            {
                Subject = new SocketsGroupFilter
                {
                    SocketsFilter = null,
                    LinksFilter = null
                },
                ExpectedJson = "{}",
                Description = "Null"
            },
            new ModelToJsonTestCase<SocketsGroupFilter>
            {
                Subject = new SocketsGroupFilter
                {
                    SocketsFilter = new SocketsFilter
                    {
                        GreenMin = 1,
                        RedMin = 2,
                        BlueMin = 1,
                        WhiteMin = 2,
                        AnyMin = 1,
                        AnyMax = 6
                    },
                    LinksFilter = new SocketsFilter
                    {
                        GreenMin = 2,
                        RedMin = 1,
                        BlueMin = 2,
                        WhiteMin = 1,
                        AnyMin = 2,
                        AnyMax = 5
                    }
                },
                ExpectedJson = "{\"sockets\":{\"g\":1,\"r\":2,\"b\":1,\"w\":2,\"min\":1,\"max\":6},\"links\":{\"g\":2,\"r\":1,\"b\":2,\"w\":1,\"min\":2,\"max\":5}}"
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_SerializeToJson(ModelToJsonTestCase<SocketsGroupFilter> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            string result = JsonSerializer.Serialize(testCase.Subject, new JsonSerializerOptions {IgnoreNullValues = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping});

            // Then
            result.Should().Be(testCase.ExpectedJson);
        }
    }
}