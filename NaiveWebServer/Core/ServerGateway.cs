using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;


namespace NaiveWebServer
{
    public class ServerGateway
    {
        public Listener connection;
        public Dispatcher dispatcher;

        public ServerGateway(Listener connection, Dispatcher dispatcher)
        {
            this.connection = connection;
            this.dispatcher = dispatcher;

            connection.OnNewClientConnection += HandleNewSocketConnection;

        }
        public void Enable()
        {
            this.connection.TryStartListening();
        }

        public void Disable()
        {
            this.connection.TryStopListening();
        }

        public void HandleNewSocketConnection(TcpClient clientSocket)
        {

            HttpContext httpContext = NewSocketConnectionToHttpContext(clientSocket);
            ForwardSocketToDispatcher(httpContext);
        }

        public HttpContext NewSocketConnectionToHttpContext(TcpClient clientSocket)
        {
            HttpContext context = new HttpContext(clientSocket);
            return context;
        }

        public void ForwardSocketToDispatcher(HttpContext httpContext)
        {
            this.dispatcher.RouteToWebApp(httpContext);
        }
    }
}
