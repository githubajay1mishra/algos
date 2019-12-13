using System;
using System.IO;
using System.Reflection;

namespace algos.test
{
    public class TestUtils
    {
        public static string GetTestDirectory()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }
    }
}