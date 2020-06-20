using System;
using System.Threading.Tasks;

namespace ShopiXamarin.Services.Contracts
{
    public interface IDialogService
    {
        Task ShowAlertAsync(string message, string title = null, string buttonLabel = null);

        Task<bool> ShowDialogAsync(string message, string title = null, string buttonLabel = null, string cancelLabel = null);

        Task ShowError(string message = "");

        Task ShowSuccess(string message);
    }
}
