using System.Text.RegularExpressions;

namespace ShopiXamarin.Validations
{
    public class IsEmailValideRule<T> : IValidationRule<T>
    {
        private string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
               + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
               + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
        private Regex ValidEmailRegex;
        public IsEmailValideRule()
        {
            ValidEmailRegex = new Regex(validEmailPattern, RegexOptions.IgnoreCase);
        }

        public string ValidationMessage { get; set; }

        public int Priority { get; set; }

        public bool Check(T value)
        {
            if (value is string s)
                return ValidEmailRegex.IsMatch(s);
            else
                return false;
        }
    }
}
