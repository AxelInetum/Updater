using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace msiAplication.ClassProcesSilentMsi
{
    public class WebServicesDatasVersions
    {
        public string urlUpdaterPilot;
        public string urlUpdaterMaster;
        public string ThelastVersionUpdaterPilot;
        public string ThelastVersionUpdaterMaster;
        public string urlConectorFPilot;
        public string urlConectorFMaster;
        public string ThelastVersionConectorFPilot;
        public string ThelastVersionConectorFMaster;

        public WebServicesDatasVersions()
        {
            urlUpdaterPilot = "";
            urlUpdaterMaster = "";
            ThelastVersionUpdaterPilot = "";
            ThelastVersionUpdaterMaster = "";
            urlConectorFPilot = "";
            urlConectorFMaster = "";
            ThelastVersionConectorFPilot = "";
            ThelastVersionConectorFMaster = "";
        }

        public void GetDatasWebServicesDatasVersions()
        {
            urlUpdaterPilot = "https://localhost:443/HefameSetup.msi";
            urlUpdaterMaster = "https://localhost:443/HefameSetup.msi";
            ThelastVersionUpdaterPilot = "1.1.2";
            ThelastVersionUpdaterMaster = "1.1.2";
            urlConectorFPilot = "https://localhost:443/HefameSetup.msi";
            urlConectorFMaster = "https://localhost:443/HefameSetup.msi";
            ThelastVersionConectorFPilot = "1.1.2";
            ThelastVersionConectorFMaster = "1.1.2";
        }
    }

}


