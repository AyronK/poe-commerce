using System.Text.Encodings.Web;
using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.TradeService.Models.Search.Filters;
using PoECommerce.TradeService.Tests.Utility;

namespace PoECommerce.TradeService.Tests.Models.JsonSerializationTest.Search.Filters
{
    [TestFixture]
    public class AccountTest
    {
        public static ModelToJsonTestCase<Account>[] TestCases =
        {
            new ModelToJsonTestCase<Account>
            {
                Subject = new Account
                {
                    Name = null
                },
                ExpectedJson = "{}",
                Description = "Null"
            },
            new ModelToJsonTestCase<Account>
            {
                Subject = new Account
                {
                    Name = "123Test"
                },
                ExpectedJson = "{\"input\":\"123Test\"}",
                Description = "Text with digits"
            },
            new ModelToJsonTestCase<Account>
            {
                Subject = new Account
                {
                    Name = "播放器"
                },
                ExpectedJson = "{\"input\":\"播放器\"}",
                Description = "Unicode characters"
            }
        };
        
        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_SerializeToJson(ModelToJsonTestCase<Account> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            string result = JsonSerializer.Serialize(testCase.Subject, new JsonSerializerOptions {IgnoreNullValues = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping});

            // Then
            result.Should().Be(testCase.ExpectedJson);
        }
    }
}