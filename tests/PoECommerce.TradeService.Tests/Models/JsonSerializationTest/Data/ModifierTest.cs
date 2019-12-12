using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.PathOfExile.Models.Data;
using PoECommerce.PathOfExile.Models.Enums;
using PoECommerce.PathOfExile.Tests.Utility;

namespace PoECommerce.PathOfExile.Tests.Models.JsonSerializationTest.Data
{
    [TestFixture]
    public class ModifierTest
    {
        public static ModelFromJsonTestCase<Modifier>[] TestCases =
        {
            new ModelFromJsonTestCase<Modifier>
            {
                Json = "{\"type\":\"delve\"}",
                ExpectedResult =
                    new Modifier
                    {
                        Id = null,
                        Text = null,
                        Type = ModifierType.Delve
                    },
                Description = "Only type"
            },
            new ModelFromJsonTestCase<Modifier>
            {
                Json = "{\"id\":\"mod1\",\"text\":\"Modifier 1\",\"type\":\"enchant\"}",
                ExpectedResult =
                    new Modifier
                    {
                        Id = "mod1",
                        Text = "Modifier 1",
                        Type = ModifierType.Enchant
                    },
                Description = "With values"
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_DeserializeFromJson(ModelFromJsonTestCase<Modifier> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            Modifier result = JsonSerializer.Deserialize<Modifier>(testCase.Json);

            // Then
            result.Should().BeEquivalentTo(testCase.ExpectedResult);
        }
    }
}