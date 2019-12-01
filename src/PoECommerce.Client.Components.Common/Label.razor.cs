using Microsoft.AspNetCore.Components;

namespace PoECommerce.Client.Components.Common
{
    public class LabelBase : PoECommerceComponentBase
    {
        [Parameter]
        public string Value { get; set; } = null;
    }
}