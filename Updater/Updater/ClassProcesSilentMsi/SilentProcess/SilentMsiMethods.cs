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
            process.StartInfo.Arguments = "/x C:\\proyectos\\hefame\\Updater\\OldVersionMsi\\HefameSetup.msi" +
                " /qn /log " + @"C:\\proyectos\\hefame\\Updater\\LogSilentCommands\\LogSilentDesInstall_" + DateTime.Now.Year.ToString() + "_" +
                DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + ".log";
            process.Start();
            process.WaitForExit();
        }

        public void InstallNewLocalAplicationMsi()
        {
            Process process = new Process();
            process.StartInfo.FileName = "msiexec.exe";
            process.StartInfo.Arguments = "/i C:\\proyectos\\hefame\\Updater\\NewVersionMsi\\HefameSetup.msi" +
                " /quiet /qn /log " + @"C:\proyectos\hefame\Updater\LogSilentCommands\SilentInstall_" + DateTime.Now.Year.ToString() + "_" +
                DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + ".log";
            process.StartInfo.Verb = "runas";
            process.Start();
            process.WaitForExit();
        }

        public void OpenNewApplicationMsi()
        {
            Process p = new Process();
            p.StartInfo.FileName = @"C:\Program Files (x86)\HefameSilentSetup\HefameSilentSetup\HefameApp\msiAplication.exe";
            p.Start();
        }
    }
}
