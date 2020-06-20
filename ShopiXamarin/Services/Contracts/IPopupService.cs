using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using ShopiXamarin.ViewModels.Base;

namespace ShopiXamarin.Services.Contracts
{
    public interface IPopupService
    {
        Task NavigateToAsync<TViewModel>(bool animate = true, ICommand ClosedCommand = null) where TViewModel : PopupModelBase;

        Task NavigateToAsync<TViewModel>(Dictionary<string, object> parameter, bool animate = true, ICommand ClosedCommand = null) where TViewModel : PopupModelBase;

        Task ClosePopupAsync(bool animate = true);

        Task CloseAllPopupAsync(bool animate = true);
    }
}
