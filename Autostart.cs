using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockToggler
{
    /// <summary>
    /// Handles the registry settings for auto-starting the application upon login.
    /// Assumes that the application name is unique.
    /// </summary>
    class Autostart
    {
        private static readonly string run = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

        /// <summary>
        /// adds a registry key to start the app when the user logs in
        /// </summary>
        private static void addRegistry()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(run, true))
            {
                key.SetValue(AppInfo.applicationName, AppInfo.executablePath);
            }
        }

        /// <summary>
        /// removes the registry key
        /// </summary>
        private static void removeRegistry()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(run, true))
            {
                if (key != null)
                {
                    key.DeleteValue(AppInfo.applicationName);
                }
            }
        }

        /// <summary>
        /// Looks for a registry key to auto-start the application
        /// </summary>
        /// <returns>true, if there is a registry entry, false otherwise</returns>
        public static bool getRegistry()
        {
            bool retVal = false;

            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(run, true))
            {
                if (key != null)
                {
                    string path = (string)key.GetValue(AppInfo.applicationName);
                    if (path != null)
                    {
                        retVal = true;
                    }
                }
            }

            return retVal;
        }

        /// <summary>
        /// Creates or deletes the auto-start registry entry depending on the autostart parameter
        /// </summary>
        /// <param name="autostart">if true, registry entry will be created, if false, it will be deleted</param>
        public static void setRegistry(bool autostart)
        {
            if(autostart && !getRegistry())
            {
                addRegistry();
            }
            else if(!autostart && getRegistry())
            {
                removeRegistry();
            }
        }
    }
}
