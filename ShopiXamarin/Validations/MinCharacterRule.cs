using System;
namespace ShopiXamarin.Validations
{
    public class MinCharacterRule<T> : IValidationRule<T>
    {
        private int _minCharacter;
        public MinCharacterRule(int minCharacter)
        {
            _minCharacter = minCharacter;
        }
        public string ValidationMessage { get; set; }

        public int Priority { get; set; }

        public bool Check(T value)
        {
            if (value is string s)
            {
                return s.Length >= _minCharacter;
            }
            return false;
        }
    }
}
