using System.Collections.Generic;
using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.PathOfExile.Models.Enums;
using PoECommerce.PathOfExile.Models.Trade.Enums;
using PoECommerce.PathOfExile.Models.Trade.Items;
using PoECommerce.PathOfExile.Models.Trade.Items.Enums;
using PoECommerce.PathOfExile.Tests.Utility;

namespace PoECommerce.PathOfExile.Tests.Models.JsonSerializationTest.Trade.Items
{
    public partial class ItemTest
    {
        public static ModelFromJsonTestCase<Item>[] DeepTestCases =
        {
            new ModelFromJsonTestCase<Item>
            {
                Json = "{\"verified\":true,\"w\":1,\"h\":1,\"ilvl\":0,\"icon\":\"https://web.poecdn.com/image/Art/2DItems/Divination/InventoryIcon.png?scale=1&w=1&h=1&v=a8ae131b97fad3c64de0e6d9f250d743\",\"league\":\"Blight\",\"name\":\"\",\"typeLine\":\"Lucky Connections\",\"identified\":true,\"note\":\"~price 1 chaos\",\"properties\":[{\"name\":\"Stack Size\",\"values\":[[\"1/7\",0]],\"displayMode\":0}],\"explicitMods\":[\"<currencyitem>{20x Orb of Fusing}\"],\"flavourText\":[\"Luck is a fool's game, and I know plenty of rich fools.\"],\"frameType\":6,\"stackSize\":1,\"maxStackSize\":7,\"artFilename\":\"LuckyConnections\",\"extended\":{\"text\":\"UmFyaXR5OiBEaXZpbmF0aW9uIENhcmQNCkx1Y2t5IENvbm5lY3Rpb25zDQotLS0tLS0tLQ0KU3RhY2sgU2l6ZTogMS83DQotLS0tLS0tLQ0KezIweCBPcmIgb2YgRnVzaW5nfQ0KLS0tLS0tLS0NCkx1Y2sgaXMgYSBmb29sJ3MgZ2FtZSwgYW5kIEkga25vdyBwbGVudHkgb2YgcmljaCBmb29scy4NCi0tLS0tLS0tDQpOb3RlOiB+cHJpY2UgMSBjaGFvcw0K\"}}",
                ExpectedResult =
                    new Item
                    {
                        IsVerified = true,
                        Width = 1,
                        Height = 1,
                        ItemLevel = 0,
                        Icon = "https://web.poecdn.com/image/Art/2DItems/Divination/InventoryIcon.png?scale=1&w=1&h=1&v=a8ae131b97fad3c64de0e6d9f250d743",
                        League = "Blight",
                        Name = "",
                        TypeName = "Lucky Connections",
                        IsIdentified = true,
                        Note = "~price 1 chaos",
                        Properties = new[]
                        {
                            new Property
                            {
                                Name = "Stack Size",
                                Values = new[]
                                {
                                    new PropertyValue
                                    {
                                        Value = "1/7",
                                        Format = TextFormat.Simple
                                    }
                                },
                                DisplayMode = PropertyDisplayMode.MultipleValues
                            }
                        },
                        ExplicitMods = new[] {"<currencyitem>{20x Orb of Fusing}"},
                        FlavourText = new[] {"Luck is a fool's game, and I know plenty of rich fools."},
                        FrameType = FrameType.DivinationCard,
                        StackSize = 1,
                        MaxStackSize = 7,
                        ArtFilename = "LuckyConnections",
                        Extended = new ExtendedMetadata
                        {
                            Text = "UmFyaXR5OiBEaXZpbmF0aW9uIENhcmQNCkx1Y2t5IENvbm5lY3Rpb25zDQotLS0tLS0tLQ0KU3RhY2sgU2l6ZTogMS83DQotLS0tLS0tLQ0KezIweCBPcmIgb2YgRnVzaW5nfQ0KLS0tLS0tLS0NCkx1Y2sgaXMgYSBmb29sJ3MgZ2FtZSwgYW5kIEkga25vdyBwbGVudHkgb2YgcmljaCBmb29scy4NCi0tLS0tLS0tDQpOb3RlOiB+cHJpY2UgMSBjaGFvcw0K"
                        }
                    },
                Description = "Lucky Connections Divination Card"
            },
            new ModelFromJsonTestCase<Item>
            {
                Json = "{\"verified\":true,\"w\":1,\"h\":1,\"ilvl\":0,\"icon\":\"https://web.poecdn.com/image/Art/2DItems/Gems/FlickerStrike.png?scale=1&w=1&h=1&v=0ba77898693022c02b2c51d5382e3f75\",\"support\":false,\"league\":\"Blight\",\"name\":\"\",\"typeLine\":\"Flicker Strike\",\"identified\":true,\"properties\":[{\"name\":\"Attack, Melee, Strike, Movement, Duration\",\"values\":[],\"displayMode\":0},{\"name\":\"Level\",\"values\":[[\"1\",0]],\"displayMode\":0,\"type\":5},{\"name\":\"Mana Cost\",\"values\":[[\"10\",0]],\"displayMode\":0},{\"name\":\"Cooldown Time\",\"values\":[[\"2.00 sec\",0]],\"displayMode\":0},{\"name\":\"Attack Speed\",\"values\":[[\"120% of base\",0]],\"displayMode\":0},{\"name\":\"Effectiveness of Added Damage\",\"values\":[[\"142%\",0]],\"displayMode\":0},{\"name\":\"Quality\",\"values\":[[\"+7%\",1]],\"displayMode\":0,\"type\":6}],\"additionalProperties\":[{\"name\":\"Experience\",\"values\":[[\"1/9569\",0]],\"displayMode\":2,\"progress\":0.00010450412810314447,\"type\":20}],\"requirements\":[{\"name\":\"Level\",\"values\":[[\"10\",0]],\"displayMode\":0},{\"name\":\"Dex\",\"values\":[[\"29\",0]],\"displayMode\":1}],\"secDescrText\":\"Teleports the character to a nearby monster and attacks with a melee weapon. If no specific monster is targeted, one is picked at random. Grants a buff that increases movement speed for a duration. The cooldown can be bypassed by expending a Frenzy Charge.\",\"explicitMods\":[\"Deals 142.2% of Base Damage\",\"Base duration is 3.00 seconds\",\"10% increased Attack Speed per Frenzy Charge\",\"16% chance to gain a Frenzy Charge on Hit\",\"Buff grants 20% increased Movement Speed\"],\"descrText\":\"Place into an item socket of the right colour to gain this skill. Right click to remove from a socket.\",\"frameType\":4,\"extended\":{\"text\":\"UmFyaXR5OiBHZW0NCkZsaWNrZXIgU3RyaWtlDQotLS0tLS0tLQ0KQXR0YWNrLCBNZWxlZSwgU3RyaWtlLCBNb3ZlbWVudCwgRHVyYXRpb24NCkxldmVsOiAxDQpNYW5hIENvc3Q6IDEwDQpDb29sZG93biBUaW1lOiAyLjAwIHNlYw0KQXR0YWNrIFNwZWVkOiAxMjAlIG9mIGJhc2UNCkVmZmVjdGl2ZW5lc3Mgb2YgQWRkZWQgRGFtYWdlOiAxNDIlDQpRdWFsaXR5OiArNyUgKGF1Z21lbnRlZCkNCkV4cGVyaWVuY2U6IDEvOTU2OQ0KLS0tLS0tLS0NClJlcXVpcmVtZW50czoNCkxldmVsOiAxMA0KRGV4OiAyOQ0KLS0tLS0tLS0NClRlbGVwb3J0cyB0aGUgY2hhcmFjdGVyIHRvIGEgbmVhcmJ5IG1vbnN0ZXIgYW5kIGF0dGFja3Mgd2l0aCBhIG1lbGVlIHdlYXBvbi4gSWYgbm8gc3BlY2lmaWMgbW9uc3RlciBpcyB0YXJnZXRlZCwgb25lIGlzIHBpY2tlZCBhdCByYW5kb20uIEdyYW50cyBhIGJ1ZmYgdGhhdCBpbmNyZWFzZXMgbW92ZW1lbnQgc3BlZWQgZm9yIGEgZHVyYXRpb24uIFRoZSBjb29sZG93biBjYW4gYmUgYnlwYXNzZWQgYnkgZXhwZW5kaW5nIGEgRnJlbnp5IENoYXJnZS4NCi0tLS0tLS0tDQpEZWFscyAxNDIuMiUgb2YgQmFzZSBEYW1hZ2UNCkJhc2UgZHVyYXRpb24gaXMgMy4wMCBzZWNvbmRzDQoxMCUgaW5jcmVhc2VkIEF0dGFjayBTcGVlZCBwZXIgRnJlbnp5IENoYXJnZQ0KMTYlIGNoYW5jZSB0byBnYWluIGEgRnJlbnp5IENoYXJnZSBvbiBIaXQNCkJ1ZmYgZ3JhbnRzIDIwJSBpbmNyZWFzZWQgTW92ZW1lbnQgU3BlZWQNCi0tLS0tLS0tDQpQbGFjZSBpbnRvIGFuIGl0ZW0gc29ja2V0IG9mIHRoZSByaWdodCBjb2xvdXIgdG8gZ2FpbiB0aGlzIHNraWxsLiBSaWdodCBjbGljayB0byByZW1vdmUgZnJvbSBhIHNvY2tldC4NCg==\"}}",
                ExpectedResult =
                    new Item
                    {
                        IsVerified = true,
                        Width = 1,
                        Height = 1,
                        ItemLevel = 0,
                        Icon = "https://web.poecdn.com/image/Art/2DItems/Gems/FlickerStrike.png?scale=1&w=1&h=1&v=0ba77898693022c02b2c51d5382e3f75",
                        IsSupportGem = false,
                        League = "Blight",
                        Name = "",
                        TypeName = "Flicker Strike",
                        IsIdentified = true,
                        Properties = new[]
                        {
                            new Property
                            {
                                Name = "Attack, Melee, Strike, Movement, Duration",
                                Values = new PropertyValue[0],
                                DisplayMode = PropertyDisplayMode.MultipleValues
                            },
                            new Property
                            {
                                Name = "Level",
                                Values = new[] {new PropertyValue {Value = "1", Format = TextFormat.Simple}},
                                DisplayMode = PropertyDisplayMode.MultipleValues,
                                Order = 5
                            },
                            new Property
                            {
                                Name = "Mana Cost",
                                Values = new[] {new PropertyValue {Value = "10", Format = TextFormat.Simple}},
                                DisplayMode = PropertyDisplayMode.MultipleValues
                            },
                            new Property
                            {
                                Name = "Cooldown Time",
                                Values = new[] {new PropertyValue {Value = "2.00 sec", Format = TextFormat.Simple}},
                                DisplayMode = PropertyDisplayMode.MultipleValues
                            },
                            new Property
                            {
                                Name = "Attack Speed",
                                Values = new[] {new PropertyValue {Value = "120% of base", Format = TextFormat.Simple}},
                                DisplayMode = PropertyDisplayMode.MultipleValues
                            },
                            new Property
                            {
                                Name = "Effectiveness of Added Damage",
                                Values = new[] {new PropertyValue {Value = "142%", Format = TextFormat.Simple}},
                                DisplayMode = PropertyDisplayMode.MultipleValues
                            },
                            new Property
                            {
                                Name = "Quality",
                                Values = new[] {new PropertyValue {Value = "+7%", Format = TextFormat.Augmented}},
                                DisplayMode = PropertyDisplayMode.MultipleValues,
                                Order = 6
                            }
                        },
                        AdditionalProperties = new[]
                        {
                            new Property
                            {
                                Name = "Experience",
                                Values = new[] {new PropertyValue {Value = "1/9569", Format = TextFormat.Simple}},
                                DisplayMode = PropertyDisplayMode.ProgressBar,
                                Progress = 0.00010450412810314447f,
                                Order = 20
                            }
                        },
                        Requirements = new[]
                        {
                            new Property
                            {
                                Name = "Level",
                                Values = new[] {new PropertyValue {Value = "10", Format = TextFormat.Simple}},
                                DisplayMode = PropertyDisplayMode.MultipleValues
                            },
                            new Property
                            {
                                Name = "Dex",
                                Values = new[] {new PropertyValue {Value = "29", Format = TextFormat.Simple}},
                                DisplayMode = PropertyDisplayMode.SingleValue
                            }
                        },
                        ExplicitMods = new[]
                        {
                            "Deals 142.2% of Base Damage",
                            "Base duration is 3.00 seconds",
                            "10% increased Attack Speed per Frenzy Charge",
                            "16% chance to gain a Frenzy Charge on Hit",
                            "Buff grants 20% increased Movement Speed"
                        },
                        FrameType = FrameType.Gem,
                        DescriptionText = "Place into an item socket of the right colour to gain this skill. Right click to remove from a socket.",
                        SecondaryDescriptionText = "Teleports the character to a nearby monster and attacks with a melee weapon. If no specific monster is targeted, one is picked at random. Grants a buff that increases movement speed for a duration. The cooldown can be bypassed by expending a Frenzy Charge.",

                        Extended = new ExtendedMetadata
                        {
                            Text = "UmFyaXR5OiBHZW0NCkZsaWNrZXIgU3RyaWtlDQotLS0tLS0tLQ0KQXR0YWNrLCBNZWxlZSwgU3RyaWtlLCBNb3ZlbWVudCwgRHVyYXRpb24NCkxldmVsOiAxDQpNYW5hIENvc3Q6IDEwDQpDb29sZG93biBUaW1lOiAyLjAwIHNlYw0KQXR0YWNrIFNwZWVkOiAxMjAlIG9mIGJhc2UNCkVmZmVjdGl2ZW5lc3Mgb2YgQWRkZWQgRGFtYWdlOiAxNDIlDQpRdWFsaXR5OiArNyUgKGF1Z21lbnRlZCkNCkV4cGVyaWVuY2U6IDEvOTU2OQ0KLS0tLS0tLS0NClJlcXVpcmVtZW50czoNCkxldmVsOiAxMA0KRGV4OiAyOQ0KLS0tLS0tLS0NClRlbGVwb3J0cyB0aGUgY2hhcmFjdGVyIHRvIGEgbmVhcmJ5IG1vbnN0ZXIgYW5kIGF0dGFja3Mgd2l0aCBhIG1lbGVlIHdlYXBvbi4gSWYgbm8gc3BlY2lmaWMgbW9uc3RlciBpcyB0YXJnZXRlZCwgb25lIGlzIHBpY2tlZCBhdCByYW5kb20uIEdyYW50cyBhIGJ1ZmYgdGhhdCBpbmNyZWFzZXMgbW92ZW1lbnQgc3BlZWQgZm9yIGEgZHVyYXRpb24uIFRoZSBjb29sZG93biBjYW4gYmUgYnlwYXNzZWQgYnkgZXhwZW5kaW5nIGEgRnJlbnp5IENoYXJnZS4NCi0tLS0tLS0tDQpEZWFscyAxNDIuMiUgb2YgQmFzZSBEYW1hZ2UNCkJhc2UgZHVyYXRpb24gaXMgMy4wMCBzZWNvbmRzDQoxMCUgaW5jcmVhc2VkIEF0dGFjayBTcGVlZCBwZXIgRnJlbnp5IENoYXJnZQ0KMTYlIGNoYW5jZSB0byBnYWluIGEgRnJlbnp5IENoYXJnZSBvbiBIaXQNCkJ1ZmYgZ3JhbnRzIDIwJSBpbmNyZWFzZWQgTW92ZW1lbnQgU3BlZWQNCi0tLS0tLS0tDQpQbGFjZSBpbnRvIGFuIGl0ZW0gc29ja2V0IG9mIHRoZSByaWdodCBjb2xvdXIgdG8gZ2FpbiB0aGlzIHNraWxsLiBSaWdodCBjbGljayB0byByZW1vdmUgZnJvbSBhIHNvY2tldC4NCg=="
                        }
                    },
                Description = "Flicker Strike Gem"
            },
            new ModelFromJsonTestCase<Item>
            {
                Json = "{\"verified\":true,\"w\":2,\"h\":4,\"ilvl\":80,\"icon\":\"https://web.poecdn.com/image/Art/2DItems/Weapons/TwoHandWeapons/TwoHandSwords/Starforge.png?scale=1&w=2&h=4&elder=1&v=0ccd07f328eefaaf0dfa139d1912457b\",\"league\":\"Blight\",\"elder\":true,\"sockets\":[{\"group\":0,\"attr\":\"D\",\"sColour\":\"G\"},{\"group\":0,\"attr\":\"S\",\"sColour\":\"R\"}],\"name\":\"Voidforge\",\"typeLine\":\"Infernal Sword\",\"identified\":true,\"properties\":[{\"name\":\"Two Handed Sword\",\"values\":[],\"displayMode\":0},{\"name\":\"Physical Damage\",\"values\":[[\"81-167\",1]],\"displayMode\":0,\"type\":9},{\"name\":\"Critical Strike Chance\",\"values\":[[\"5.00%\",0]],\"displayMode\":0,\"type\":12},{\"name\":\"Attacks per Second\",\"values\":[[\"1.43\",1]],\"displayMode\":0,\"type\":13},{\"name\":\"Weapon Range\",\"values\":[[\"13\",0]],\"displayMode\":0,\"type\":14}],\"requirements\":[{\"name\":\"Level\",\"values\":[[\"67\",0]],\"displayMode\":0},{\"name\":\"Str\",\"values\":[[\"113\",0]],\"displayMode\":1},{\"name\":\"Dex\",\"values\":[[\"113\",0]],\"displayMode\":1}],\"implicitMods\":[\"30% increased Global Accuracy Rating\"],\"explicitMods\":[\"55% increased Physical Damage\",\"6% increased Attack Speed\",\"+96 to maximum Life\",\"Your Elemental Damage can Shock\",\"Gain 300% of Weapon Physical Damage as Extra Damage of a random Element\",\"20% increased Area of Effect for Attacks\",\"Deal no Non-Elemental Damage\"],\"flavourText\":[\"A weapon born of nothingness,\\r\",\"can only create more nothingness.\"],\"frameType\":3,\"extended\":{\"dps\":200.29,\"pdps\":200.29,\"edps\":0,\"dps_aug\":true,\"pdps_aug\":true,\"mods\":{\"implicit\":[{\"name\":\"\",\"tier\":\"\",\"magnitudes\":[{\"hash\":\"implicit.stat_624954515\",\"min\":30,\"max\":30}]}],\"explicit\":[{\"name\":\"\",\"tier\":\"\",\"magnitudes\":[{\"hash\":\"explicit.stat_4031851097\",\"min\":1,\"max\":1}]},{\"name\":\"\",\"tier\":\"\",\"magnitudes\":[{\"hash\":\"explicit.stat_1038949719\",\"min\":300,\"max\":300}]},{\"name\":\"\",\"tier\":\"\",\"magnitudes\":[{\"hash\":\"explicit.stat_1509134228\",\"min\":50,\"max\":100}]},{\"name\":\"\",\"tier\":\"\",\"magnitudes\":[{\"hash\":\"explicit.stat_210067635\",\"min\":5,\"max\":8}]},{\"name\":\"\",\"tier\":\"\",\"magnitudes\":[{\"hash\":\"explicit.stat_2933625540\",\"min\":1,\"max\":1}]},{\"name\":\"\",\"tier\":\"\",\"magnitudes\":[{\"hash\":\"explicit.stat_1840985759\",\"min\":20,\"max\":20}]},{\"name\":\"\",\"tier\":\"\",\"magnitudes\":[{\"hash\":\"explicit.stat_3299347043\",\"min\":90,\"max\":100}]}]},\"hashes\":{\"implicit\":[[\"implicit.stat_624954515\",[0]]],\"explicit\":[[\"explicit.stat_1509134228\",[2]],[\"explicit.stat_210067635\",[3]],[\"explicit.stat_3299347043\",[6]],[\"explicit.stat_2933625540\",[4]],[\"explicit.stat_1038949719\",[1]],[\"explicit.stat_1840985759\",[5]],[\"explicit.stat_4031851097\",[0]]]},\"text\":\"UmFyaXR5OiBVbmlxdWUNClZvaWRmb3JnZQ0KSW5mZXJuYWwgU3dvcmQNCi0tLS0tLS0tDQpUd28gSGFuZGVkIFN3b3JkDQpQaHlzaWNhbCBEYW1hZ2U6IDgxLTE2NyAoYXVnbWVudGVkKQ0KQ3JpdGljYWwgU3RyaWtlIENoYW5jZTogNS4wMCUNCkF0dGFja3MgcGVyIFNlY29uZDogMS40MyAoYXVnbWVudGVkKQ0KV2VhcG9uIFJhbmdlOiAxMw0KLS0tLS0tLS0NClJlcXVpcmVtZW50czoNCkxldmVsOiA2Nw0KU3RyOiAxMTMNCkRleDogMTEzDQotLS0tLS0tLQ0KU29ja2V0czogRy1SIA0KLS0tLS0tLS0NCkl0ZW0gTGV2ZWw6IDgwDQotLS0tLS0tLQ0KMzAlIGluY3JlYXNlZCBHbG9iYWwgQWNjdXJhY3kgUmF0aW5nDQotLS0tLS0tLQ0KNTUlIGluY3JlYXNlZCBQaHlzaWNhbCBEYW1hZ2UNCjYlIGluY3JlYXNlZCBBdHRhY2sgU3BlZWQNCis5NiB0byBtYXhpbXVtIExpZmUNCllvdXIgRWxlbWVudGFsIERhbWFnZSBjYW4gU2hvY2sNCkdhaW4gMzAwJSBvZiBXZWFwb24gUGh5c2ljYWwgRGFtYWdlIGFzIEV4dHJhIERhbWFnZSBvZiBhIHJhbmRvbSBFbGVtZW50DQoyMCUgaW5jcmVhc2VkIEFyZWEgb2YgRWZmZWN0IGZvciBBdHRhY2tzDQpEZWFsIG5vIE5vbi1FbGVtZW50YWwgRGFtYWdlDQotLS0tLS0tLQ0KQSB3ZWFwb24gYm9ybiBvZiBub3RoaW5nbmVzcywNCmNhbiBvbmx5IGNyZWF0ZSBtb3JlIG5vdGhpbmduZXNzLg0KLS0tLS0tLS0NCkVsZGVyIEl0ZW0NCg==\"}}",
                ExpectedResult =
                    new Item
                    {
                        IsVerified = true,
                        Width = 2,
                        Height = 4,
                        ItemLevel = 80,
                        Icon = "https://web.poecdn.com/image/Art/2DItems/Weapons/TwoHandWeapons/TwoHandSwords/Starforge.png?scale=1&w=2&h=4&elder=1&v=0ccd07f328eefaaf0dfa139d1912457b",
                        IsElder = true,
                        League = "Blight",
                        Name = "Voidforge",
                        TypeName = "Infernal Sword",
                        IsIdentified = true,
                        Sockets = new[]
                        {
                            new Socket {Group = 0, Attribute = Attribute.Dexterity, Colour = SocketColour.Green},
                            new Socket {Group = 0, Attribute = Attribute.Strength, Colour = SocketColour.Red}
                        },
                        Properties = new[]
                        {
                            new Property
                            {
                                Name = "Two Handed Sword",
                                Values = new PropertyValue[0],
                                DisplayMode = PropertyDisplayMode.MultipleValues
                            },
                            new Property
                            {
                                Name = "Physical Damage",
                                Values = new[] {new PropertyValue {Value = "81-167", Format = TextFormat.Augmented}},
                                DisplayMode = PropertyDisplayMode.MultipleValues,
                                Order = 9
                            },
                            new Property
                            {
                                Name = "Critical Strike Chance",
                                Values = new[] {new PropertyValue {Value = "5.00%", Format = TextFormat.Simple}},
                                DisplayMode = PropertyDisplayMode.MultipleValues,
                                Order = 12
                            },
                            new Property
                            {
                                Name = "Attacks per Second",
                                Values = new[] {new PropertyValue {Value = "1.43", Format = TextFormat.Augmented}},
                                DisplayMode = PropertyDisplayMode.MultipleValues,
                                Order = 13
                            },
                            new Property
                            {
                                Name = "Weapon Range",
                                Values = new[] {new PropertyValue {Value = "13", Format = TextFormat.Simple}},
                                DisplayMode = PropertyDisplayMode.MultipleValues,
                                Order = 14
                            }
                        },
                        Requirements = new[]
                        {
                            new Property
                            {
                                Name = "Level",
                                Values = new[] {new PropertyValue {Value = "67", Format = TextFormat.Simple}},
                                DisplayMode = PropertyDisplayMode.MultipleValues
                            },
                            new Property
                            {
                                Name = "Str",
                                Values = new[] {new PropertyValue {Value = "113", Format = TextFormat.Simple}},
                                DisplayMode = PropertyDisplayMode.SingleValue
                            },
                            new Property
                            {
                                Name = "Dex",
                                Values = new[] {new PropertyValue {Value = "113", Format = TextFormat.Simple}},
                                DisplayMode = PropertyDisplayMode.SingleValue
                            }
                        },
                        ImplicitMods = new[]
                        {
                            "30% increased Global Accuracy Rating"
                        },
                        ExplicitMods = new[]
                        {
                            "55% increased Physical Damage",
                            "6% increased Attack Speed",
                            "+96 to maximum Life",
                            "Your Elemental Damage can Shock",
                            "Gain 300% of Weapon Physical Damage as Extra Damage of a random Element",
                            "20% increased Area of Effect for Attacks",
                            "Deal no Non-Elemental Damage"
                        },
                        FlavourText = new[]
                        {
                            "A weapon born of nothingness,\r",
                            "can only create more nothingness."
                        },
                        FrameType = FrameType.Unique,
                        Extended = new ExtendedMetadata
                        {
                            DpS = 200.29f,
                            PDpS = 200.29f,
                            EDpS = 0f,
                            IsDpSAugmented = true,
                            IsPDpSAugmented = true,
                            Modifiers = new Dictionary<ModifierType, Modifier[]>
                            {
                                {
                                    ModifierType.Implicit, new[]
                                    {
                                        new Modifier
                                        {
                                            Name = "",
                                            Tier = "",
                                            Magnitudes = new[]
                                            {
                                                new Magnitude
                                                {
                                                    Hash = "implicit.stat_624954515",
                                                    Min = 30,
                                                    Max = 30
                                                }
                                            }
                                        }
                                    }
                                },
                                {
                                    ModifierType.Explicit, new[]
                                    {
                                        new Modifier
                                        {
                                            Name = "",
                                            Tier = "",
                                            Magnitudes = new[]
                                            {
                                                new Magnitude
                                                {
                                                    Hash = "explicit.stat_4031851097",
                                                    Min = 1,
                                                    Max = 1
                                                }
                                            }
                                        },
                                        new Modifier
                                        {
                                            Name = "",
                                            Tier = "",
                                            Magnitudes = new[]
                                            {
                                                new Magnitude
                                                {
                                                    Hash = "explicit.stat_1038949719",
                                                    Min = 300,
                                                    Max = 300
                                                }
                                            }
                                        },
                                        new Modifier
                                        {
                                            Name = "",
                                            Tier = "",
                                            Magnitudes = new[]
                                            {
                                                new Magnitude
                                                {
                                                    Hash = "explicit.stat_1509134228",
                                                    Min = 50,
                                                    Max = 100
                                                }
                                            }
                                        },
                                        new Modifier
                                        {
                                            Name = "",
                                            Tier = "",
                                            Magnitudes = new[]
                                            {
                                                new Magnitude
                                                {
                                                    Hash = "explicit.stat_210067635",
                                                    Min = 5,
                                                    Max = 8
                                                }
                                            }
                                        },
                                        new Modifier
                                        {
                                            Name = "",
                                            Tier = "",
                                            Magnitudes = new[]
                                            {
                                                new Magnitude
                                                {
                                                    Hash = "explicit.stat_2933625540",
                                                    Min = 1,
                                                    Max = 1
                                                }
                                            }
                                        },
                                        new Modifier
                                        {
                                            Name = "",
                                            Tier = "",
                                            Magnitudes = new[]
                                            {
                                                new Magnitude
                                                {
                                                    Hash = "explicit.stat_1840985759",
                                                    Min = 20,
                                                    Max = 20
                                                }
                                            }
                                        },
                                        new Modifier
                                        {
                                            Name = "",
                                            Tier = "",
                                            Magnitudes = new[]
                                            {
                                                new Magnitude
                                                {
                                                    Hash = "explicit.stat_3299347043",
                                                    Min = 90,
                                                    Max = 100
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                            Hashes = new Dictionary<ModifierType, Hash[]>
                            {
                                {
                                    ModifierType.Implicit, new[]
                                    {
                                        new Hash
                                        {
                                            Id = "implicit.stat_624954515",
                                            Values = new[] { 0 }
                                        }
                                    }
                                },
                                {
                                    ModifierType.Explicit, new[]
                                    {
                                        new Hash
                                        {
                                            Id = "explicit.stat_1509134228",
                                            Values = new[] { 2 }
                                        },
                                        new Hash
                                        {
                                            Id = "explicit.stat_210067635",
                                            Values = new[] { 3 }
                                        },
                                        new Hash
                                        {
                                            Id = "explicit.stat_3299347043",
                                            Values = new[] { 6 }
                                        },
                                        new Hash
                                        {
                                            Id = "explicit.stat_2933625540",
                                            Values = new[] { 4 }
                                        },
                                        new Hash
                                        {
                                            Id = "explicit.stat_1038949719",
                                            Values = new[] { 1 }
                                        },
                                        new Hash
                                        {
                                            Id = "explicit.stat_1840985759",
                                            Values = new[] { 5 }
                                        },
                                        new Hash
                                        {
                                            Id = "explicit.stat_4031851097",
                                            Values = new[] { 0 }
                                        }
                                    }
                                }
                            },
                            Text = "UmFyaXR5OiBVbmlxdWUNClZvaWRmb3JnZQ0KSW5mZXJuYWwgU3dvcmQNCi0tLS0tLS0tDQpUd28gSGFuZGVkIFN3b3JkDQpQaHlzaWNhbCBEYW1hZ2U6IDgxLTE2NyAoYXVnbWVudGVkKQ0KQ3JpdGljYWwgU3RyaWtlIENoYW5jZTogNS4wMCUNCkF0dGFja3MgcGVyIFNlY29uZDogMS40MyAoYXVnbWVudGVkKQ0KV2VhcG9uIFJhbmdlOiAxMw0KLS0tLS0tLS0NClJlcXVpcmVtZW50czoNCkxldmVsOiA2Nw0KU3RyOiAxMTMNCkRleDogMTEzDQotLS0tLS0tLQ0KU29ja2V0czogRy1SIA0KLS0tLS0tLS0NCkl0ZW0gTGV2ZWw6IDgwDQotLS0tLS0tLQ0KMzAlIGluY3JlYXNlZCBHbG9iYWwgQWNjdXJhY3kgUmF0aW5nDQotLS0tLS0tLQ0KNTUlIGluY3JlYXNlZCBQaHlzaWNhbCBEYW1hZ2UNCjYlIGluY3JlYXNlZCBBdHRhY2sgU3BlZWQNCis5NiB0byBtYXhpbXVtIExpZmUNCllvdXIgRWxlbWVudGFsIERhbWFnZSBjYW4gU2hvY2sNCkdhaW4gMzAwJSBvZiBXZWFwb24gUGh5c2ljYWwgRGFtYWdlIGFzIEV4dHJhIERhbWFnZSBvZiBhIHJhbmRvbSBFbGVtZW50DQoyMCUgaW5jcmVhc2VkIEFyZWEgb2YgRWZmZWN0IGZvciBBdHRhY2tzDQpEZWFsIG5vIE5vbi1FbGVtZW50YWwgRGFtYWdlDQotLS0tLS0tLQ0KQSB3ZWFwb24gYm9ybiBvZiBub3RoaW5nbmVzcywNCmNhbiBvbmx5IGNyZWF0ZSBtb3JlIG5vdGhpbmduZXNzLg0KLS0tLS0tLS0NCkVsZGVyIEl0ZW0NCg=="
                        }
                    },
                Description = "Voidforge Unique Sword"
            },
            new ModelFromJsonTestCase<Item>
            {
                Json = "{\"verified\":true,\"w\":2,\"h\":2,\"ilvl\":81,\"icon\":\"https://web.poecdn.com/image/Art/2DItems/Armours/Helmets/HelmetStrInt8.png?scale=1&w=2&h=2&v=59807b6bf308473f389a97b37513c89e\",\"league\":\"Blight\",\"sockets\":[{\"group\":0,\"attr\":\"I\",\"sColour\":\"B\"},{\"group\":0,\"attr\":\"S\",\"sColour\":\"R\"},{\"group\":0,\"attr\":\"S\",\"sColour\":\"R\"},{\"group\":1,\"attr\":\"S\",\"sColour\":\"R\"}],\"name\":\"Entropy Guardian\",\"typeLine\":\"Magistrate Crown\",\"identified\":true,\"corrupted\":true,\"properties\":[{\"name\":\"Armour\",\"values\":[[\"160\",0]],\"displayMode\":0,\"type\":16},{\"name\":\"Energy Shield\",\"values\":[[\"31\",0]],\"displayMode\":0,\"type\":18}],\"requirements\":[{\"name\":\"Level\",\"values\":[[\"60\",0]],\"displayMode\":0},{\"name\":\"Str\",\"values\":[[\"64\",0]],\"displayMode\":1},{\"name\":\"Int\",\"values\":[[\"64\",0]],\"displayMode\":1}],\"implicitMods\":[\"32% increased Burning Damage\"],\"explicitMods\":[\"+2 to Level of Socketed Minion Gems\",\"+88 to maximum Life\",\"+64 to maximum Mana\",\"+13% to Cold Resistance\"],\"enchantMods\":[\"Tornado Shot fires an additional secondary Projectile\"],\"frameType\":2,\"extended\":{\"ar\":160,\"es\":31,\"mods\":{\"implicit\":[{\"name\":\"\",\"tier\":\"\",\"magnitudes\":[{\"hash\":\"implicit.stat_1175385867\",\"min\":30,\"max\":40}]}],\"enchant\":[{\"name\":\"Enchantment Tornado Shot Num Of Secondary Projectiles 2\",\"tier\":\"\",\"magnitudes\":[{\"hash\":\"enchant.stat_1580810115\",\"min\":1,\"max\":1}]}],\"explicit\":[{\"name\":\"Summoner's\",\"tier\":\"P2\",\"magnitudes\":[{\"hash\":\"explicit.stat_3604946673\",\"min\":2,\"max\":2}]},{\"name\":\"Athlete's\",\"tier\":\"P2\",\"magnitudes\":[{\"hash\":\"explicit.stat_3299347043\",\"min\":80,\"max\":89}]},{\"name\":\"Mazarine\",\"tier\":\"P3\",\"magnitudes\":[{\"hash\":\"explicit.stat_1050105434\",\"min\":60,\"max\":64}]},{\"name\":\"of the Seal\",\"tier\":\"S7\",\"magnitudes\":[{\"hash\":\"explicit.stat_4220027924\",\"min\":12,\"max\":17}]}]},\"hashes\":{\"implicit\":[[\"implicit.stat_1175385867\",[0]]],\"enchant\":[[\"enchant.stat_1580810115\",[0]]],\"explicit\":[[\"explicit.stat_3604946673\",[0]],[\"explicit.stat_3299347043\",[1]],[\"explicit.stat_1050105434\",[2]],[\"explicit.stat_4220027924\",[3]]]},\"text\":\"UmFyaXR5OiBSYXJlDQpFbnRyb3B5IEd1YXJkaWFuDQpNYWdpc3RyYXRlIENyb3duDQotLS0tLS0tLQ0KQXJtb3VyOiAxNjANCkVuZXJneSBTaGllbGQ6IDMxDQotLS0tLS0tLQ0KUmVxdWlyZW1lbnRzOg0KTGV2ZWw6IDYwDQpTdHI6IDY0DQpJbnQ6IDY0DQotLS0tLS0tLQ0KU29ja2V0czogQi1SLVIgUiANCi0tLS0tLS0tDQpJdGVtIExldmVsOiA4MQ0KLS0tLS0tLS0NClRvcm5hZG8gU2hvdCBmaXJlcyBhbiBhZGRpdGlvbmFsIHNlY29uZGFyeSBQcm9qZWN0aWxlDQotLS0tLS0tLQ0KMzIlIGluY3JlYXNlZCBCdXJuaW5nIERhbWFnZQ0KLS0tLS0tLS0NCisyIHRvIExldmVsIG9mIFNvY2tldGVkIE1pbmlvbiBHZW1zDQorODggdG8gbWF4aW11bSBMaWZlDQorNjQgdG8gbWF4aW11bSBNYW5hDQorMTMlIHRvIENvbGQgUmVzaXN0YW5jZQ0KLS0tLS0tLS0NCkNvcnJ1cHRlZA0K\"}}",
                ExpectedResult =
                    new Item
                    {
                        IsVerified = true,
                        Width = 2,
                        Height = 2,
                        ItemLevel = 81,
                        Icon = "https://web.poecdn.com/image/Art/2DItems/Armours/Helmets/HelmetStrInt8.png?scale=1&w=2&h=2&v=59807b6bf308473f389a97b37513c89e",
                        IsCorrupted = true,
                        League = "Blight",
                        Name = "Entropy Guardian",
                        TypeName = "Magistrate Crown",
                        IsIdentified = true,
                        Sockets = new[]
                        {
                            new Socket {Group = 0, Attribute = Attribute.Intelligence, Colour = SocketColour.Blue},
                            new Socket {Group = 0, Attribute = Attribute.Strength, Colour = SocketColour.Red},
                            new Socket {Group = 0, Attribute = Attribute.Strength, Colour = SocketColour.Red},
                            new Socket {Group = 1, Attribute = Attribute.Strength, Colour = SocketColour.Red}
                        },
                        Properties = new[]
                        {
                            new Property
                            {
                                Name = "Armour",
                                Values = new[] {new PropertyValue {Value = "160", Format = TextFormat.Simple}},
                                DisplayMode = PropertyDisplayMode.MultipleValues,
                                Order = 16
                            },
                            new Property
                            {
                                Name = "Energy Shield",
                                Values = new[] {new PropertyValue {Value = "31", Format = TextFormat.Simple}},
                                DisplayMode = PropertyDisplayMode.MultipleValues,
                                Order = 18
                            }
                        },
                        Requirements = new[]
                        {
                            new Property
                            {
                                Name = "Level",
                                Values = new[] {new PropertyValue {Value = "60", Format = TextFormat.Simple}},
                                DisplayMode = PropertyDisplayMode.MultipleValues
                            },
                            new Property
                            {
                                Name = "Str",
                                Values = new[] {new PropertyValue {Value = "64", Format = TextFormat.Simple}},
                                DisplayMode = PropertyDisplayMode.SingleValue
                            },
                            new Property
                            {
                                Name = "Int",
                                Values = new[] {new PropertyValue {Value = "64", Format = TextFormat.Simple}},
                                DisplayMode = PropertyDisplayMode.SingleValue
                            }
                        },
                        ImplicitMods = new[]
                        {
                            "32% increased Burning Damage"
                        },
                        ExplicitMods = new[]
                        {
                            "+2 to Level of Socketed Minion Gems",
                            "+88 to maximum Life",
                            "+64 to maximum Mana",
                            "+13% to Cold Resistance"
                        },
                        EnchantMods = new[]
                        {
                            "Tornado Shot fires an additional secondary Projectile"
                        },
                        FrameType = FrameType.Rare,
                        Extended = new ExtendedMetadata
                        {
                            Armour = 160,
                            EnergyShield = 31,
                            Modifiers = new Dictionary<ModifierType, Modifier[]>
                            {
                                {
                                    ModifierType.Implicit, new[]
                                    {
                                        new Modifier
                                        {
                                            Name = "",
                                            Tier = "",
                                            Magnitudes = new[]
                                            {
                                                new Magnitude
                                                {
                                                    Hash = "implicit.stat_1175385867",
                                                    Min = 30,
                                                    Max = 40
                                                }
                                            }
                                        }
                                    }
                                },
                                {
                                    ModifierType.Enchant, new[]
                                    {
                                        new Modifier
                                        {
                                            Name = "Enchantment Tornado Shot Num Of Secondary Projectiles 2",
                                            Tier = "",
                                            Magnitudes = new[]
                                            {
                                                new Magnitude
                                                {
                                                    Hash = "enchant.stat_1580810115",
                                                    Min = 1,
                                                    Max = 1
                                                }
                                            }
                                        }
                                    }
                                },
                                {
                                    ModifierType.Explicit, new[]
                                    {
                                        new Modifier
                                        {
                                            Name = "Summoner's",
                                            Tier = "P2",
                                            Magnitudes = new[]
                                            {
                                                new Magnitude
                                                {
                                                    Hash = "explicit.stat_3604946673",
                                                    Min = 2,
                                                    Max = 2
                                                }
                                            }
                                        },
                                        new Modifier
                                        {
                                            Name = "Athlete's",
                                            Tier = "P2",
                                            Magnitudes = new[]
                                            {
                                                new Magnitude
                                                {
                                                    Hash = "explicit.stat_3299347043",
                                                    Min = 80,
                                                    Max = 89
                                                }
                                            }
                                        },
                                        new Modifier
                                        {
                                            Name = "Mazarine",
                                            Tier = "P3",
                                            Magnitudes = new[]
                                            {
                                                new Magnitude
                                                {
                                                    Hash = "explicit.stat_1050105434",
                                                    Min = 60,
                                                    Max = 64
                                                }
                                            }
                                        },
                                        new Modifier
                                        {
                                            Name = "of the Seal",
                                            Tier = "S7",
                                            Magnitudes = new[]
                                            {
                                                new Magnitude
                                                {
                                                    Hash = "explicit.stat_4220027924",
                                                    Min = 12,
                                                    Max = 17
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                            Hashes = new Dictionary<ModifierType, Hash[]>
                            {
                                {
                                    ModifierType.Implicit, new[]
                                    {
                                        new Hash
                                        {
                                            Id = "implicit.stat_1175385867",
                                            Values = new[] { 0 }
                                        }
                                    }
                                },
                                {
                                    ModifierType.Enchant, new[]
                                    {
                                        new Hash
                                        {
                                            Id = "enchant.stat_1580810115",
                                            Values = new[] { 0 }
                                        }
                                    }
                                },
                                {
                                    ModifierType.Explicit, new[]
                                    {
                                        new Hash
                                        {
                                            Id = "explicit.stat_3604946673",
                                            Values = new[] { 0 }
                                        },
                                        new Hash
                                        {
                                            Id = "explicit.stat_3299347043",
                                            Values = new[] { 1 }
                                        },
                                        new Hash
                                        {
                                            Id = "explicit.stat_1050105434",
                                            Values = new[] { 2 }
                                        },
                                        new Hash
                                        {
                                            Id = "explicit.stat_4220027924",
                                            Values = new[] { 3 }
                                        }
                                    }
                                }
                            },
                            Text = "UmFyaXR5OiBSYXJlDQpFbnRyb3B5IEd1YXJkaWFuDQpNYWdpc3RyYXRlIENyb3duDQotLS0tLS0tLQ0KQXJtb3VyOiAxNjANCkVuZXJneSBTaGllbGQ6IDMxDQotLS0tLS0tLQ0KUmVxdWlyZW1lbnRzOg0KTGV2ZWw6IDYwDQpTdHI6IDY0DQpJbnQ6IDY0DQotLS0tLS0tLQ0KU29ja2V0czogQi1SLVIgUiANCi0tLS0tLS0tDQpJdGVtIExldmVsOiA4MQ0KLS0tLS0tLS0NClRvcm5hZG8gU2hvdCBmaXJlcyBhbiBhZGRpdGlvbmFsIHNlY29uZGFyeSBQcm9qZWN0aWxlDQotLS0tLS0tLQ0KMzIlIGluY3JlYXNlZCBCdXJuaW5nIERhbWFnZQ0KLS0tLS0tLS0NCisyIHRvIExldmVsIG9mIFNvY2tldGVkIE1pbmlvbiBHZW1zDQorODggdG8gbWF4aW11bSBMaWZlDQorNjQgdG8gbWF4aW11bSBNYW5hDQorMTMlIHRvIENvbGQgUmVzaXN0YW5jZQ0KLS0tLS0tLS0NCkNvcnJ1cHRlZA0K"
                        }
                    },
                Description = "Rare Helmet with Tornado Shot Enchantment"
            },
            new ModelFromJsonTestCase<Item>
            {
                Json = "{\"verified\":true,\"w\":1,\"h\":2,\"ilvl\":5,\"icon\":\"https://web.poecdn.com/gen/image/WzksNCx7ImYiOiJBcnRcLzJESXRlbXNcL0ZsYXNrc1wvbGlmZWZsYXNrMSIsInNwIjowLjYwODUsImxldmVsIjowfV0/f58edd1b16/Item.png\",\"league\":\"Blight\",\"name\":\"\",\"typeLine\":\"Saturated Small Life Flask of Steadiness\",\"identified\":true,\"properties\":[{\"name\":\"Recovers %0 Life over %1 Seconds\",\"values\":[[\"105\",1],[\"9.00\",1]],\"displayMode\":3},{\"name\":\"Consumes %0 of %1 Charges on use\",\"values\":[[\"7\",0],[\"21\",0]],\"displayMode\":3},{\"name\":\"Currently has %0 Charges\",\"values\":[[\"0\",0]],\"displayMode\":3}],\"explicitMods\":[\"50% increased Amount Recovered\",\"33% reduced Recovery rate\",\"55% increased Block and Stun Recovery during Flask effect\"],\"descrText\":\"Right click to drink. Can only hold charges while in belt. Refills as you kill monsters.\",\"frameType\":1,\"extended\":{\"mods\":{\"explicit\":[{\"name\":\"of Steadiness\",\"tier\":\"S1\",\"magnitudes\":[{\"hash\":\"explicit.stat_3479987487\",\"min\":40,\"max\":60}]},{\"name\":\"Saturated\",\"tier\":\"P1\",\"magnitudes\":[{\"hash\":\"explicit.stat_700317374\",\"min\":50,\"max\":50},{\"hash\":\"explicit.stat_173226756\",\"min\":-33,\"max\":-33}]}]},\"hashes\":{\"explicit\":[[\"explicit.stat_700317374\",[1]],[\"explicit.stat_173226756\",[1]],[\"explicit.stat_3479987487\",[0]]]},\"text\":\"UmFyaXR5OiBNYWdpYw0KU2F0dXJhdGVkIFNtYWxsIExpZmUgRmxhc2sgb2YgU3RlYWRpbmVzcw0KLS0tLS0tLS0NClJlY292ZXJzIDEwNSAoYXVnbWVudGVkKSBMaWZlIG92ZXIgOS4wMCAoYXVnbWVudGVkKSBTZWNvbmRzDQpDb25zdW1lcyA3IG9mIDIxIENoYXJnZXMgb24gdXNlDQpDdXJyZW50bHkgaGFzIDAgQ2hhcmdlcw0KLS0tLS0tLS0NCkl0ZW0gTGV2ZWw6IDUNCi0tLS0tLS0tDQo1MCUgaW5jcmVhc2VkIEFtb3VudCBSZWNvdmVyZWQNCjMzJSByZWR1Y2VkIFJlY292ZXJ5IHJhdGUNCjU1JSBpbmNyZWFzZWQgQmxvY2sgYW5kIFN0dW4gUmVjb3ZlcnkgZHVyaW5nIEZsYXNrIGVmZmVjdA0KLS0tLS0tLS0NClJpZ2h0IGNsaWNrIHRvIGRyaW5rLiBDYW4gb25seSBob2xkIGNoYXJnZXMgd2hpbGUgaW4gYmVsdC4gUmVmaWxscyBhcyB5b3Uga2lsbCBtb25zdGVycy4NCg==\"}}",
                ExpectedResult =
                    new Item
                    {
                        IsVerified = true,
                        Width = 1,
                        Height = 2,
                        ItemLevel = 5,
                        Icon = "https://web.poecdn.com/gen/image/WzksNCx7ImYiOiJBcnRcLzJESXRlbXNcL0ZsYXNrc1wvbGlmZWZsYXNrMSIsInNwIjowLjYwODUsImxldmVsIjowfV0/f58edd1b16/Item.png",
                        League = "Blight",
                        Name = "",
                        TypeName = "Saturated Small Life Flask of Steadiness",
                        IsIdentified = true,
                        Properties = new[]
                        {
                            new Property
                            {
                                Name = "Recovers %0 Life over %1 Seconds",
                                Values = new[]
                                {
                                    new PropertyValue {Value = "105", Format = TextFormat.Augmented},
                                    new PropertyValue {Value = "9.00", Format = TextFormat.Augmented}
                                },
                                DisplayMode = PropertyDisplayMode.Template
                            },
                            new Property
                            {
                                Name = "Consumes %0 of %1 Charges on use",
                                Values = new[]
                                {
                                    new PropertyValue {Value = "7", Format = TextFormat.Simple},
                                    new PropertyValue {Value = "21", Format = TextFormat.Simple}
                                },
                                DisplayMode = PropertyDisplayMode.Template
                            },
                            new Property
                            {
                                Name = "Currently has %0 Charges",
                                Values = new[]
                                {
                                    new PropertyValue {Value = "0", Format = TextFormat.Simple}
                                },
                                DisplayMode = PropertyDisplayMode.Template
                            }
                        },
                        ExplicitMods = new[]
                        {
                            "50% increased Amount Recovered",
                            "33% reduced Recovery rate",
                            "55% increased Block and Stun Recovery during Flask effect"
                        },
                        DescriptionText = "Right click to drink. Can only hold charges while in belt. Refills as you kill monsters.",
                        FrameType = FrameType.Magic,
                        Extended = new ExtendedMetadata
                        {
                            Modifiers = new Dictionary<ModifierType, Modifier[]>
                            {
                                {
                                    ModifierType.Explicit, new[]
                                    {
                                        new Modifier
                                        {
                                            Name = "of Steadiness",
                                            Tier = "S1",
                                            Magnitudes = new[]
                                            {
                                                new Magnitude
                                                {
                                                    Hash = "explicit.stat_3479987487",
                                                    Min = 40,
                                                    Max = 60
                                                }
                                            }
                                        },
                                        new Modifier
                                        {
                                            Name = "Saturated",
                                            Tier = "P1",
                                            Magnitudes = new[]
                                            {
                                                new Magnitude
                                                {
                                                    Hash = "explicit.stat_700317374",
                                                    Min = 50,
                                                    Max = 50
                                                },
                                                new Magnitude
                                                {
                                                    Hash = "explicit.stat_173226756",
                                                    Min = -33,
                                                    Max = -33
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                            Hashes = new Dictionary<ModifierType, Hash[]>
                            {
                                {
                                    ModifierType.Explicit, new[]
                                    {
                                        new Hash
                                        {
                                            Id = "explicit.stat_700317374",
                                            Values = new[] { 1 }
                                        },
                                        new Hash
                                        {
                                            Id = "explicit.stat_173226756",
                                            Values = new[] { 1 }
                                        },
                                        new Hash
                                        {
                                            Id = "explicit.stat_3479987487",
                                            Values = new[] { 0 }
                                        }
                                    }
                                }
                            },
                            Text = "UmFyaXR5OiBNYWdpYw0KU2F0dXJhdGVkIFNtYWxsIExpZmUgRmxhc2sgb2YgU3RlYWRpbmVzcw0KLS0tLS0tLS0NClJlY292ZXJzIDEwNSAoYXVnbWVudGVkKSBMaWZlIG92ZXIgOS4wMCAoYXVnbWVudGVkKSBTZWNvbmRzDQpDb25zdW1lcyA3IG9mIDIxIENoYXJnZXMgb24gdXNlDQpDdXJyZW50bHkgaGFzIDAgQ2hhcmdlcw0KLS0tLS0tLS0NCkl0ZW0gTGV2ZWw6IDUNCi0tLS0tLS0tDQo1MCUgaW5jcmVhc2VkIEFtb3VudCBSZWNvdmVyZWQNCjMzJSByZWR1Y2VkIFJlY292ZXJ5IHJhdGUNCjU1JSBpbmNyZWFzZWQgQmxvY2sgYW5kIFN0dW4gUmVjb3ZlcnkgZHVyaW5nIEZsYXNrIGVmZmVjdA0KLS0tLS0tLS0NClJpZ2h0IGNsaWNrIHRvIGRyaW5rLiBDYW4gb25seSBob2xkIGNoYXJnZXMgd2hpbGUgaW4gYmVsdC4gUmVmaWxscyBhcyB5b3Uga2lsbCBtb25zdGVycy4NCg=="
                        }
                    },
                Description = "Magic Life Flask"
            },
            new ModelFromJsonTestCase<Item>
            {
                Json = "{\"verified\":true,\"w\":1,\"h\":1,\"ilvl\":0,\"icon\":\"https://web.poecdn.com/image/Art/2DItems/Currency/CurrencyRerollRare.png?scale=1&w=1&h=1&v=c60aa876dd6bab31174df91b1da1b4f9\",\"league\":\"Blight\",\"name\":\"\",\"typeLine\":\"Chaos Orb\",\"identified\":true,\"note\":\"~price 2 chisel\",\"properties\":[{\"name\":\"Stack Size\",\"values\":[[\"1/10\",0]],\"displayMode\":0}],\"explicitMods\":[\"Reforges a rare item with new random modifiers\"],\"descrText\":\"Right click this item then left click a rare item to apply it.\",\"frameType\":5,\"stackSize\":1,\"maxStackSize\":10,\"extended\":{\"text\":\"UmFyaXR5OiBDdXJyZW5jeQ0KQ2hhb3MgT3JiDQotLS0tLS0tLQ0KU3RhY2sgU2l6ZTogMS8xMA0KLS0tLS0tLS0NClJlZm9yZ2VzIGEgcmFyZSBpdGVtIHdpdGggbmV3IHJhbmRvbSBtb2RpZmllcnMNCi0tLS0tLS0tDQpSaWdodCBjbGljayB0aGlzIGl0ZW0gdGhlbiBsZWZ0IGNsaWNrIGEgcmFyZSBpdGVtIHRvIGFwcGx5IGl0Lg0KLS0tLS0tLS0NCk5vdGU6IH5wcmljZSAyIGNoaXNlbA0K\"}}",
                ExpectedResult =
                    new Item
                    {
                        IsVerified = true,
                        Width = 1,
                        Height = 1,
                        ItemLevel = 0,
                        Icon = "https://web.poecdn.com/image/Art/2DItems/Currency/CurrencyRerollRare.png?scale=1&w=1&h=1&v=c60aa876dd6bab31174df91b1da1b4f9",
                        League = "Blight",
                        Name = "",
                        TypeName = "Chaos Orb",
                        IsIdentified = true,
                        Note = "~price 2 chisel",
                        Properties = new[]
                        {
                            new Property
                            {
                                Name = "Stack Size",
                                Values = new[]
                                {
                                    new PropertyValue
                                    {
                                        Value = "1/10",
                                        Format = TextFormat.Simple
                                    }
                                },
                                DisplayMode = PropertyDisplayMode.MultipleValues
                            }
                        },
                        ExplicitMods = new[] {"Reforges a rare item with new random modifiers"},
                        DescriptionText = "Right click this item then left click a rare item to apply it.",
                        FrameType = FrameType.Currency,
                        StackSize = 1,
                        MaxStackSize = 10,
                        Extended = new ExtendedMetadata
                        {
                            Text = "UmFyaXR5OiBDdXJyZW5jeQ0KQ2hhb3MgT3JiDQotLS0tLS0tLQ0KU3RhY2sgU2l6ZTogMS8xMA0KLS0tLS0tLS0NClJlZm9yZ2VzIGEgcmFyZSBpdGVtIHdpdGggbmV3IHJhbmRvbSBtb2RpZmllcnMNCi0tLS0tLS0tDQpSaWdodCBjbGljayB0aGlzIGl0ZW0gdGhlbiBsZWZ0IGNsaWNrIGEgcmFyZSBpdGVtIHRvIGFwcGx5IGl0Lg0KLS0tLS0tLS0NCk5vdGU6IH5wcmljZSAyIGNoaXNlbA0K"
                        }
                    },
                Description = "Chaos Orb"
            },
            new ModelFromJsonTestCase<Item>
            {
                Json = "{\"verified\":true,\"w\":1,\"h\":1,\"ilvl\":0,\"icon\":\"https://web.poecdn.com/image/Art/2DItems/Currency/ProphecyOrbRed.png?scale=1&w=1&h=1&v=dc9105d2b038a79c7c316fc2ba30cef0\",\"league\":\"Blight\",\"name\":\"\",\"typeLine\":\"Plague of Frogs\",\"identified\":true,\"descrText\":\"Right-click to add this prophecy to your character.\",\"flavourText\":[\"Wet and slippery flesh, clinging feet and tongue. No matter the colour before, now the earth is green.\"],\"prophecyText\":\"You will discover an outdoor location flooded with frogs.\",\"frameType\":8,\"extended\":{\"text\":\"UmFyaXR5OiBOb3JtYWwNClBsYWd1ZSBvZiBGcm9ncw0KLS0tLS0tLS0NCldldCBhbmQgc2xpcHBlcnkgZmxlc2gsIGNsaW5naW5nIGZlZXQgYW5kIHRvbmd1ZS4gTm8gbWF0dGVyIHRoZSBjb2xvdXIgYmVmb3JlLCBub3cgdGhlIGVhcnRoIGlzIGdyZWVuLg0KLS0tLS0tLS0NCllvdSB3aWxsIGRpc2NvdmVyIGFuIG91dGRvb3IgbG9jYXRpb24gZmxvb2RlZCB3aXRoIGZyb2dzLg0KLS0tLS0tLS0NClJpZ2h0LWNsaWNrIHRvIGFkZCB0aGlzIHByb3BoZWN5IHRvIHlvdXIgY2hhcmFjdGVyLg0K\"}}",
                ExpectedResult =
                    new Item
                    {
                        IsVerified = true,
                        Width = 1,
                        Height = 1,
                        ItemLevel = 0,
                        Icon = "https://web.poecdn.com/image/Art/2DItems/Currency/ProphecyOrbRed.png?scale=1&w=1&h=1&v=dc9105d2b038a79c7c316fc2ba30cef0",
                        League = "Blight",
                        Name = "",
                        TypeName = "Plague of Frogs",
                        IsIdentified = true,
                        DescriptionText = "Right-click to add this prophecy to your character.",
                        FlavourText = new[] {"Wet and slippery flesh, clinging feet and tongue. No matter the colour before, now the earth is green."},
                        FrameType = FrameType.Prophecy,
                        ProphecyText = "You will discover an outdoor location flooded with frogs.",
                        Extended = new ExtendedMetadata
                        {
                            Text = "UmFyaXR5OiBOb3JtYWwNClBsYWd1ZSBvZiBGcm9ncw0KLS0tLS0tLS0NCldldCBhbmQgc2xpcHBlcnkgZmxlc2gsIGNsaW5naW5nIGZlZXQgYW5kIHRvbmd1ZS4gTm8gbWF0dGVyIHRoZSBjb2xvdXIgYmVmb3JlLCBub3cgdGhlIGVhcnRoIGlzIGdyZWVuLg0KLS0tLS0tLS0NCllvdSB3aWxsIGRpc2NvdmVyIGFuIG91dGRvb3IgbG9jYXRpb24gZmxvb2RlZCB3aXRoIGZyb2dzLg0KLS0tLS0tLS0NClJpZ2h0LWNsaWNrIHRvIGFkZCB0aGlzIHByb3BoZWN5IHRvIHlvdXIgY2hhcmFjdGVyLg0K"
                        }
                    },
                Description = "Plague of Frogs Prophecy"
            },
            new ModelFromJsonTestCase<Item>
            {
                Json = "{\"verified\":true,\"w\":2,\"h\":1,\"ilvl\":76,\"icon\":\"https://web.poecdn.com/image/Art/2DItems/Belts/AbyssBelt.png?scale=1&w=2&h=1&v=cd7c25de181e6a77812020eb6e867971\",\"league\":\"Blight\",\"sockets\":[{\"group\":0,\"attr\":\"A\",\"sColour\":\"A\"}],\"name\":\"\",\"typeLine\":\"Stygian Vise\",\"identified\":true,\"note\":\"~price 1 chaos\",\"implicitMods\":[\"Has 1 Abyssal Socket\"],\"frameType\":0,\"extended\":{\"mods\":{\"implicit\":[{\"name\":\"\",\"tier\":\"\",\"magnitudes\":[{\"hash\":\"implicit.stat_3527617737\",\"min\":1,\"max\":1}]}]},\"hashes\":{\"implicit\":[[\"implicit.stat_3527617737\",[0]]]},\"text\":\"UmFyaXR5OiBOb3JtYWwNClN0eWdpYW4gVmlzZQ0KLS0tLS0tLS0NClNvY2tldHM6IEEgDQotLS0tLS0tLQ0KSXRlbSBMZXZlbDogNzYNCi0tLS0tLS0tDQpIYXMgMSBBYnlzc2FsIFNvY2tldA0KLS0tLS0tLS0NCk5vdGU6IH5wcmljZSAxIGNoYW9zDQo=\"}}",
                ExpectedResult =
                    new Item
                    {
                        IsVerified = true,
                        Width = 2,
                        Height = 1,
                        ItemLevel = 76,
                        Icon = "https://web.poecdn.com/image/Art/2DItems/Belts/AbyssBelt.png?scale=1&w=2&h=1&v=cd7c25de181e6a77812020eb6e867971",
                        League = "Blight",
                        Sockets = new[]
                        {
                            new Socket {Group = 0, Attribute = Attribute.Abyss, Colour = SocketColour.Abyss}
                        },
                        Note = "~price 1 chaos",
                        Name = "",
                        TypeName = "Stygian Vise",
                        IsIdentified = true,
                        ImplicitMods = new[]
                        {
                            "Has 1 Abyssal Socket"
                        },
                        FrameType = FrameType.Normal,
                        Extended = new ExtendedMetadata
                        {
                            Modifiers = new Dictionary<ModifierType, Modifier[]>
                            {
                                {
                                    ModifierType.Implicit, new[]
                                    {
                                        new Modifier
                                        {
                                            Name = "",
                                            Tier = "",
                                            Magnitudes = new[]
                                            {
                                                new Magnitude
                                                {
                                                    Hash = "implicit.stat_3527617737",
                                                    Min = 1,
                                                    Max = 1
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                            Hashes = new Dictionary<ModifierType, Hash[]>
                            {
                                {
                                    ModifierType.Implicit, new[]
                                    {
                                        new Hash
                                        {
                                            Id = "implicit.stat_3527617737",
                                            Values = new[] { 0 }
                                        }
                                    }
                                }
                            },
                            Text = "UmFyaXR5OiBOb3JtYWwNClN0eWdpYW4gVmlzZQ0KLS0tLS0tLS0NClNvY2tldHM6IEEgDQotLS0tLS0tLQ0KSXRlbSBMZXZlbDogNzYNCi0tLS0tLS0tDQpIYXMgMSBBYnlzc2FsIFNvY2tldA0KLS0tLS0tLS0NCk5vdGU6IH5wcmljZSAxIGNoYW9zDQo="
                        }
                    },
                Description = "White Stygian Belt with One Abyssal Socket"
            },
            new ModelFromJsonTestCase<Item>
            {
                Json = "{\"verified\":true,\"w\":1,\"h\":1,\"ilvl\":0,\"icon\":\"https://web.poecdn.com/image/Art/2DItems/Currency/Delve/Reroll1x1A.png?scale=1&w=1&h=1&v=e1d44f3d008b43923e17788a3964ea5a\",\"league\":\"Blight\",\"delve\":true,\"sockets\":[{\"group\":0,\"attr\":\"DV\",\"sColour\":\"DV\"}],\"name\":\"\",\"typeLine\":\"Primitive Chaotic Resonator\",\"identified\":true,\"properties\":[{\"name\":\"Stack Size\",\"values\":[[\"1/10\",0]],\"displayMode\":0},{\"name\":\"Requires <unmet>{1} Socketed Fossil\",\"values\":[],\"displayMode\":0}],\"explicitMods\":[\"Reforges a rare item with new random modifiers\"],\"descrText\":\"All sockets must be filled with Fossils before this item can be used.\",\"frameType\":5,\"stackSize\":1,\"maxStackSize\":10,\"extended\":{\"mods\":{\"delve\":[]},\"hashes\":{\"delve\":[]},\"text\":\"UmFyaXR5OiBDdXJyZW5jeQ0KUHJpbWl0aXZlIENoYW90aWMgUmVzb25hdG9yDQotLS0tLS0tLQ0KU3RhY2sgU2l6ZTogMS8xMA0KUmVxdWlyZXMgezF9IFNvY2tldGVkIEZvc3NpbA0KLS0tLS0tLS0NClNvY2tldHM6IEQgDQotLS0tLS0tLQ0KUmVmb3JnZXMgYSByYXJlIGl0ZW0gd2l0aCBuZXcgcmFuZG9tIG1vZGlmaWVycw0KLS0tLS0tLS0NCkFsbCBzb2NrZXRzIG11c3QgYmUgZmlsbGVkIHdpdGggRm9zc2lscyBiZWZvcmUgdGhpcyBpdGVtIGNhbiBiZSB1c2VkLg0K\"}}",
                ExpectedResult =
                    new Item
                    {
                        IsVerified = true,
                        Width = 1,
                        Height = 1,
                        ItemLevel = 0,
                        Icon = "https://web.poecdn.com/image/Art/2DItems/Currency/Delve/Reroll1x1A.png?scale=1&w=1&h=1&v=e1d44f3d008b43923e17788a3964ea5a",
                        IsDelve = true,
                        League = "Blight",
                        Name = "",
                        TypeName = "Primitive Chaotic Resonator",
                        IsIdentified = true,
                        Sockets = new[]
                        {
                            new Socket {Group = 0, Attribute = Attribute.Delve, Colour = SocketColour.Delve}
                        },
                        Properties = new[]
                        {
                            new Property
                            {
                                Name = "Stack Size",
                                Values = new[] {new PropertyValue {Value = "1/10", Format = TextFormat.Simple}},
                                DisplayMode = PropertyDisplayMode.MultipleValues
                            },
                            new Property
                            {
                                Name = "Requires <unmet>{1} Socketed Fossil",
                                Values = new PropertyValue[0],
                                DisplayMode = PropertyDisplayMode.MultipleValues
                            }
                        },
                        ExplicitMods = new[]
                        {
                            "Reforges a rare item with new random modifiers"
                        },
                        DescriptionText = "All sockets must be filled with Fossils before this item can be used.",
                        FrameType = FrameType.Currency,
                        StackSize = 1,
                        MaxStackSize = 10,
                        Extended = new ExtendedMetadata
                        {
                            Modifiers = new Dictionary<ModifierType, Modifier[]>
                            {
                                {
                                    ModifierType.Delve, new Modifier[0]
                                }
                            },
                            Hashes = new Dictionary<ModifierType, Hash[]>
                            {
                                {
                                    ModifierType.Delve, new Hash[0]
                                }
                            },
                            Text = "UmFyaXR5OiBDdXJyZW5jeQ0KUHJpbWl0aXZlIENoYW90aWMgUmVzb25hdG9yDQotLS0tLS0tLQ0KU3RhY2sgU2l6ZTogMS8xMA0KUmVxdWlyZXMgezF9IFNvY2tldGVkIEZvc3NpbA0KLS0tLS0tLS0NClNvY2tldHM6IEQgDQotLS0tLS0tLQ0KUmVmb3JnZXMgYSByYXJlIGl0ZW0gd2l0aCBuZXcgcmFuZG9tIG1vZGlmaWVycw0KLS0tLS0tLS0NCkFsbCBzb2NrZXRzIG11c3QgYmUgZmlsbGVkIHdpdGggRm9zc2lscyBiZWZvcmUgdGhpcyBpdGVtIGNhbiBiZSB1c2VkLg0K"
                        }
                    },
                Description = "Voidforge Unique Sword"
            }
        };

        [Test]
        [TestCaseSource(nameof(DeepTestCases))]
        public void When_DeserializeFromJson_DeepExamples(ModelFromJsonTestCase<Item> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            Item result = JsonSerializer.Deserialize<Item>(testCase.Json);

            // Then
            result.Should().BeEquivalentTo(testCase.ExpectedResult);
        }
    }
}