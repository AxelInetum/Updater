using msiAplication.ClassProcesSilentMsi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using msiAplication.ClassProcesSilentMsi.LoggerMethods;
using Updater.ClassProcesSilentMsi.VersionData;
using Updater.ClassProcesSilentMsi.SilentProcess;
using Updater.Logger;
using FarmaciaFmas;

namespace msiAplication.ClassProcesSilentMsi
{
    public class ProcessSilentMsi
    {
        private Ilogger _LoggerMethod;
        private MethodLoggerDatas _MethoLoggerDatas = new MethodLoggerDatas();
        public ProcessSilentMsi(Ilogger loggerMethod)
       {
            _LoggerMethod = loggerMethod;
       }

       public void StartProcessSilent(CommonDataProcessSilent commonDataProcessSilent , DatasPathSilentSetup datasPathSilentSetupObject)
       {
            try
            {
                //desinstalamos la versión antigua con su instalador propio  
                commonDataProcessSilent.ProcessSilentMsiMethods.DesinstallOldLocalAplicationMsi(datasPathSilentSetupObject._PathOldVersionMsiFile);
                //instalamos la versión nueva descargada del https
                commonDataProcessSilent.ProcessSilentMsiMethods.InstallNewLocalAplicationMsi(datasPathSilentSetupObject._PathNewversionMsiFile);
                //movemos el instalador nuevo descargado a la carpeta de version antigua
                commonDataProcessSilent.MsiAplicationUtilities.MoveMsiOldErVersionFolder(datasPathSilentSetupObject._PathOldVersionMsiFile, datasPathSilentSetupObject._PathNewversionMsiFile); 
            }
            catch(Exception ex)
            {
                _MethoLoggerDatas.MethodLoggerDatasFill("Metodo: StartProcessSilent ", " clase: ProcessSilentMsi", " Error: "
                         + ex.ToString(), " Fecha: " + DateTime.Now.ToString());
                _LoggerMethod.CreateLog(_MethoLoggerDatas);

            }
        }
    }
}
