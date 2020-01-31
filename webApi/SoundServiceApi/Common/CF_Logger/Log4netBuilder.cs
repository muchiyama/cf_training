using log4net.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace Common.CF_Logger
{
    public class Log4netBuilder
    {
        private string _log4netConfig;
        private string _loggerName;
        private Assembly _assembly;
        public Log4netBuilder() {  }

        public Log4netBuilder Log4netConfig(string _path)
        {
            _log4netConfig = _path;
            return this;
        }

        public Log4netBuilder Assembly(Assembly _assembly)
        {
            this._assembly = _assembly;
            return this;
        }

        public Log4netBuilder LoggerName(string _loggerName)
        {
            this._loggerName = _loggerName;
            return this;
        }

        public log4net.ILog Build()
        {
            log4net.Config.XmlConfigurator.Configure(GetRepos(), GetConfig());
            return log4net.LogManager.GetLogger(System.Reflection.Assembly.GetEntryAssembly(), _loggerName);
        }

        private ILoggerRepository GetRepos() => log4net.LogManager.GetRepository(_assembly);

        private XmlElement GetConfig()
        {
            var res = new XmlDocument();
            res.Load(GetXmlStream());
            return res.DocumentElement;
        }

        private Stream GetXmlStream() => (Stream)File.OpenRead(_log4netConfig);

    }
}
