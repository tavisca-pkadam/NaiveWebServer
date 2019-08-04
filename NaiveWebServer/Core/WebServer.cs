using System;
using System.Collections.Generic;
using System.Text;

namespace NaiveWebServer
{
    public class WebServer
    { 
        public Connection connection;
        public ServerConfiguration serverConfiguration;
        public WebServer()
        {
            connection = new Connection(serverConfiguration);
        }
    }
}
