using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace ShopiXamarin.ViewModels.Base
{
    public class PopupModelBase : ViewModelBase
    {
        public PopupModelBase()
        {
            
        }

        public ICommand ClosedCommand { get; set; }

        public ICommand CloseCommand => new Command(async () =>
        {
            if (IsBusy)
            {
                return;
            }
            await _popupService.ClosePopupAsync();
            if (ClosedCommand != null && ClosedCommand.CanExecute(null)) 
            {
                ClosedCommand.Execute(null);
            }
        });
    }
}
