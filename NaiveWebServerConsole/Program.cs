﻿using System;
using NaiveWebServer;

namespace NaiveWebServerConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            WebServer webServer = new WebServer();
            webServer.Start();
            Console.WriteLine("Web Server Started");

            var  staticWebApp = new WebApp("google", "/google/", @"C:\Users\pakadam\Documents\server", "static");
            //staticWebApp.location = "/google/";
            //staticWebApp.directory = @"C:\Users\pakadam\Documents\server\C.gitignore";
            webServer.webAppsHandler.Add(staticWebApp);

            var restWebApp = new WebApp("leapyearrestapp", "/leapyearrestapp", @"LeapYearRestApp", "rest");
            webServer.webAppsHandler.Add(restWebApp);

            Console.ReadKey(true);

            webServer.Stop();
            Console.WriteLine("Web Server was Stopped");
            Console.ReadKey(true);

        }
    }
}
