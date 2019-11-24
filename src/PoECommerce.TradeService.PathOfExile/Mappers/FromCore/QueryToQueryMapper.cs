using PoECommerce.Core;
using PoECommerce.PathOfExile.Models.Search;
using PoECommerce.PathOfExile.Models.Search.Enums;
using PoECommerce.PathOfExile.Models.Search.Filters.Wrappers;
using CoreModels = PoECommerce.Core.Model.Search;

namespace PoECommerce.TradeService.PathOfExile.Mappers.FromCore
{
    internal class QueryToQueryMapper : IModelMapper<CoreModels.Query, Query>, IModelMapper<CoreModels.OnlineStatus?, OnlineStatusOption>
    {
        public OnlineStatusOption Map(CoreModels.OnlineStatus? mapOperand)
        {
            switch (mapOperand)
            {
                case CoreModels.OnlineStatus.Online:
                    return new OnlineStatusOption {Value = OnlineStatus.Online};
                default:
                    return null;
            }
        }

        public Query Map(CoreModels.Query mapOperand)
        {
            return new Query
            {
                Name = mapOperand.Name,
                Text = mapOperand.Text,
                Type = mapOperand.Type,
                Status = Map(mapOperand.OnlineStatus)
            };
        }
    }
}