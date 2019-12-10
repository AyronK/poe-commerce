using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace PoECommerce.Client.Components.Common
{
    public class TextFieldBase : PoECommerceComponentBase
    {
        private string _value;

        [Parameter]
        public bool ReadOnly { get; set; }

        [Parameter]
        public bool Required { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public string PlaceHolder { get; set; }

        [Parameter]
        public string Value
        {
            get => _value;
            set
            {
                if (!EqualityComparer<string>.Default.Equals(value, _value))
                {
                    _value = value;
                    States["filled"] = !string.IsNullOrEmpty(_value);
                    ValueChanged.InvokeAsync(value);
                }
            }
        }

        [Parameter]
        public EventCallback<string> ValueChanged { get; set; }

        [Parameter]
        public string Type { get; set; } = "text";

        protected EventCallback<FocusEventArgs> OnFocus { get; set; }

        protected EventCallback<FocusEventArgs> OnFocusOut { get; set; }

        [Parameter]
        public string Style { get; set; }

        [Parameter]
        public string InputStyle { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            States.Add("focused", false);
            States.Add("filled", false);

            OnFocus = new EventCallbackFactory().Create(this, (FocusEventArgs args) => States["focused"] = true);
            OnFocusOut = new EventCallbackFactory().Create(this, (FocusEventArgs args) => States["focused"] = false);
        }
    }
}