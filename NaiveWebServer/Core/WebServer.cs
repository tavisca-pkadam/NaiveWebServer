using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace NaiveWebServer
{
    public class WebServer
    {
        public ServerGateway serverGateway;
        public Connection connection;
        public ServerConfiguration serverConfiguration;
        public Dispatcher dispatcher;
        public WebAppsHandler webAppsHandler;

        public WebServer()
        {

            serverConfiguration = new ServerConfiguration();
            webAppsHandler = new WebAppsHandler();

            connection = new Connection(serverConfiguration);
            dispatcher = new Dispatcher(webAppsHandler);
            serverGateway = new ServerGateway(connection, dispatcher);
        }

        public void Start()
        {
            

            serverGateway.Enable();
        }

        public void Stop()
        {
            

            serverGateway.Disable();
        }
    }
}
