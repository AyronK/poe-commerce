using System.Linq;
using PoECommerce.Core;
using PoECommerce.PathOfExile.Models.Search;
using PoECommerce.PathOfExile.Models.Search.Enums;
using PoECommerce.PathOfExile.Models.Search.Filters;
using PoECommerce.PathOfExile.Models.Search.Filters.Wrappers;
using CoreModels = PoECommerce.Core.Model.Search;

namespace PoECommerce.TradeService.PathOfExile.Mappers.FromCore
{
    internal class QueryToQueryMapper : IModelMapper<CoreModels.Query, Query>, IModelMapper<CoreModels.SortType, SortType>
    {
        public Query Map(CoreModels.Query mapOperand)
        {
            return new Query
            {
                Name = mapOperand.Name,
                Text = mapOperand.Text,
                Type = mapOperand.Type,
                Status = Map(mapOperand.OnlineStatus),
                Filter = new Filter
                {
                    TypeFilter = mapOperand.TypeFilter != null ? Map(mapOperand.TypeFilter) is TypeFilter typeFilter ? new FilterWrapper<TypeFilter> { Filter = typeFilter } : null : null,
                    WeaponFilter = mapOperand.WeaponFilter != null ? Map(mapOperand.WeaponFilter) is WeaponsFilter weaponFilter ? new FilterWrapper<WeaponsFilter> { Filter = weaponFilter } : null : null,
                    ArmourFilter = mapOperand.ArmourFilter != null ? Map(mapOperand.ArmourFilter) is ArmoursFilter armourFilter ? new FilterWrapper<ArmoursFilter> { Filter = armourFilter } : null : null,
                    SocketFilter = mapOperand.SocketFilter != null ? Map(mapOperand.SocketFilter) is SocketsGroupFilter socketFilter ? new FilterWrapper<SocketsGroupFilter> { Filter = socketFilter } : null : null,
                    RequirementsFilter = mapOperand.RequirementsFilter != null ? Map(mapOperand.RequirementsFilter) is RequirementsFilter requirementsFilter ? new FilterWrapper<RequirementsFilter> { Filter = requirementsFilter } : null : null,
                    MapsFilter = mapOperand.MapsFilter != null ? Map(mapOperand.MapsFilter) is MapsFilter mapsFilter ? new FilterWrapper<MapsFilter> { Filter = mapsFilter } : null : null,
                    MiscellaneousFilter = mapOperand.MiscellaneousFilter != null ? Map(mapOperand.MiscellaneousFilter) is MiscellaneousFilter miscellaneousFilter ? new FilterWrapper<MiscellaneousFilter> { Filter = miscellaneousFilter } : null : null,
                    TradeFilter = mapOperand.TradeFilter != null ? Map(mapOperand.TradeFilter) is TradeFilter tradeFilter ? new FilterWrapper<TradeFilter> { Filter = tradeFilter } : null : null
                },
                ModifiersFilters = Map(mapOperand.ModifiersFilter)
            };
        }

        private ItemRarityOption Map(CoreModels.ItemRarity? mapOperand)
        {
            ItemRarity? mapped = mapOperand switch
            {
                CoreModels.ItemRarity.NonUnique => ItemRarity.NonUnique,
                CoreModels.ItemRarity.Normal => ItemRarity.Normal,
                CoreModels.ItemRarity.Magic => ItemRarity.Magic,
                CoreModels.ItemRarity.Rare => ItemRarity.Rare,
                CoreModels.ItemRarity.Unique => ItemRarity.Unique,
                CoreModels.ItemRarity.Relic => ItemRarity.Relic,
                _ => null,
            };

            return mapped.HasValue ? new ItemRarityOption { Value = mapped.Value } : null;
        }

        private OnlineStatusOption Map(Core.Model.Enums.OnlineStatus? mapOperand)
        {
            switch (mapOperand)
            {
                case Core.Model.Enums.OnlineStatus.Online:
                    return new OnlineStatusOption { Value = OnlineStatus.Online };
                default:
                    return null;
            }
        }

        private TypeFilter Map(CoreModels.TypeFilter mapOperand)
        {
            return new TypeFilter
            {
                Category = mapOperand.Category != null ? new StringOption { Value = mapOperand.Category } : null,
                Rarity = Map(mapOperand.ItemRarity)
            };
        }

        private WeaponsFilter Map(CoreModels.WeaponsFilter mapOperand)
        {
            return new WeaponsFilter
            {
                Damage = Map(mapOperand.Damage),
                CriticalChance = Map(mapOperand.CriticalChance),
                PhysicalDps = Map(mapOperand.PhysicalDps),
                AttacksPerSecond = Map(mapOperand.AttacksPerSecond),
                Dps = Map(mapOperand.Dps),
                ElementalDps = Map(mapOperand.ElementalDps)
            };
        }

        private ArmoursFilter Map(CoreModels.ArmoursFilter mapOperand)
        {
            return new ArmoursFilter
            {
                Armour = Map(mapOperand.Armour),
                EnergyShield = Map(mapOperand.EnergyShield),
                Evasion = Map(mapOperand.Evasion),
                Block = Map(mapOperand.Block)
            };
        }

        private RequirementsFilter Map(CoreModels.RequirementsFilter mapOperand)
        {
            return new RequirementsFilter
            {
                Level = Map(mapOperand.Level),
                Dexterity = Map(mapOperand.Dexterity),
                Strength = Map(mapOperand.Strength),
                Intelligence = Map(mapOperand.Intelligence)
            };
        }

        private FilterMagnitude Map(CoreModels.FilterMagnitude mapOperand)
        {
            if (mapOperand == null)
            {
                return null;
            }

            return new FilterMagnitude
            {
                Min = mapOperand.Min,
                Max = mapOperand.Max
            };
        }

        private SocketsGroupFilter Map(CoreModels.SocketsGroupFilter mapOperand)
        {
            return new SocketsGroupFilter
            {
                SocketsFilter = Map(mapOperand.SocketsFilter),
                LinksFilter = Map(mapOperand.LinksFilter)
            };
        }

        private SocketsFilter Map(CoreModels.SocketsFilter mapOperand)
        {
            return new SocketsFilter
            {
                GreenMin = mapOperand.GreenMin,
                RedMin = mapOperand.RedMin,
                BlueMin = mapOperand.BlueMin,
                WhiteMin = mapOperand.WhiteMin,
                AnyMin = mapOperand.AnyMin,
                AnyMax = mapOperand.AnyMax
            };
        }

        private MapsFilter Map(CoreModels.MapsFilter mapOperand)
        {
            return new MapsFilter
            {
                Tier = Map(mapOperand.Tier),
                IncreasedItemQuantity = Map(mapOperand.IncreasedItemQuantity),
                PackSize = Map(mapOperand.PackSize),
                IncreasedItemRarity = Map(mapOperand.IncreasedItemRarity),
                Shaped = mapOperand.Shaped.HasValue ? new BooleanOption { Value = mapOperand.Shaped } : null,
                Blighted = mapOperand.Blighted.HasValue ? new BooleanOption { Value = mapOperand.Blighted } : null,
                Elder = mapOperand.Elder.HasValue ? new BooleanOption { Value = mapOperand.Elder } : null,
                Series = mapOperand.Series != null ? new StringOption { Value = mapOperand.Series } : null
            };
        }

        private MiscellaneousFilter Map(CoreModels.MiscellaneousFilter mapOperand)
        {
            return new MiscellaneousFilter
            {
                Quality = Map(mapOperand.Quality),
                GemLevel = Map(mapOperand.GemLevel),
                ItemLevel = Map(mapOperand.ItemLevel),
                GemLevelProgress = Map(mapOperand.GemLevelProgress),
                Shaper = mapOperand.Shaper.HasValue ? new BooleanOption { Value = mapOperand.Shaper } : null,
                Fractured = mapOperand.Fractured.HasValue ? new BooleanOption { Value = mapOperand.Fractured } : null,
                AlternateArt = mapOperand.AlternateArt.HasValue ? new BooleanOption { Value = mapOperand.AlternateArt } : null,
                Corrupted = mapOperand.Corrupted.HasValue ? new BooleanOption { Value = mapOperand.Corrupted } : null,
                Crafted = mapOperand.Crafted.HasValue ? new BooleanOption { Value = mapOperand.Crafted } : null,
                Enchanted = mapOperand.Enchanted.HasValue ? new BooleanOption { Value = mapOperand.Enchanted } : null,
                Elder = mapOperand.Elder.HasValue ? new BooleanOption { Value = mapOperand.Elder } : null,
                Synthesised = mapOperand.Synthesised.HasValue ? new BooleanOption { Value = mapOperand.Synthesised } : null,
                Identified = mapOperand.Identified.HasValue ? new BooleanOption { Value = mapOperand.Identified } : null,
                Mirrored = mapOperand.Mirrored.HasValue ? new BooleanOption { Value = mapOperand.Mirrored } : null,
                Veiled = mapOperand.Veiled.HasValue ? new BooleanOption { Value = mapOperand.Veiled } : null,
                TalismanTier = Map(mapOperand.TalismanTier)
            };
        }

        private TradeFilter Map(CoreModels.TradeFilter mapOperand)
        {
            if (mapOperand == null)
            {
                return null;
            }

            return new TradeFilter
            {
                Account = mapOperand.AccountName != null ? new Account { Name = mapOperand.AccountName } : null,
                Price = mapOperand.Price is CoreModels.Price price ? new Price { Max = price.Max, Min = price.Min, Currency = price.Currency } : null,
                Indexed = Map(mapOperand.Indexed),
                SaleType = Map(mapOperand.SaleType)
            };
        }

        private SaleTypeOption Map(CoreModels.SaleType? mapOperand)
        {
            SaleType? mapped = mapOperand switch
            {
                CoreModels.SaleType.NotPriced => SaleType.NotPriced,
                CoreModels.SaleType.Priced => SaleType.Priced,
                _ => null,
            };

            return mapped.HasValue ? new SaleTypeOption { Value = mapped.Value } : null;
        }

        private IndexedOption Map(CoreModels.Indexed? mapOperand)
        {
            Indexed? mapped = mapOperand switch
            {
                CoreModels.Indexed.OneDay => Indexed.OneDay,
                CoreModels.Indexed.OneMonth => Indexed.OneMonth,
                CoreModels.Indexed.OneWeek => Indexed.OneWeek,
                CoreModels.Indexed.ThreeDays => Indexed.ThreeDays,
                CoreModels.Indexed.TwoMonths => Indexed.TwoMonths,
                CoreModels.Indexed.TwoWeek => Indexed.TwoWeek,
                _ => null,
            };

            return mapped.HasValue ? new IndexedOption { Value = mapped.Value } : null;
        }

        private ModifierGroupFilter[] Map(CoreModels.ModifiersFilter mapOperand)
        {
            return mapOperand?.GroupFilters.Select(Map).ToArray();
        }

        private ModifierGroupFilter Map(CoreModels.ModifierGroupFilter mapOperand)
        {
            if (mapOperand == null)
            {
                return null;
            }

            return new ModifierGroupFilter
            {
                Operand = Map(mapOperand.Operand),
                Filters = mapOperand.Filters?.Select(Map).ToArray()
            };
        }

        private ModifierFilter Map(CoreModels.SingleModifierFilter mapOperand)
        {
            if (mapOperand == null)
            {
                return null;
            }

            return new ModifierFilter
            {
                Id = mapOperand.Id,
                Disabled = mapOperand.Disabled ? true : (bool?)null,
                Magnitude = Map(mapOperand.Magnitude)
            };
        }

        private FilterOperand Map(CoreModels.FilterOperand mapOperand)
        {
            return mapOperand switch
            {
                CoreModels.FilterOperand.And => FilterOperand.And,
                CoreModels.FilterOperand.Count => FilterOperand.Count,
                CoreModels.FilterOperand.If => FilterOperand.If,
                CoreModels.FilterOperand.Not => FilterOperand.Not,
                CoreModels.FilterOperand.Weight => FilterOperand.Weight,
            };
        }

        public SortType Map(CoreModels.SortType mapOperand)
        {
            return mapOperand switch
            {
                CoreModels.SortType.Ascending => SortType.Ascending,
                CoreModels.SortType.Descending => SortType.Descending,
            };
        }
    }
}