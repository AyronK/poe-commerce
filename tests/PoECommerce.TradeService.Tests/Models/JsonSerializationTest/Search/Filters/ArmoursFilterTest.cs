using System.Text.Encodings.Web;
using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.PathOfExile.Models.Search.Filters;
using PoECommerce.PathOfExile.Tests.Utility;

namespace PoECommerce.PathOfExile.Tests.Models.JsonSerializationTest.Search.Filters
{
    [TestFixture]
    public class ArmoursFilterTest
    {
        public static ModelToJsonTestCase<ArmoursFilter>[] TestCases =
        {
            new ModelToJsonTestCase<ArmoursFilter>
            {
                Subject = new ArmoursFilter
                {
                    Armour = null,
                    EnergyShield = null,
                    Evasion = null,
                    Block = null
                },
                ExpectedJson = "{}",
                Description = "Null"
            },
            new ModelToJsonTestCase<ArmoursFilter>
            {
                Subject = new ArmoursFilter
                {
                    Armour = new FilterMagnitude {Min = 1, Max = 2},
                    EnergyShield = new FilterMagnitude {Min = 1, Max = 2},
                    Evasion = new FilterMagnitude {Min = 1, Max = 2},
                    Block = new FilterMagnitude {Min = 1, Max = 2}
                },
                ExpectedJson = "{\"ar\":{\"min\":1,\"max\":2},\"es\":{\"min\":1,\"max\":2},\"ev\":{\"min\":1,\"max\":2},\"block\":{\"min\":1,\"max\":2}}"
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_SerializeToJson(ModelToJsonTestCase<ArmoursFilter> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            string result = JsonSerializer.Serialize(testCase.Subject, new JsonSerializerOptions {IgnoreNullValues = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping});

            // Then
            result.Should().Be(testCase.ExpectedJson);
        }
    }
}