﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace PoECommerce.Client.Components.Common
{
    public class TextFieldBase : ComponentBase
    {
        private string _value;

        [Parameter]
        public string Id { get; set; } = "id_" + Guid.NewGuid();

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public string Icon { get; set; }

        [Parameter]
        public bool TextArea { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public bool ReadOnly { get; set; }

        [Parameter]
        public bool Required { get; set; }

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
                    ValueChanged.InvokeAsync(value);
                    NotifyFieldChanged();
                }
            }
        }

        protected FieldIdentifier FieldIdentifier { get; private set; }

        protected EditContext EditContext { get; private set; }

        [Parameter]
        public string Type { get; set; } = "text";

        [Parameter]
        public string InputStyle { get; set; }

        [Parameter]
        public EventCallback<string> ValueChanged { get; set; }

        protected void NotifyFieldChanged()
        {
            EditContext?.NotifyFieldChanged(FieldIdentifier);
        }
    }
}