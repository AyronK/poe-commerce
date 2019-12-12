using PoECommerce.Core;
using PoECommerce.PathOfExile.Models.Search;
using CoreModels = PoECommerce.Core.Model.Search;

namespace PoECommerce.TradeService.PathOfExile.Mappers.ToCore
{
    internal class QueryResultToSearchResultMapper : IModelMapper<QueryResult, CoreModels.SearchResult>
    {
        public CoreModels.SearchResult Map(QueryResult mapOperand)
        {
            return new CoreModels.SearchResult
            {
                Total = mapOperand.Total,
                QueryId = mapOperand.Id,
                ItemIds = mapOperand.Result
            };
        }
    }
}