using System;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Reflection;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Linq.Expressions;
using System.Diagnostics;

namespace NaiveWebServer
{
    public abstract class RestApp
    {
        public Dictionary<string, MethodInfo> listOfMethods;
        public JObject jsonBody;

        public void CreateListOfMethods()
        {
            MethodInfo[] methodInfos = typeof(LeapYearRestApp).GetMethods();
            foreach (var method in methodInfos)
            {
                listOfMethods.Add(method.Name.ToLower(), method);
                Debug.WriteLine($"LeapYearRestApp -> LeapYearRestApp method.Name{ method.Name.ToLower()}");
            }
        }

        public string MatchRequestTypeToFunction(HttpContext httpContext)
        {

            this.jsonBody = JObject.Parse(httpContext.request.body);



            string location = httpContext.request.location.Replace("/leapyearrestapp/", "");


            string requestType = "";
            if (httpContext.request.methodType == RequestType.Get)
            {
                requestType = "get";
            }
            if (httpContext.request.methodType == RequestType.Post)
            {
                requestType = "post";
            }


            try
            {
                object[] mParam = new object[] { };

                var method = this.listOfMethods.First(x => x.Key == requestType + location);
                Debug.WriteLine($"LeapYearRestApp -> MatchRequestTypeToFunction requestType+location{requestType + location} method{method.Key}");

                return method.Value.Invoke(this, mParam).ToString();
            }
            catch (System.Exception)
            {
                Dictionary<string, string> myDictionary = new Dictionary<string, string>()
            {
                {"message","Method Not Found" }
            };

                return JsonConvert.SerializeObject(myDictionary);
            }
        }

    }

}