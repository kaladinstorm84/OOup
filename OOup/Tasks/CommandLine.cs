using OOup.Interfaces;
using OOup.Statuses;
using OOup.Tasks.TaskBases;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOup.Tasks
{
    public class CommandLine : BaseTask
    {
        public CommandLine()
        {
        }

        public string Command { get; set; }
        public string Arguments { get; set; }
        public string WorkingDirectory => TaskSettings.CurrentWorkingDirectory;
        public CommandLine(string command, string arguments)
        {
            Command = command;
            Arguments = arguments;
        }


        public override void Run()
        {
            Log("Running");
            string command = Command;
            string args = Arguments;


            Process process = new Process();
            try
            {
                process.StartInfo.FileName = command;
                process.StartInfo.WorkingDirectory = WorkingDirectory;
                process.StartInfo.Arguments = args;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                process.ErrorDataReceived += Process_ErrorDataReceived;
                process.OutputDataReceived += Process_OutputDataReceived;
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
                if(process.ExitCode != 0)
                {
                    Fail($"Error Code : {process.ExitCode.ToString()}");
                }
                else
                {
                    Complete();
                }
            }catch (Exception ex)
            {
                Fail(ex.Message);
            }
        }

        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            WriteToStatus($"{e.Data??""}", Statuses.Status.InProgress);
        }

        private void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if(e.Data!=null && e.Data!="")
                WriteToStatus($"{e.Data??""}", Statuses.Status.Failed);
        }
    }
}
