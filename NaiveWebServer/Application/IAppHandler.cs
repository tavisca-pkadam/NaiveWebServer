using System;
using System.Collections.Generic;
using System.Text;

namespace NaiveWebServer
{
    public interface IAppHandler
    {
        void HandleRequest(HttpContext httpContext);

        void SendResponse(string responseBody, HttpContext httpContext);

    }
}
