using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.PathOfExile.Models.Data;
using PoECommerce.PathOfExile.Models.Enums;
using PoECommerce.PathOfExile.Tests.Utility;

namespace PoECommerce.PathOfExile.Tests.Models.JsonSerializationTest.Data
{
    [TestFixture]
    internal class ModifiersDataResultTest
    {
        public static ModelFromJsonTestCase<ModifiersDataResult>[] TestCases =
        {
            new ModelFromJsonTestCase<ModifiersDataResult>
            {
                Json = "{\"entries\":[],\"label\":\"explicit\"}",
                ExpectedResult =
                    new ModifiersDataResult
                    {
                        Modifiers = new Modifier[0],
                        ModifierType = ModifierType.Explicit
                    },
                Description = "Empty items"
            },
            new ModelFromJsonTestCase<ModifiersDataResult>
            {
                Json = "{\"entries\":[{\"id\":\"mod1\",\"text\":\"Modifier 1\",\"type\":\"enchant\"}],\"label\":\"implicit\"}",
                ExpectedResult =
                    new ModifiersDataResult
                    {
                        Modifiers = new[]
                        {
                            new Modifier
                            {
                                Id = "mod1",
                                Text = "Modifier 1",
                                Type = ModifierType.Enchant
                            }
                        },
                        ModifierType = ModifierType.Implicit
                    },
                Description = "Empty items"
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_DeserializeFromJson(ModelFromJsonTestCase<ModifiersDataResult> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            ModifiersDataResult result = JsonSerializer.Deserialize<ModifiersDataResult>(testCase.Json);

            // Then
            result.Should().BeEquivalentTo(testCase.ExpectedResult);
        }
    }
}