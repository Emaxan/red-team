using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace RedTeam.TechArtSurvey.WebApi.Filters
{
    public class ArrayExceptionAttribute : Attribute, IExceptionFilter
    {
        /// <summary>Executes an asynchronous exception filter.</summary>
        /// <returns>An asynchronous exception filter.</returns>
        /// <param name="actionExecutedContext">The action executed context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task ExecuteExceptionFilterAsync(HttpActionExecutedContext actionExecutedContext,
            CancellationToken cancellationToken)
        {
            if (actionExecutedContext.Exception != null &&
                actionExecutedContext.Exception is IndexOutOfRangeException)
                actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest,
                    "Элемент вне диапазона");
            return Task.FromResult<object>(null);
        }

        /// <summary>
        ///     Gets or sets a value indicating whether more than one instance of the indicated attribute can be specified for
        ///     a single program element.
        /// </summary>
        /// <returns>true if more than one instance is allowed to be specified; otherwise, false. The default is false.</returns>
        public bool AllowMultiple => true;
    }
}