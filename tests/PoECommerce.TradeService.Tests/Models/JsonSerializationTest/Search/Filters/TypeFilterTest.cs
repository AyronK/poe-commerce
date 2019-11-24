using System.Text.Encodings.Web;
using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.PathOfExile.Models.Search.Enums;
using PoECommerce.PathOfExile.Models.Search.Filters;
using PoECommerce.PathOfExile.Models.Search.Filters.Wrappers;
using PoECommerce.PathOfExile.Tests.Utility;

namespace PoECommerce.PathOfExile.Tests.Models.JsonSerializationTest.Search.Filters
{
    [TestFixture]
    public class TypeFilterTest
    {
        public static ModelToJsonTestCase<TypeFilter>[] TestCases =
        {
            new ModelToJsonTestCase<TypeFilter>
            {
                Subject = new TypeFilter
                {
                    Category = null,
                    Rarity = null
                },
                ExpectedJson = "{}",
                Description = "Null"
            },
            new ModelToJsonTestCase<TypeFilter>
            {
                Subject = new TypeFilter
                {
                    Category = new StringOption {Value = "testCat"},
                    Rarity = new ItemRarityOption {Value = ItemRarity.Rare}
                },
                ExpectedJson = "{\"category\":{\"option\":\"testCat\"},\"rarity\":{\"option\":\"rare\"}}"
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_SerializeToJson(ModelToJsonTestCase<TypeFilter> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            string result = JsonSerializer.Serialize(testCase.Subject, new JsonSerializerOptions {IgnoreNullValues = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping});

            // Then
            result.Should().Be(testCase.ExpectedJson);
        }
    }
}