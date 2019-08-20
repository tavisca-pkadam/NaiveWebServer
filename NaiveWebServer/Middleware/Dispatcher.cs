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
            webApp.ForwardRequestToHandler(httpContext);
        }


        public void SendInvalidWebAppResponse(HttpContext httpContext)
        {
            httpContext.response.UpdateBody("Invalid Response");

            string content = httpContext.response.body;

            System.IO.StreamWriter writer = new System.IO.StreamWriter(httpContext.client.GetStream());
            writer.Write("HTTP/1.0 200 OK");
            writer.Write(Environment.NewLine);
            writer.Write("Content-Type: application/json; charset=UTF-8");
            writer.Write(Environment.NewLine);
            writer.Write("Content-Length: " + content.Length);
            writer.Write(Environment.NewLine);
            writer.Write(Environment.NewLine);
            writer.Write(content);
            writer.Flush();
            httpContext.client.Close();
        }
    }
}
