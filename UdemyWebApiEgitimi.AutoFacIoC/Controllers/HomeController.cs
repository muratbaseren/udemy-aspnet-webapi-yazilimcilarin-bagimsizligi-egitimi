using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using UdemyWebApiEgitimi.AutoFacIoC.Models;

namespace UdemyWebApiEgitimi.AutoFacIoC.Controllers
{
    public class HomeController : ApiController
    {
        private IBildirim _bildirim;

        public HomeController(IBildirim bildirim)
        {
            _bildirim = bildirim;
        }

        public IHttpActionResult Get()
        {
            //IBildirim bildirim = WebApiApplication.Container.Resolve<IBildirim>();
            //bildirim.Gonder();

            _bildirim.Gonder();

            return Ok();
        }
    }
}
