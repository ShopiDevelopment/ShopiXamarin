using System;
using System.Threading;
using System.Threading.Tasks;
using ShopiXamarin.Services.Contracts;
using ShopiXamarin.ViewModels.Base;
using Newtonsoft.Json;

namespace ShopiXamarin.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private const string LoginApi = "{0}/customer/login";
        private const string ForgotPasswordApi = "{0}/customer/forgetPassword";
        private readonly IAnalyticService _analyticService;
        private bool _isUserAutheticated;
        public AuthenticationService(IAnalyticService analyticService)
        {
            _analyticService = analyticService;
        }

        public bool IsUserAutheticated()
        {
            return _isUserAutheticated;
        }

        public Task<bool> AutheticateAsync(string userName, string password, CancellationToken cancellationToken)
        {
            _analyticService.LoginAttempted(userName);
            _isUserAutheticated = true;
            return Task.FromResult(_isUserAutheticated);
        }

        public bool Logout()
        {
            _isUserAutheticated = false;
            return true;
        }
    }
}
