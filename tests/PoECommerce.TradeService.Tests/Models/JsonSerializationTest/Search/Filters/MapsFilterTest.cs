using System.Text.Encodings.Web;
using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.PathOfExile.Models.Search.Filters;
using PoECommerce.PathOfExile.Models.Search.Filters.Wrappers;
using PoECommerce.PathOfExile.Tests.Utility;

namespace PoECommerce.PathOfExile.Tests.Models.JsonSerializationTest.Search.Filters
{
    [TestFixture]
    public class MapsFilterTest
    {
        public static ModelToJsonTestCase<MapsFilter>[] TestCases =
        {
            new ModelToJsonTestCase<MapsFilter>
            {
                Subject = new MapsFilter
                {
                    Tier = null,
                    IncreasedItemQuantity = null,
                    IncreasedItemRarity = null,
                    PackSize = null,
                    Elder = null,
                    Shaped = null,
                    Blighted = null,
                    Series = null
                },
                ExpectedJson = "{}",
                Description = "Null"
            },
            new ModelToJsonTestCase<MapsFilter>
            {
                Subject = new MapsFilter
                {
                    Tier = new FilterMagnitude {Min = 1, Max = 2},
                    IncreasedItemQuantity = new FilterMagnitude {Min = 1, Max = 2},
                    IncreasedItemRarity = new FilterMagnitude {Min = 1, Max = 2},
                    PackSize = new FilterMagnitude {Min = 1, Max = 2},
                    Elder = new BooleanOption {Value = true},
                    Shaped = new BooleanOption {Value = false},
                    Blighted = new BooleanOption {Value = false},
                    Series = new StringOption {Value = "test"}
                },
                ExpectedJson = "{\"map_tier\":{\"min\":1,\"max\":2},\"map_iiq\":{\"min\":1,\"max\":2},\"map_packsize\":{\"min\":1,\"max\":2},\"map_iir\":{\"min\":1,\"max\":2},\"map_shaped\":{\"option\":false},\"map_blighted\":{\"option\":false},\"map_elder\":{\"option\":true},\"map_series\":{\"option\":\"test\"}}"
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_SerializeToJson(ModelToJsonTestCase<MapsFilter> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            string result = JsonSerializer.Serialize(testCase.Subject, new JsonSerializerOptions {IgnoreNullValues = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping});

            // Then
            result.Should().Be(testCase.ExpectedJson);
        }
    }
}