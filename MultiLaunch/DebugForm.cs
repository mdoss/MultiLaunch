using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MultiLaunch
{
    public partial class DebugForm : Form
    {
        public DebugForm()
        {
            InitializeComponent();
        }
        private void btnRunningProcsList_Click(object sender, EventArgs e)
        {
            ProcessButton.OpenRunningProcList();
        }

        private void btnRunningProcs_Click(object sender, EventArgs e)
        {
            ProcessButton.OpenRunningProcesses();
        }

        private void btnSavedButtons_Click(object sender, EventArgs e)
        {
            string result = "";
            if (Properties.Settings.Default.btnStringList != null)
            {
                var list = Properties.Settings.Default.btnStringList.Cast<string>().ToList();
                foreach (var str in list)
                {
                    result += str + "\n";
                }
                MessageBox.Show(result);
            }
            //Properties.Settings.Default.btnStringList = new System.Collections.Specialized.StringCollection();
            Properties.Settings.Default.Save();
            // ProcessButton.OpenSavedButtons();
            // ProcessButton.SaveButtons(buttons);
            //MessageBox.Show(Properties.Settings.Default.settingTest);
            //  Properties.Settings.Default.settingTest = "bullshit";

            // Properties.Settings.Default.Save();
        }

        private void btnClearSaved_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.btnStringList.Clear();
        }
    }
}
