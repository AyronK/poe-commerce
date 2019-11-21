using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.TradeService.Models.Enums;
using PoECommerce.TradeService.Models.TradeAPI.Items;
using PoECommerce.TradeService.Models.TradeAPI.Items.Enums;

namespace PoECommerce.TradeService.Tests.Models.JsonSerializationTest.TradeAPI.Items
{
    [TestFixture]
    public class PropertyTest
    {
        public static ModelFromJsonTestCase<Property>[] TestCases =
        {
            new ModelFromJsonTestCase<Property>
            {
                Json = "{\"name\":\"Two Handed Sword\",\"values\":null,\"displayMode\":1}",
                ExpectedResult =
                    new Property
                    {
                        Name = "Two Handed Sword",
                        Values = null,
                        DisplayMode = PropertyDisplayMode.SingleValue,
                        Order = null,
                        Progress = null
                    },
                Description = "Without values"
            },
            new ModelFromJsonTestCase<Property>
            {
                Json = "{\"name\":\"Two Handed Sword\",\"values\":null,\"displayMode\":1,\"progress\":5}",
                ExpectedResult =
                    new Property
                    {
                        Name = "Two Handed Sword",
                        Values = null,
                        DisplayMode = PropertyDisplayMode.SingleValue,
                        Order = null,
                        Progress = 5
                    },
                Description = "Without values but with progress"
            },
            new ModelFromJsonTestCase<Property>
            {
                Json = "{\"name\":\"Quality\",\"values\":[[\"+9%\",1]],\"displayMode\":0,\"type\":6}",
                ExpectedResult =
                    new Property
                    {
                        Name = "Quality",
                        Values = new[]
                        {
                            new PropertyValue
                            {
                                Format = TextFormat.Augmented,
                                Value = "+9%"
                            }
                        },
                        DisplayMode = PropertyDisplayMode.MultipleValues,
                        Order = 6,
                        Progress = null
                    },
                Description = "With single value"
            },
            new ModelFromJsonTestCase<Property>
            {
                Json = "{\"name\":\"Custom\",\"values\":[[\"+9%\",1],[\"10-120\",6]],\"displayMode\":2,\"type\":10}",
                ExpectedResult =
                    new Property
                    {
                        Name = "Custom",
                        Values = new[]
                        {
                            new PropertyValue
                            {
                                Format = TextFormat.Augmented,
                                Value = "+9%"
                            },
                            new PropertyValue
                            {
                                Format = TextFormat.LightningDamage,
                                Value = "10-120"
                            }
                        },
                        DisplayMode = PropertyDisplayMode.ProgressBar,
                        Order = 10,
                        Progress = null
                    },
                Description = "With multiple values"
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_DeserializeFromJson(ModelFromJsonTestCase<Property> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            Property result = JsonSerializer.Deserialize<Property>(testCase.Json);

            // Then
            result.Should().BeEquivalentTo(testCase.ExpectedResult);
        }
    }
}