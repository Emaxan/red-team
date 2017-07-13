using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace RedTeam.iTechArtSurvay.WebApi.Filters
{
    public class CustomActionAttribute : Attribute, IActionFilter
    {
        /// <summary>Executes the filter action asynchronously.</summary>
        /// <returns>The newly created task for this operation.</returns>
        /// <param name="actionContext">The action context.</param>
        /// <param name="cancellationToken">The cancellation token assigned for this task.</param>
        /// <param name="continuation">The delegate function to continue after the action method is invoked.</param>
        public async Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext,
                                                                        CancellationToken cancellationToken,
                                                                        Func<Task<HttpResponseMessage>> continuation)
        {
            var timer = Stopwatch.StartNew();
            var result = await continuation();
            var seconds = timer.ElapsedMilliseconds/1000.0;
            result.Headers.Add("Elapsed-Time", seconds.ToString());
            return result;
        }

        /// <summary>
        ///     Gets or sets a value indicating whether more than one instance of the indicated attribute can be specified for
        ///     a single program element.
        /// </summary>
        /// <returns>true if more than one instance is allowed to be specified; otherwise, false. The default is false.</returns>
        public bool AllowMultiple => false;
    }
}