using msiAplication.ClassProcesSilentMsi.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Updater.Logger;

namespace Updater.ClassProcesSilentMsi.ProcessValidatedFarmacia
{
    public class ProcessValidatedFarmaciaRun
    {

        private Ilogger _loggerMethod;
        private MethodLoggerDatas _MethoLoggerDatas = new MethodLoggerDatas();
        public ProcessValidatedFarmaciaRun(Ilogger loggerMethod)
        {
            _loggerMethod = loggerMethod;
        }

        public Process ProcessValidatedRun()
        {
            Process processFarmacia = null;
            try
            {          
                foreach (Process process in Process.GetProcesses())
                {
                    if (process != null && process.ProcessName == "FarmaciaF+")
                    {
                        processFarmacia = process;
                        break;
                    }
                }
            }
            catch(Exception ex)
            {
                _MethoLoggerDatas.MethodLoggerDatasFill("Metodo: ProcessValidatedRun", " clase: ProcessValidatedFarmaciaRun", " Error: "
                             + ex.ToString(), " Fecha: " + DateTime.Now.ToString());
                _loggerMethod.CreateLog(_MethoLoggerDatas);
            }

            return processFarmacia;
        }

        public void RunProcessFarmacia()
        {
            Process processFarmacia = new Process();
            try
            {
                processFarmacia.StartInfo.FileName = @"C:\FarmaciaFmas\FarmaciaF+.exe";
                processFarmacia.Start();
            }
            catch(Exception ex)
            {
                _MethoLoggerDatas.MethodLoggerDatasFill("Metodo: RunProcessFarmacia", " clase: ProcessValidatedFarmaciaRun", " Error: "
                             + ex.ToString(), " Fecha: " + DateTime.Now.ToString());
                _loggerMethod.CreateLog(_MethoLoggerDatas);
            }    
        }
    }
}
