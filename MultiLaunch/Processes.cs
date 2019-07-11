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
                Process proc = Process.Start(button.FilePath);
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
            foreach (var rBut in runningProcs)
            {
                if (rBut.Item2 == button)
                {
                    runningProcs.Remove(rBut);
                }
            }
        }

        public void OpenRunningProcs()
        {
            Form procForm = new Form();
            Label procLbl = new Label();
            procLbl.AutoSize = true;
            foreach(var proc in runningProcs)
            {
                procLbl.Text += proc.Item1.ToString();
            }
            procForm.Controls.Add(procLbl);
            procForm.Show();
        }

        private void process_Exited(object sender, EventArgs e)
        {
            Process proc = sender as Process;
            foreach(var rProc in runningProcs)
            {
                if(rProc.Item1 == proc)
                {
                    rProc.Item2.SetRunning(false);
                    runningProcs.Remove(rProc);
                    break;
                }
            }
        }


    }
}
