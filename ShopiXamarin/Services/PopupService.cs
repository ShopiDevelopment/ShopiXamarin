using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;
using ShopiXamarin.Services.Contracts;
using ShopiXamarin.ViewModels.Base;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;

namespace ShopiXamarin.Services
{
    public class PopupService : IPopupService
    {
        public Task NavigateToAsync<TViewModel>(bool animate = true ,ICommand ClosedCommand = null) where TViewModel : PopupModelBase
        {
            return InternalNavigateToAsync(typeof(TViewModel), new Dictionary<string, object>(), animate, ClosedCommand);
        }

        public Task NavigateToAsync<TViewModel>(Dictionary<string, object> navigationData, bool animate = true, ICommand ClosedCommand = null) where TViewModel : PopupModelBase
        {
            return InternalNavigateToAsync(typeof(TViewModel), navigationData, animate, ClosedCommand);
        }

        public async Task ClosePopupAsync(bool animate = true)
        {
            try
            {
                await PopupNavigation.Instance.PopAsync(animate);
            }
            catch
            {

            }
        }

        public async Task CloseAllPopupAsync(bool animate = true)
        {
            try
            {
                await PopupNavigation.Instance.PopAllAsync(animate);
            }
            catch
            {

            }
        }

        private async Task InternalNavigateToAsync(Type viewModelType, Dictionary<string, object> parameter, bool animate, ICommand ClosedCommand)
        {
            PopupPage page = CreatePage(viewModelType, parameter, ClosedCommand);

            await PopupNavigation.Instance.PushAsync(page, animate);

            await (page.BindingContext as PopupModelBase).InitializeAsync();
        }

        private Type GetPageTypeForViewModel(Type viewModelType)
        {
            var viewName = viewModelType.FullName.Replace("Model", string.Empty);
            var viewModelAssemblyName = viewModelType.GetTypeInfo().Assembly.FullName;
            var viewAssemblyName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewName, viewModelAssemblyName);
            var viewType = Type.GetType(viewAssemblyName);
            return viewType;
        }

        private PopupPage CreatePage(Type viewModelType, Dictionary<string, object> parameter, ICommand ClosedCommand)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);
            if (pageType == null)
            {
                throw new Exception($"Cannot locate page type for {viewModelType}");
            }

            PopupPage page = Activator.CreateInstance(pageType) as PopupPage;
            var model = AppContainer.Resolve(viewModelType) as PopupModelBase;
            model.ClosedCommand = ClosedCommand;
            page.Disappearing += (e, a) => { try { model._cts.Cancel(); model._cts.Dispose(); } catch { } };
            model.Initialize(parameter);
            page.BindingContext = model;
            return page;
        }
    }
}
