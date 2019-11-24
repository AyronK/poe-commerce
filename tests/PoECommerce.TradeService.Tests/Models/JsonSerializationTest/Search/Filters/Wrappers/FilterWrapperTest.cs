using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.TradeService.Models.Search.Filters.Wrappers;
using PoECommerce.TradeService.Tests.Utility;

namespace PoECommerce.TradeService.Tests.Models.JsonSerializationTest.Search.Filters.Wrappers
{
    [TestFixture]
    public class FilterWrapperTest
    {
        public static ModelToJsonTestCase<FilterWrapper<string>>[] TestCases =
        {
            new ModelToJsonTestCase<FilterWrapper<string>>
            {
                Subject = new FilterWrapper<string> {Filter = null, Disabled = null},
                ExpectedJson = "{}",
                Description = "Null"
            },
            new ModelToJsonTestCase<FilterWrapper<string>>
            {
                Subject = new FilterWrapper<string> {Filter = "test", Disabled = null},
                ExpectedJson = "{\"filters\":\"test\"}",
                Description = "Disabled null"
            },
            new ModelToJsonTestCase<FilterWrapper<string>>
            {
                Subject = new FilterWrapper<string> {Filter = null, Disabled = true},
                ExpectedJson = "{\"disabled\":true}",
                Description = "Filter null"
            },
            new ModelToJsonTestCase<FilterWrapper<string>>
            {
                Subject = new FilterWrapper<string> {Filter = "test", Disabled = false},
                ExpectedJson = "{\"disabled\":false,\"filters\":\"test\"}"
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_SerializeToJson(ModelToJsonTestCase<FilterWrapper<string>> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            string result = JsonSerializer.Serialize(testCase.Subject, new JsonSerializerOptions {IgnoreNullValues = true});

            // Then
            result.Should().Be(testCase.ExpectedJson);
        }
    }
}