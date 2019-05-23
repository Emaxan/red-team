using System.Collections.Generic;
using JetBrains.Annotations;
using System.ComponentModel.DataAnnotations;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto.Questions
{
    [UsedImplicitly]
    public class MatrixDto : QuestionDto
    {
        public ICollection<MatrixElemDto> Rows { get; set; }

        public ICollection<MatrixElemDto> Columns { get; set; }
    }
}