using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using log4net.Config;
using System.IO;
using log4net.Layout;
using log4net.Core;

namespace LiteSchool.Library.Logging
{
    /*http://stackoverflow.com/questions/17752268/log4net-adonetappender-wont-insert-null-values-into-the-database*/
    public class RawExceptionLayout : IRawLayout
    {
        public virtual object Format(LoggingEvent loggingEvent)
        {
            if (loggingEvent.ExceptionObject != null)
                return loggingEvent.ExceptionObject.ToString();
            else
                return null;
        }
    }

    public class Log4NetAdapter : ILogger
    {
        private readonly log4net.ILog _log;

        public Log4NetAdapter()
        {
            XmlConfigurator.Configure();
            _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            log4net.Util.SystemInfo.NullText = null;
            log4net.Util.SystemInfo.NotAvailableText = null;
        }

        public void Log(string message)
        {
            try { 
            _log.Info(message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Log(string message, Exception ex, out Guid ticket)
        {
            ticket = Guid.NewGuid();
            log4net.LogicalThreadContext.Properties["ticket"] = ticket;
            _log.Error(message, ex);
        }

        public void Log(Exception ex, out Guid ticket)
        {
            Log(ex.Message, ex, out ticket);
        }

        public void Log(string message, Exception ex)
        {
            _log.Error(message, ex);
        }

        public void Log(Exception ex)
        {
            Log(ex.Message, ex);
        }
    }
}
