using System.Collections.Generic;

namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys.Questions
{
    public class Matrix : Question
    {
        public ICollection<MatrixRow> MatrixRows { get; set; }

        public ICollection<MatrixCol> MatrixCols { get; set; }
    }
}