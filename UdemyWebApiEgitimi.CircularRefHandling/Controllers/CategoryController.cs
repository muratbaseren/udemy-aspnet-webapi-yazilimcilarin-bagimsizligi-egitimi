using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UdemyWebApiEgitimi.CircularRefHandling.Controllers
{
    public class CategoryController : ApiController
    {
        NorthwindEntities db = new NorthwindEntities();

        public IEnumerable<Category> Get()
        {
            db.Configuration.ProxyCreationEnabled = false;

            return db.Categories.Include("Products").ToList();
        }
    }
}
