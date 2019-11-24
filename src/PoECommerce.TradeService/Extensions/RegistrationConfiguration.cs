using System;

namespace PoECommerce.PathOfExile.Extensions
{
    public class RegistrationConfiguration
    {
        public ServiceSettings<IPathOfExileDataService> DataServiceSettings { get; set; } = new ServiceSettings<IPathOfExileDataService>();

        public ServiceSettings<IPathOfExileTradeService> TradeServiceSettings { get; set; } = new ServiceSettings<IPathOfExileTradeService>();
    }
}