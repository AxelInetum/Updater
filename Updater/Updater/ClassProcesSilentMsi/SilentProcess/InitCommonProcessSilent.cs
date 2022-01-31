using FarmaciaFmas;
using msiAplication.ClassProcesSilentMsi;
using msiAplication.ClassProcesSilentMsi.Interfaces;
using msiAplication.ClassProcesSilentMsi.LoggerMethods;
using PopupWithTimer.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Updater.ClassProcesSilentMsi.VersionData;
using Updater.Logger;
using Updater.Xml;

namespace Updater.ClassProcesSilentMsi.SilentProcess
{
    public class CommonDataProcessSilent
    {
        //utilidades que utilizara el aplicativo 
        public MsiAplicationUtilities MsiAplicationUtilities;
        //objeto para obtener los metodos para instalar y desinstalar el msi de manera silenciosa 
        public SilentMsiMethods ProcessSilentMsiMethods;
        //objeto para obtener los metodos para acceso al servidor https (descargar de la version nueva del msi)
        public HttpsMethods HttpsMethods;
        //objeto para realizar lecturas del xml (obtención versiones de conectorF y updater) 
        public XmlReaderConfig ReadDataConfigXml;
        //variables para almacenar las versiones del conector F y updater 
        public string currentVersion;
        public string TheLastVersion;
        private Ilogger _LoggerMethod;
        private MethodLoggerDatas _MethoLoggerDatas = new MethodLoggerDatas();
        //objeto para realizar las operaciones de conexión al webservices 
        public WS_ClieAPI WS_ClieAPI;
        //objeto para actualizar el config.xml con la nueva versión del updater 
        public XmlWriterConfig XmlWriterConfigs;
        public ProcessSilentMsi processSilentMsi;
        public string pathProcess;

        public CommonDataProcessSilent(Ilogger loggerMethod)
        {
          try
             {
                //objeto llamado desde FarmaciaMas para realizar el login , el mismo objeto hace el login y genera el token 
                //para acceder a la api y descargar las versiones del update y el conector+F 
                WS_ClieAPI = new WS_ClieAPI();
                //objeto para crear los logs 
                _LoggerMethod = loggerMethod;
                //objeto para sobreescribir la version del update en el config.xml
                XmlWriterConfigs = new XmlWriterConfig(_LoggerMethod);
                processSilentMsi = new ProcessSilentMsi(_LoggerMethod);
                //utilidades que utilizara el aplicativo 
                MsiAplicationUtilities = new MsiAplicationUtilities();
                //objeto para obtener los metodos para instalar y desinstalar el msi de manera silenciosa 
                ProcessSilentMsiMethods = new SilentMsiMethods();
                //objeto para obtener los metodos para acceso al servidor https (descargar de la version nueva del msi)
                HttpsMethods = null;
                //objeto para realizar lecturas del xml (obtención versiones de conectorF y updater) 
                ReadDataConfigXml = new XmlReaderConfig(_LoggerMethod);
                //rellenamos el objeto con las versiones del updater y conector F
                ReadDataConfigXml.LoadXmlReaderConfigFill();
                //variables para almacenar las versiones del conector F y updater 
                currentVersion = null;
                TheLastVersion = null;
                //rut donde realizar el proceso de desintalación 
             }
             catch (Exception ex)
             {
                _MethoLoggerDatas.MethodLoggerDatasFill("Metodo: StartInitAtributesProcessSilent ", " clase: InitProcessSilent", " Error: "
                              + ex.ToString(), " Fecha: " + DateTime.Now.ToString());
                _LoggerMethod.CreateLog(_MethoLoggerDatas);
             }
         }
     }
}








