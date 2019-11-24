using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.PathOfExile.Models.Trade.Items;
using PoECommerce.PathOfExile.Tests.Utility;

namespace PoECommerce.PathOfExile.Tests.Models.JsonSerializationTest.Trade.Items
{
    [TestFixture]
    public class ModifierTest
    {
        public static ModelFromJsonTestCase<Modifier>[] TestCases =
        {
            new ModelFromJsonTestCase<Modifier>
            {
                Json = "{\"name\":null,\"tier\":null,\"magnitudes\":null}",
                ExpectedResult =
                    new Modifier
                    {
                        Name = null,
                        Tier = null,
                        Magnitudes = null
                    },
                Description = "All null"
            },
            new ModelFromJsonTestCase<Modifier>
            {
                Json = "{\"name\":\"Test\",\"tier\":null,\"magnitudes\":null}",
                ExpectedResult =
                    new Modifier
                    {
                        Name = "Test",
                        Tier = null,
                        Magnitudes = null
                    },
                Description = "With name"
            },
            new ModelFromJsonTestCase<Modifier>
            {
                Json = "{\"name\":\"Test\",\"tier\":null,\"magnitudes\":[]}",
                ExpectedResult =
                    new Modifier
                    {
                        Name = "Test",
                        Tier = null,
                        Magnitudes = new Magnitude[0]
                    },
                Description = "With name and empty magnitudes"
            },
            new ModelFromJsonTestCase<Modifier>
            {
                Json = "{\"name\":null,\"tier\":null,\"magnitudes\":[{\"hash\":\"explicit.stat_3299347043\",\"min\":50,\"max\":50}]}",
                ExpectedResult =
                    new Modifier
                    {
                        Name = null,
                        Tier = null,
                        Magnitudes = new[]
                        {
                            new Magnitude
                            {
                                Hash = "explicit.stat_3299347043",
                                Min = 50,
                                Max = 50
                            }
                        }
                    },
                Description = "With single magnitude"
            },
            new ModelFromJsonTestCase<Modifier>
            {
                Json = "{\"name\":null,\"tier\":null,\"magnitudes\":[{\"hash\":\"explicit.stat_3299347043\",\"min\":50,\"max\":50},{\"hash\":\"explicit.stat_8949347123\",\"min\":10,\"max\":100}]}",
                ExpectedResult =
                    new Modifier
                    {
                        Name = null,
                        Tier = null,
                        Magnitudes = new[]
                        {
                            new Magnitude
                            {
                                Hash = "explicit.stat_3299347043",
                                Min = 50,
                                Max = 50
                            },
                            new Magnitude
                            {
                                Hash = "explicit.stat_8949347123",
                                Min = 10,
                                Max = 100
                            }
                        }
                    },
                Description = "With multiple magnitudes"
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