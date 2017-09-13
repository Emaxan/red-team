namespace RedTeam.Common.Validator
{
    public class FakeValidator : IValidator
    {
        public bool ValidateDefaultValue(string value)
        {
            return true;
        }
    }
}