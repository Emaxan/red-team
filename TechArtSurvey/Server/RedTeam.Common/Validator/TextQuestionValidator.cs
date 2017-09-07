namespace RedTeam.Common.Validator
{
    public class TextQuestionValidator : IValidator
    {
        public bool ValidateDefaultValue(string value)
        {
            return value == null;
        }
    }
}