using System;

namespace PoECommerce.TradeService.Extensions
{
    public class RegistrationConfiguration
    {
        public ServiceSettings<IPoEDataService> DataServiceSettings { get; set; } = new ServiceSettings<IPoEDataService>();

        public ServiceSettings<IPoETradeService> TradeServiceSettings { get; set; } = new ServiceSettings<IPoETradeService>();

        public Func<string> LeagueNameFactory { get; set; } = null;
    }
}