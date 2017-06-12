using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace SockMin.Helpers
{
    public static class FileHelpers
    {
        public static string getResourceAsString(string resource, string filename)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = $"SockMin.Web.{resource}.{filename}";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

    }
}