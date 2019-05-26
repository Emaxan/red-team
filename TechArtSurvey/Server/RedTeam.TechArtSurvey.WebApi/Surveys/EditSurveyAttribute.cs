using System;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace RedTeam.TechArtSurvey.WebApi.Surveys
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
    public class EditSurveyAttribute : ParameterBindingAttribute
    {
        public override HttpParameterBinding GetBinding(HttpParameterDescriptor parameter)
        {
            if (parameter == null)
                throw new ArgumentException("Invalid parameter");

            return new EditSurveyModelBinding(parameter);
        }
    }
}