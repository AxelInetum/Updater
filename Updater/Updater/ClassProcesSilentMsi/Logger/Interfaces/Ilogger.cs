using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Updater.Logger;

namespace msiAplication.ClassProcesSilentMsi.Interfaces
{
    public interface Ilogger
    {
          void CreateLog(MethodLoggerDatas datas);
    }
}
