using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Updater.Logger
{
    public class MethodLoggerDatas
    {
        public string Method;
        public string Class;
        public string Error;
        public string Date;

        public MethodLoggerDatas()
        {
            this.Method = "";
            this.Class = "";
            this.Error = "";
            this.Date = "";
        }

        public void MethodLoggerDatasFill(string Method, string Class, string Error, string Date)
        {
            this.Method = Method;
            this.Class = Class;
            this.Error = Error;
            this.Date = Date;
        }
    }
}
