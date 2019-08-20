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
    public class LeapYearRestApp : IRestApp
    {
        public LeapYearRestApp()
        {
            this.listOfMethods = new Dictionary<string, MethodInfo>();

            CreateListOfMethods();
        }

        public string GetLeapYear()
        {
            // Return 10 LeapYears
            if (this.IsALeapYearCheck(Int32.Parse(jsonBody["year"].ToString())))
            {
                Dictionary<string, string> myDictionary1 = new Dictionary<string, string>()
                {
                    {"message","It Is A Leap Year" }
                };
                return JsonConvert.SerializeObject(myDictionary1);

            }

            Dictionary<string, string> myDictionary2 = new Dictionary<string, string>()
                {
                    {"message","It Is Not A Leap Year" }
                };
            return JsonConvert.SerializeObject(myDictionary2);

        }

        public string PostIsALeapYear()
        {
            if (this.IsALeapYearCheck(Int32.Parse(jsonBody["year"].ToString())))
            {
                Dictionary<string, string> myDictionary1 = new Dictionary<string, string>()
                {
                    {"message","It Is A Leap Year" }
                };
                return JsonConvert.SerializeObject(myDictionary1);

            }

            Dictionary<string, string> myDictionary2 = new Dictionary<string, string>()
                {
                    {"message","It Is Not A Leap Year" }
                };
            return JsonConvert.SerializeObject(myDictionary2);


        }

        public bool IsALeapYearCheck(int year)
        {
            if (year % 100 == 0)
            {
                return false;
            }
            if (year % 4 == 0)
            {
                return true;
            }
            return false;
        }
    }
}