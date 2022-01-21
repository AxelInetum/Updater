using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Updater.Logger;

namespace msiAplication.ClassProcesSilentMsi.LoggerMethods
{
    public class LoggerUtilities
    {

        public LoggerUtilities()
        {

        }

        private bool ExistFolderLogger(string path)
        {
            return Directory.Exists(path);
        }

        public void CreateFolderLogger(string path)
        {
            if (!this.ExistFolderLogger(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public bool ExistFileLogger(string path)
        {
            return File.Exists(path);
        }

        public void WriteFileMethodLogger(string path, MethodLoggerDatas methodLoggerData)
        {
            using (var tw = new StreamWriter(path, true))
            {
                this.AddDatasFile(tw, methodLoggerData);
            }
        }

        public void CreateFileMethodLogger(string path, MethodLoggerDatas methodLoggerData)
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                this.AddDatasFile(sw, methodLoggerData);
            }
        }

        private void AddDatasFile(StreamWriter tw, MethodLoggerDatas methodLoggerData)
        {
            tw.WriteLine("No se ha podido realizar el proceso de actualización por la siguiente excepción: ");
            tw.WriteLine(methodLoggerData.Error);
            tw.WriteLine("Con fecha y hora :" + DateTime.Now.ToString());
            tw.WriteLine("\r\n");
            tw.WriteLine("\r\n");
        }  
        
    }
}
