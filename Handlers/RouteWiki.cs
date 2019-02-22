using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Conceptos2Mvc.Handlers
{
    public class RouteWiki : IRouteHandler
    {
        private List<String> provincias;

        public RouteWiki(List<String> provincias)
        {
            this.provincias = provincias;
        }
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new HandlerWiki(this.provincias, requestContext);
        }
    }
}