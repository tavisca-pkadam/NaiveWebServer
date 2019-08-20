using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace NaiveWebServer
{
    public class RestApiHandler : IAppHandler
    {
        public RestApp restApp;
        private string directory;

        public RestApiHandler(RestApp restApp)
        {
            this.restApp = restApp;
        }

        public void HandleRequest(HttpContext httpContext)
        {
            string responseData = this.restApp.MatchRequestTypeToFunction(httpContext);
            SendResponse(responseData, httpContext);
        }
        public void SendResponse(string responseBody, HttpContext httpContext)
        {
            httpContext.response.contentType = "application/json; charset=UTF-8";
            httpContext.response.UpdateBody(responseBody);
            httpContext.SendResponseToClient();
        }
        
    }
}
