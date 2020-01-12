using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using NLog;

namespace PoECommerce.Client.Pages.Common
{
    public class ErrorHandlingComponentBase : ComponentBase
    {
        [Inject]
        protected ILogger Logger { get; set; }

        protected virtual void OnException(Exception ex)
        {
            Logger.Error(ex, "Unhandled error");
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            try
            {
                base.BuildRenderTree(builder);
            }
            catch (Exception ex)
            {
                OnException(ex);
            }
        }

        protected override void OnAfterRender(bool firstRender)
        {
            try
            {
                base.OnAfterRender(firstRender);
            }
            catch (Exception ex)
            {
                OnException(ex);
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            try
            {
                await base.OnAfterRenderAsync(firstRender);
            }
            catch (Exception ex)
            {
                OnException(ex);
            }
        }

        protected override void OnInitialized()
        {
            try
            {
                base.OnInitialized();
            }
            catch (Exception ex)
            {
                OnException(ex);
            }
        }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await base.OnInitializedAsync();
            }
            catch (Exception ex)
            {
                OnException(ex);
            }
        }

        protected override void OnParametersSet()
        {
            try
            {
                base.OnParametersSet();
            }
            catch (Exception ex)
            {
                OnException(ex);
            }
        }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                await base.OnParametersSetAsync();
            }
            catch (Exception ex)
            {
                OnException(ex);
            }
        }

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            try
            {
                await base.SetParametersAsync(parameters);
            }
            catch (Exception ex)
            {
                OnException(ex);
            }
        }

        protected override bool ShouldRender()
        {
            try
            {
                return base.ShouldRender();
            }
            catch (Exception ex)
            {
                OnException(ex);
                return false;
            }
        }

        protected new void StateHasChanged()
        {
            try
            {
                base.InvokeAsync(base.StateHasChanged);
            }
            catch (Exception ex)
            {
                OnException(ex);
                throw;
            }
        }

        protected new async Task InvokeAsync(Action workItem)
        {
            try
            {
                await base.InvokeAsync(workItem);
            }
            catch (Exception ex)
            {
                OnException(ex);
                throw;
            }
        }
    }
}