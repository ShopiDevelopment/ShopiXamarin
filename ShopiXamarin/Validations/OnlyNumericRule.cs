using System;
using System.Linq;

namespace ShopiXamarin.Validations
{
    public class OnlyNumericRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public int Priority { get; set; }

        public bool Check(T value)
        {
            if (value is string s)
            {
                return s.All(char.IsDigit);
            }
            return false;
        }
    }
}
