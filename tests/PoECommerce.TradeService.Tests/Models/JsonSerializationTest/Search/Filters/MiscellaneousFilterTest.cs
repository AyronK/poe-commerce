using System.Text.Encodings.Web;
using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.TradeService.Models.Search.Filters;
using PoECommerce.TradeService.Models.Search.Filters.Wrappers;
using PoECommerce.TradeService.Tests.Utility;

namespace PoECommerce.TradeService.Tests.Models.JsonSerializationTest.Search.Filters
{
    [TestFixture]
    public class MiscellaneousFilterTest
    {
        public static ModelToJsonTestCase<MiscellaneousFilter>[] TestCases =
        {
            new ModelToJsonTestCase<MiscellaneousFilter>
            {
                Subject = new MiscellaneousFilter
                {
                    Quality = null,
                    GemLevel = null,
                    ItemLevel = null,
                    GemLevelProgress = null,
                    Shaper = null,
                    Fractured = null,
                    AlternateArt = null,
                    Corrupted = null,
                    Crafted = null,
                    Enchanted = null,
                    Elder = null,
                    Synthesised = null,
                    Identified = null,
                    Mirrored = null,
                    Veiled = null,
                    TalismanTier = null
                },
                ExpectedJson = "{}",
                Description = "Null"
            },
            new ModelToJsonTestCase<MiscellaneousFilter>
            {
                Subject = new MiscellaneousFilter
                {
                    Quality = new FilterMagnitude {Min = 1, Max = 2},
                    GemLevel = new FilterMagnitude {Min = 1, Max = 2},
                    ItemLevel = new FilterMagnitude {Min = 1, Max = 2},
                    GemLevelProgress = new FilterMagnitude {Min = 1, Max = 2},
                    Shaper = new BooleanOption {Value = true},
                    Fractured = new BooleanOption {Value = true},
                    AlternateArt = new BooleanOption {Value = true},
                    Corrupted = new BooleanOption {Value = true},
                    Crafted = new BooleanOption {Value = true},
                    Enchanted = new BooleanOption {Value = true},
                    Elder = new BooleanOption {Value = true},
                    Synthesised = new BooleanOption {Value = true},
                    Identified = new BooleanOption {Value = true},
                    Mirrored = new BooleanOption {Value = true},
                    Veiled = new BooleanOption {Value = true},
                    TalismanTier = new FilterMagnitude {Min = 1, Max = 2}
                },
                ExpectedJson = "{\"quality\":{\"min\":1,\"max\":2},\"gem_level\":{\"min\":1,\"max\":2},\"ilvl\":{\"min\":1,\"max\":2},\"gem_level_progress\":{\"min\":1,\"max\":2},\"shaper_item\":{\"option\":true},\"fractured_item\":{\"option\":true},\"alternate_art\":{\"option\":true},\"corrupted\":{\"option\":true},\"crafted\":{\"option\":true},\"enchanted\":{\"option\":true},\"elder_item\":{\"option\":true},\"synthesised_item\":{\"option\":true},\"identified\":{\"option\":true},\"mirrored\":{\"option\":true},\"veiled\":{\"option\":true},\"talisman_tier\":{\"min\":1,\"max\":2}}"
            }
        };
        
        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_SerializeToJson(ModelToJsonTestCase<MiscellaneousFilter> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            string result = JsonSerializer.Serialize(testCase.Subject, new JsonSerializerOptions {IgnoreNullValues = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping});

            // Then
            result.Should().Be(testCase.ExpectedJson);
        }
    }
}