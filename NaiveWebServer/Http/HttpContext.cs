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
    public class HttpContext
    {
        public TcpClient client;
        public NetworkStream networkStream;
        public HttpRequest request;
        public HttpResponse response;

        public HttpContext(TcpClient clientSocket)
        {

            this.client = clientSocket;

            NetworkStream stream = client.GetStream();
            byte[] data = new byte[client.ReceiveBufferSize];
            int bytesRead = stream.Read(data, 0, Convert.ToInt32(client.ReceiveBufferSize));
            string requestData = Encoding.ASCII.GetString(data, 0, bytesRead);


            request = new HttpRequest(requestData);
            response = new HttpResponse();
        }



    }
}
