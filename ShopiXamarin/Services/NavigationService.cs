using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Threading.Tasks;
using ShopiXamarin.Services.Contracts;
using ShopiXamarin.ViewModels;
using ShopiXamarin.ViewModels.Authentication;
using ShopiXamarin.ViewModels.Base;
using ShopiXamarin.Views.Authentication;
using Xamarin.Forms;

namespace ShopiXamarin.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IAuthenticationService _authenticationService;
        public ViewModelBase PreviousPageViewModel
        {
            get
            {
                var mainPage = Application.Current.MainPage as NavigationPage;
                var viewModel = mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2].BindingContext;
                return viewModel as ViewModelBase;
            }
        }

        public NavigationService(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public Task InitializeAsync(bool forceLogin)
        {
            if (_authenticationService.IsUserAutheticated() && !forceLogin)
                return NavigateToAsync<MainViewModel>();
            else
                return NavigateToAsync<LoginViewModel>();

        }

        public Task NavigateToAsync<TViewModel>(bool isFullPage = true, bool animate = false) where TViewModel : ViewModelBase
        {
            return InternalNavigateToAsync(typeof(TViewModel), new Dictionary<string, object>(), isFullPage , animate);
        }

        public Task NavigateToAsync<TViewModel>(Dictionary<string, object> navigationData, bool isFullPage = false, bool animate = false) where TViewModel : ViewModelBase
        {
            return InternalNavigateToAsync(typeof(TViewModel), navigationData, isFullPage, animate);
        }

        public async Task PopToRootTabMenu(bool animate)
        {
            if (Views.MainView.Instance != null)
            {
                var tabNavigation = Views.MainView.Instance.CurrentPage as NavigationPage;
                if (tabNavigation != null)
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await tabNavigation.PopToRootAsync(animate);
                    });
                }
            }
        }

        public async Task PopToRoot(bool animate)
        {
            var mainPage = Application.Current.MainPage as NavigationPage;

            if (mainPage != null)
            {
                await mainPage.PopToRootAsync(animate);
            }
        }

        public void RemoveLastFromTabBackStackAsync()
        {
            if (Views.MainView.Instance != null)
            {
                var tabNavigation = Views.MainView.Instance.CurrentPage as NavigationPage;
                if (tabNavigation != null)
                {
                    try
                    {
                        tabNavigation.Navigation.RemovePage(
                            tabNavigation.Navigation.NavigationStack[tabNavigation.Navigation.NavigationStack.Count - 2]);
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }

        public void RemoveLastFromBackStackAsync()
        {
            var mainPage = Application.Current.MainPage as NavigationPage;

            if (mainPage != null)
            {
                try
                {
                    mainPage.Navigation.RemovePage(
                        mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2]);
                }
                catch (Exception ex)
                {

                }
            }
        }

        public Task RemoveBackStackAsync()
        {
            var mainPage = Application.Current.MainPage as NavigationPage;

            if (mainPage != null)
            {
                for (int i = 0; i < mainPage.Navigation.NavigationStack.Count - 1; i++)
                {
                    var page = mainPage.Navigation.NavigationStack[i];
                    mainPage.Navigation.RemovePage(page);
                }
            }

            return Task.FromResult(true);
        }

        public Task RemoveTabBackStackAsync()
        {
            var mainPage = Views.MainView.Instance.CurrentPage as NavigationPage;

            if (mainPage != null)
            {
                for (int i = 0; i < mainPage.Navigation.NavigationStack.Count - 1; i++)
                {
                    var page = mainPage.Navigation.NavigationStack[i];
                    mainPage.Navigation.RemovePage(page);
                }
            }
            return Task.FromResult(true);
        }

        public void ChangeTab(int pageIndex)
        {
            if (Views.MainView.Instance != null)
            {
                Views.MainView.Instance.CurrentPage = Views.MainView.Instance.Children[pageIndex];
            }
        }

        private async Task InternalNavigateToAsync(Type viewModelType, Dictionary<string, object> navigationData, bool isFullPage, bool animate)
        {
            Page page = CreatePage(viewModelType, navigationData);
            var viewModel = (page.BindingContext as ViewModelBase);
            if (page is LoginView || page is Views.MainView || page is Views.SplashView)
            {
                var navigationPage = new NavigationPage(page);
                viewModel.BackCommand = new Command(async () => { try { await navigationPage.PopAsync(); viewModel._cts.Cancel(); viewModel._cts.Dispose(); } catch { } });
                Application.Current.MainPage = navigationPage;
            }
            else
            {
                var navigationPage = Application.Current.MainPage as NavigationPage;
                if (navigationPage != null)
                {
                    if (isFullPage)
                    {
                        await navigationPage.PushAsync(page, animate);
                        viewModel.BackCommand = new Command(async () => { await navigationPage.PopAsync(); viewModel._cts.Cancel(); viewModel._cts.Dispose(); });
                    }
                    else
                    {
                        var tabNavigationPage = Views.MainView.Instance?.CurrentPage as NavigationPage;
                        if (tabNavigationPage != null)
                        {
                            await tabNavigationPage.PushAsync(page, animate);
                            if (viewModel != null)
                            {
                                viewModel.BackCommand = new Command(async () => { await tabNavigationPage.PopAsync(); viewModel._cts.Cancel(); viewModel._cts.Dispose(); });
                            }
                        }
                    }
                }
                else
                {
                    var mainNavigationPage = new NavigationPage(page);
                    viewModel.BackCommand = new Command(async () => { await mainNavigationPage.PopAsync(); viewModel._cts.Cancel(); viewModel._cts.Dispose(); });
                    Application.Current.MainPage = mainNavigationPage;
                }
            }
            if (page.BindingContext != null)
            {
                await (page.BindingContext as ViewModelBase).InitializeAsync();
            }
        }

        private Type GetPageTypeForViewModel(Type viewModelType)
        {
            var viewName = viewModelType.FullName.Replace("Model", string.Empty);
            var viewModelAssemblyName = viewModelType.GetTypeInfo().Assembly.FullName;
            var viewAssemblyName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewName, viewModelAssemblyName);
            var viewType = Type.GetType(viewAssemblyName);
            return viewType;
        }

        private Page CreatePage(Type viewModelType, Dictionary<string, object> navigationData)
        {
            try
            {
                Type pageType = GetPageTypeForViewModel(viewModelType);
                if (pageType == null)
                {
                    throw new Exception($"Cannot locate page type for {viewModelType}");
                }

                Page page = Activator.CreateInstance(pageType) as Page;
                var model = AppContainer.Resolve(viewModelType) as ViewModelBase;
                model.Initialize(navigationData);
                page.BindingContext = model;
                return page;
            }
            catch (Exception ex)
            {
                var page = new Views.ErrorView();
                page.BindingContext = ex.ToString();
                return page;
            }
        }
    }
}
