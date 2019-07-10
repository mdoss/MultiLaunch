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
        ContextMenu cm = new ContextMenu();
        MenuItem removeProgram, runProgram, changeProgram;
        Form1 form1;

        public ProcessButton()
        {
            removeProgram = new MenuItem("Remove Program", new EventHandler(this.RemoveProgramButton_Click));
            runProgram = new MenuItem("Run", new EventHandler(this.RunProgramButton_Click));
            changeProgram = new MenuItem("Change Program", new EventHandler(this.ChangeProgramButton_Click));
            NameLabel = new Label();
            NameLabel.Text = "labelTextBroke";
            NameLabel.Location = new Point(0, 0);
            NameLabel.Visible = false;
            this.ContextMenu = cm;
            NameLabel.Click += (sender, args) => InvokeOnClick(this, args);
            this.Controls.Add(NameLabel);

        }

        public void SetProgram(string filePath)
        {
            FilePath = filePath;
            FileName = Path.GetFileNameWithoutExtension(filePath);
            NameLabel.Text = FileName;
            NameLabel.Visible = true;
            BackgroundImage = Icon.ExtractAssociatedIcon(filePath).ToBitmap();
            BackgroundImageLayout = ImageLayout.Stretch;
            Text = "";
            cm.MenuItems.Add(runProgram);
            cm.MenuItems.Add(changeProgram);
            cm.MenuItems.Add(removeProgram);
        }

        private void RemoveProgramButton_Click(object sender, EventArgs e)
        {
            if(form1 == null)
                form1 = (Form1)Application.OpenForms[0];
            form1.RemoveProgramButton(this);
        }

        private void RunProgramButton_Click(object sender, EventArgs e)
        {
            if (form1 == null)
                form1 = (Form1)Application.OpenForms[0];
            //form1.RunProgramButton(this);
        }

        private void ChangeProgramButton_Click(object sender, EventArgs e)
        {
            if (form1 == null)
                form1 = (Form1)Application.OpenForms[0];
            form1.ChangeProgramButton(this);
        }
    }
}
