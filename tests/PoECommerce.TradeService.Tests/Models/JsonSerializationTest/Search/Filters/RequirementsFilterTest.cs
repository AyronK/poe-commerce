using System.Text.Encodings.Web;
using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.TradeService.Models.Search.Filters;
using PoECommerce.TradeService.Tests.Utility;

namespace PoECommerce.TradeService.Tests.Models.JsonSerializationTest.Search.Filters
{
    [TestFixture]
    public class RequirementsFilterTest
    {
        public static ModelToJsonTestCase<RequirementsFilter>[] TestCases =
        {
            new ModelToJsonTestCase<RequirementsFilter>
            {
                Subject = new RequirementsFilter
                {
                    Level = null,
                    Dexterity = null,
                    Strength = null,
                    Intelligence = null
                },
                ExpectedJson = "{}",
                Description = "Null"
            },
            new ModelToJsonTestCase<RequirementsFilter>
            {
                Subject = new RequirementsFilter
                {
                    Level = new FilterMagnitude {Min = 1, Max = 2},
                    Dexterity = new FilterMagnitude {Min = 1, Max = 2},
                    Strength = new FilterMagnitude {Min = 1, Max = 2},
                    Intelligence = new FilterMagnitude {Min = 1, Max = 2}
                },
                ExpectedJson = "{\"lvl\":{\"min\":1,\"max\":2},\"dex\":{\"min\":1,\"max\":2},\"str\":{\"min\":1,\"max\":2},\"int\":{\"min\":1,\"max\":2}}"
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_SerializeToJson(ModelToJsonTestCase<RequirementsFilter> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            string result = JsonSerializer.Serialize(testCase.Subject, new JsonSerializerOptions {IgnoreNullValues = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping});

            // Then
            result.Should().Be(testCase.ExpectedJson);
        }
    }
}