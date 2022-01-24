using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Updater.ClassProcesSilentMsi.SilentProcess
{
    public class DatasSilentProcess
    {
        public string urlUpdaterPilot;
        public string urlUpdaterMaster;
        public string theLastVersionUpdaterPilot;
        public string theLastVersionUpdaterMaster;

        public DatasSilentProcess()
        {
            urlUpdaterPilot = "";
            urlUpdaterMaster = "";
            theLastVersionUpdaterPilot = "";
            theLastVersionUpdaterMaster = "";
        }
    }
}
