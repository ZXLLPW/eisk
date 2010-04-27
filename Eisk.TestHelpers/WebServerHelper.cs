using System;
using System.IO;
using System.Configuration;
using System.Diagnostics;

namespace Eisk.TestHelpers
{
    
    public sealed class WebServerHelper
    {
        WebServerHelper() { }
        //static Process server;

        public static void StartWebServer()
        {
            if (Process.GetProcessesByName("WebDev.WebServer40").Length == 0)
            {
                string webServerExePath = (string)ConfigurationManager.AppSettings["WebServerExePath"];
                
                if (webServerExePath == null)
                    webServerExePath = @"C:\Program Files (x86)\Common Files\microsoft shared\DevServer\10.0\WebDev.WebServer40.exe";
                
                Process.Start(webServerExePath, GetWebServerArguments());
            }
        }

        public static void StopWebServer()
        {
            if (Process.GetProcessesByName("WebDev.WebServer40").Length > 0)
            {
                Process.GetProcessesByName("WebDev.WebServer40")[0].Kill();
            }
        }

        static string GetWebServerArguments()
        {
            string args = String.Format(System.Globalization.CultureInfo.CurrentCulture, "/port:{0} /path:\"{1}\" /vpath:\"{2}\"", GetPort(), GetWebApplicationPath(), GetVPath());
            return args;
        }

        static string GetVPath()
        {
            return "/Eisk.Web";
        }

        static string GetPort()
        {
            return "3238";
        }

        static string GetWebApplicationPath()
        {
            FileInfo f = new FileInfo(@"..\..\..\..\Eisk.Web");
            return f.FullName;
        }
    }

}