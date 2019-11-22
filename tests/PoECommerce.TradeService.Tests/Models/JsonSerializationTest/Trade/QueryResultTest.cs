using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.TradeService.Models.Trade;
using PoECommerce.TradeService.Tests.Utility;

namespace PoECommerce.TradeService.Tests.Models.JsonSerializationTest.TradeAPI
{
    [TestFixture]
    public class QueryResultTest
    {
        public static ModelFromJsonTestCase<QueryResult>[] TestCases =
        {
            new ModelFromJsonTestCase<QueryResult>
            {
                Json = "{\"id\":null,\"total\":0,\"result\":null}",
                ExpectedResult =
                    new QueryResult
                    {
                        Id = null,
                        Total = 0,
                        Result =null
                    },
                Description = "All is empty"
            },
            new ModelFromJsonTestCase<QueryResult>
            {
                Json = "{\"id\":\"asSDaf789\",\"total\":0,\"result\":[]}",
                ExpectedResult =
                    new QueryResult
                    {
                        Id = "asSDaf789",
                        Total = 0,
                        Result = new string[0]
                    },
                Description = "With emtpy result"
            },
            new ModelFromJsonTestCase<QueryResult>
            {
                Json = "{\"id\":\"5dsf465sdDS\",\"total\":1,\"result\":[\"testResult1\"]}",
                ExpectedResult =
                    new QueryResult
                    {
                        Id = "5dsf465sdDS",
                        Total = 1,
                        Result = new[] {"testResult1"}
                    },
                Description = "With single result"
            },
            new ModelFromJsonTestCase<QueryResult>
            {
                Json = "{\"id\":\"SD464fds654\",\"total\":2,\"result\":[\"testResult1\",\"testResult2\"]}",
                ExpectedResult =
                    new QueryResult
                    {
                        Id = "SD464fds654",
                        Total = 2,
                        Result = new[] { "testResult1", "testResult2" }
                    },
                Description = "With multiple results"
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_SerializeToJson(ModelFromJsonTestCase<QueryResult> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            QueryResult result = JsonSerializer.Deserialize<QueryResult>(testCase.Json);

            // Then
            result.Should().BeEquivalentTo(testCase.ExpectedResult);
        }
    }
}