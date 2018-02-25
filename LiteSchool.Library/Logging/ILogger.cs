using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiteSchool.Library.Logging
{
    public interface ILogger
    {
        void Log(string message);
        void Log(string message, Exception ex);
        void Log(Exception ex);

        void Log(string message, Exception ex, out Guid ticket);
        void Log(Exception ex, out Guid ticket);
    }
}
