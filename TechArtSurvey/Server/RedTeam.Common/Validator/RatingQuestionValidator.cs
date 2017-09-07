namespace RedTeam.Common.Validator
{
    public class RatingQuestionValidator : IValidator
    {
        public bool ValidateDefaultValue(string value)
        {
            return !(int.TryParse(value, out int stars) && (0 >= stars || stars <= 5));
        }
    }
}