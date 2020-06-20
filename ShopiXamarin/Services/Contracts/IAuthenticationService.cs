using System;
using System.Threading;
using System.Threading.Tasks;

namespace ShopiXamarin.Services.Contracts
{
    public interface IAuthenticationService
    {
        bool IsUserAutheticated();

        Task<bool> AutheticateAsync(string userName, string password, CancellationToken cancellationToken);

        bool Logout();
    }
}
