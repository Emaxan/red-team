namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto
{
    public class QuestionAnswerDto
    {
        public int ReplyOnSurveyId { get; set; }

        public int QuestionId { get; set; }

        public string Value { get; set; }

        public QuestionDto Question { get; set; }

        public SurveyResponseDto SurveyResponse { get; set; }
    }
}