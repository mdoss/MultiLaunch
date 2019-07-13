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
using System.Runtime.Serialization.Formatters.Binary;

namespace MultiLaunch
{
    [Serializable()]
    public class ProcessButton : Button
    {
        private static List<ProcessButton> buttons = new List<ProcessButton>();
        private static Processes procs = new Processes();
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public Label NameLabel { get; set; }
        public ProgressBar pBar { get; set; }
        ContextMenu cm = new ContextMenu();
        MenuItem removeProgram, runProgram, changeProgram, openFolder, stopProgram;

        Form1 form1;

        public ProcessButton()
        {
            removeProgram = new MenuItem("Remove Program", new EventHandler(this.RemoveProgramButton_Click));
            runProgram = new MenuItem("Run", new EventHandler(this.RunProgramButton_Click));
            stopProgram = new MenuItem("Stop", new EventHandler(this.StopProgramButton_Click));
            changeProgram = new MenuItem("Change Program", new EventHandler(this.ChangeProgramButton_Click));
            openFolder = new MenuItem("Open in Explorer", new EventHandler(this.OpenFolderButton_Click));
            NameLabel = new Label();
            pBar = new ProgressBar();

            pBar.Minimum = 0;
            pBar.Maximum = 1;
            pBar.Visible = false;

            NameLabel.Text = "SomethingTerriblyWrongHasHappened";
            NameLabel.Parent = this;
            NameLabel.BackColor = Color.Black;
            NameLabel.ForeColor = Color.White;
            NameLabel.Location = new Point(0, 0);
            NameLabel.Visible = false;

            this.Text = "Add Program";
            this.AllowDrop = true;
            this.DragEnter += NewButton_DragEnter;
            this.DragDrop += NewButton_DragDrop;
            this.Click += new EventHandler(AddProgramButton_Click);

            buttons.Add(this);
            this.Resize += ProcessButton_Resize;
            this.ContextMenu = cm;
            this.Controls.Add(NameLabel);
            this.Controls.Add(pBar);
        }        

        public void SetProgram(string filePath)
        {
            if (IsAlreadyLoaded(filePath))
                return;
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
            Properties.Settings.Default.btnStringList.Add(this.FilePath);
            Properties.Settings.Default.Save();
        }

        public void SetRunning(bool running)
        {
            if (running)
            {
                pBar.Value = 1;
                cm.MenuItems.Add(1, stopProgram);
            }
            else
            {
                pBar.Value = 0;
                cm.MenuItems.Remove(stopProgram);
            }
        }

        public static List<ProcessButton> GetAllButtons()
        {
            return buttons;
        }

        public void RemoveButton()
        {
            procs.RemoveProcess(this);
            Properties.Settings.Default.btnStringList.Remove(this.FilePath);
            buttons.Remove(this);
            if (form1 == null)
                form1 = (Form1)Application.OpenForms[0];
            form1.SortButtons(buttons);
        }

        public void LoadProgramButton(string filePath)
        {
            if (IsAlreadyLoaded(filePath))
                return;
            this.SetProgram(filePath);
            this.Click -= new EventHandler(AddProgramButton_Click);
            this.Click += new EventHandler(RunProgramButton_Click);
            this.DragDrop -= NewButton_DragDrop;
            this.DragDrop += ChangeButton_DragDrop;
        }

        public static void CheckRunning()
        {
            procs.CheckRunningProcesses(buttons);
        }

        public static void CloseAll()
        {
            procs.StopAllRunning();
        }
        
        public static void OpenRunningProcList()
        {
            procs.OpenRunningProcsList();
        }

        public static void OpenRunningProcesses()
        {
            procs.OpenRunningProcesses();
        }

        private bool IsAlreadyLoaded(string filePath)
        {
            foreach(var button in buttons)
            {
                if(button.FilePath == filePath)
                    return true;
            }
            return false;
        }

        private void CreateNewButton()
        {
            if (form1 == null)
                form1 = (Form1)Application.OpenForms[0];
            form1.Controls.Add(new ProcessButton());
            form1.SortButtons(buttons);
        }
        
        private void SortButtons()
        {
            if (form1 == null)
                form1 = (Form1)Application.OpenForms[0];
            form1.SortButtons(buttons);
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
            Properties.Settings.Default.btnStringList.Remove(this.FilePath);
            form1.RemoveProgramButton(this);
        }

        private void RunProgramButton_Click(object sender, EventArgs e)
        {
            if (!procs.isAlreadyRunning(this))
            {
                procs.RunProcess(this);
                Refresh();
            }
            else
                Debug.WriteLine(this.FileName + " is already running");
        }

        private void StopProgramButton_Click(object sender, EventArgs e)
        {
            procs.StopProcess(this);
            Refresh();
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

        private void NewButton_DragEnter(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 1)
            {
                //MessageBox.Show("Too many files selected");
                return;
            }
            if (Path.GetExtension(files[0]).Equals(".exe", StringComparison.InvariantCultureIgnoreCase))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void NewButton_DragDrop(object sender, DragEventArgs e)
        {
            ProcessButton button = sender as ProcessButton;
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 1)
            {
                MessageBox.Show("Too many files selected");
                return;
            }
            if (Path.GetExtension(files[0]).Equals(".exe", StringComparison.InvariantCultureIgnoreCase))
            {
                CreateProgramButton(button, Path.GetFullPath(files[0]));
            }
            else
            {
                MessageBox.Show("Not an executable");
            }
        }

        private void ChangeButton_DragDrop(object sender, DragEventArgs e)
        {
            ProcessButton button = sender as ProcessButton;
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 1)
            {
                MessageBox.Show("Too many files selected");
                return;
            }
            if (Path.GetExtension(files[0]).Equals(".exe", StringComparison.InvariantCultureIgnoreCase))
            {
                this.SetProgram(Path.GetFullPath(files[0]));
            }
            else
            {
                MessageBox.Show("Not an executable");
            }
        }

        private void AddProgramButton_Click(object sender, EventArgs e)
        {
            ProcessButton button = sender as ProcessButton;
            Debug.WriteLine(button.NameLabel);
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Executable Programs (*.exe) | *.exe";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                CreateProgramButton(button, openFileDialog.FileName);
            }
        }

        private void CreateProgramButton(ProcessButton button, string filePath)
        {
            if (IsAlreadyLoaded(filePath))
                return;
            button.SetProgram(filePath);
            button.Click -= new EventHandler(AddProgramButton_Click);
            button.Click += new EventHandler(RunProgramButton_Click);
            button.DragDrop -= NewButton_DragDrop;
            button.DragDrop += ChangeButton_DragDrop;
            CreateNewButton();
        }

        private void ChangeProgramButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\MyImgur\\";
            openFileDialog.Filter = "Executable Programs (*.exe) | *.exe";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = openFileDialog.FileName;
                SetProgram(selectedFileName);
            }
        }
    }
}
