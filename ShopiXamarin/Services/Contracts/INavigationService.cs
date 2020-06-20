using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShopiXamarin.ViewModels.Base;

namespace ShopiXamarin.Services.Contracts
{
    public interface INavigationService
    {
        ViewModelBase PreviousPageViewModel { get; }

        Task InitializeAsync(bool forceLogin);

        Task NavigateToAsync<TViewModel>(bool isFullPage = true, bool animate = true) where TViewModel : ViewModelBase;

        Task NavigateToAsync<TViewModel>(Dictionary<string, object> navigationData, bool isFullPage = false, bool animate = true) where TViewModel : ViewModelBase;

        void RemoveLastFromBackStackAsync();

        void RemoveLastFromTabBackStackAsync();

        Task PopToRootTabMenu(bool animate);

        Task PopToRoot(bool animate);

        Task RemoveBackStackAsync();

        Task RemoveTabBackStackAsync();

        void ChangeTab(int pageIndex);
    }
}
