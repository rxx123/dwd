using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kcdz.dwd.api.common
{
    public class NLogger
    {
        public static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
    }
}
