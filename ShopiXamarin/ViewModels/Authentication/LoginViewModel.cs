using System;
using System.Windows.Input;
using ShopiXamarin.Services.Contracts;
using ShopiXamarin.Validations;
using ShopiXamarin.ViewModels.Base;
using Xamarin.Forms;

namespace ShopiXamarin.ViewModels.Authentication
{
    public class LoginViewModel : ViewModelBase
    {
        private bool _valideActive;
        private readonly IAuthenticationService _authenticationService;
        public LoginViewModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            Email.Validations.Add(new IsNotNullOrEmptyRule<string>());
            Email.Validations.Add(new IsEmailValideRule<string>());
            Password.Validations.Add(new IsNotNullOrEmptyRule<string>());
        }

        private ValidatableObject<string> _email = new ValidatableObject<string>();
        public ValidatableObject<string> Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private ValidatableObject<string> _password = new ValidatableObject<string>();
        public ValidatableObject<string> Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public ICommand ValueChangedCommand => new Command<IValidity>(async (IValidity obj) =>
        {
            if (_valideActive)
            {
                obj.Validate();
            }
        });

        public ICommand LoginCommand => new Command(async () =>
        {
            _valideActive = true;
            Email.Validate();
            Password.Validate();
            if (!Email.IsValid || !Password.IsValid)
            {
                return;
            }
            var isSuccess = await _authenticationService.AutheticateAsync(Email.Value, Password.Value, _cts.Token);
            if (isSuccess)
            {
                await _navigationService.InitializeAsync(false);
            }
        });
    }
}
