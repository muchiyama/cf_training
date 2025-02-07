﻿using log4net.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace Common.CF_Logger
{
    internal class Log4netBuilder
    {
        private string log4netConfig;
        private string loggerName;
        private Assembly assembly;
        public Log4netBuilder() {  }

        /// <summary>
        /// Confファイルのパス
        /// </summary>
        /// <param name="_path"></param>
        /// <returns></returns>
        public Log4netBuilder Log4netConfig(string _path)
        {
            log4netConfig = _path;
            return this;
        }

        /// <summary>
        /// 実行アセンブリ
        /// </summary>
        /// <param name="_assembly"></param>
        /// <returns></returns>
        public Log4netBuilder Assembly(Assembly _assembly)
        {
            this.assembly = _assembly;
            return this;
        }

        /// <summary>
        /// ロガー名
        /// </summary>
        /// <param name="_loggerName"></param>
        /// <returns></returns>
        public Log4netBuilder LoggerName(string _loggerName)
        {
            this.loggerName = _loggerName;
            return this;
        }

        /// <summary>
        /// Buildする
        /// </summary>
        /// <returns></returns>
        public log4net.ILog Build()
        {
            log4net.Config.XmlConfigurator.Configure(GetRepos(), GetConfig());
            return log4net.LogManager.GetLogger(System.Reflection.Assembly.GetEntryAssembly(), loggerName);
        }

        /// <summary>
        /// TODO: 何やってるか忘れた
        /// </summary>
        /// <returns></returns>
        private ILoggerRepository GetRepos() => log4net.LogManager.GetRepository(assembly);

        /// <summary>
        /// Confファイル取得
        /// </summary>
        /// <returns></returns>
        private XmlElement GetConfig()
        {
            var res = new XmlDocument();
            res.Load(GetXmlStream());
            return res.DocumentElement;
        }

        /// <summary>
        /// コンフィグファイルを開く
        /// </summary>
        /// <returns></returns>
        private Stream GetXmlStream() => (Stream)File.OpenRead(log4netConfig);

    }
}
