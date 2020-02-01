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
        public static CF_ILogger GetCFLogger() => Const.IsDev ? CF_Logger.CreateInstance  // 開発用のLogger 
                                                              : CF_Logger.CreateInstance; // 本番用のLogger
    }
}
