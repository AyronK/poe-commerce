using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace PoECommerce.Client.Components.Common
{
    public class SelectBase : PoECommerceComponentBase
    {
        private bool _isSectionOpen;
        private string _value;
        
        [Parameter]
        public string PlaceHolder { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string Value
        {
            get => _value;
            set
            {
                if (value != _value)
                {
                    _value = value;
                    States["filled"] = !string.IsNullOrEmpty(_value);
                    ValueChanged.InvokeAsync(value);
                }
            }
        }

        [Parameter]
        public EventCallback<string> ValueChanged { get; set; }

        protected bool IsSectionOpen
        {
            get => _isSectionOpen;
            set
            {
                _isSectionOpen = value;
                States["focused"] = _isSectionOpen;
                StateHasChanged();
            }
        }

        protected EventCallback<FocusEventArgs> OnFocus { get; set; }
        protected EventCallback<FocusEventArgs> OnFocusOut { get; set; }

        public void SetValue(string value)
        {
            Value = value;
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            EventCallbackFactory eventCallbackFactory = new EventCallbackFactory();

            OnFocus = eventCallbackFactory.Create(this, (FocusEventArgs args) => IsSectionOpen = !IsSectionOpen);
            OnFocusOut = eventCallbackFactory.Create(this, (FocusEventArgs args) => IsSectionOpen = !IsSectionOpen);
        }
    }
}