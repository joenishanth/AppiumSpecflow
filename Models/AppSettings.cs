using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppiumSpecflow.Models
{
    public class AppSettings
    {
        public Uri RemoteServerAddress { get; set; }
        public string PlatformName { get; set; }
        public string PlatformVersion { get; set; }
        public string DeviceName { get; set; }
        public string App { get; set; }
        public string AutomationName { get; set; }
        public string AppPackage { get; set; }
        public string AppActivity { get; set; }
        public string UserName { get; set; }
        public string AccessKey { get; set; }
    }
}
