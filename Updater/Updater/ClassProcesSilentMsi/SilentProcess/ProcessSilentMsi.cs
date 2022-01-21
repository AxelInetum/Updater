using msiAplication.ClassProcesSilentMsi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using msiAplication.ClassProcesSilentMsi.LoggerMethods;
using Updater.ClassProcesSilentMsi.VersionData;
using Updater.ClassProcesSilentMsi.SilentProcess;

namespace msiAplication.ClassProcesSilentMsi
{
    public class ProcessSilentMsi
    {
       public ProcessSilentMsi()
       { 
        
       }

       public void StartProcessSilent(InitProcessSilent initProcessSilent)
       {
            try
            {          
                //bajamos la version del msi del https 
                initProcessSilent.HttpsMethods.HttpsDownloadNewVersionMsi();
                //comprobamos que se ha descargado correctamente comprobando que localmente existe el fichero 
                if (initProcessSilent.HttpsMethods.HttpsCorrectDownloafileNewVersionMsi())
                {
                    //desinstalamos la versión antigua con su instalador propio  
                    initProcessSilent.ProcessSilentMsiMethods.DesinstallOldLocalAplicationMsi();
                    //instalamos la versión nueva descargada del https
                    initProcessSilent.ProcessSilentMsiMethods.InstallNewLocalAplicationMsi();
                    //movemos el instalador nuevo descargado a la carpeta de version antigua
                    initProcessSilent.MsiAplicationUtilities.MoveMsiOldErVersionFolder();
                    //limpiamos la version descargada https de la carpeta de nueva version
                    initProcessSilent.MsiAplicationUtilities.DeleteNewVersionMsi();
                    //cerramoa el aplicativo al cerrarse el updater detectara que se ha cerrado y lo reabrira con la version nueva instalada 
                    Environment.Exit(0);
                }           
            }
            catch(Exception ex)
            {

            }
        }
    }
}
