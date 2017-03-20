using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Routing;

namespace UdemyWebApiEgitimi.Routing.Constraints
{
    public class LastLetter : IHttpRouteConstraint
    {
        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName, IDictionary<string, object> values, HttpRouteDirection routeDirection)
        {
            string paramVal = values[parameterName].ToString().ToLower();

            if (paramVal.EndsWith("a") || paramVal.EndsWith("b") || paramVal.EndsWith("c"))
                return true;

            return false;
        }
    }
}