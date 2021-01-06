using Microsoft.AspNetCore.Components;
using MonitorInterface.Client.Services.Modals;
using System;

namespace MonitorInterface.Client.Views.Components
{
    public partial class Modal : ComponentBase, IDisposable
    {
        [Inject] private IModalService ModalService { get; set; }

        private bool ComponentDisableBackgroundCancel { get; set; }
        private bool ComponentHideCloseButton { get; set; }
        private bool IsVisible { get; set; }
        private string Title { get; set; }
        private RenderFragment Content { get; set; }
        private ModalParameters Parameters { get; set; }

        [Parameter] public EventCallback<int> ItemsChanged { get; set; }

        /// <summary>
        /// Sets the title for the modal being displayed
        /// </summary>
        /// <param name="title">Text to display as the title of the modal</param>
        public void SetTitle(string title)
        {
            Title = title;
            StateHasChanged();
        }

        protected override void OnInitialized()
        {
            ((ModalService)ModalService).OnShow += ShowModal;
            ((ModalService)ModalService).CloseModal += CloseModal;
        }

        private async void ShowModal(string title, RenderFragment content, ModalParameters parameters)
        {
            Title = title;
            Content = content;
            Parameters = parameters;

            IsVisible = true;
            await InvokeAsync(StateHasChanged);
        }

        private async void CloseModal()
        {
            IsVisible = false;
            Title = "";
            Content = null;
            await ItemsChanged.InvokeAsync(1);
            await InvokeAsync(StateHasChanged);
        }

        private void HandleBackgroundClick()
        {
            if (ComponentDisableBackgroundCancel) return;

            ModalService.Cancel();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                ((ModalService)ModalService).OnShow -= ShowModal;
                ((ModalService)ModalService).CloseModal -= CloseModal;
            }
        }
    }
}
