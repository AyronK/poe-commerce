using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace PoECommerce.Client.Components.Common
{
    public class SelectOptionBase : PoECommerceComponentBase
    {
        [CascadingParameter]
        public SelectBase Parent { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
        
        [Parameter]
        public RenderFragment Before { get; set; }

        [Parameter]
        public string Text { get; set; }

        [Parameter]
        public string Value { get; set; }

        protected EventCallback<MouseEventArgs> OnMouseDown { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            Parent.RegisterOption(Value, Text);

            OnMouseDown = new EventCallbackFactory().Create(this, (MouseEventArgs args) =>
            {
                Parent.SetValue(Value);
            });
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            Parent.RegisterOption(Value, Text);
        }
    }
}