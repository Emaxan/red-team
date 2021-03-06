﻿using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;

namespace RedTeam.TechArtSurvey.WebApi.Surveys
{
    public class EditSurveyModelBinding : HttpParameterBinding
    {
        public EditSurveyModelBinding(HttpParameterDescriptor descriptor)
            : base(descriptor)
        {

        }


        public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider,
            HttpActionContext actionContext,
            CancellationToken cancellationToken)
        {
            var binding = actionContext
                .ActionDescriptor
                .ActionBinding;

            if (binding.ParameterBindings.Length > 1 ||
                actionContext.Request.Method == HttpMethod.Get)
                return EmptyTask.Start();

            var type = binding
                .ParameterBindings[0]
                .Descriptor.ParameterType;

            if (type == typeof(string))
            {
                return actionContext.Request.Content
                    .ReadAsStringAsync()
                    .ContinueWith((task) =>
                    {
                        var stringResult = task.Result;
                        SetValue(actionContext, stringResult);
                    }, cancellationToken);
            }
            else if (type == typeof(byte[]))
            {
                return actionContext.Request.Content
                    .ReadAsByteArrayAsync()
                    .ContinueWith((task) =>
                    {
                        byte[] result = task.Result;
                        SetValue(actionContext, result);
                    }, cancellationToken);
            }

            throw new InvalidOperationException("Only string and byte[] are supported for [EditSurvey] parameters");
        }

        public override bool WillReadBody
        {
            get
            {
                return true;
            }
        }
    }
}