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
    class Processes
    {
        List<Tuple<Process, ProcessButton>> runningProcs = new List<Tuple<Process, ProcessButton>>();

        public bool RunProcess(ProcessButton button)
        {
            try
            {
                Process[] procs = Process.GetProcessesByName(button.FileName);
                Process proc;
                if (procs.Length == 0) //if the program is not currently running
                    proc = Process.Start(button.FilePath);
                else
                    proc = procs[0]; //get process from open processes. this doesn't always work with programs that run multiple processes, maybe ill fix eventually if im not lazy
                var tuple = new Tuple<Process, ProcessButton>(proc, button);
                runningProcs.Add(tuple);
                Debug.WriteLine("Added " + proc.ToString() + " to runningProcs list");
                proc.EnableRaisingEvents = true;
                proc.Exited += process_Exited;
                button.SetRunning(true);
            }
            catch (Exception ex)
            {
                return false;
                MessageBox.Show("Could not run program\n" + ex.ToString());
            }
            return true;
        }

        public void RemoveProcess(ProcessButton button)
        {
            var butInList = isButtonInList(button);
            if(butInList != null)
            {
                runningProcs.Remove(butInList);
            }
            else
            {
                MessageBox.Show("Failed to remove process");
            }
        }
        
        public void OpenRunningProcsList()
        {
            Form procForm = new Form();
            Label procLbl = new Label();
            procLbl.AutoSize = true;
            foreach(var proc in runningProcs.ToList())
            {
                procLbl.Text += proc.Item1.ToString() + "\n";
            }
            procForm.Controls.Add(procLbl);
            procForm.Show();
        }

        public void OpenRunningProcesses()
        {
            Form procForm = new Form();
            Label procLbl = new Label();
            procLbl.AutoSize = true;
            foreach (var proc in GetRunning().ToList())
            {
                procLbl.Text += proc.ProcessName + "\n";
            }
            procForm.Controls.Add(procLbl);
            procForm.Show();
        }

        public void CheckRunning(List<ProcessButton> buttons)
        {
            foreach(var button in buttons)
            {
                if (isButtonInList(button) != null)
                    continue;
                foreach(var process in GetRunning().ToList())
                {
                    if(button.FileName == process.ProcessName)
                    {
                        RunProcess(button);
                    }
                }
            }
        }

        private Tuple<Process, ProcessButton> isButtonInList(ProcessButton button) //returns null if not found
        {
            foreach (var rBut in runningProcs.ToList())
            {
                if (rBut.Item2 == button)
                {
                    return rBut;
                }
            }
            return null;
        }

        private void process_Exited(object sender, EventArgs e)
        {
            Process proc = sender as Process;
            foreach(var rProc in runningProcs.ToList())
            {
                if(rProc.Item1 == proc)
                {
                    rProc.Item2.SetRunning(false);
                    runningProcs.Remove(rProc);
                    return;
                }
            }
        }

        private List<Process> GetRunning()
        {
            return Process.GetProcesses().Where(p => !string.IsNullOrEmpty(p.MainWindowTitle)).ToList();
        }



    }
}
