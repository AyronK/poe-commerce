using System;
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
        public bool IsAutocomplete { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string Style { get; set; }

        [Parameter]
        public string Value
        {
            get => _value;
            set
            {
                if (IsAutocomplete && Value != null && value != null && Value.IndexOf(value, StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    return;
                }

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

        protected EventCallback<KeyboardEventArgs> OnKeyDown { get; set; }
        protected EventCallback<MouseEventArgs> OnClick { get; set; }
        protected EventCallback<FocusEventArgs> OnFocus { get; set; }
        protected EventCallback<FocusEventArgs> OnFocusOut { get; set; }

        [Parameter]
        public EventCallback<ChangeEventArgs> OnInput { get; set; }

        [Parameter]
        public int MaxElements { get; set; } = 5;

        public void SetValue(string value)
        {
            Value = value;
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            EventCallbackFactory eventCallbackFactory = new EventCallbackFactory();

            OnClick = eventCallbackFactory.Create(this, (MouseEventArgs args) => IsSectionOpen = true);
            OnFocus = eventCallbackFactory.Create(this, (FocusEventArgs args) => IsSectionOpen = true);
            OnFocusOut = eventCallbackFactory.Create(this, (FocusEventArgs args) => IsSectionOpen = false);
            OnKeyDown = eventCallbackFactory.Create(this, (KeyboardEventArgs args) =>
            {
                if (args.Key == "Enter" || args.Key == "Escape")
                {
                    OnFocusOut.InvokeAsync(new FocusEventArgs());
                }
                else
                {
                    OnFocus.InvokeAsync(new FocusEventArgs());
                }
            });
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            States["autocomplete"] = IsAutocomplete;
        }
    }
}