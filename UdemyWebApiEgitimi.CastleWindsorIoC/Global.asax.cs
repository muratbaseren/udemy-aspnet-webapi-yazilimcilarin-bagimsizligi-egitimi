using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using UdemyWebApiEgitimi.CastleWindsorIoC.App_Start;
using UdemyWebApiEgitimi.CastleWindsorIoC.Models;

namespace UdemyWebApiEgitimi.CastleWindsorIoC
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static IWindsorContainer Container;

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            Container = new WindsorContainer();
            Container.Install(FromAssembly.This());

            Container.Register(
                Component.For<IBildirim>().ImplementedBy<SmsBildirimi>().LifestyleTransient());

            GlobalConfiguration.Configuration.DependencyResolver = 
                new WindsorDependencyResolver(Container);
        }
    }
}
