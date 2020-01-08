using PoECommerce.Core;
using PoECommerce.Core.Model.Search;
using PoECommerce.PathOfExile;

namespace PoECommerce.Client.Shared
{
    public class PoECommerceFacade : IPoECommerceFacade
    {
        private readonly ITradeService _tradeService;

        public IPathOfExileFacade PathOfExile { get; }

        public void ClearSession()
        {
            CurrentTradeSession = null;
        }

        public TradeSession CurrentTradeSession { get; private set; }

        public PoECommerceFacade(IPathOfExileFacade pathOfExile, ITradeService tradeService)
        {
            _tradeService = tradeService;
            PathOfExile = pathOfExile;
            CurrentTradeSession = null;
        }

        public TradeSession SearchItems(Query query)
        {
            CurrentTradeSession = new TradeSession(query, _tradeService);
            return CurrentTradeSession;
        }
    }
}