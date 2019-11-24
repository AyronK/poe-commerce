using PoECommerce.Core;
using PoECommerce.PathOfExile.Models.Trade;
using PoECommerce.PathOfExile.Models.Trade.Items;
using CoreModels = PoECommerce.Core.Model.Search;

namespace PoECommerce.TradeService.PathOfExile.Mappers.ToCore
{
    internal class ListedItemToListedItemMapper : IModelMapper<ListedItem, CoreModels.ListedItem>, IModelMapper<Item, CoreModels.Item>
    {
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
                Width = mapOperand.Width
            };
        }

        public CoreModels.ListedItem Map(ListedItem mapOperand)
        {
            return new CoreModels.ListedItem
            {
                ListingId = mapOperand.Id,
                Item = Map(mapOperand.Item)
            };
        }
    }
}