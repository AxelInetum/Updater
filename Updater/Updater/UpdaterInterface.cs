using msiAplication.ClassProcesSilentMsi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Updater.ClassProcesSilentMsi.SilentProcess;
using Updater.ClassProcesSilentMsi.VersionData;

namespace Updater
{
    public partial class UpdaterInterface : Form
    {
        public UpdaterInterface()
        {
            InitializeComponent();

            Timer MyTimer = new Timer();
            MyTimer.Interval = (1000);
            MyTimer.Tick += new EventHandler(InitTimerProcessUpdater);
            MyTimer.Start();

        }
       private void InitTimerProcessUpdater(object sender, EventArgs e)
       {
          //parte comun
            //Creamos el objeto con todas lav variable que se necesitan  
            InitProcessSilent initProcessSilent = new InitProcessSilent();
            //inicializamos los atributos 
            initProcessSilent.StartInitAtributesProcessSilent();
            //objeto para rellenar los datos de we b 
            WebServicesDatasVersions webServicesDatasVersions = new WebServicesDatasVersions();
            //rellanamos el objeto con los datos de la url y la ultima version del conector y update 
            webServicesDatasVersions.GetDatasWebServicesDatasVersions();
            //variables para rellenar la version actual del xml y la recibida de servidor https 
            Version currentversion;
            Version theLastVersionHttps;
            //ejecutamos el proceso para el conector 
            ProcessSilentMsi processSilentMsi = new ProcessSilentMsi();
            //incialiamos el objeto de descarga de fichero 
            HttpsMethods HttpsMethods = new HttpsMethods("");
            TheLastVersionDatas theLastVersionDatas;
          //

          //conecto F 
            //objeto con los datos de que versión se ha de comparar la piloto o la master (primero miramos la piloto y luego la master) 
            theLastVersionDatas = initProcessSilent.MsiAplicationUtilities.WhatVersionCompareConectorF(webServicesDatasVersions);
            //le seteamos la url de la ultima version
            HttpsMethods.httpRemotServer = theLastVersionDatas.urlLastVersion;
            //le agregamos al objeto que tiene todas las variables 
            initProcessSilent.HttpsMethods = HttpsMethods;
            //cojemos la version actual y la ultima version , pasamos los dos a objeto version
            currentversion = new Version(initProcessSilent.ReadDataConfigXml.versionConectorF);
            theLastVersionHttps = new Version(theLastVersionDatas.theLastVersion);
            //guardamos la version actual del conector F y la ultima version que proviene del webservices de hefame 
            initProcessSilent.currentVersion = currentversion;
            initProcessSilent.TheLastVersion = theLastVersionHttps;

            //comparamos la version actual con la remota (si la version actual es inferior generamos el proceso)
            if (initProcessSilent.MsiAplicationUtilities.CompareVersions(initProcessSilent.currentVersion, initProcessSilent.TheLastVersion) < 0)
            {
                //ejecutamos el proceso de actualización para el conector F 
                processSilentMsi.StartProcessSilent(initProcessSilent);
            }
          //

          /*
          //Updater F 
            //objeto con los datos de que versión se ha de comparar la piloto o la master (primero miramos la piloto y luego la master) 
            theLastVersionDatas = initProcessSilent.MsiAplicationUtilities.WhatVersionCompareUpdater(webServicesDatasVersions);
            //le seteamos la url de la ultima version
            HttpsMethods.httpRemotServer = theLastVersionDatas.urlLastVersion;
            //le agregamos al objeto que tiene todas las variables 
            initProcessSilent.HttpsMethods = HttpsMethods;
            //cojemos la version actual y la ultima version , pasamos los dos a objeto version
            currentversion = new Version(initProcessSilent.ReadDataConfigXml.versionConectorF);
            theLastVersionHttps = new Version(theLastVersionDatas.theLastVersion);
            //guardamos la version actual del conector F y la ultima version que proviene del webservices de hefame 
            initProcessSilent.currentVersion = currentversion;
            initProcessSilent.TheLastVersion = theLastVersionHttps;
            //comparamos la version actual con la remota (si la version actual es inferior generamos el proceso)
            if (initProcessSilent.MsiAplicationUtilities.CompareVersions(initProcessSilent.currentVersion, initProcessSilent.TheLastVersion) < 0)
            {
                //ejecutamos el proceso de actualización para el conector F 
                processSilentMsi.StartProcessSilent(initProcessSilent);
            }
          //
          */
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}

