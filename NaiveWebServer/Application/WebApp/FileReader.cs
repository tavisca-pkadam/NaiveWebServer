using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Diagnostics;

namespace NaiveWebServer
{
    class FileReader
    {
        private const string invalidFileResponse = "Resource Not Found";

        public string ReadFile(string filePath)
        {
            Debug.WriteLine(filePath);
            filePath = filePath.Replace("/", "\\");

            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }
            return invalidFileResponse;
        }


    }
}
