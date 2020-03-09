using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalTask.ApplicationLogger
{
    public static class Logger
    {
        static Logger()
        {
            XmlConfigurator.Configure();
        }

        public static ILog Log { get; } = LogManager.GetLogger("LOGGER");
    }
}
