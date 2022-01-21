using msiAplication.ClassProcesSilentMsi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Updater.Xml;

namespace PopupWithTimer.Xml
{
    public class XmlWriterConfig
    {
        private XmlDocument doc = new XmlDocument();
        public string localipAdress;
        public string port;
        public int limitProductsPopup;
        public string distribuitorHeFame;
        public int portDistribuitorHeFame;
        public bool automaticSubstituation = false;
        public int secondsTimerPopup;
        public string UrlGetDescriptionProduct;
        private string pathXml = @"C:\FarmaciaFmas\Config.xml";
        private Ilogger _LoggerMethod;
        public DatasHefameXml _DatasHefameXml;

        public XmlWriterConfig()
        {
            this.localipAdress = "";
            this.port = "";
            this.limitProductsPopup = 0;
            this.distribuitorHeFame = "";
            this.portDistribuitorHeFame = 0;
            this.automaticSubstituation = false;
            this.secondsTimerPopup = 0;
            this.UrlGetDescriptionProduct = "";   
             doc.Load(this.pathXml);

        }

        public void WriteXmlConfig()
        {
            try
            {
                XmlNode root = doc.DocumentElement;
                XmlNode Nodeport = root.SelectSingleNode("parametros").SelectSingleNode("port");
                XmlNode NodetimePopup = root.SelectSingleNode("parametros").SelectSingleNode("timepopup");
                XmlNode limitProductPopup= root.SelectSingleNode("parametros").SelectSingleNode("limitProductsPopup");
                XmlNode distribuitohefame  = root.SelectSingleNode("parametros").SelectSingleNode("distribuitorhefame");
                XmlNode portdistribuitorhefame = root.SelectSingleNode("parametros").SelectSingleNode("portdistribuitorhefame");
                
                XmlNode keyOrder = root.SelectSingleNode("parametros").SelectSingleNode("keyOrder");
                XmlNode reasonOrder = root.SelectSingleNode("parametros").SelectSingleNode("ReasonOrder");
                XmlNode selectedallpropuctspopup = root.SelectSingleNode("parametros").SelectSingleNode("selectedAllProductsPopup");
                XmlNode initRunSocket = root.SelectSingleNode("parametros").SelectSingleNode("initRunSocket");
                XmlNode automaticsubstituation = root.SelectSingleNode("parametros").SelectSingleNode("automaticsubstituation");
                XmlNode localIpAdressProxy = root.SelectSingleNode("parametros").SelectSingleNode("ProxyLocalIpMachine");

                doc.Save(this.pathXml);         
            }
            catch (Exception ex)
            {
           
            }

        }
    }
}
