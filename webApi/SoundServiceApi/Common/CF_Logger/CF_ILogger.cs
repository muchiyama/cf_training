using System;
using System.Collections.Generic;
using System.Text;

namespace Common.CF_Logger
{
    public abstract class CF_ILogger
    {
        public abstract void Debug(string msg);
        public abstract void Info(string msg);
        public abstract void Error(string msg, Exception ex = null);
        public abstract void Fatal(string msg, Exception ex = null);
    }
}
