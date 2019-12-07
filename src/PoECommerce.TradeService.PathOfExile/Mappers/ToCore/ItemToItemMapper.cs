using System;
using System.Collections.Generic;
using PoECommerce.Core;
using PoECommerce.PathOfExile.Models.Data;
using PoECommerce.PathOfExile.Models.Data.Enums;
using PoECommerce.PathOfExile.Models.Enums;

namespace PoECommerce.TradeService.PathOfExile.Mappers.ToCore
{
    internal class ItemToItemMapper : IModelMapper<KeyValuePair<ItemCategory, Item>, Core.Model.Data.Item>, IModelMapper<ItemCategory, Core.Model.Data.ItemCategory>
    {
        public Core.Model.Data.Item Map(KeyValuePair<ItemCategory, Item> mapOperand)
        {
            IDictionary<ItemFlag, bool> valueFlags = mapOperand.Value.Flags;

            return new Core.Model.Data.Item
            {
                Name = mapOperand.Value.Name,
                Text = mapOperand.Value.Text,
                Type = mapOperand.Value.Type,
                Disclaimer = mapOperand.Value.Discriminator,
                ItemCategory = Map(mapOperand.Key),
                IsProphecy = valueFlags != null && valueFlags.TryGetValue(ItemFlag.Prophecy, out bool isProphecy) && isProphecy,
                IsUnique = valueFlags != null && valueFlags.TryGetValue(ItemFlag.Unique, out bool isUnique) && isUnique,
                
            };
        }

        public Core.Model.Data.ItemCategory Map(ItemCategory mapOperand)
        {
            switch (mapOperand)
            {
                case ItemCategory.Accessory:
                    return Core.Model.Data.ItemCategory.Accessory;
                case ItemCategory.Armour:
                    return Core.Model.Data.ItemCategory.Armour;
                case ItemCategory.DivinationCard:
                    return Core.Model.Data.ItemCategory.DivinationCard;
                case ItemCategory.Currency:
                    return Core.Model.Data.ItemCategory.Currency;
                case ItemCategory.Flask:
                    return Core.Model.Data.ItemCategory.Flask;
                case ItemCategory.Gem:
                    return Core.Model.Data.ItemCategory.Gem;
                case ItemCategory.Jewel:
                    return Core.Model.Data.ItemCategory.Jewel;
                case ItemCategory.NormalMap:
                    return Core.Model.Data.ItemCategory.NormalMap;
                case ItemCategory.ShapedMap:
                    return Core.Model.Data.ItemCategory.ShapedMap;
                case ItemCategory.ElderMap:
                    return Core.Model.Data.ItemCategory.ElderMap;
                case ItemCategory.BlightedMap:
                    return Core.Model.Data.ItemCategory.BlightedMap;
                case ItemCategory.Weapon:
                    return Core.Model.Data.ItemCategory.Weapon;
                case ItemCategory.Leaguestone:
                    return Core.Model.Data.ItemCategory.Leaguestone;
                case ItemCategory.Prophecy:
                    return Core.Model.Data.ItemCategory.Prophecy;
                case ItemCategory.CapturedBeast:
                    return Core.Model.Data.ItemCategory.CapturedBeast;
                case ItemCategory.Fragment:
                    return Core.Model.Data.ItemCategory.Fragment;
                case ItemCategory.Oil:
                    return Core.Model.Data.ItemCategory.Oil;
                case ItemCategory.Incubator:
                    return Core.Model.Data.ItemCategory.Incubator;
                case ItemCategory.Scarab:
                    return Core.Model.Data.ItemCategory.Scarab;
                case ItemCategory.Resonator:
                    return Core.Model.Data.ItemCategory.Resonator;
                case ItemCategory.Fossil:
                    return Core.Model.Data.ItemCategory.Fossil;
                case ItemCategory.Vial:
                    return Core.Model.Data.ItemCategory.Vial;
                case ItemCategory.Net:
                    return Core.Model.Data.ItemCategory.Net;
                case ItemCategory.Essence:
                    return Core.Model.Data.ItemCategory.Essence;
                case ItemCategory.Misc:
                    return Core.Model.Data.ItemCategory.Misc;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mapOperand), mapOperand, null);
            }
        }
    }
}