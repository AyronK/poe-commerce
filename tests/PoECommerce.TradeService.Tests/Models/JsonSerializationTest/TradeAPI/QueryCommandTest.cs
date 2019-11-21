using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.TradeService.Models.TradeAPI;

namespace PoECommerce.TradeService.Tests.Models.JsonSerializationTest.TradeAPI
{
    [TestFixture]
    public class QueryCommandTest
    {
        public static ModelToJsonTestCase<QueryCommand>[] TestCases =
        {
            new ModelToJsonTestCase<QueryCommand>
            {
                Subject = new QueryCommand
                {
                    Query = null
                },
                ExpectedJson = "{}"
            },
            new ModelToJsonTestCase<QueryCommand>
            {
                Subject = new QueryCommand
                {
                    Query = new Query
                    {
                        Name = "Super",
                        Type = "Valuable item"
                    }
                },
                ExpectedJson = "{\"query\":{\"name\":\"Super\",\"type\":\"Valuable item\"}}"
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_SerializeToJson(ModelToJsonTestCase<QueryCommand> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            string result = JsonSerializer.Serialize(testCase.Subject, new JsonSerializerOptions {IgnoreNullValues = true});

            // Then
            result.Should().Be(testCase.ExpectedJson);
        }
    }
}