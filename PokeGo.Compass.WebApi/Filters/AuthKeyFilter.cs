using Ninject;
using Ninject.Syntax;
using PokeGo.Compass.Core.Providers;
using PokeGo.Compass.Core.Repositories;
using PokeGo.Compass.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace PokeGo.Compass.WebApi.Attributes
{
    public class AuthKeyRequiredAttribute : Attribute {}

    public class AuthKeyFilter : AuthorizeAttribute
    {
        private readonly IResolutionRoot _resolutionRoot;

        public AuthKeyFilter(IResolutionRoot resolutionRoot)
        {
            _resolutionRoot = resolutionRoot;
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (!ShouldAuthenticate(actionContext))
                return;
             
            if(Authorize(actionContext))
                return;

            HandleUnauthorizedRequest(actionContext);
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            var challengeMessage = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            challengeMessage.Headers.Add("WWW-Authenticate", "Basic");
            throw new HttpResponseException(challengeMessage);
        }

        private bool ShouldAuthenticate(HttpActionContext actionContext)
        {
            return actionContext.ActionDescriptor.GetCustomAttributes<AuthKeyRequiredAttribute>(true).Count > 0 ||
                actionContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes<AuthKeyRequiredAttribute>(true).Count > 0;
        }

        private bool Authorize(HttpActionContext actionContext)
        {
            try
            {
                var loginService = _resolutionRoot.Get<ILoginService>();

                IEnumerable<string> values;

                actionContext.Request.Headers.TryGetValues("X-AUTH-KEY", out values);

                if (!values.Any())
                {
                    return false;
                }

                loginService.DoLoginByAuthKey(values.First());

                return true;
           }
           catch (Exception)
           {
               return false;
           }
        }

    }
}