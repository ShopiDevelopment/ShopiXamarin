namespace ShopiXamarin.Validations
{
    public interface IValidity
    {
        bool IsValid { get; set; }

        bool Validate();
    }
}
