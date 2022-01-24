using msiAplication.ClassProcesSilentMsi.Interfaces;
using msiAplication.ClassProcesSilentMsi.LoggerMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Updater.Logger;
using Updater.Xml;

namespace PopupWithTimer.Xml
{
    public class XmlWriterConfig
    {
        private XmlDocument doc = new XmlDocument();
        private Ilogger _LoggerMethod;
        private string pathXml = @"C:\FarmaciaFmas\Config.xml";
        private MethodLoggerDatas _MethoLoggerDatas = new MethodLoggerDatas();

        public XmlWriterConfig(Ilogger loggerMethod)
        {
            _LoggerMethod = loggerMethod;
             doc.Load(this.pathXml);
        }

        public void UpdateXmlConfigLasVersionConectorF(string ConectorF)
        {
            try
            {
                XmlNode root = doc.DocumentElement;
                XmlNode conectorFVersion = root.SelectSingleNode("parametros").SelectSingleNode("versionConector");
                conectorFVersion.InnerText = ConectorF;
                doc.Save(this.pathXml);         
            }
            catch (Exception ex)
            {
                _MethoLoggerDatas.MethodLoggerDatasFill("Metodo: UpdateXmlConfigLasVersionConectorF ", " clase: XmlWriterConfig", " Error: "
                     + ex.ToString(), " Fecha: " + DateTime.Now.ToString());
                _LoggerMethod.CreateLog(_MethoLoggerDatas);

            }
        }

        public void UpdateXmlConfigLasVersionUpdater(string updater)
        {
            try
            {
                XmlNode root = doc.DocumentElement;
                XmlNode updaterVersion = root.SelectSingleNode("parametros").SelectSingleNode("versionUpdater");
                updaterVersion.InnerText = updater;
                doc.Save(this.pathXml);
            }
            catch (Exception ex)
            {
                _MethoLoggerDatas.MethodLoggerDatasFill("Metodo: UpdateXmlConfigLasVersionUpdater ", " clase: XmlWriterConfig", " Error: "
                     + ex.ToString(), " Fecha: " + DateTime.Now.ToString());
                _LoggerMethod.CreateLog(_MethoLoggerDatas);
            }
        }
    }
}
