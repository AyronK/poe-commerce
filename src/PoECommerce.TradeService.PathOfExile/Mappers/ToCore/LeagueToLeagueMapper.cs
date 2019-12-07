using PoECommerce.Core;
using CoreModels = PoECommerce.Core.Model.Data;
using PoECommerce.PathOfExile.Models.Data;

namespace PoECommerce.TradeService.PathOfExile.Mappers.ToCore
{
    internal class LeagueToLeagueMapper : IModelMapper<League, CoreModels.League>
    {
        public CoreModels.League Map(League mapOperand)
        {
            return new CoreModels.League
            {
                Id = mapOperand.Id,
                Text = mapOperand.Text,
            };
        }
    }
}