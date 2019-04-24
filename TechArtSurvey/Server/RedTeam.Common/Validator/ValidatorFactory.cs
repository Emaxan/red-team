using System;
using JetBrains.Annotations;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;

namespace RedTeam.Common.Validator
{
    [UsedImplicitly]
    public class ValidatorFactory : IValidatorFactory
    {
        public IValidator GetValidator(QuestionTypes type)
        {
            switch(type)
            {
                case QuestionTypes.Checkbox:
                case QuestionTypes.RadioGroup:
                    return new FakeValidator();
                case QuestionTypes.Text:
                    return new TextQuestionValidator();
                case QuestionTypes.Rating:
                    return new RatingQuestionValidator();
                case QuestionTypes.Comment:
                    throw new NotImplementedException(); // TODO
                case QuestionTypes.Dropdown:
                    throw new NotImplementedException();
                case QuestionTypes.Boolean:
                    throw new NotImplementedException();
                case QuestionTypes.Matrix:
                    throw new NotImplementedException();
                case QuestionTypes.BarRating:
                    throw new NotImplementedException();
                case QuestionTypes.DatePicker:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}