using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace PoECommerce.Client.Components.Common
{
    public class SelectBase : PoECommerceComponentBase
    {
        [Parameter]
        public Dictionary<string, string> ValuesMap { get; set; } = new Dictionary<string, string>();

        private bool _isSectionOpen;
        private string _value;
        protected string _valueText;

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
                if (string.Equals(value, _value, StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                _value = value;
                _valueText = ValuesMap.TryGetValue(value ?? string.Empty, out string textValue) ? textValue : value;

                States["filled"] = !string.IsNullOrEmpty(_value);

                ValueChanged.InvokeAsync(_value);
                StateHasChanged();
            }
        }

        /// <summary>
        ///     Updates <see cref="Value" /> which should handle <see cref="_valueText" /> change as well according to
        ///     <see cref="ValuesMap" />.
        /// </summary
        protected string ValueText
        {
            get => _valueText;
            set
            {
                Value = value;
                StateHasChanged();
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
        protected EventCallback<ChangeEventArgs> OnChange { get; set; }
        protected EventCallback<ChangeEventArgs> OnInputWrapper { get; set; }

        [Parameter]
        public EventCallback<ChangeEventArgs> OnInput { get; set; }

        [Parameter]
        public int MaxElements { get; set; } = 5;

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
            OnChange = eventCallbackFactory.Create(this, (ChangeEventArgs args) => SetValue(args.Value.ToString()));
            OnInputWrapper = eventCallbackFactory.Create(this, (ChangeEventArgs args) =>
            {
                ValueText = args.Value.ToString();
                OnInput.InvokeAsync(args);
            });
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            States["autocomplete"] = IsAutocomplete;
            _valueText = ValuesMap.TryGetValue(_value ?? string.Empty, out string textValue) ? textValue : _value;
        }

        internal void SetValue(string value)
        {
            Value = value;
            StateHasChanged();
        }

        internal void RegisterOption(string value, string text)
        {
            if (!ValuesMap.TryGetValue(value ?? string.Empty, out string existingKey) || existingKey != (text ?? string.Empty))
            {
                ValuesMap[value ?? string.Empty] = text ?? string.Empty;
            }
        }
    }
}