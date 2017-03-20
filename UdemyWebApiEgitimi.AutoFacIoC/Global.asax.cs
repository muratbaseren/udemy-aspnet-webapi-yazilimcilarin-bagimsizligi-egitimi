
using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using UdemyWebApiEgitimi.AutoFacIoC.Models;

namespace UdemyWebApiEgitimi.AutoFacIoC
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static IContainer Container;

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var builder = new ContainerBuilder();
            builder.RegisterType<SmsBildirimi>().As<IBildirim>().SingleInstance();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            Container = builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver =
                new AutofacWebApiDependencyResolver(Container);
        }
    }
}
