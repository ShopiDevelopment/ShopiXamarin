using System.Threading.Tasks;
using Acr.UserDialogs;
using ShopiXamarin.Services.Contracts;

namespace ShopiXamarin.Services
{
    public class DialogService : IDialogService
    {
        public Task ShowAlertAsync(string message, string title = null, string buttonLabel = null)
        {
            return UserDialogs.Instance.AlertAsync(message, title, buttonLabel);
        }

        public Task<bool> ShowDialogAsync(string message, string title = null, string buttonLabel = null, string cancelLabel = null)
        {
            return UserDialogs.Instance.ConfirmAsync(message, title, buttonLabel, cancelLabel);
        }

        public Task ShowError(string message = "")
        {
            return ShowAlertAsync(string.IsNullOrEmpty(message) ? Resource.AppResource.GenericErrorText : message, null, Resource.AppResource.OK);
        }

        public Task ShowSuccess(string message)
        {
            return ShowAlertAsync(message, null, Resource.AppResource.OK);
        }
    }
}
