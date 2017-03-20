using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UdemyWebApiEgitimi.NinjectIoCKullanimi.Models
{
    public static class NinjectHelper
    {
        public static IKernel Kernel { get; private set; }

        public static void Configure()
        {
            Kernel = new StandardKernel();
            Kernel.Bind<IBildirim>().To<SmsBildirimi>().InSingletonScope();
        }
    }
}