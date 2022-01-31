using FarmaciaFmas;
using msiAplication.ClassProcesSilentMsi;
using msiAplication.ClassProcesSilentMsi.Interfaces;
using msiAplication.ClassProcesSilentMsi.LoggerMethods;
using PopupWithTimer.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Updater.ClassProcesSilentMsi.ProcessValidatedFarmacia;
using Updater.ClassProcesSilentMsi.SilentProcess;
using Updater.ClassProcesSilentMsi.VersionData;

namespace Updater
{
    public partial class UpdaterInterface : Form
    {
        private Ilogger _LoggerMethod = new LoggerMethod();
        private ProcessValidatedFarmaciaRun _ProcessValidatedFarmaciaRun = new ProcessValidatedFarmaciaRun(new LoggerMethod());

        //comprobación que el updater no este funcionando 
        //


        //cojer el tiempo del xml (de una hora)    
        public UpdaterInterface()
        {
            InitializeComponent();


            // 'Comprobamos si la aplicación updater la primera cosa que tiene que hacer 
            /*Dim contador As Byte = 0
            Dim p As Process
            For Each p In Process.GetProcesses()
                If Not p Is Nothing Then
                    If p.ProcessName = "FarmaciaF+" Then
                        contador = contador + 1
                    End If
                End If
            Next
            If contador > 1 Then
                MsgBox("La aplicación se encuentra en ejecución, revise la barra de notificaciones.", vbCritical, "F+Club")
                End
            End If
            */



            //180000000

            Timer myTimerProcessUpdater = new Timer();
            myTimerProcessUpdater.Interval = (1000);
            myTimerProcessUpdater.Tick += new EventHandler(InitTimerProcessUpdater);
            myTimerProcessUpdater.Start();


            //comprobacion  del updater  
            Timer myTimerValidatedProcessFarmacia = new Timer();
            myTimerValidatedProcessFarmacia.Interval = (5000);
            myTimerValidatedProcessFarmacia.Tick += new EventHandler(ValidatedProcessFarmaciaRun);
            myTimerValidatedProcessFarmacia.Start();

     



        }
       private void InitTimerProcessUpdater(object sender, EventArgs e)
       {
            //parte comun
            //Creamos el objeto con todas lav variable que se necesitan  
            CommonDataProcessSilent commonDataProcessSilent = new CommonDataProcessSilent(_LoggerMethod);
            //leemos la versión actual del ConectorF desde el config.xml 
            commonDataProcessSilent.currentVersion = commonDataProcessSilent.ReadDataConfigXml.versionConectorF;
            //realizamos el proceso de pasar la versión actual del conector y realizar la comparación de versión 
            //primero miramos si existe un versión piloto , sino existe miramos la maestra 
            //si existe la piloto y la actual es igual no realizamos ninguna acción , sino se realizara el proceso de actualización 
            //si no existe la versión piloto entonces se mira la master si la master es inferior entonces se realiza la actualización
            DatasPathSilentSetup DatasPathSilentSetupObject = commonDataProcessSilent.WS_ClieAPI.ChequearVersionMaestraAsync(commonDataProcessSilent.currentVersion,"CONECTOR").Result;

            //si tenemos ruta entonces tenemos que actualizar 
            if (DatasPathSilentSetupObject != null)
            {
                commonDataProcessSilent.processSilentMsi.StartProcessSilent(commonDataProcessSilent, DatasPathSilentSetupObject);
            }















            /*


            WebServicesDatasVersions webServicesDatasVersions = new WebServicesDatasVersions(_LoggerMethod);
            //rellanamos el objeto con los datos de la url y la ultima version del conector y update 
            webServicesDatasVersions.GetDatasWebServicesDatasVersions();
            //variables para rellenar la version actual del xml y la recibida de servidor https 
            Version currentversion;
            Version theLastVersionHttps;
            //ejecutamos el proceso para el conector 
            ProcessSilentMsi processSilentMsi = new ProcessSilentMsi(_LoggerMethod);
            //incialiamos el objeto de descarga de fichero 
            HttpsMethods HttpsMethods = new HttpsMethods("");
            TheLastVersionDatas theLastVersionDatas;
            XmlWriterConfig XmlWriterConfigs = new XmlWriterConfig(_LoggerMethod); 
            //

            //conecto F 
            //objeto con los datos de que versión se ha de comparar la piloto o la master (primero miramos la piloto y luego la master) 
            theLastVersionDatas = commonDataProcessSilent.MsiAplicationUtilities.WhatVersionCompareConectorF(webServicesDatasVersions);
            //le seteamos la url de la ultima version
            HttpsMethods.httpRemotServer = theLastVersionDatas.urlLastVersion;
            //le agregamos al objeto que tiene todas las variables 
            commonDataProcessSilent.HttpsMethods = HttpsMethods;
            //cojemos la version actual y la ultima version , pasamos los dos a objeto version
            currentversion = new Version(commonDataProcessSilent.ReadDataConfigXml.versionConectorF);
            theLastVersionHttps = new Version(theLastVersionDatas.theLastVersion);
            //guardamos la version actual del conector F y la ultima version que proviene del webservices de hefame 


            //comparamos la version actual con la remota (si la version actual es inferior generamos el proceso)
            if (commonDataProcessSilent.MsiAplicationUtilities.CompareVersions(null, null) < 0)
            {
                //ejecutamos el proceso de actualización para el conector F 
      
            }
            */
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
                  //actualizamo los tags del xml .config 
                  //actualizamos el tag del xml.config de la ultima version del conectorF
                  XmlWriterConfigs.UpdateXmlConfigLasVersionConectorF(theLastVersionHttps.ToString());
                  //cerramoa el aplicativo al cerrarse el updater detectara que se ha cerrado y lo reabrira con la version nueva instalada 
                  Environment.Exit(0);
              }
            //
            */
        }
       //metodo para comprobar que el farmacia + esta funcionando
       private void ValidatedProcessFarmaciaRun(object sender, EventArgs e)
       {
           Process validatedFarmarciaRun =_ProcessValidatedFarmaciaRun.ProcessValidatedRun();
           if (validatedFarmarciaRun ==null)
           {
                _ProcessValidatedFarmaciaRun.RunProcessFarmacia();
           }
       }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void UpdaterInterface_Load(object sender, EventArgs e)
        {

        }
    }
}

