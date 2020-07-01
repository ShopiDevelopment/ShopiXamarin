using System;
using System.Threading;
using System.Threading.Tasks;
using ShopiXamarin.Services.Contracts;
using ShopiXamarin.ViewModels.Base;
using Newtonsoft.Json;
using ShopiXamarin.Models;
using ShopiXamarin.Utils;
using _ShopiXamarin.Network;
using _ShopiXamarin.Data;
using AutoMapper;
using _ShopiXamarin.Data.Responses;

namespace ShopiXamarin.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private const string GetUserEP = "https://run.mocky.io/v3/860602ad-6ac8-4ed5-bbdf-b0d1d5666aac";
        private readonly IAnalyticService _analyticService;
        private readonly ISettingsService _settingsService;
        private readonly IOperations _operations;
        
        public AuthenticationService(IAnalyticService analyticService,
                                     ISettingsService settingsService,
                                     IOperations operations)
        {
            _analyticService = analyticService;
            _settingsService = settingsService;
            _operations = operations;
            var userJson = _settingsService.GetItem(Constants.SettingKeys.UserSettingKey);
            if (!string.IsNullOrEmpty(userJson))
            {
                try
                {
                    User = JsonConvert.DeserializeObject<UserModel>(userJson);
                    _analyticService.Init(User.Email, User.Id.ToString());
                }
                catch (Exception ex)
                {

                }
            }
        }

        public bool IsUserAutheticated()
        {
            return _user != null;
        }

        private UserModel _user;
        private UserModel User
        {
            get => _user;
            set
            {
                _user = value;
                _settingsService.AddItem(Constants.SettingKeys.UserSettingKey, JsonConvert.SerializeObject(value));
            }
        }

        public async Task<bool> AutheticateAsync(string email, string password, CancellationToken cancellationToken)
        {
            _analyticService.LoginAttempted(email);
            try
            {
                var response = await _operations.GetResponse<UserResponse>(GetUserEP, cancellationToken);
                User = response.User.ToModel();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool Logout()
        {
            User = null;
            return true;
        }
    }
}
