using System.Text.Encodings.Web;
using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.TradeService.Models.Search.Filters;
using PoECommerce.TradeService.Tests.Utility;

namespace PoECommerce.TradeService.Tests.Models.JsonSerializationTest.Search.Filters
{
    [TestFixture]
    public class ModifierFilterTest
    {
        public static ModelToJsonTestCase<ModifierFilter>[] TestCases =
        {
            new ModelToJsonTestCase<ModifierFilter>
            {
                Subject = new ModifierFilter
                {
                    Id = null,
                    Disabled = null,
                    Magnitude = null
                },
                ExpectedJson = "{}",
                Description = "Null"
            },
            new ModelToJsonTestCase<ModifierFilter>
            {
                Subject = new ModifierFilter
                {
                    Id = "test.mod",
                    Disabled = true,
                    Magnitude = new FilterMagnitude {Min = 1, Max = 2}
                },
                ExpectedJson = "{\"id\":\"test.mod\",\"value\":{\"min\":1,\"max\":2},\"disabled\":true}"
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_SerializeToJson(ModelToJsonTestCase<ModifierFilter> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            string result = JsonSerializer.Serialize(testCase.Subject, new JsonSerializerOptions {IgnoreNullValues = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping});

            // Then
            result.Should().Be(testCase.ExpectedJson);
        }
    }
}