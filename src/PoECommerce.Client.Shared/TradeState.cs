using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PoECommerce.Client.Shared.Display;
using PoECommerce.Core;
using PoECommerce.Core.Model.Search;
using PoECommerce.PathOfExile.GameClient.Abstractions;

namespace PoECommerce.Client.Shared
{
    public class TradeState : ITradeState
    {
        public IReadOnlyDictionary<string, TradeSession> Sessions => _sessions;

        private readonly Dictionary<string, TradeSession> _sessions = new Dictionary<string, TradeSession>();
        private readonly Func<ITradeService> _getTradeService;
        private bool _isCompact;
        private bool _isVisible = true;
        public TradeSession CurrentTradeSession { get; private set; }

        public TradeState(Func<ITradeService> getTradeService)
        {
            _getTradeService = getTradeService;
        }

        public bool IsCompact
        {
            get => _isCompact;
            set
            {
                _isCompact = value;
                OnIsCompactChanged?.Invoke(this, _isCompact);
            }
        }

        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                _isVisible = value;
                OnIsVisibleChanged?.Invoke(this, _isVisible);
            }
        }

        public event EventHandler<bool> OnIsCompactChanged;
        public event EventHandler<bool> OnIsVisibleChanged;
        public event EventHandler<TradeSession> OnNewSession;

        public TradeSession SearchItems(Query query)
        {
            TradeSession tradeSession = new TradeSession(query, _getTradeService(), s =>
            {
                _sessions.Remove(s.Id);
                if (CurrentTradeSession == s)
                {
                    CurrentTradeSession = null;
                }
            });
            _sessions.Add(tradeSession.Id, tradeSession);
            CurrentTradeSession = tradeSession;
            OnNewSession?.Invoke(this, CurrentTradeSession);
            return tradeSession;
        }
    }
}