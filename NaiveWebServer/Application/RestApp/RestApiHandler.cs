using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace NaiveWebServer
{
    public class RestApiHandler : IAppHandler
    {
        public IRestApp restApp;
        private string directory;

        public RestApiHandler(IRestApp restApp)
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

            httpContext.response.UpdateBody(responseBody);

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
