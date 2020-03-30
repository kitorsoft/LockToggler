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
    public partial class DetailsForm : Form
    {
        private class KeyControl
        {
            public System.Windows.Forms.Label label;
            public System.Windows.Forms.NumericUpDown num;
        }

        private Dictionary<Keys, KeyControl> keyControls = new Dictionary<Keys, KeyControl>();

        public DetailsForm()
        {
            InitializeComponent();

            tbInstructions.Text = UI.getLabel("Explanation").Replace("\\n", Environment.NewLine);

            this.SuspendLayout();

            // create controls for each key setting
            int i = 0;
            foreach(Keys key in KeyMap.dtKeys.Keys)
            {
                CreateControls(key, i++);
            }

            cbAutostart.Checked = Autostart.getRegistry();
            cbAutostart.Text = UI.getLabel("Autostart");

            cbSound.Checked = Properties.Settings.Default.playSound;
            cbSound.Text = UI.getLabel("PlaySound");

            // move buttons to the (new) bottom
            btnCancel.Location = new Point(btnCancel.Location.X, getYPosition(i+1));
            btnSave.Location = new Point(btnSave.Location.X, getYPosition(i+1));

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        /// <summary>
        /// Creates a Label and NumericUpDown control for the given key code.
        /// The control will be positioned below the sound check box
        /// </summary>
        /// <param name="key">key code</param>
        /// <param name="i">the number of the element for correct positioning</param>
        private void CreateControls(Keys key, int i)
        {
            Label label = new Label();
            NumericUpDown num = new NumericUpDown();

            int y = getYPosition(i);
            string propertyName = "delay" + key.ToString();

            ((System.ComponentModel.ISupportInitialize)(num)).BeginInit();

            label = new Label()
            {
                AutoSize = true,
                Location = new System.Drawing.Point(43, y + 2),
                Name = "lbl" + key.ToString(),
                Size = new System.Drawing.Size(53, 13),
                TabIndex = 2,
                Text = UI.getLabel(key.ToString()),
            };


            num = new NumericUpDown()
            {
                Location = new System.Drawing.Point(130, y),
                DecimalPlaces = 0,
                Increment = 100,
                Maximum = 5000,
                Minimum = -1,
                Name = key.ToString(),
                Size = new System.Drawing.Size(100, 20),
                TabIndex = 4,
                TextAlign = HorizontalAlignment.Right,
                Value = Convert.ToInt32(Properties.Settings.Default[propertyName]),
            };

            this.Controls.Add(label);
            this.Controls.Add(num);

            ((System.ComponentModel.ISupportInitialize)(num)).EndInit();

            keyControls.Add(key, new KeyControl() { label = label, num = num });
        }

        /// <summary>
        /// Calculates the y position for the i-th control below the sound check box.
        /// Assumes the control will be positioned 25px below its predecessor.
        /// </summary>
        /// <param name="i">number of the control</param>
        /// <returns>y position in pixels</returns>
        private int getYPosition(int i)
        {
            return cbSound.Location.Y + cbSound.Size.Height + (i + 1) * 25;
        }


        /// <summary>
        /// save settings and close the dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            save();
            this.Close();
        }

        /// <summary>
        /// save all settings from the generted controls and the static ones
        /// </summary>
        private void save()
        {
            foreach (var i in keyControls)
            {
                string propertyName = "delay" + i.Key.ToString();
                Properties.Settings.Default[propertyName] = Convert.ToInt32(i.Value.num.Value);
            }

            // autostart does get saved to the registry, not settings, to take effect
            if(cbAutostart.Checked != Autostart.getRegistry())
            {
                Autostart.setRegistry(cbAutostart.Checked);
            }

            Properties.Settings.Default.playSound = cbSound.Checked;

            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// close the dialog without saving any changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DetailsForm_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.AppIcon;
            this.Text = Properties.Resources.ResourceManager.GetString("ApplicationName") + " - " + UI.getLabel("Settings");

            btnCancel.Text = UI.getLabel("btnCancel");
            btnSave.Text = UI.getLabel("btnSave");
        }
    }
}
