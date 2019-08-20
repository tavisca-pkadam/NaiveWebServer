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
            string responseData = fileReader.ReadFile(this.directory + httpContext.request.location);
            SendResponse(responseData, httpContext);
        }

        public void SendResponse(string responseBody, HttpContext httpContext)
        {

            httpContext.response.UpdateBody(responseBody);

            // Send back a response.
            string content = httpContext.response.body;

            System.IO.StreamWriter writer = new System.IO.StreamWriter(httpContext.client.GetStream());
            writer.Write("HTTP/1.0 200 OK");
            writer.Write(Environment.NewLine);
            writer.Write("Content-Type: text/plain; charset=UTF-8");
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
