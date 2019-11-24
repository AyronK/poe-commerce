using System.Text.Encodings.Web;
using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.PathOfExile.Models.Search.Filters;
using PoECommerce.PathOfExile.Tests.Utility;

namespace PoECommerce.PathOfExile.Tests.Models.JsonSerializationTest.Search.Filters
{
    [TestFixture]
    public class SocketsFilterTest
    {
        public static ModelToJsonTestCase<SocketsFilter>[] TestCases =
        {
            new ModelToJsonTestCase<SocketsFilter>
            {
                Subject = new SocketsFilter
                {
                    GreenMin = null,
                    RedMin = null,
                    BlueMin = null,
                    WhiteMin = null,
                    AnyMin = null,
                    AnyMax = null
                },
                ExpectedJson = "{}",
                Description = "Null"
            },
            new ModelToJsonTestCase<SocketsFilter>
            {
                Subject = new SocketsFilter
                {
                    GreenMin = 1,
                    RedMin = 2,
                    BlueMin = 1,
                    WhiteMin = 2,
                    AnyMin = 1,
                    AnyMax = 6
                },
                ExpectedJson = "{\"g\":1,\"r\":2,\"b\":1,\"w\":2,\"min\":1,\"max\":6}"
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_SerializeToJson(ModelToJsonTestCase<SocketsFilter> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            string result = JsonSerializer.Serialize(testCase.Subject, new JsonSerializerOptions {IgnoreNullValues = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping});

            // Then
            result.Should().Be(testCase.ExpectedJson);
        }
    }
}