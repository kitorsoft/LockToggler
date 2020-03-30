using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LockToggler
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.AppIcon;
            this.Text = Properties.Resources.ResourceManager.GetString("ApplicationName") + " - " + UI.getLabel("About");

            tbAbout.Text = UI.getLabel("AboutText");
            lblLicense.Text = UI.getLabel("License") + ":";
            lblLicenseLink.Text = Properties.Resources.ResourceManager.GetString("License");
            btnClose.Text = UI.getLabel("buttonClose");
        }

        /// <summary>
        /// open the link to the license details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblLicenseLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                VisitLink();
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }

        /// <summary>
        /// open the license link in the browser
        /// </summary>
        private void VisitLink()
        {
            // Change the color of the link text by setting LinkVisited
            // to true.
            lblLicenseLink.LinkVisited = true;
            //Call the Process.Start method to open the default browser
            //with a URL:
            System.Diagnostics.Process.Start(Properties.Resources.ResourceManager.GetString("LicenseLink"));
        }
    }
}
