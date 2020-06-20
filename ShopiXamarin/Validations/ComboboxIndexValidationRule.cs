using System;
namespace ShopiXamarin.Validations
{
    public class ComboboxIndexValidationRule : IValidationRule<int>
    {
        public string ValidationMessage { get; set; }

        public int Priority { get; set; }

        public bool Check(int value)
        {
            return value > 0;
        }
    }
}
