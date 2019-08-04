using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace NaiveWebServer
{
    public class Context
    {
        public TcpClient client;
        public NetworkStream clientStream;
        public HttpRequest request;
        public HttpResponse response;
    }
}
