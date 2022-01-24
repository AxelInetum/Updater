using msiAplication.ClassProcesSilentMsi;
using msiAplication.ClassProcesSilentMsi.Interfaces;
using msiAplication.ClassProcesSilentMsi.LoggerMethods;
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
    public class InitProcessSilent
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
        public Version currentVersion;
        public Version TheLastVersion;
        private Ilogger _LoggerMethod;
        private MethodLoggerDatas _MethoLoggerDatas = new MethodLoggerDatas();

        public InitProcessSilent(Ilogger loggerMethod)
        {
            try
            {
                _LoggerMethod = loggerMethod;
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








