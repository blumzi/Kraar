using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ASCOM.Utilities;
using ASCOM.DenkoviUSB;

namespace ASCOM.DenkoviUSB
{
    [ComVisible(false)]					// Form not registered for COM!
    public partial class SetupDialogForm : Form
    {
        public SetupDialogForm()
        {
            InitializeComponent();
            // Initialise current values of user settings from the ASCOM Profile
            InitUI();
        }

        private void cmdOK_Click(object sender, EventArgs e) // OK button event handler
        {
            // Place any validation constraint checks here
            // Update the state variables with results from the dialogue
            Switch.ftdiIndex = Convert.ToUInt32(textBoxFtdiIndex.Text);
            Switch.traceState = chkTrace.Checked;
            for (int i = 0; i < 8; i++)
            {
                Control[] controls = tableLayoutPanelLabels.Controls.Find("textBoxLabel" + i.ToString(), true);
                Switch.SetLabel(i, (controls[0] as TextBox).Text);
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e) // Cancel button event handler
        {
            Close();
        }

        private void BrowseToAscom(object sender, EventArgs e) // Click on ASCOM logo event handler
        {
            try
            {
                System.Diagnostics.Process.Start("http://ascom-standards.org/");
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void InitUI()
        {
            Switch s = new Switch();

            chkTrace.Checked = Switch.traceState;
            // set the list of com ports to those that are currently available
            textBoxFtdiIndex.Text = Switch.ftdiIndex.ToString();

            using (Profile driverProfile = new Profile())
            {
                driverProfile.DeviceType = "Switch";
                for (int i = 0; i < 8; i++)
                {
                    Control[] controls = tableLayoutPanelLabels.Controls.Find("textBoxLabel" + i.ToString(), true);
                    (controls[0] as TextBox).Text = driverProfile.GetValue(Switch.driverID, "Labels", i.ToString(), "Relay" + i.ToString());
                }
            }
        }

        private void textBox_Validated(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;

            if (tb.Text == string.Empty)
                tb.Text = string.Format("Relay{0}", tb.Tag);
        }
    }
}