using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lawrukmvc.Helpers
{
    // The legacy route handler, used for getting the HttpHandler for the request   2: public class LegacyRouteHandler : IRouteHandler {   3:     public IHttpHandler GetHttpHandler(RequestContext requestContext) {   4:         return new LegacyHandler(requestContext)   5:     }   6: }   7:     8: // The legacy HttpHandler that handles the request   9: public class LegacyHandler : MvcHandler {  10:     public LegacyHandler(RequestContext requestContext) : base(requestContext) { }  11:    12:     protected override void ProcessRequest(HttpContextBase httpContext) {  13:         string redirectActionName = ((LegacyRoute)RequestContext.RouteData.Route).RedirectActionName;  14:    15:         // ... copy all of the querystring parameters and put them within RouteContext.RouteData.Values  16:    17:         VirtualPathData data = RouteTable.Routes.GetVirtualPath(RouteContext, redirectActionName, RouteContext.RouteData.Values);  18:    19:         httpContext.Status = "301 Moved Permanently";  20:         httpContext.AppendHeader("Location", data.VirtualPath);  21:     }  22: }

}
