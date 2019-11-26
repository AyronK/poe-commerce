using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace PoECommerce.Client.Components.Common
{
    public class CheckboxBase : PoECommerceComponentBase
    {
        private bool _checked;

        [Parameter]
        public bool Checked
        {
            get => _checked;
            set
            {
                if (!EqualityComparer<bool>.Default.Equals(value, _checked))
                {
                    _checked = value;
                    CheckedChanged?.Invoke(Checked);
                }
            }
        }

        [Parameter]
        public Action<bool> CheckedChanged { get; set; }

        [Parameter]
        public string Label { get; set; }

        protected void ChangeHandler(ChangeEventArgs e)
        {
            Checked = (bool) e.Value;
            CheckedChanged?.Invoke(Checked);
        }
    }
}