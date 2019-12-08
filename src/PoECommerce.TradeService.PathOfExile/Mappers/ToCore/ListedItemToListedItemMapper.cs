using System;
using System.Linq;
using PoECommerce.Core;
using PoECommerce.PathOfExile.Models.Trade;
using PoECommerce.PathOfExile.Models.Trade.Enums;
using PoECommerce.PathOfExile.Models.Trade.Items;
using PoECommerce.PathOfExile.Models.Trade.Items.Enums;
using PoECommerce.PathOfExile.Models.Trade.Listings;
using CoreModels = PoECommerce.Core.Model.Trade;
using Item = PoECommerce.PathOfExile.Models.Trade.Items.Item;

namespace PoECommerce.TradeService.PathOfExile.Mappers.ToCore
{
    internal class ListedItemToListedItemMapper : IModelMapper<ListedItem, CoreModels.ListedItem>, IModelMapper<Item, CoreModels.Item>
    {
        public CoreModels.ListedItem Map(ListedItem mapOperand)
        {
            return new CoreModels.ListedItem
            {
                ListingId = mapOperand.Id,
                Item = Map(mapOperand.Item),
                Listing = Map(mapOperand.Listing)
            };
        }

        public CoreModels.Listing Map(Listing mapOperand)
        {
            return new CoreModels.Listing
            {
                Account = Map(mapOperand.Account),
                Indexed = mapOperand.Indexed,
                Whisper = mapOperand.Whisper,
                Price = Map(mapOperand.Price),
                Stash = Map(mapOperand.Stash)
            };
        }

        public CoreModels.Account Map(Account mapOperand)
        {
            return new CoreModels.Account
            {
                Name = mapOperand.Name,
                Language = mapOperand.Language,
                LastCharacterName = mapOperand.LastCharacterName,
                Online = Map(mapOperand.Online)
            };
        }

        public CoreModels.OnlineStatus Map(Online mapOperand)
        {
            if (mapOperand is null)
            {
                return new CoreModels.OnlineStatus
                {
                    IsOnline = false
                };
            }

            return new CoreModels.OnlineStatus
            {
                IsOnline = true,
                Status = mapOperand.Status,
                League = mapOperand.League
            };
        }

        public CoreModels.Price Map(Price mapOperand)
        {
            return new CoreModels.Price
            {
                Currency = mapOperand.Currency,
                Type = mapOperand.Type,
                Amount = mapOperand.Amount
            };
        }

        public CoreModels.Stash Map(Stash mapOperand)
        {
            if (mapOperand is null)
            {
                return null;
            }

            return new CoreModels.Stash
            {
                Name = mapOperand.Name,
                X = mapOperand.X,
                Y = mapOperand.Y
            };
        }

        public CoreModels.Item Map(Item mapOperand)
        {
            return new CoreModels.Item
            {
                Name = mapOperand.Name,
                TypeName = mapOperand.TypeName,
                League = mapOperand.League,
                IsSupportGem = mapOperand.IsSupportGem,
                ItemLevel = mapOperand.ItemLevel,
                Icon = mapOperand.Icon,
                IsElder = mapOperand.IsElder,
                Height = mapOperand.Height,
                IsFractured = mapOperand.IsFractured,
                IsShaper = mapOperand.IsShaper,
                IsVerified = mapOperand.IsVerified,
                Width = mapOperand.Width,
                ItemType = Map(mapOperand.FrameType),
                Description = mapOperand.SecondaryDescriptionText,
                Properties = mapOperand.Properties?.Select(Map).ToArray(),
                AdditionalProperties = mapOperand.AdditionalProperties?.Select(Map).ToArray(),
                Requirements = mapOperand.Requirements?.Select(Map).ToArray(),
                CraftedMods = mapOperand.CraftedMods,
                ExplicitMods = mapOperand.ExplicitMods,
                EnchantMods = mapOperand.EnchantMods,
                FracturedMods = mapOperand.FracturedMods,
                ImplicitMods = mapOperand.ImplicitMods,
                PseudoMods = mapOperand.PseudoMods,
                UtilityMods = mapOperand.UtilityMods,
                FlavourText = mapOperand.FlavourText,
                IsCorrupted = mapOperand.IsCorrupted,
                IsIdentified = mapOperand.IsIdentified,
                Note = mapOperand.Note,
                ProphecyText = mapOperand.ProphecyText
            };
        }

        public CoreModels.Property Map(Property mapOperand)
        {
            return new CoreModels.Property
            {
                Name = mapOperand.Name,
                DisplayMode = Map(mapOperand.DisplayMode),
                Order = mapOperand.Order,
                Progress = mapOperand.Progress,
                Values = mapOperand.Values?.Select(Map).ToArray(),
            };
        }

        public CoreModels.PropertyValue Map(PropertyValue mapOperand)
        {
            return new CoreModels.PropertyValue
            {
                Value = mapOperand.Value,
                Format = Map(mapOperand.Format)
            };
        }

        public CoreModels.PropertyDisplayMode Map(PropertyDisplayMode mapOperand)
        {
            switch (mapOperand)
            {
                case PropertyDisplayMode.MultipleValues:
                    return CoreModels.PropertyDisplayMode.MultipleValues;
                case PropertyDisplayMode.SingleValue:
                    return CoreModels.PropertyDisplayMode.SingleValue;
                case PropertyDisplayMode.ProgressBar:
                    return CoreModels.PropertyDisplayMode.ProgressBar;
                case PropertyDisplayMode.Template:
                    return CoreModels.PropertyDisplayMode.Template;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mapOperand), mapOperand, null);
            }
        }

        public CoreModels.TextFormat Map(TextFormat mapOperand)
        {
            switch (mapOperand)
            {
                case TextFormat.Simple:
                    return CoreModels.TextFormat.Simple;
                case TextFormat.Augmented:
                    return CoreModels.TextFormat.Augmented;
                case TextFormat.FireDamage:
                    return CoreModels.TextFormat.FireDamage;
                case TextFormat.ColdDamage:
                    return CoreModels.TextFormat.ColdDamage;
                case TextFormat.LightningDamage:
                    return CoreModels.TextFormat.LightningDamage;
                case TextFormat.ChaosDamage:
                    return CoreModels.TextFormat.ChaosDamage;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mapOperand), mapOperand, null);
            }
        }

        public CoreModels.ItemType Map(FrameType mapOperand)
        {
            switch (mapOperand)
            {
                case FrameType.Normal:
                    return CoreModels.ItemType.Normal;
                case FrameType.Magic:
                    return CoreModels.ItemType.Magic;
                case FrameType.Rare:
                    return CoreModels.ItemType.Rare;
                case FrameType.Unique:
                    return CoreModels.ItemType.Unique;
                case FrameType.Gem:
                    return CoreModels.ItemType.Gem;
                case FrameType.Currency:
                    return CoreModels.ItemType.Currency;
                case FrameType.DivinationCard:
                    return CoreModels.ItemType.DivinationCard;
                case FrameType.Prophecy:
                    return CoreModels.ItemType.Prophecy;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mapOperand), mapOperand, null);
            }
        }
    }
}