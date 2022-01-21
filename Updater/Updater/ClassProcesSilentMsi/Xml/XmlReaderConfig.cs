using System;
using System.Collections.Generic;
using System.Xml;
using msiAplication.ClassProcesSilentMsi.Interfaces;
using Updater.Logger;

namespace Updater.Xml
{
    public class XmlReaderConfig
    {
        private XmlDocument doc = new XmlDocument();
        private  Ilogger _LoggerMethod;
        private string _filename = @"C:\FarmaciaFmas\Config.xml";
        private MethodLoggerDatas _MethoLoggerDatas = new MethodLoggerDatas();
        public string versionConectorF;
        public string versionUpdater;
        public XmlReaderConfig(Ilogger loggerMethod)
        {
            doc.Load(this._filename);
            versionConectorF = "";
            versionUpdater = "";
            _LoggerMethod = loggerMethod;
        }

        public void LoadXmlReaderConfigFill()
        {
            try
            {
                this.versionConectorF  = this.GetValue("parametros", "versionConector");
                this.versionUpdater = this.GetValue("parametros", "versionUpdater");

            }
            catch (Exception ex)
            {
                _MethoLoggerDatas.MethodLoggerDatasFill("Metodo: LoadXmlReaderConfigFill ", " clase: XmlReaderConfig", " Error: "
                                 + ex.ToString(), " Fecha: " + DateTime.Now.ToString());
                _LoggerMethod.CreateLog(_MethoLoggerDatas);
            }
        }

        private string GetValue(string tag, string valor)
        {
            XmlNodeList nodeList = doc.GetElementsByTagName(tag);
            string value = null;
            try
            {
                foreach (XmlNode tags in nodeList)
                {
                    if (tags.Name.Contains(tag))
                    {
                        value = tags.SelectSingleNode(valor).InnerText;
                        break;
                    }
                }
                return value;
            }
            catch (Exception ex)
            {
                _MethoLoggerDatas.MethodLoggerDatasFill("Metodo: GetValue ", " clase: XmlReaderConfig", " Error: "
                                 + ex.ToString(), " Fecha: " + DateTime.Now.ToString());
                _LoggerMethod.CreateLog(_MethoLoggerDatas);
                return "";
            }

        }
    }
}
