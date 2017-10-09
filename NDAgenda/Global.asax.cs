using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using Castle.Windsor;
using Castle.Windsor.Installer;
using NDAgenda.Infra;

namespace NDAgenda
{
    public class Global : HttpApplication
    {

        private static IWindsorContainer _container; 

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            RegisterWindsor();
        }

        protected void Application_End()
        {
            _container.Dispose();
        }

        private static void RegisterWindsor()
        {
            _container = new WindsorContainer()
                .Install(FromAssembly.This());
            var windsorControllerFactory = new WindsorControllerFactory(_container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(windsorControllerFactory);
           
        }
    }
}