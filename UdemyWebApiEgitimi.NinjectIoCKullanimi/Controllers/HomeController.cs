using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UdemyWebApiEgitimi.NinjectIoCKullanimi.App_Start;
using UdemyWebApiEgitimi.NinjectIoCKullanimi.Models;

namespace UdemyWebApiEgitimi.NinjectIoCKullanimi.Controllers
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
            //IBildirim bildirim = NinjectHelper.Kernel.Get<IBildirim>();
            //bildirim.Gonder();

            //BildirimManager bm = new BildirimManager(NinjectHelper.Kernel.Get<IBildirim>());

            //BildirimManager bm = NinjectHelper.Kernel.Get<BildirimManager>();
            //bm.BildirimYap();

            //BildirimManager bm = NinjectWebCommon.bootstrapper.Kernel.Get<BildirimManager>();

            _bildirim.Gonder();

            return Ok();
        }
    }
}
