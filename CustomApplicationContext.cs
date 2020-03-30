using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LockToggler
{
    /// <summary>
    /// This ApplicationContext creates a notification icon and a keyboard hook.
    /// It also handles the menu of the icon.
    /// </summary>
    class CustomApplicationContext : ApplicationContext
    {
        private NotifyIcon notifyIcon = null;
        private Container components = null;
        private Form detailsForm = null;
        private Form aboutForm = null;

        public CustomApplicationContext()
        {
            InitializeContext();

            detailsForm = MainForm;
        }

        /// <summary>
        /// Creates the notification icon and keyboard hook
        /// </summary>
        private void InitializeContext()
        {
            components = new System.ComponentModel.Container();

            notifyIcon = new NotifyIcon(components)
            {
                ContextMenuStrip = new ContextMenuStrip(),
                Icon = Properties.Resources.AppIcon,
                Text = Properties.Resources.ResourceManager.GetString("ApplicationName"),
                Visible = true
            };
            notifyIcon.ContextMenuStrip.Opening += ContextMenuStrip_Opening;
            notifyIcon.DoubleClick += (object s, EventArgs eArgs) => ShowDetailsForm();

            KeyboardWatcher.start();
        }

        /// <summary>
        /// creates the context menu items for the notification icon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = false;

            if (notifyIcon.ContextMenuStrip.Items.Count == 0)
            {
                ToolStripItem item = notifyIcon.ContextMenuStrip.Items.Add(UI.getLabel("MenuSettings"), null, (object s, EventArgs eArgs) => ShowDetailsForm());
                item.Font = new Font(item.Font, item.Font.Style | FontStyle.Bold);

                notifyIcon.ContextMenuStrip.Items.Add(new ToolStripSeparator());
                notifyIcon.ContextMenuStrip.Items.Add(UI.getLabel("MenuAbout"), null, (object s, EventArgs eArgs) => ShowAboutForm());

                notifyIcon.ContextMenuStrip.Items.Add(new ToolStripSeparator());
                notifyIcon.ContextMenuStrip.Items.Add(UI.getLabel("MenuExit"), null, (object s, EventArgs eArgs) => ExitThread());
            }
        }

        /// <summary>
        /// detaches the keyboard hook
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            KeyboardWatcher.stop();

            if (disposing && components != null)
            {
                components.Dispose();
            }
        }

        /// <summary>
        /// Closes and forms and removes the notification icon
        /// </summary>
        protected override void ExitThreadCore()
        {
            if (detailsForm != null)
            {
                detailsForm.Close();
            }
            if (aboutForm != null)
            {
                aboutForm.Close();
            }
            notifyIcon.Visible = false; // remove tray icon
            base.ExitThreadCore();
        }

        private void ShowDetailsForm()
        {
            if (detailsForm == null)
            {
                detailsForm = new DetailsForm();
                detailsForm.Closed += (object sender, EventArgs e) => { detailsForm = null; };
                detailsForm.Show();
            }
            else
            {
                detailsForm.Activate();
            }
        }

        private void ShowAboutForm()
        {
            if (aboutForm == null)
            {
                aboutForm = new AboutForm();
                aboutForm.Closed += (object sender, EventArgs e) => { aboutForm = null; };
                aboutForm.Show();
            }
            else
            {
                aboutForm.Activate();
            }
        }
    }
}
