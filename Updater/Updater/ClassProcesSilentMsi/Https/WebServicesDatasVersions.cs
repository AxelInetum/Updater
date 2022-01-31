using msiAplication.ClassProcesSilentMsi.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Updater.Logger;
using Updater.Xml;

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
        private Ilogger _LoggerMethod;
        private MethodLoggerDatas _MethoLoggerDatas = new MethodLoggerDatas();
        private XmlReaderConfig ReadDataConfigXml;
        public WebServicesDatasVersions(Ilogger loggerMethod)
        {
            _LoggerMethod = loggerMethod;
            urlUpdaterPilot = "";
            urlUpdaterMaster = "";
            ThelastVersionUpdaterPilot = "";
            ThelastVersionUpdaterMaster = "";
            urlConectorFPilot = "";
            urlConectorFMaster = "";
            ThelastVersionConectorFPilot = "";
            ThelastVersionConectorFMaster = "";
            ReadDataConfigXml = new XmlReaderConfig(_LoggerMethod);
        }

        public void GetDatasWebServicesDatasVersions()
        {
            try
            {
                HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create("http://hi.hefame.es/aracnida/actualiza.asp?"+"consultaVersion");
                webrequest.Method = "POST";
                webrequest.ContentType = "application/json";
                webrequest.ContentLength = 0;

                string key = "hI5sdf=2";
                string xuser = ReadDataConfigXml.GetValue("parametros", "CodigoFarmacia");
                string xsalt = "hi";
                string xkey = "815b69a62ebc9a9e0f75774225969242";

                /*Parametros de la cabecera*/
                webrequest.Headers.Add("x-user", xuser);
                webrequest.Headers.Add("x-salt", xsalt);
                webrequest.Headers.Add("x-key", xkey);
                webrequest.Headers.Add("x-hash", "MD5");

                Stream stream = webrequest.GetRequestStream();
                stream.Close();
                string result;
                using (WebResponse response = webrequest.GetResponse()) 
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        result = reader.ReadToEnd();
                        string axel = Convert.ToString(result);
                    }
                }




                /*

                urlUpdaterPilot = "https://localhost:443/HefameSetup.msi";
                urlUpdaterMaster = "https://localhost:443/HefameSetup.msi";
                ThelastVersionUpdaterPilot = "1.1.2";
                ThelastVersionUpdaterMaster = "1.1.2";
                urlConectorFPilot = "https://localhost:443/HefameSetup.msi";
                urlConectorFMaster = "https://localhost:443/HefameSetup.msi";
                ThelastVersionConectorFPilot = "1.1.2";
                ThelastVersionConectorFMaster = "1.1.2";
                */

            }

            catch (Exception ex)
            {
                _MethoLoggerDatas.MethodLoggerDatasFill("Metodo: GetDatasWebServicesDatasVersions ", " clase: WebServicesDatasVersions", " Error: "
                            + ex.ToString(), " Fecha: " + DateTime.Now.ToString());
                _LoggerMethod.CreateLog(_MethoLoggerDatas);
            }
        }
    }

}


