using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace msiAplication.ClassProcesSilentMsi
{
    public class SilentMsiMethods
    {
        public SilentMsiMethods()
        {
        }
        public void DesinstallOldLocalAplicationMsi()
        {
            //necesito el msi antiguo para desinstalarlo 
            Process process = new Process();
            process.StartInfo.FileName = "msiexec.exe";
            process.StartInfo.Arguments = "/x C:\\FarmaciaFmas\\OldVersionMsi\\HefameSetup.msi" +
                " /qn /log " + @"C:\\FarmaciaFmas\\LogSilentCommands\\LogSilentDesInstall_" + DateTime.Now.Year.ToString() + "_" +
                DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + ".log";
            process.Start();
            process.WaitForExit();
        }

        public void InstallNewLocalAplicationMsi()
        {
            Process process = new Process();
            process.StartInfo.FileName = "msiexec.exe";
            process.StartInfo.Arguments = "/i C:\\FarmaciaFmas\\NewVersionMsi\\HefameSetup.msi" +
                " /quiet /qn /log " + @"C:\\FarmaciaFmas\\LogSilentCommands\SilentInstall_" + DateTime.Now.Year.ToString() + "_" +
                DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + ".log";
            process.StartInfo.Verb = "runas";
            process.Start();
            process.WaitForExit();
        }
    }
}
