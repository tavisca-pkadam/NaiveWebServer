using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace NaiveWebServer
{
    public class WebApp
    {
        public string name;
        public string location;
        public string directory;
        public IAppHandler appHandler;

        public WebApp(string name, string location, string directory, string appType)
        {

            this.name = name;
            this.location = location;
            this.directory = directory;
            this.appHandler = AppHandlerStrategy.GetHandler(appType, directory);
        }

        public void ForwardRequestToHandler(HttpContext httpContext)
        {

            try
            {
                this.appHandler.HandleRequest(httpContext);

            }catch(NullReferenceException nullException)
            {
                Debug.WriteLine(nullException.Message);
            }
        }

    }
}
