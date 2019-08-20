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


        public void SendResponseToClient()
        {
            System.IO.StreamWriter writer = new System.IO.StreamWriter(this.client.GetStream());
            writer.Write("HTTP/1.0 200 OK");
            writer.Write(Environment.NewLine);
            writer.Write("Content-Type: "+this.response.contentType);
            writer.Write(Environment.NewLine);
            writer.Write("Content-Length: " + this.response.body.Length);
            writer.Write(Environment.NewLine);
            writer.Write(Environment.NewLine);
            writer.Write(this.response.body);
            writer.Flush();
            
            this.client.Close();
        }



    }
}
