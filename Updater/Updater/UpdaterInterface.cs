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

namespace Updater
{
    public partial class UpdaterInterface : Form
    {
        public UpdaterInterface()
        {
            InitializeComponent();
            ProcessSilentMsi.InitProcessSilentMsi();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
