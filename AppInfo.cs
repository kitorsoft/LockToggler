using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockToggler
{
    /// <summary>
    /// provides tome information about the application
    /// </summary>
    class AppInfo
    {
        public static string executablePath
        {
            get
            {
                return System.Reflection.Assembly.GetExecutingAssembly().Location;
            }
        }

        public static string applicationName
        {
            get
            {
                return Properties.Resources.ResourceManager.GetString("ApplicationName");
            }
        }

    }
}
