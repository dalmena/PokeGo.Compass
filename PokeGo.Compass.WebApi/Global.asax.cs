﻿using PokeGo.Compass.WebApi.App_Start;
using System.Web.Http;

namespace PokeGo.Compass.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
