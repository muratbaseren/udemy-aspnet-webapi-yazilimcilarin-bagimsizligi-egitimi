using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UdemyWebApiEgitimi.DependencyInjection.Models;

namespace UdemyWebApiEgitimi.DependencyInjection.Controllers
{
    public class HomeController : ApiController
    {
        public void Get()
        {
            Bildirim bildirim = Creator.CreateBildirimInstance();
            bildirim.Yap();
            bildirim.Yap2();
        }
    }
}
