using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Ninject;

using RedTeam.Logger;
using RedTeam.Logger.Interfaces;

namespace RedTeam.TechArtSurvey.WebApi.Utils
{
    public class TechArtSurveyLoggerHandler : DelegatingHandler
    {

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var stopWath = Stopwatch.StartNew();
            var response = await base.SendAsync(request, cancellationToken);
            stopWath.Stop();
            var req = $"{request.Method.Method} {request.RequestUri} HTTP{request.Version}.".PadRight(90);
            var time = $"Handled by {stopWath.ElapsedMilliseconds} ms.".PadRight(25);
            LoggerContext.GetLogger.Info($"Process request: {req} {time} Response: HTTP{response.Version} {response.StatusCode}");

            return response;
        }

    }
}