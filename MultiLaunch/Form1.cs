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
        private int maxRows = 4;
        private int maxCols = 4;

        public Form1()
        {
            InitializeComponent();
            if(Properties.Settings.Default.btnStringList == null)
                Properties.Settings.Default.btnStringList = new System.Collections.Specialized.StringCollection();
            LoadSavedButtons();
            timerCheckRunning.Start();
            this.Controls.Add(new ProcessButton());
            SortButtons(ProcessButton.GetAllButtons());
        }

        public void RemoveProgramButton(ProcessButton button)
        {
            Controls.Remove(button);
            button.RemoveButton();
        }

        public void SortButtons(List<ProcessButton> buttons)
        {
            int numRows = (buttons.Count - 1) / maxRows;
            int numCols, newX, newY;
            if (buttons.Count < maxCols)
                numCols = buttons.Count;
            else
                numCols = maxCols;
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

        private void form_closed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void timerCheckRunning_Tick(object sender, EventArgs e) //hooking a driver function to tell when a process launched seemed like too much work, though i hate this way of checking if the process is running
        {
            ProcessButton.CheckRunning(); 
        }

        private void btnDebugButtons_Click(object sender, EventArgs e)
        {
            new DebugForm().Show();
        }

        private void btnCloseAll_Click(object sender, EventArgs e)
        {
            ProcessButton.CloseAll();
        }
    }
}
