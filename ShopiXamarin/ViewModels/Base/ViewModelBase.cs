using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using ShopiXamarin.Services.Contracts;
using Xamarin.Forms;

namespace ShopiXamarin.ViewModels.Base
{
    public abstract class ViewModelBase : ExtendedBindableObject
    {
        protected readonly IDialogService _dialogService;
        protected readonly INavigationService _navigationService;
        protected readonly IPopupService _popupService;
        protected readonly IAnalyticService _analyticService;
        public CancellationTokenSource _cts;

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        private bool _initialized;
        public bool Initialized
        {
            get => _initialized;
            set => SetProperty(ref _initialized, value);
        }

        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public ViewModelBase()
        {
            _dialogService = AppContainer.Resolve<IDialogService>();
            _navigationService = AppContainer.Resolve<INavigationService>();
            _popupService = AppContainer.Resolve<IPopupService>();
            _analyticService = AppContainer.Resolve<IAnalyticService>();
        }

        public virtual void Initialize(Dictionary<string, object> navigationData)
        {
            _cts = new CancellationTokenSource();
        }

        public virtual Task InitializeAsync()
        {
            Initialized = true;
            return Task.FromResult(false);
        }

        private ICommand _backCommand;
        public ICommand BackCommand
        {
            get => _backCommand;
            set => SetProperty(ref _backCommand, value);
        }

        private bool _emptyData;
        public bool EmptyData
        {
            get => _emptyData;
            set => SetProperty(ref _emptyData, value);
        }

        private string _emptyDataText;
        public string EmptyDataText
        {
            get => _emptyDataText;
            set => SetProperty(ref _emptyDataText, value);
        }

        private ICommand _successCommand;
        public ICommand SuccessCommand
        {
            get => _successCommand;
            set => SetProperty(ref _successCommand, value);
        }
    }
}
