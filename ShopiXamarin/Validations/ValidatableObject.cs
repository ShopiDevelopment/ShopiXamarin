using System.Collections.Generic;
using System.Linq;
using ShopiXamarin.ViewModels.Base;
using Xamarin.Forms;

namespace ShopiXamarin.Validations
{
    public class ValidatableObject<T> : ExtendedBindableObject, IValidity
    {
        private bool _validateLock = true;
        private readonly List<IValidationRule<T>> _validations;

        public List<IValidationRule<T>> Validations => _validations;

        private List<string> _errors;
        public List<string> Errors
        {
            get => _errors;
            set => SetProperty(ref _errors, value);
        }

        private string _errorText;
        public string ErrorText
        {
            get => _errorText;
            set => SetProperty(ref _errorText, value);
        }

        private T _value;
        public T Value
        {
            get => _value;
            set
            {
                SetProperty(ref _value, value);
                OnPropertyChanged("TextColor");
            }
        }

        private bool _isValid;
        public bool IsValid
        {
            get => _isValid;
            set => SetProperty(ref _isValid, value);
        }

        public ValidatableObject()
        {
            _isValid = true;
            _errors = new List<string>();
            _validations = new List<IValidationRule<T>>();
        }

        public bool Validate()
        {
            _validateLock = false;
            Errors.Clear();

            IEnumerable<string> errors = _validations.Where(v => !v.Check(Value))                             
                .Select(v => v.ValidationMessage);

			Errors = errors.ToList();
            ErrorText = string.Empty;
            ErrorText = Errors.FirstOrDefault();
            IsValid = !Errors.Any();
            OnPropertyChanged("BackgroundColor");
            OnPropertyChanged("BorderColor");
            return this.IsValid;
        }


        public Color BackgroundColor
        {
            get
            {
                if (!IsEnabled)
                {
                    return Color.White;
                }
                if (_validateLock)
                {
                    return Color.White;
                }
                if (IsValid)
                {
                    return (Color)Application.Current.Resources["ValidInputBackground"];
                }
                else
                {
                    return (Color)Application.Current.Resources["InValidInputBackground"];
                }
            }
        }

        public Color BorderColor
        {
            get
            {
                if (!IsEnabled)
                {
                    return (Color)Application.Current.Resources["DisabledInputBorder"];
                }
                if (_validateLock)
                {
                    return Color.Black;
                }
                if (IsValid)
                {
                    return (Color)Application.Current.Resources["ValidInputBorder"];
                }
                else
                {
                    return (Color)Application.Current.Resources["InValidInputBorder"];
                }
            }
        }

        public Color TextColor
        {
            get
            {
                if (typeof(T) == typeof(int))
                {
                    return (int)(object)Value < 1 ? (Color)Application.Current.Resources["PlaceHolderColor"] : Color.Black; 
                }
                return Color.Black;
            }
        }

        private bool _isEnabled = true;
        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }
    }
}
