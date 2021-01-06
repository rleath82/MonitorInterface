﻿using Microsoft.AspNetCore.Components;
using System;

namespace MonitorInterface.Client.Services.Modals
{
    public class ModalService : IModalService
    {
        /// <summary>
        /// Invoked when the modal component closes.
        /// </summary>
        public event Action<ModalResult> OnClose;

        /// <summary>
        /// Internal event used to close the modal instance.
        /// </summary>
        internal event Action CloseModal;

        /// <summary>
        /// Internal event used to trigger the modal component to show.
        /// </summary>
        internal event Action<string, RenderFragment, ModalParameters> OnShow;

        private Type _modalType;

        /// <summary>
        /// Shows the modal with the component type using the specified title.
        /// </summary>
        /// <param name="title">Modal title.</param>
        /// <param name="componentType">Type of component to display.</param>
        public void Show<T>(string title) where T : ComponentBase
        {
            Show<T>(title, new ModalParameters());
        }

        ///// <summary>
        ///// Shows the modal with the component type using the specified <paramref name="title"/>, 
        ///// passing the specified <paramref name="parameters"/>. 
        ///// </summary>
        ///// <param name="title">Modal title.</param>
        ///// <param name="componentType">Type of component to display.</param>
        ///// <param name="parameters">Key/Value collection of parameters to pass to component being displayed.</param>
        //public void Show<T>(string title, ModalParameters parameters) where T : ComponentBase
        //{
        //    Show<T>(title, parameters);
        //}

        /// <summary>
        /// Shows the modal with the component type using the specified <paramref name="title"/>, 
        /// passing the specified <paramref name="parameters"/> and setting a custom CSS style. 
        /// </summary>
        /// <param name="title">Modal title.</param>
        /// <param name="parameters">Key/Value collection of parameters to pass to component being displayed.</param>
        public void Show<T>(string title, ModalParameters parameters) where T : ComponentBase
        {
            if (!typeof(ComponentBase).IsAssignableFrom(typeof(T)))
            {
                throw new ArgumentException($"{typeof(T).FullName} must be a Blazor Component");
            }

            var content = new RenderFragment(x => { x.OpenComponent(1, typeof(T)); x.CloseComponent(); });
            _modalType = typeof(T);

            OnShow?.Invoke(title, content, parameters);
        }


        /// <summary>
        /// Closes the modal and invokes the <see cref="OnClose"/> event.
        /// </summary>
        public void Cancel()
        {
            CloseModal?.Invoke();
            OnClose?.Invoke(ModalResult.Cancel(_modalType));
        }

        /// <summary>
        /// Closes the modal and invokes the <see cref="OnClose"/> event with the specified <paramref name="modalResult"/>.
        /// </summary>
        /// <param name="modalResult"></param>
        public void Close(ModalResult modalResult)
        {
            modalResult.ModalType = _modalType;
            CloseModal?.Invoke();
            OnClose?.Invoke(modalResult);
        }
    }
}
