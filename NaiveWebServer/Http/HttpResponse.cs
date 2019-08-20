using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Diagnostics;

namespace NaiveWebServer
{
    public class HttpResponse:IResponse
    {
      
        public string httpVersion = "HTTP/1.1";
        public string contentType = "text/html";
        public string contentLength;
        public string body;

        public void UpdateBody(string body)
        {
            this.body = body;
        }

        


    }
}
