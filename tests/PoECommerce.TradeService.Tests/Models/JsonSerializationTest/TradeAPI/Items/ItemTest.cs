using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.TradeService.Models.Enums;
using PoECommerce.TradeService.Models.TradeAPI.Items;
using PoECommerce.TradeService.Models.TradeAPI.Items.Enums;

namespace PoECommerce.TradeService.Tests.Models.JsonSerializationTest.TradeAPI.Items
{
    [TestFixture]
    public partial class ItemTest
    {
        public static ModelFromJsonTestCase<Item>[] TestCases =
        {
            new ModelFromJsonTestCase<Item>
            {
                Json = "{}",
                ExpectedResult =
                    new Item
                    {
                        IsVerified = false,
                        Width = 0,
                        Height = 0,
                        ItemLevel = 0,
                        Icon = null,
                        League = null,
                        IsElder = false,
                        IsShaper = false,
                        IsFractured = false,
                        IsSupportGem = false,
                        Sockets = null,
                        Name = null,
                        TypeName = null,
                        IsIdentified = false,
                        IsCorrupted = false,
                        Note = null,
                        Properties = null,
                        AdditionalProperties = null,
                        Requirements = null,
                        UtilityMods = null,
                        ExplicitMods = null,
                        CraftedMods = null,
                        EnchantMods = null,
                        FracturedMods = null,
                        FlavourText = null,
                        FrameType = FrameType.Normal,
                        IsRelic = false,
                        Extended = null,
                        DescriptionText = null,
                        SecondaryDescriptionText = null,
                        StackSize = null,
                        MaxStackSize = null,
                        ProphecyText = null,
                        ArtFilename = null,
                        IsDelve = false,
                        IncubatedItem = null,
                        PseudoMods = null
                    },
                Description = "All nulls"
            },
            new ModelFromJsonTestCase<Item>
            {
                Json = "{\"verified\":true,\"w\":1,\"h\":2,\"ilvl\":83,\"league\":\"Delve\",\"name\":\"\",\"typeLine\":\"Explosive Trap\",\"identified\":true,\"frameType\":4}",
                ExpectedResult =
                    new Item
                    {
                        IsVerified = true,
                        Width = 1,
                        Height = 2,
                        ItemLevel = 83,
                        League = "Delve",
                        Name = "",
                        TypeName = "Explosive Trap",
                        IsIdentified = true,
                        FrameType = FrameType.Gem
                    },
                Description = "With must have properties"
            },
            new ModelFromJsonTestCase<Item>
            {
                Json = "{\"verified\":true,\"elder\":true,\"shaper\":true,\"fractured\":true,\"support\":true,\"identified\":true,\"corrupted\":true,\"isRelic\":true,\"delve\":true}",
                ExpectedResult =
                    new Item
                    {
                        IsVerified = true,
                        IsElder = true,
                        IsShaper = true,
                        IsFractured = true,
                        IsSupportGem = true,
                        IsIdentified = true,
                        IsCorrupted = true,
                        IsRelic = true,
                        IsDelve = true
                    },
                Description = "All booleans set true"
            },
            new ModelFromJsonTestCase<Item>
            {
                Json = "{\"w\":1,\"h\":2,\"ilvl\":3,\"stackSize\":4,\"maxStackSize\":5,\"frameType\":6}",
                ExpectedResult =
                    new Item
                    {
                        Width = 1,
                        Height = 2,
                        ItemLevel = 3,
                        FrameType = FrameType.DivinationCard,
                        StackSize = 4,
                        MaxStackSize = 5
                    },
                Description = "All integers set"
            },
            new ModelFromJsonTestCase<Item>
            {
                Json = "{\"icon\":\"iconTest\",\"league\":\"leagueTest\",\"name\":\"nameTest\",\"typeLine\":\"typeTest\",\"note\":\"noteTest\",\"descrText\":\"descTest\",\"secDescrText\":\"secDescTest\",\"prophecyText\":\"prophecyTest\",\"artFilename\":\"artTest\"}",
                ExpectedResult =
                    new Item
                    {
                        Icon = "iconTest",
                        League = "leagueTest",
                        Name = "nameTest",
                        TypeName = "typeTest",
                        Note = "noteTest",
                        DescriptionText = "descTest",
                        SecondaryDescriptionText = "secDescTest",
                        ProphecyText = "prophecyTest",
                        ArtFilename = "artTest"
                    },
                Description = "All strings set"
            },
            new ModelFromJsonTestCase<Item>
            {
                Json = "{\"sockets\":[{\"group\":2,\"attr\":\"S\",\"sColour\":\"R\"}]}",
                ExpectedResult =
                    new Item
                    {
                        Sockets = new[]
                        {
                            new Socket
                            {
                                Group = 2,
                                Attribute = Attribute.Strength,
                                Colour = SocketColour.Red
                            }
                        }
                    },
                Description = "With sockets"
            },
            new ModelFromJsonTestCase<Item>
            {
                Json = "{\"properties\":[{\"name\":\"Two Handed Sword\",\"values\":null,\"displayMode\":1,\"progress\":5}]}",
                ExpectedResult =
                    new Item
                    {
                        Properties = new[]
                        {
                            new Property
                            {
                                Name = "Two Handed Sword",
                                Values = null,
                                DisplayMode = PropertyDisplayMode.SingleValue,
                                Order = null,
                                Progress = 5
                            }
                        }
                    },
                Description = "With properties"
            },
            new ModelFromJsonTestCase<Item>
            {
                Json = "{\"additionalProperties\":[{\"name\":\"Two Handed Sword\",\"values\":null,\"displayMode\":1,\"progress\":5}]}",
                ExpectedResult =
                    new Item
                    {
                        AdditionalProperties = new[]
                        {
                            new Property
                            {
                                Name = "Two Handed Sword",
                                Values = null,
                                DisplayMode = PropertyDisplayMode.SingleValue,
                                Order = null,
                                Progress = 5
                            }
                        }
                    },
                Description = "With additional properties"
            },
            new ModelFromJsonTestCase<Item>
            {
                Json = "{\"requirements\":[{\"name\":\"Two Handed Sword\",\"values\":null,\"displayMode\":1,\"progress\":5}]}",
                ExpectedResult =
                    new Item
                    {
                        Requirements = new[]
                        {
                            new Property
                            {
                                Name = "Two Handed Sword",
                                Values = null,
                                DisplayMode = PropertyDisplayMode.SingleValue,
                                Order = null,
                                Progress = 5
                            }
                        }
                    },
                Description = "With requirements"
            },
            new ModelFromJsonTestCase<Item>
            {
                Json = "{\"utilityMods\":[\"mod1\",\"mod2\"]}",
                ExpectedResult =
                    new Item
                    {
                        UtilityMods = new[] {"mod1", "mod2"}
                    },
                Description = "With utility mods"
            },
            new ModelFromJsonTestCase<Item>
            {
                Json = "{\"explicitMods\":[\"mod1\",\"mod2\"]}",
                ExpectedResult =
                    new Item
                    {
                        ExplicitMods = new[] {"mod1", "mod2"}
                    },
                Description = "With explicit mods"
            },
            new ModelFromJsonTestCase<Item>
            {
                Json = "{\"craftedMods\":[\"mod1\",\"mod2\"]}",
                ExpectedResult =
                    new Item
                    {
                        CraftedMods = new[] {"mod1", "mod2"}
                    },
                Description = "With crafted mods"
            },
            new ModelFromJsonTestCase<Item>
            {
                Json = "{\"fracturedMods\":[\"mod1\",\"mod2\"]}",
                ExpectedResult =
                    new Item
                    {
                        FracturedMods = new[] {"mod1", "mod2"}
                    },
                Description = "With fractured mods"
            },
            new ModelFromJsonTestCase<Item>
            {
                Json = "{\"enchantMods\":[\"mod1\",\"mod2\"]}",
                ExpectedResult =
                    new Item
                    {
                        EnchantMods = new[] {"mod1", "mod2"}
                    },
                Description = "With enchant mods"
            },
            new ModelFromJsonTestCase<Item>
            {
                Json = "{\"pseudoMods\":[\"mod1\",\"mod2\"]}",
                ExpectedResult =
                    new Item
                    {
                        PseudoMods = new[] {"mod1", "mod2"}
                    },
                Description = "With pseudo mods"
            },
            new ModelFromJsonTestCase<Item>
            {
                Json = "{\"flavourText\":[\"line1\",\"line2\"]}",
                ExpectedResult =
                    new Item
                    {
                        FlavourText = new[] {"line1", "line2"}
                    },
                Description = "With flavour text"
            },
            new ModelFromJsonTestCase<Item>
            {
                Json = "{\"incubatedItem\":{\"name\":\"test\",\"total\":100,\"progress\":90,\"level\":83}}",
                ExpectedResult =
                    new Item
                    {
                        IncubatedItem =
                            new IncubatedItem
                            {
                                Name = "test",
                                Total = 100,
                                Progress = 90,
                                Level = 83
                            }
                    },
                Description = "With incubated item"
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_DeserializeFromJson(ModelFromJsonTestCase<Item> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            Item result = JsonSerializer.Deserialize<Item>(testCase.Json);

            // Then
            result.Should().BeEquivalentTo(testCase.ExpectedResult);
        }
    }
}