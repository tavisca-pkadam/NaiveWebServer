using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace NaiveWebServer
{
    
    public class HttpRequest : IRequest
    {
        public RequestType methodType { get; private set; }
        public string location { get; private set; }
        public string body { get; private set; }

        Dictionary<string, string> tokens;

        public HttpRequest(string data)
        {
            this.body = "";
            ParseRequestData(data);
            this.tokens = new Dictionary<string, string>();
        }

        public void ParseRequestData(string data)
        {
            bool isData = false;
            var dataNewLineSplit = data.Split('\n');
            for (int index = 0; index < dataNewLineSplit.Length; index++)
            {
                if (index == 0)
                {
                    var urlHeader = dataNewLineSplit[index].Split(' ');

                    #region Parse Method Type
                    if (urlHeader[0] == "GET")
                    {
                        this.methodType = RequestType.Get;
                    }
                    else if (urlHeader[0] == "POST")
                    {
                        this.methodType = RequestType.Post;
                    }
                    else if (urlHeader[0] == "PUT")
                    {
                        this.methodType = RequestType.Put;
                    }
                    else if (urlHeader[0] == "OPTION")
                    {
                        this.methodType = RequestType.Option;
                    }
                    #endregion

                    #region Parse Location

                    this.location = urlHeader[1];

                    #endregion

               
                }
                if (dataNewLineSplit[index].Contains("{") || isData == true)
                {
                    isData = true;
                    this.body += dataNewLineSplit[index];

                }
            }
        }
    }
}
