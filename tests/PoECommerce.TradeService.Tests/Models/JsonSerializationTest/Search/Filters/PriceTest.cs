using System.Text.Encodings.Web;
using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.PathOfExile.Models.Search.Filters;
using PoECommerce.PathOfExile.Tests.Utility;

namespace PoECommerce.PathOfExile.Tests.Models.JsonSerializationTest.Search.Filters
{
    [TestFixture]
    public class PriceTest
    {
        public static ModelToJsonTestCase<Price>[] TestCases =
        {
            new ModelToJsonTestCase<Price>
            {
                Subject = new Price
                {
                    Currency = null,
                    Min = null,
                    Max = null
                },
                ExpectedJson = "{}",
                Description = "Null"
            },
            new ModelToJsonTestCase<Price>
            {
                Subject = new Price
                {
                    Min = 1,
                    Max = null,
                    Currency = "chaos"
                },
                ExpectedJson = "{\"option\":\"chaos\",\"min\":1}",
                Description = "Max null"
            },
            new ModelToJsonTestCase<Price>
            {
                Subject = new Price
                {
                    Min = null,
                    Max = 2,
                    Currency = "chaos"
                },
                ExpectedJson = "{\"option\":\"chaos\",\"max\":2}",
                Description = "Min null"
            },
            new ModelToJsonTestCase<Price>
            {
                Subject = new Price
                {
                    Min = 1,
                    Max = 2,
                    Currency = "chaos"
                },
                ExpectedJson = "{\"option\":\"chaos\",\"min\":1,\"max\":2}"
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_SerializeToJson(ModelToJsonTestCase<Price> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            string result = JsonSerializer.Serialize(testCase.Subject, new JsonSerializerOptions {IgnoreNullValues = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping});

            // Then
            result.Should().Be(testCase.ExpectedJson);
        }
    }
}