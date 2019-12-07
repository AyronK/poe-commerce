using System.Collections.Generic;
using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.PathOfExile.Models.Enums;
using PoECommerce.PathOfExile.Models.Trade.Items;
using PoECommerce.PathOfExile.Tests.Utility;

namespace PoECommerce.PathOfExile.Tests.Models.JsonSerializationTest.Trade.Items
{
    [TestFixture]
    public class ExtendedMetadataTest
    {
        public static ModelFromJsonTestCase<ExtendedMetadata>[] TestCases =
        {
            new ModelFromJsonTestCase<ExtendedMetadata>
            {
                Json = "{}",
                ExpectedResult =
                    new ExtendedMetadata
                    {
                        Modifiers = null,
                        Hashes = null,
                        DpS = null,
                        IsDpSAugmented = null,
                        PDpS = null,
                        IsPDpSAugmented = null,
                        EDpS = null,
                        Text = null,
                        Armour = null,
                        IsArmourAugmented = null,
                        EnergyShield = null,
                        IsEnergyShieldAugmented = null,
                        Evasion = null,
                        IsEvasionAugmented = null
                    },
                Description = "All nulls"
            },
            new ModelFromJsonTestCase<ExtendedMetadata>
            {
                Json = "{\"dps\":100.5,\"dps_aug\":true,\"pdps\":40.9,\"pdps_aug\":true,\"edps\":60.6}",
                ExpectedResult =
                    new ExtendedMetadata
                    {
                        Modifiers = null,
                        Hashes = null,
                        DpS = 100.5f,
                        IsDpSAugmented = true,
                        PDpS = 40.9f,
                        IsPDpSAugmented = true,
                        EDpS = 60.6f,
                        Text = null,
                        Armour = null,
                        IsArmourAugmented = null,
                        EnergyShield = null,
                        IsEnergyShieldAugmented = null,
                        Evasion = null,
                        IsEvasionAugmented = null
                    },
                Description = "Correct dps numbers and booleans"
            },
            new ModelFromJsonTestCase<ExtendedMetadata>
            {
                Json = "{\"ar\":200,\"ar_aug\":false,\"ev\":300,\"ev_aug\":false,\"es\":400,\"es_aug\":false}",
                ExpectedResult =
                    new ExtendedMetadata
                    {
                        Modifiers = null,
                        Hashes = null,
                        DpS = null,
                        IsDpSAugmented = null,
                        PDpS = null,
                        IsPDpSAugmented = null,
                        EDpS = null,
                        Text = null,
                        Armour = 200,
                        IsArmourAugmented = false,
                        EnergyShield = 400,
                        IsEnergyShieldAugmented = false,
                        Evasion = 300,
                        IsEvasionAugmented = false
                    },
                Description = "Correct armour numbers and booleans"
            },
            new ModelFromJsonTestCase<ExtendedMetadata>
            {
                Json = "{\"mods\":{\"explicit\":[]},\"hashes\":{\"crafted\":[]}}",
                ExpectedResult =
                    new ExtendedMetadata
                    {
                        Modifiers = new Dictionary<ModifierType, Modifier[]> {{ModifierType.Explicit, new Modifier[0]}},
                        Hashes = new Dictionary<ModifierType, Hash[]> {{ModifierType.Crafted, new Hash[0]}},
                        DpS = null,
                        IsDpSAugmented = null,
                        PDpS = null,
                        IsPDpSAugmented = null,
                        EDpS = null,
                        Text = null,
                        Armour = null,
                        IsArmourAugmented = null,
                        EnergyShield = null,
                        IsEnergyShieldAugmented = null,
                        Evasion = null,
                        IsEvasionAugmented = null
                    },
                Description = "With single modifier and hash"
            },
            new ModelFromJsonTestCase<ExtendedMetadata>
            {
                Json = "{\"mods\":{\"pseudo\":[],\"implicit\":[]},\"hashes\":{\"enchant\":[],\"delve\":[]}}",
                ExpectedResult =
                    new ExtendedMetadata
                    {
                        Modifiers = new Dictionary<ModifierType, Modifier[]>
                        {
                            {ModifierType.Pseudo, new Modifier[0]},
                            {ModifierType.Implicit, new Modifier[0]}
                        },
                        Hashes = new Dictionary<ModifierType, Hash[]>
                        {
                            {ModifierType.Enchant, new Hash[0]},
                            {ModifierType.Delve, new Hash[0]}
                        },
                        DpS = null,
                        IsDpSAugmented = null,
                        PDpS = null,
                        IsPDpSAugmented = null,
                        EDpS = null,
                        Text = null,
                        Armour = null,
                        IsArmourAugmented = null,
                        EnergyShield = null,
                        IsEnergyShieldAugmented = null,
                        Evasion = null,
                        IsEvasionAugmented = null
                    },
                Description = "With multiple modifiers and hashes"
            },
            new ModelFromJsonTestCase<ExtendedMetadata>
            {
                Json = "{\"mods\":{\"explicit\":[{\"name\":\"Test\",\"tier\":null,\"magnitudes\":[]}]},\"hashes\":{\"crafted\":[[\"explicit.stat_1509134228\",[2]]]}}",
                ExpectedResult =
                    new ExtendedMetadata
                    {
                        Modifiers = new Dictionary<ModifierType, Modifier[]>
                        {
                            {
                                ModifierType.Explicit,
                                new[]
                                {
                                    new Modifier
                                    {
                                        Name = "Test",
                                        Tier = null,
                                        Magnitudes = new Magnitude[0]
                                    }
                                }
                            }
                        },
                        Hashes = new Dictionary<ModifierType, Hash[]>
                        {
                            {
                                ModifierType.Crafted,
                                new[]
                                {
                                    new Hash {Id = "explicit.stat_1509134228", Values = new[] { 2 }}
                                }
                            }
                        },
                        DpS = null,
                        IsDpSAugmented = null,
                        PDpS = null,
                        IsPDpSAugmented = null,
                        EDpS = null,
                        Text = null,
                        Armour = null,
                        IsArmourAugmented = null,
                        EnergyShield = null,
                        IsEnergyShieldAugmented = null,
                        Evasion = null,
                        IsEvasionAugmented = null
                    },
                Description = "With single modifier and hash, both deeper"
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_DeserializeFromJson(ModelFromJsonTestCase<ExtendedMetadata> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            ExtendedMetadata result = JsonSerializer.Deserialize<ExtendedMetadata>(testCase.Json);

            // Then
            result.Should().BeEquivalentTo(testCase.ExpectedResult);
        }
    }
}