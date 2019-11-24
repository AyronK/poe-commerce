using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.TradeService.Models.Search.Enums;
using PoECommerce.TradeService.Models.Search.Filters.Wrappers;
using PoECommerce.TradeService.Tests.Utility;

namespace PoECommerce.TradeService.Tests.Models.JsonSerializationTest.Search.Filters.Wrappers
{
    [TestFixture]
    public class OnlineStatusOptionTest
    {
        public static ModelToJsonTestCase<OnlineStatusOption>[] TestCases =
        {
            new ModelToJsonTestCase<OnlineStatusOption>
            {
                Subject = new OnlineStatusOption {Value = null},
                ExpectedJson = "{}",
                Description = "Null"
            },
            new ModelToJsonTestCase<OnlineStatusOption>
            {
                Subject = new OnlineStatusOption {Value = OnlineStatus.Online},
                ExpectedJson = "{\"option\":\"online\"}"
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_SerializeToJson(ModelToJsonTestCase<OnlineStatusOption> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            string result = JsonSerializer.Serialize(testCase.Subject, new JsonSerializerOptions {IgnoreNullValues = true});

            // Then
            result.Should().Be(testCase.ExpectedJson);
        }
    }
}