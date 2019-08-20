using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace NaiveWebServer
{
    class StaticAppHandler : IAppHandler
    {
        private string directory;
        private FileReader fileReader;

        public StaticAppHandler(string directory)
        {
            this.fileReader = new FileReader();
            this.directory = directory;
        }
       

        public void HandleRequest(HttpContext httpContext)
        {
            httpContext.response.contentType = "text/plain; charset=UTF-8";
            string responseData = fileReader.ReadFile(this.directory + httpContext.request.location);
            SendResponse(responseData, httpContext);
        }

        public void SendResponse(string responseBody, HttpContext httpContext)
        {

            httpContext.response.UpdateBody(responseBody);
            httpContext.SendResponseToClient();

        }

    }
}
