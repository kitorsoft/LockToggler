using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LockToggler
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // make sure, this programs is run only in a single instance
            bool createdNew = false;
            Mutex m = new Mutex(true, AppInfo.applicationName, out createdNew);
            if (!createdNew)
            {
                MessageBox.Show(AppInfo.applicationName + " is already running!", "Multiple Instances");
                return;
            }

#if DEBUG
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo("de-DE");
#endif

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // instaed of:
            //Application.Run(new Form1());
            // we create a context and assign a main form, then run the context:
            // CustomApplicationContext creates notification and registers keyboard hook
            ApplicationContext applicationContext = new CustomApplicationContext();
            // no main, form, app starts in tray
            //applicationContext.MainForm = new DetailsForm();
            Application.Run(applicationContext);

            // done; free up mutex, so another instance can be started
            m.ReleaseMutex();
        }

        
    }
}
