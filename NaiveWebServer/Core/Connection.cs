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
    public class Connection
    {
        public ServerConfiguration _serverConfiguration;
        public TcpListener _serverListener;
        public Thread listenerThread;
        public event Action<TcpClient> OnNewClientConnection;

        public Connection(ServerConfiguration serverConfiguration)
        {
            _serverConfiguration = serverConfiguration;
            _serverListener = new TcpListener(IPAddress.Parse(_serverConfiguration.server_domain),
                                                                    _serverConfiguration.server_port);
        }
        public bool TryStartListening()
        {

            try
            {
                _serverListener.Start();
                Console.WriteLine($"Server has started on {_serverConfiguration.server_domain} { _serverConfiguration.server_port} Waiting for a connection...");
                KeepAcceptingClients();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void KeepAcceptingClients()
        {

            listenerThread = new Thread(_ =>
            {
                while (true)
                {
                    TcpClient clientSocket = _serverListener.AcceptTcpClient();
                    OnNewClientConnection(clientSocket);
                }
            });
            listenerThread.Start();
        }

        public bool TryStopListening()
        {

            try
            {
                this.listenerThread?.Abort();
                this._serverListener.Stop();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}
