using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.TradeService.Models.Search.Filters.Wrappers;
using PoECommerce.TradeService.Tests.Utility;

namespace PoECommerce.TradeService.Tests.Models.JsonSerializationTest.Search.Filters.Wrappers
{
    [TestFixture]
    public class BooleanOptionTest
    {
        public static ModelToJsonTestCase<BooleanOption>[] TestCases =
        {
            new ModelToJsonTestCase<BooleanOption>
            {
                Subject = new BooleanOption {Value = null},
                ExpectedJson = "{}",
                Description = "Null"
            },
            new ModelToJsonTestCase<BooleanOption>
            {
                Subject = new BooleanOption {Value = true},
                ExpectedJson = "{\"option\":true}",
                Description = "True"
            },
            new ModelToJsonTestCase<BooleanOption>
            {
                Subject = new BooleanOption {Value = false},
                ExpectedJson = "{\"option\":false}",
                Description = "False"
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_SerializeToJson(ModelToJsonTestCase<BooleanOption> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            string result = JsonSerializer.Serialize(testCase.Subject, new JsonSerializerOptions {IgnoreNullValues = true});

            // Then
            result.Should().Be(testCase.ExpectedJson);
        }
    }
}