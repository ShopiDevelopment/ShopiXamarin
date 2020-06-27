using System;
using System.Windows.Input;
using ShopiXamarin.Services.Contracts;
using ShopiXamarin.ViewModels.Base;
using Xamarin.Forms;

namespace ShopiXamarin.ViewModels.Profile
{
    public class ProfileViewModel : ViewModelBase
    {
        private readonly IAuthenticationService _authenticationService;
        public ProfileViewModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public ICommand LogoutCommand => new Command(async () =>
        {
            bool isSuccess = _authenticationService.Logout();
            if (isSuccess)
            {
                await _navigationService.InitializeAsync(false);
            }
        });
    }
}
