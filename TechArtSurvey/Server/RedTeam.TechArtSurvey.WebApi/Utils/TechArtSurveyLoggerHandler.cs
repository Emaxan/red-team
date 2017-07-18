﻿using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Ninject;
using RedTeam.Logger.Interfaces;

namespace RedTeam.TechArtSurvey.WebApi.Utils
{
    public class TechArtSurveyLoggerHandler : DelegatingHandler
    {
        private readonly ILog _log;

        public TechArtSurveyLoggerHandler()
        {
            _log = NinjectDependencyResolver.Kernel.Get<ILog>();
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var stopWath = Stopwatch.StartNew();
            var response = await base.SendAsync(request, cancellationToken);
            stopWath.Stop();
            _log.Info($"Process request: {request.Method.Method} {request.RequestUri} HTTP{request.Version}. Handled by {stopWath.ElapsedMilliseconds} ms. Response: HTTP{response.Version} {response.StatusCode}");

            return response;
        }
    }
}