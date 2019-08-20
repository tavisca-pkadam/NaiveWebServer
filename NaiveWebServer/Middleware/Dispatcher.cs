using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace NaiveWebServer
{
    public class Dispatcher
    {
        public WebAppsHandler webAppsHandler;
        public Dispatcher(WebAppsHandler webAppsHandler)
        {

            this.webAppsHandler = webAppsHandler;
        }
        public void RouteToWebApp(HttpContext httpContext)
        {
            WebApp webApp = webAppsHandler.GetWebAppByLocation(httpContext.request.location);
            if(webApp == null)
            {
                SendInvalidWebAppResponse(httpContext);
            }
            else{
                webApp.ForwardRequestToHandler(httpContext);
            }
        }


        public void SendInvalidWebAppResponse(HttpContext httpContext)
        {
            httpContext.response.contentType = "text/plain; charset=UTF-8";
            httpContext.response.UpdateBody("Invalid Response");
            httpContext.SendResponseToClient();

        }
    }
}
