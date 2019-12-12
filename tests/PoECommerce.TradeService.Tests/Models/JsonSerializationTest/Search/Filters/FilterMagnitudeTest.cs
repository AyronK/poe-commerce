using System.Text.Encodings.Web;
using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.PathOfExile.Models.Search.Filters;
using PoECommerce.PathOfExile.Tests.Utility;

namespace PoECommerce.PathOfExile.Tests.Models.JsonSerializationTest.Search.Filters
{
    [TestFixture]
    public class FilterMagnitudeTest
    {
        public static ModelToJsonTestCase<FilterMagnitude>[] TestCases =
        {
            new ModelToJsonTestCase<FilterMagnitude>
            {
                Subject = new FilterMagnitude
                {
                    Min = null,
                    Max = null
                },
                ExpectedJson = "{}",
                Description = "Null"
            },
            new ModelToJsonTestCase<FilterMagnitude>
            {
                Subject = new FilterMagnitude
                {
                    Min = 1,
                    Max = null
                },
                ExpectedJson = "{\"min\":1}",
                Description = "Max null"
            },
            new ModelToJsonTestCase<FilterMagnitude>
            {
                Subject = new FilterMagnitude
                {
                    Min = null,
                    Max = 2
                },
                ExpectedJson = "{\"max\":2}",
                Description = "Min null"
            },
            new ModelToJsonTestCase<FilterMagnitude>
            {
                Subject = new FilterMagnitude
                {
                    Min = 1,
                    Max = 2
                },
                ExpectedJson = "{\"min\":1,\"max\":2}"
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_SerializeToJson(ModelToJsonTestCase<FilterMagnitude> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            string result = JsonSerializer.Serialize(testCase.Subject, new JsonSerializerOptions {IgnoreNullValues = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping});

            // Then
            result.Should().Be(testCase.ExpectedJson);
        }
    }
}