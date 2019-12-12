using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace PoECommerce.Client.Components.Common
{
    public class ButtonBase : PoECommerceComponentBase
    {
        [Parameter]
        public string Value { get; set; } = null;

        [Parameter]
        public ElementType ElementType { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }
        
        [Parameter]
        public string Style { get; set; }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            States.Clear();

            switch (ElementType)
            {
                case ElementType.Primary:
                    States["primary"] = true;
                    break;
                case ElementType.Secondary:
                    States["secondary"] = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}