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
    public class ProcessButton : Button
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public Label NameLabel { get; set; }
        public ProgressBar pBar { get; set; }
        ContextMenu cm = new ContextMenu();
        MenuItem removeProgram, runProgram, changeProgram, openFolder;
        Form1 form1;

        public ProcessButton()
        {
            removeProgram = new MenuItem("Remove Program", new EventHandler(this.RemoveProgramButton_Click));
            runProgram = new MenuItem("Run", new EventHandler(this.RunProgramButton_Click));
            changeProgram = new MenuItem("Change Program", new EventHandler(this.ChangeProgramButton_Click));
            openFolder = new MenuItem("Open in Explorer", new EventHandler(this.OpenFolderButton_Click));
            NameLabel = new Label();
            pBar = new ProgressBar();

            pBar.Minimum = 0;
            pBar.Maximum = 1;
            pBar.Visible = false;

            NameLabel.Text = "SomethingTerriblyWrongHasHappened";
            NameLabel.Parent = this;
            NameLabel.Click += NameLabel_LostFocus;
            NameLabel.LostFocus += NameLabel_LostFocus;
            NameLabel.BackColor = Color.Aqua;
            NameLabel.ForeColor = Color.Azure;
            NameLabel.Location = new Point(0, 0);
            NameLabel.Visible = false;

            this.Resize += ProcessButton_Resize;
            this.ContextMenu = cm;
            //NameLabel.Click += (sender, args) => InvokeOnClick(this, args); //right click label and it sends a left click to button
            this.Controls.Add(NameLabel);
            this.Controls.Add(pBar);
        }

        public void SetProgram(string filePath)
        {
            FilePath = filePath;
            FileName = Path.GetFileNameWithoutExtension(filePath);
            NameLabel.Text = FileName;
            NameLabel.Visible = true;
            pBar.Visible = true;
            BackgroundImage = Icon.ExtractAssociatedIcon(filePath).ToBitmap();
            BackgroundImageLayout = ImageLayout.Stretch;
            Text = "";
            cm.MenuItems.Add(runProgram);
            cm.MenuItems.Add(openFolder);
            cm.MenuItems.Add(changeProgram);
            cm.MenuItems.Add(removeProgram);
        }

        public void SetRunning(bool running)
        {
            if (running)
                pBar.Value = 1;
            else
                pBar.Value = 0;
        }

        private void ProcessButton_Resize(object sender, EventArgs e)
        {
            pBar.Width = this.Width;
            pBar.Location = new Point(0, this.Height - pBar.Height);
        }

        private void RemoveProgramButton_Click(object sender, EventArgs e)
        {
            if (form1 == null)
                form1 = (Form1)Application.OpenForms[0];
            form1.RemoveProgramButton(this);
        }

        private void RunProgramButton_Click(object sender, EventArgs e)
        {
            if (form1 == null)
                form1 = (Form1)Application.OpenForms[0];
            form1.RunProgramButton(this);
            //NameLabel.BringToFront();
           // NameLabel.Refresh();
        }

        private void OpenFolderButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(FilePath))
            {
                Process.Start("explorer.exe", "/select, " + FilePath);
            }
            else
            {
                MessageBox.Show("Couldn't find containing folder. Did you change the path?");
            }
        }

        private void ChangeProgramButton_Click(object sender, EventArgs e)
        {
            if (form1 == null)
                form1 = (Form1)Application.OpenForms[0];
            form1.ChangeProgramButton(this);
        }

        private void NameLabel_LostFocus(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            Debug.WriteLine("Bring to front");
            Debug.WriteLine(lbl.Text);
            Debug.WriteLine(NameLabel.Text);
            NameLabel.ForeColor = Color.Azure;
            NameLabel.BringToFront();
            NameLabel.Refresh();
        }
    }
}
