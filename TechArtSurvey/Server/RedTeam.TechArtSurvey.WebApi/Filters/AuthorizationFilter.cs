using Ninject;
using RedTeam.TechArtSurvey.Foundation.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.Results;
using RedTeam.TechArtSurvey.Foundation.Dto.AccountDto;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;
namespace RedTeam.TechArtSurvey.WebApi.Filters
{

    public class AuthorizationAttribute : AuthorizeAttribute
    {
        private IAccountService _accountService;
        private const string _authCookieName = "AUTHENTICATION";

        [Inject]
        public IAccountService AccountService
        {
            get { return _accountService; }
            set { _accountService = value; }
        }



        //public override void OnAuthorization(HttpActionContext actionContext)
        //{
        //    var httpContext = HttpContext.Current;
        //    httpContext.User = new GenericPrincipal(new GenericIdentity(""), null);
        //    if (httpContext.Request.Cookies[_authCookieName] != null)
        //    {
        //        //must be compared with db:
        //        string token = httpContext.Request.Cookies[_authCookieName]["token"];
        //        var result = _accountService.AuthorizeByTokenAsync(token).Result;
        //        if (result.Code == ServiceResponseCodes.Ok)
        //        {
        //            var user = result.Content as AuthorizeDto;
        //            httpContext.User = new GenericPrincipal(new GenericIdentity(user.Email), user.Roles);
        //        }
        //        else
        //        {
        //            httpContext.User = new GenericPrincipal(new GenericIdentity(""), null);
        //        }
        //    }

        //    if (!SkipAuthorization(actionContext) && httpContext.User == null)
        //    {
        //        actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
        //    }
        //}
        private static bool SkipAuthorization(HttpActionContext actionContext)
        {
            Contract.Assert(actionContext != null);
            return actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any()
                   || actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
        }

    }
}