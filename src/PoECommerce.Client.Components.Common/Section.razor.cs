using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace PoECommerce.Client.Components.Common
{
    public class SectionBase : PoECommerceComponentBase
    {
        private bool _isOpen;

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        protected EventCallback<MouseEventArgs> OnClick { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public bool IsOpen
        {
            get => _isOpen;
            set
            {
                _isOpen = value;
                States["open"] = _isOpen;
                StateHasChanged();
            }
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            OnClick = new EventCallbackFactory().Create(this, (MouseEventArgs args) => IsOpen = !IsOpen);
        }
    }
}