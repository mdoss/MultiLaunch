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
        List<ProcessButton> buttons = new List<ProcessButton>();
        Processes procs = new Processes();
        
        public Form1()
        {
            InitializeComponent();
            AddButton();
        }

        public void RemoveProgramButton(ProcessButton button)
        {
            Controls.Remove(button);
            buttons.Remove(button);

            SortButtons();
        }

        public void ChangeProgramButton(ProcessButton button)
        {
            ChangeProgramButton_Click(button, EventArgs.Empty);
        }

        public void RunProgramButton(ProcessButton button)
        {
            RunProgramButton_Click(button, EventArgs.Empty);
        }

        private void AddProgramButton_Click(object sender, EventArgs e)
        {
            ProcessButton button = sender as ProcessButton;
            Debug.WriteLine(button.NameLabel);
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\MyImgur\\";
            openFileDialog.Filter = "Executable Programs (*.exe) | *.exe";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                CreateProgramButton(button, openFileDialog.FileName);
            }
        }

        private void RunProgramButton_Click(object sender, EventArgs e)
        {
            ProcessButton button = sender as ProcessButton;
            procs.RunProcess(button);
            Refresh();
        }

        private void ChangeProgramButton_Click(object sender, EventArgs e)
        {
            ProcessButton button = sender as ProcessButton;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\MyImgur\\";
            openFileDialog.Filter = "Executable Programs (*.exe) | *.exe";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = openFileDialog.FileName;
                button.SetProgram(selectedFileName);
            }
        }

        private void AddButton()
        {
            ProcessButton newButton = new ProcessButton();
            newButton.Location = new Point(0, 0);
            newButton.Height = 500;
            newButton.Width = 500;
            newButton.Text = "Add Program";
            newButton.AllowDrop = true;
            newButton.DragEnter += NewButton_DragEnter;
            newButton.DragDrop += NewButton_DragDrop;
            newButton.Click += new EventHandler(AddProgramButton_Click);
            Controls.Add(newButton);
            buttons.Add(newButton);
            SortButtons();
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
            if(files.Length > 1)
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

        private void CreateProgramButton(ProcessButton button, string filePath)
        {
            string selectedFileName = filePath;
            button.SetProgram(filePath);
            button.Click -= new EventHandler(AddProgramButton_Click);
            button.Click += new EventHandler(RunProgramButton_Click);
            button.DragDrop -= NewButton_DragDrop;
            button.DragDrop += ChangeButton_DragDrop;
            AddButton();
        }

        private void ChangeProgramButton(ProcessButton button, string filePath)
        {
            button.SetProgram(filePath);
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
                ChangeProgramButton(button, Path.GetFullPath(files[0]));
            }
            else
            {
                MessageBox.Show("Not an executable");
            }
        }

        private void SortButtons()
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

        private void form_LoseFocus(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void form_Resize(object sender, EventArgs e)
        {
            SortButtons();
        }

        private void btnRunningProcs_Click(object sender, EventArgs e)
        {
            procs.OpenRunningProcs();
        }
    }
}
