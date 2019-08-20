using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using System.Linq.Expressions;
using System.Linq;

namespace NaiveWebServer
{
    public class AppHandlerStrategy
    {


        public static IAppHandler GetHandler(string appType, string directory)
        {

            IAppHandler appHandler;

            if (appType == "static")
            {
                Debug.WriteLine(directory);
                appHandler = new StaticAppHandler(directory);
                return appHandler;
            }
            if (appType == "rest")
            {
                var testAssembly = Assembly.GetExecutingAssembly();
                Type restAppType = testAssembly.GetType("NaiveWebServer."+directory);

                RestApp restApp = (RestApp)Activator.CreateInstance(restAppType);

                appHandler = new RestApiHandler(restApp);
                return appHandler;
            }
            return null;
        }

   
    }
}
