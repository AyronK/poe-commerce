using System.Text.Encodings.Web;
using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.TradeService.Models.Search.Enums;
using PoECommerce.TradeService.Models.Search.Filters;
using PoECommerce.TradeService.Models.Search.Filters.Wrappers;
using PoECommerce.TradeService.Tests.Utility;

namespace PoECommerce.TradeService.Tests.Models.JsonSerializationTest.Search.Filters
{
    [TestFixture]
    public class TradeFilterTest
    {
        public static ModelToJsonTestCase<TradeFilter>[] TestCases =
        {
            new ModelToJsonTestCase<TradeFilter>
            {
                Subject = new TradeFilter
                {
                    Account = null,
                    Indexed = null,
                    SaleType = null,
                    Price = null
                },
                ExpectedJson = "{}",
                Description = "Null"
            },
            new ModelToJsonTestCase<TradeFilter>
            {
                Subject = new TradeFilter
                {
                    Account = new Account
                    {
                        Name = "123Test"
                    },
                    Indexed = new IndexedOption
                    {
                        Value = Indexed.OneMonth
                    },
                    SaleType = new SaleTypeOption
                    {
                        Value = SaleType.Priced
                    },
                    Price = new Price
                    {
                        Min = 1,
                        Max = 2,
                        Currency = "chaos"
                    }
                },
                ExpectedJson = "{\"account\":{\"input\":\"123Test\"},\"indexed\":{\"option\":\"1month\"},\"sale_type\":{\"option\":\"priced\"},\"price\":{\"option\":\"chaos\",\"min\":1,\"max\":2}}"
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_SerializeToJson(ModelToJsonTestCase<TradeFilter> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            string result = JsonSerializer.Serialize(testCase.Subject, new JsonSerializerOptions {IgnoreNullValues = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping});

            // Then
            result.Should().Be(testCase.ExpectedJson);
        }
    }
}