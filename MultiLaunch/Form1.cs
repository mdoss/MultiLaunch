using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace MultiLaunch
{
    public partial class Form1 : Form
    {
        private int MAX_ROWS = 4;
        private int MAX_COLUMNS = 4;
       // Processes procs = new Processes();
        
        public Form1()
        {
            InitializeComponent();
            if(Properties.Settings.Default.btnStringList == null)
                Properties.Settings.Default.btnStringList = new System.Collections.Specialized.StringCollection();
            LoadSavedButtons();
            // if(Properties.Settings.Default.ListOfButtonsSettings == null)
            //    Properties.Settings.Default.ListOfButtonsSettings = new List<ProcessButton>();
            this.Controls.Add(new ProcessButton());
            SortButtons(ProcessButton.GetAllButtons());
        }

        public void RemoveProgramButton(ProcessButton button)
        {
            Controls.Remove(button);
            button.RemoveButton();
           // procs.RemoveProcess(button);
           // SortButtons(ProcessButton.GetAllButtons());
        }

        public void SortButtons(List<ProcessButton> buttons)
        {
            int numRows = (buttons.Count - 1) / MAX_ROWS;
            int numCols, newX, newY;
            if (buttons.Count < MAX_COLUMNS)
                numCols = buttons.Count;
            else
                numCols = MAX_COLUMNS;
            int rowIndex, colIndex;
            for (int i = 0; i < buttons.Count; i++)
            {
                //this.Text = "numRows: " + numRows + "\tsize.y: " + (int)(.8f * (ClientSize.Height / (numRows + 1)));
                buttons[i].Size = new Size((int)(.8f * (ClientSize.Width / numCols)), (int)(.8f * (ClientSize.Height / (numRows + 1))));
                colIndex = (i + numCols) % numCols;
                rowIndex = i / numCols;
                newX = ((ClientSize.Width / (numCols * 2)) + (colIndex * (ClientSize.Width / numCols)) - (buttons[i].Width / 2));
                if (numRows == 0)
                    newY = (ClientSize.Height / 2) - (buttons[i].Height / 2);
                else
                    newY = (buttons[i].Height / 2) + 10 + (rowIndex * (ClientSize.Height / (numRows + 1))) - (buttons[i].Height / 2);
                
                buttons[i].Location = new Point(newX, newY);
            }
        }

        private void LoadSavedButtons()
        {
            var btnStringList = Properties.Settings.Default.btnStringList.Cast<string>().ToList();
            Properties.Settings.Default.btnStringList = new System.Collections.Specialized.StringCollection();
            foreach (var filePath in btnStringList)
            {
                var button = new ProcessButton();
                button.LoadProgramButton(filePath);
                Controls.Add(button);
            }
            ProcessButton.CheckRunning();
        }

        private void form_LoseFocus(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void form_Resize(object sender, EventArgs e)
        {
            SortButtons(ProcessButton.GetAllButtons());
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

        private void form_closed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void btnRefreshSaved_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.btnStringList.Clear();
        }
    }
}
