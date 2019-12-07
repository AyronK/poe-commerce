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
                    TypeFilter = Map(mapOperand.TypeFilter) is TypeFilter typeFilter ? new FilterWrapper<TypeFilter> { Filter = typeFilter } : null,
                    WeaponFilter = Map(mapOperand.WeaponFilter) is WeaponsFilter weaponFilter ? new FilterWrapper<WeaponsFilter> { Filter = weaponFilter } : null,
                    TradeFilter = Map(mapOperand.TradeFilter) is TradeFilter tradeFilter ? new FilterWrapper<TradeFilter> { Filter = tradeFilter } : null
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

        private OnlineStatusOption Map(CoreModels.OnlineStatus? mapOperand)
        {
            switch (mapOperand)
            {
                case CoreModels.OnlineStatus.Online:
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