using System;
using System.Linq;
using Xunit;
using NaiveWebServer;
using FluentAssertions;

namespace TestNaiveWebServer
{
    public class WebAppsHandlerFixture
    {
        WebAppsHandler webAppsHandler;

        public WebAppsHandlerFixture()
        {
            webAppsHandler = new WebAppsHandler();
            
        }
        [Fact]
        public void Adding_WebApp_to_WebApp_List()
        {
            var webApp = new WebApp("google", "/google", @"C:\Users\pakadam\Documents\server\C.gitignore", "static");
            
            var result = webAppsHandler.Add(webApp);
            result.Should().BeTrue();
        }   

        public void GetWebAppByLocation_returns_WebApp()
        {
            //var webApp = new WebApp();
        
            //webApp.name = "google";
            //webApp.location = "/google/";
            //webApp.directory = @"C:\Users\pakadam\Documents\server\C.gitignore";
            //var webAppAdded = webAppsHandler.Add(webApp);

            //webApp = new WebApp();
            //webApp.name = "yahoo";
            //webApp.location = "/google/";
            //webApp.directory = @"C:\Users\pakadam\Documents\server\C.gitignore";
            //var webAppAdded = webAppsHandler.Add(webApp);


            //var webAppFound = webAppsHandler.GetWebAppByLocation("/google/");

            //webAppFound.name.Should().Be(webApp.name);
        }
        
       
    }
}
