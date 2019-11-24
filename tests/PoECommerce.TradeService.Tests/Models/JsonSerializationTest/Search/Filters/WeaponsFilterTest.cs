using System.Text.Encodings.Web;
using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.PathOfExile.Models.Search.Filters;
using PoECommerce.PathOfExile.Tests.Utility;

namespace PoECommerce.PathOfExile.Tests.Models.JsonSerializationTest.Search.Filters
{
    [TestFixture]
    public class WeaponsFilterTest
    {
        public static ModelToJsonTestCase<WeaponsFilter>[] TestCases =
        {
            new ModelToJsonTestCase<WeaponsFilter>
            {
                Subject = new WeaponsFilter
                {
                    Dps = null,
                    Damage = null,
                    ElementalDps = null,
                    CriticalChance = null,
                    AttacksPerSecond = null,
                    PhysicalDps = null
                },
                ExpectedJson = "{}",
                Description = "Null"
            },
            new ModelToJsonTestCase<WeaponsFilter>
            {
                Subject = new WeaponsFilter
                {
                    Dps = new FilterMagnitude {Min = 1, Max = 2},
                    Damage = new FilterMagnitude {Min = 1, Max = 2},
                    ElementalDps = new FilterMagnitude {Min = 1, Max = 2},
                    CriticalChance = new FilterMagnitude {Min = 1, Max = 2},
                    AttacksPerSecond = new FilterMagnitude {Min = 1, Max = 2},
                    PhysicalDps = new FilterMagnitude {Min = 1, Max = 2}
                },
                ExpectedJson = "{\"damage\":{\"min\":1,\"max\":2},\"crit\":{\"min\":1,\"max\":2},\"pdps\":{\"min\":1,\"max\":2},\"aps\":{\"min\":1,\"max\":2},\"dps\":{\"min\":1,\"max\":2},\"edps\":{\"min\":1,\"max\":2}}"
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_SerializeToJson(ModelToJsonTestCase<WeaponsFilter> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            string result = JsonSerializer.Serialize(testCase.Subject, new JsonSerializerOptions {IgnoreNullValues = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping});

            // Then
            result.Should().Be(testCase.ExpectedJson);
        }
    }
}