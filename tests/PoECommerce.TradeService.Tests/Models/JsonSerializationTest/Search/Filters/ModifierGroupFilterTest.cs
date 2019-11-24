using System.Text.Encodings.Web;
using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.TradeService.Models.Search.Enums;
using PoECommerce.TradeService.Models.Search.Filters;
using PoECommerce.TradeService.Tests.Utility;

namespace PoECommerce.TradeService.Tests.Models.JsonSerializationTest.Search.Filters
{
    [TestFixture]
    public class ModifierGroupFilterTest
    {
        public static ModelToJsonTestCase<ModifierGroupFilter>[] TestCases =
        {
            new ModelToJsonTestCase<ModifierGroupFilter>
            {
                Subject = new ModifierGroupFilter
                {
                    Operand = FilterOperand.And,
                    Filters = null
                },
                ExpectedJson = "{\"type\":\"and\"}",
                Description = "Operand only"
            },
            new ModelToJsonTestCase<ModifierGroupFilter>
            {
                Subject = new ModifierGroupFilter
                {
                    Operand = FilterOperand.Not,
                    Filters = new[]
                    {
                        new ModifierFilter
                        {
                            Id = "test.mod",
                            Disabled = true,
                            Magnitude = new FilterMagnitude {Min = 1, Max = 2}
                        }
                    }
                },
                ExpectedJson = "{\"type\":\"not\",\"filters\":[{\"id\":\"test.mod\",\"value\":{\"min\":1,\"max\":2},\"disabled\":true}]}"
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_SerializeToJson(ModelToJsonTestCase<ModifierGroupFilter> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            string result = JsonSerializer.Serialize(testCase.Subject, new JsonSerializerOptions {IgnoreNullValues = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping});

            // Then
            result.Should().Be(testCase.ExpectedJson);
        }
    }
}