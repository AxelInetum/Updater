using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Updater.ClassProcesSilentMsi.VersionData;

namespace msiAplication.ClassProcesSilentMsi
{
    public class MsiAplicationUtilities
    {
        public MsiAplicationUtilities()
        {

        }

        public int CompareVersions(Version currentversion, Version theLastVersionHttps)
        {
            return currentversion.CompareTo(theLastVersionHttps);
        }

        public TheLastVersionDatas WhatVersionCompareConectorF(WebServicesDatasVersions WebServicesDatasVersions)
        {
            TheLastVersionDatas theLastVersionDatas = new TheLastVersionDatas();

            if (!string.IsNullOrWhiteSpace(WebServicesDatasVersions.ThelastVersionConectorFPilot))
            {
                theLastVersionDatas.theLastVersion = WebServicesDatasVersions.ThelastVersionConectorFPilot;
                theLastVersionDatas.urlLastVersion = WebServicesDatasVersions.urlConectorFPilot;
            }
            else
            {
                theLastVersionDatas.theLastVersion = WebServicesDatasVersions.ThelastVersionConectorFMaster;
                theLastVersionDatas.urlLastVersion = WebServicesDatasVersions.urlConectorFMaster;
            }

            return theLastVersionDatas;
        }

        public TheLastVersionDatas WhatVersionCompareUpdater(WebServicesDatasVersions WebServicesDatasVersions)
        {
            TheLastVersionDatas theLastVersionDatas = new TheLastVersionDatas();

            if (!string.IsNullOrWhiteSpace(WebServicesDatasVersions.ThelastVersionUpdaterPilot))
            {
                theLastVersionDatas.theLastVersion = WebServicesDatasVersions.ThelastVersionUpdaterPilot;
                theLastVersionDatas.urlLastVersion = WebServicesDatasVersions.urlConectorFPilot;
            }
            else
            {
                theLastVersionDatas.theLastVersion = WebServicesDatasVersions.ThelastVersionUpdaterMaster;
                theLastVersionDatas.urlLastVersion = WebServicesDatasVersions.urlUpdaterMaster;
            }

            return theLastVersionDatas;
        }

        public void MoveMsiOldErVersionFolder()
        {
            string origin = "C:\\FarmaciaFmas\\NewVersionMsi\\HefameSetup.msi";
            string destiny = "C:\\FarmaciaFmas\\OldVersionMsi\\HefameSetup.msi";
            File.Copy(origin, destiny, true);
        }

        public void DeleteNewVersionMsi()
        {
            string origin = "C:\\FarmaciaFmas\\HefameSetup.msi";
            File.Delete(origin);
        }
    }
}
