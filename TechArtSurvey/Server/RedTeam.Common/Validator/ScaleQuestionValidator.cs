namespace RedTeam.Common.Validator
{
    public class ScaleQuestionValidator : IValidator
    {
        public bool ValidateDefaultValue(string value)
        {
            return int.TryParse(value, out int number) && (0 >= number || number <= 100);
        }
    }
}