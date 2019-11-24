using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.PathOfExile.Models.Search;
using PoECommerce.PathOfExile.Models.Search.Enums;
using PoECommerce.PathOfExile.Models.Search.Filters;
using PoECommerce.PathOfExile.Models.Search.Filters.Wrappers;
using PoECommerce.PathOfExile.Tests.Utility;

namespace PoECommerce.PathOfExile.Tests.Models.JsonSerializationTest.Search
{
    public partial class QueryTest
    {
        public static ModelToJsonTestCase<Query>[] DeepTestCases =
        {
            new ModelToJsonTestCase<Query>
            {
                Subject = new Query
                {
                    Status = new OnlineStatusOption {Value = OnlineStatus.Online},
                    Name = "Ascent From Flesh",
                    Type = "Chain Belt",
                    ModifiersFilters = new[]
                    {
                        new ModifierGroupFilter
                        {
                            Operand = FilterOperand.And,
                            Filters = new[]
                            {
                                new ModifierFilter
                                {
                                    Id = "pseudo.pseudo_total_fire_resistance",
                                    Magnitude = new FilterMagnitude
                                    {
                                        Min = 49,
                                        Max = 50
                                    },
                                    Disabled = false
                                },
                                new ModifierFilter
                                {
                                    Id = "pseudo.pseudo_total_elemental_resistance",
                                    Magnitude = new FilterMagnitude
                                    {
                                        Min = 51,
                                        Max = 52
                                    },
                                    Disabled = false
                                }
                            }
                        }
                    },
                    Filter = new Filter
                    {
                        TypeFilter = new FilterWrapper<TypeFilter>
                        {
                            Filter = new TypeFilter
                            {
                                Category = new StringOption
                                {
                                    Value = "weapon.runedagger"
                                },
                                Rarity = new ItemRarityOption
                                {
                                    Value = ItemRarity.Rare
                                }
                            }
                        },
                        WeaponFilter = new FilterWrapper<WeaponsFilter>
                        {
                            Filter = new WeaponsFilter
                            {
                                Damage = new FilterMagnitude
                                {
                                    Min = 1,
                                    Max = 2
                                },
                                CriticalChance = new FilterMagnitude
                                {
                                    Min = 5,
                                    Max = 6
                                },
                                PhysicalDps = new FilterMagnitude
                                {
                                    Min = 9,
                                    Max = 10
                                },
                                AttacksPerSecond = new FilterMagnitude
                                {
                                    Min = 3,
                                    Max = 4
                                },
                                Dps = new FilterMagnitude
                                {
                                    Min = 7,
                                    Max = 8
                                },
                                ElementalDps = new FilterMagnitude
                                {
                                    Min = 11,
                                    Max = 12
                                }
                            },
                            Disabled = false
                        },
                        ArmourFilter = new FilterWrapper<ArmoursFilter>
                        {
                            Filter = new ArmoursFilter
                            {
                                Armour = new FilterMagnitude
                                {
                                    Min = 13,
                                    Max = 14
                                },
                                EnergyShield = new FilterMagnitude
                                {
                                    Min = 17,
                                    Max = 18
                                },
                                Evasion = new FilterMagnitude
                                {
                                    Min = 15,
                                    Max = 16
                                },
                                Block = new FilterMagnitude
                                {
                                    Min = 19,
                                    Max = 20
                                }
                            }
                        },
                        SocketFilter = new FilterWrapper<SocketsGroupFilter>
                        {
                            Filter = new SocketsGroupFilter
                            {
                                SocketsFilter = new SocketsFilter
                                {
                                    GreenMin = 2,
                                    RedMin = 1,
                                    BlueMin = 1,
                                    WhiteMin = 2,
                                    AnyMin = 5,
                                    AnyMax = 6
                                },
                                LinksFilter = new SocketsFilter
                                {
                                    GreenMin = 2,
                                    RedMin = 1,
                                    BlueMin = 1,
                                    WhiteMin = 2,
                                    AnyMin = 4,
                                    AnyMax = 5
                                }
                            }
                        },
                        RequirementsFilter = new FilterWrapper<RequirementsFilter>
                        {
                            Filter = new RequirementsFilter
                            {
                                Level = new FilterMagnitude
                                {
                                    Min = 20,
                                    Max = 22
                                },
                                Dexterity = new FilterMagnitude
                                {
                                    Min = 25,
                                    Max = 26
                                },
                                Strength = new FilterMagnitude
                                {
                                    Min = 23,
                                    Max = 24
                                },
                                Intelligence = new FilterMagnitude
                                {
                                    Min = 27,
                                    Max = 28
                                }
                            }
                        },
                        MiscellaneousFilter = new FilterWrapper<MiscellaneousFilter>
                        {
                            Filter = new MiscellaneousFilter
                            {
                                Quality = new FilterMagnitude
                                {
                                    Min = 37,
                                    Max = 38
                                },
                                GemLevel = new FilterMagnitude
                                {
                                    Min = 41,
                                    Max = 42
                                },
                                ItemLevel = new FilterMagnitude
                                {
                                    Min = 39,
                                    Max = 40
                                },
                                GemLevelProgress = new FilterMagnitude
                                {
                                    Min = 43,
                                    Max = 44
                                },
                                TalismanTier = new FilterMagnitude
                                {
                                    Min = 45,
                                    Max = 46
                                },
                                Shaper = new BooleanOption
                                {
                                    Value = true
                                },
                                Fractured = new BooleanOption
                                {
                                    Value = false
                                },
                                AlternateArt = new BooleanOption
                                {
                                    Value = true
                                },
                                Corrupted = new BooleanOption
                                {
                                    Value = false
                                },
                                Crafted = new BooleanOption
                                {
                                    Value = true
                                },
                                Enchanted = new BooleanOption
                                {
                                    Value = false
                                },
                                Elder = new BooleanOption
                                {
                                    Value = true
                                },
                                Synthesised = new BooleanOption
                                {
                                    Value = false
                                },
                                Identified = new BooleanOption
                                {
                                    Value = true
                                },
                                Mirrored = new BooleanOption
                                {
                                    Value = false
                                },
                                Veiled = new BooleanOption
                                {
                                    Value = true
                                }
                            }
                        },
                        MapsFilter = new FilterWrapper<MapsFilter>
                        {
                            Disabled = false,
                            Filter = new MapsFilter
                            {
                                Tier = new FilterMagnitude
                                {
                                    Min = 29,
                                    Max = 30
                                },
                                IncreasedItemQuantity = new FilterMagnitude
                                {
                                    Min = 33,
                                    Max = 34
                                },
                                PackSize = new FilterMagnitude
                                {
                                    Min = 31,
                                    Max = 32
                                },
                                IncreasedItemRarity = new FilterMagnitude
                                {
                                    Min = 35,
                                    Max = 36
                                },
                                Shaped = new BooleanOption
                                {
                                    Value = false
                                },
                                Blighted = new BooleanOption
                                {
                                    Value = true
                                },
                                Elder = new BooleanOption
                                {
                                    Value = true
                                },
                                Series = new StringOption
                                {
                                    Value = "synthesis"
                                }
                            }
                        },
                        TradeFilter = new FilterWrapper<TradeFilter>
                        {
                            Disabled = false,
                            Filter = new TradeFilter
                            {
                                Account = new Account
                                {
                                    Name = "123123"
                                },
                                Indexed = new IndexedOption
                                {
                                    Value = Indexed.TwoMonths
                                },
                                SaleType = new SaleTypeOption
                                {
                                    Value = SaleType.NotPriced
                                },
                                Price = new Price
                                {
                                    Currency = "chaos",
                                    Min = 47,
                                    Max = 48
                                }
                            }
                        }
                    }
                },
                ExpectedJson = "{\"status\":{\"option\":\"online\"},\"name\":\"Ascent From Flesh\",\"type\":\"Chain Belt\",\"stats\":[{\"type\":\"and\",\"filters\":[{\"id\":\"pseudo.pseudo_total_fire_resistance\",\"value\":{\"min\":49,\"max\":50},\"disabled\":false},{\"id\":\"pseudo.pseudo_total_elemental_resistance\",\"value\":{\"min\":51,\"max\":52},\"disabled\":false}]}],\"filters\":{\"type_filters\":{\"filters\":{\"category\":{\"option\":\"weapon.runedagger\"},\"rarity\":{\"option\":\"rare\"}}},\"weapon_filters\":{\"disabled\":false,\"filters\":{\"damage\":{\"min\":1,\"max\":2},\"crit\":{\"min\":5,\"max\":6},\"pdps\":{\"min\":9,\"max\":10},\"aps\":{\"min\":3,\"max\":4},\"dps\":{\"min\":7,\"max\":8},\"edps\":{\"min\":11,\"max\":12}}},\"armour_filters\":{\"filters\":{\"ar\":{\"min\":13,\"max\":14},\"es\":{\"min\":17,\"max\":18},\"ev\":{\"min\":15,\"max\":16},\"block\":{\"min\":19,\"max\":20}}},\"socket_filters\":{\"filters\":{\"sockets\":{\"g\":2,\"r\":1,\"b\":1,\"w\":2,\"min\":5,\"max\":6},\"links\":{\"g\":2,\"r\":1,\"b\":1,\"w\":2,\"min\":4,\"max\":5}}},\"req_filters\":{\"filters\":{\"lvl\":{\"min\":20,\"max\":22},\"dex\":{\"min\":25,\"max\":26},\"str\":{\"min\":23,\"max\":24},\"int\":{\"min\":27,\"max\":28}}},\"misc_filters\":{\"filters\":{\"quality\":{\"min\":37,\"max\":38},\"gem_level\":{\"min\":41,\"max\":42},\"ilvl\":{\"min\":39,\"max\":40},\"gem_level_progress\":{\"min\":43,\"max\":44},\"shaper_item\":{\"option\":true},\"fractured_item\":{\"option\":false},\"alternate_art\":{\"option\":true},\"corrupted\":{\"option\":false},\"crafted\":{\"option\":true},\"enchanted\":{\"option\":false},\"elder_item\":{\"option\":true},\"synthesised_item\":{\"option\":false},\"identified\":{\"option\":true},\"mirrored\":{\"option\":false},\"veiled\":{\"option\":true},\"talisman_tier\":{\"min\":45,\"max\":46}}},\"map_filters\":{\"disabled\":false,\"filters\":{\"map_tier\":{\"min\":29,\"max\":30},\"map_iiq\":{\"min\":33,\"max\":34},\"map_packsize\":{\"min\":31,\"max\":32},\"map_iir\":{\"min\":35,\"max\":36},\"map_shaped\":{\"option\":false},\"map_blighted\":{\"option\":true},\"map_elder\":{\"option\":true},\"map_series\":{\"option\":\"synthesis\"}}},\"trade_filters\":{\"disabled\":false,\"filters\":{\"account\":{\"input\":\"123123\"},\"indexed\":{\"option\":\"2months\"},\"sale_type\":{\"option\":\"unpriced\"},\"price\":{\"option\":\"chaos\",\"min\":47,\"max\":48}}}}}",
                Description = "Request using all filters at once with one AND modifiers filter group"
            }
        };

        [Test]
        [TestCaseSource(nameof(DeepTestCases))]
        public void When_SerializeTomJson_DeepExamples(ModelToJsonTestCase<Query> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            string result = JsonSerializer.Serialize(testCase.Subject, new JsonSerializerOptions {IgnoreNullValues = true});

            // Then
            result.Should().Be(testCase.ExpectedJson);
        }
    }
}