using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PoECommerce.Client.Shared.Display;
using PoECommerce.Core;
using PoECommerce.Core.Model.Search;
using PoECommerce.PathOfExile;
using PoECommerce.PathOfExile.GameClient.Abstractions;

namespace PoECommerce.Client.Shared
{
    public class PoECommerceFacade : IPoECommerceFacade
    {
        private readonly ITradeService _tradeService;
        private readonly IWindowManager _windowManager;

        public IPathOfExileFacade PathOfExile { get; }

        public IReadOnlyDictionary<string, TradeSession> Sessions => _sessions;

        private readonly Dictionary<string, TradeSession> _sessions;

        public PoECommerceFacade(IPathOfExileFacade pathOfExile, ITradeService tradeService, IWindowManager windowManager, Dictionary<string, TradeSession> sessionStore)
        {
            _tradeService = tradeService;
            _windowManager = windowManager;
            PathOfExile = pathOfExile;
            _sessions = sessionStore ?? throw new ArgumentNullException(nameof(sessionStore));
        }

        public TradeSession SearchItems(Query query)
        {
            TradeSession tradeSession = new TradeSession(query, _tradeService, s => _sessions.Remove(s.Id));
            _sessions.Add(tradeSession.Id, tradeSession);
            return tradeSession;
        }

        public Task OpenCompactResults(string tradeSessionId = null)
        {
            return _windowManager.LoadUrl(2, $"/CompactTrade/{tradeSessionId}", true);
        }

        public Task OpenAdvancedResults(string tradeSessionId = null)
        {
            return _windowManager.LoadUrl(1, $"/Trade/{tradeSessionId}", true);
        }

        public Task CloseCompactResults()
        {
            return _windowManager.Minimize(2);
        }

        public Task CloseAdvancedResults()
        {
            return _windowManager.Minimize(1);
        }
    }
}