using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace NaiveWebServer
{
    public class WebAppsHandler
    {
        readonly List<WebApp> webAppList;

        public WebAppsHandler()
        {
            webAppList = new List<WebApp>();
        }

        public bool Add(WebApp webApp)
        {
            webAppList.Add(webApp);
            return true;
        }

        public WebApp GetWebAppByLocation(string webAppLocation)
        {

            WebApp webApp = null;
            string regex = webAppLocation.Split("/")[1];
                    webAppList.ForEach(x => Debug.WriteLine(x.location));
            try
            {
                webApp = webAppList.First(x => x.location.StartsWith("/" + regex));
            }
            catch(ArgumentNullException argumentException)
            {
                Debug.WriteLine(argumentException.Message);
                return null;
            }


            return webApp;
        }
    }
}
