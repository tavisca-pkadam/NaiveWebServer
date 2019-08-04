using System;
using System.Collections.Generic;
using System.Text;

namespace NaiveWebServer
{
    public class HttpResponse
    {
        // HTTP/1.0 200 OK
        // Date: Fri, 08 Aug 2003 08:12:31 GMT
        // Server: Apache/1.3.27 (Unix)
        // MIME-version: 1.0
        // Last-Modified: Fri, 01 Aug 2003 12:45:26 GMT
        // Content-Type: text/html
        // Content-Length: 2345
        // * a blank line *
        // <HTML> ...
        public string httpVersion = "HTTP/1.0";
        public IHttpStatusCode httpStatusCode;
        public string contentType = "text/html";
        public string contentLength;
        public string body;
    }
}
