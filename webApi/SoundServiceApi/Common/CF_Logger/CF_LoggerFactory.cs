using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Xml;
using System.IO;

namespace Common.CF_Logger
{
    public static class CF_LoggerFactory
    {
        public static CF_Logger GetCFLogger() => new CF_Logger();
    }
}
