using System;
using PoECommerce.PathOfExile.Web.Abstractions;

namespace PoECommerce.PathOfExile.Extensions
{
    public class RegistrationConfiguration
    {
        public string LocalStorageDirectory { get; set; }

        public ServiceSettings<IPathOfExileDataService> DataServiceSettings { get; set; } = new ServiceSettings<IPathOfExileDataService>();

        public ServiceSettings<IPathOfExileTradeService> TradeServiceSettings { get; set; } = new ServiceSettings<IPathOfExileTradeService>();
    }
}