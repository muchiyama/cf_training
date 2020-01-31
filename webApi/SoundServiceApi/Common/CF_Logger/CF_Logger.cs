using System;
using System.Collections.Generic;
using System.Text;

namespace Common.CF_Logger
{
    public class CF_Logger : CF_ILogger
    {
        /// <summary>
        /// ラップしてるロガー
        /// </summary>
        private readonly log4net.ILog logger;

        /// <summary>
        /// BUilderオブジェクト
        /// </summary>
        private readonly Log4netBuilder builder;

        /// <summary>
        /// logger object wrapped in log4net
        /// </summary>
        public CF_Logger()
        {
            logger = new Log4netBuilder().Log4netConfig(Const.loggerConfDir)
                   .LoggerName(Const.loggerName)
                   .Assembly(System.Reflection.Assembly.GetEntryAssembly())
                   .Build();
        }

        public override void Debug(string msg)
        {
            if (logger.IsDebugEnabled)
                logger.Debug(msg);
        }
        public override void Info(string msg)
        {
            if (logger.IsInfoEnabled)
                logger.Info(msg);
        }
        public override void Error(string msg, Exception ex = null)
        {
            if (logger.IsErrorEnabled)
                logger.Error(msg, ex);
        }
        public override void Fatal(string msg, Exception ex = null)
        {
            if (logger.IsFatalEnabled)
                logger.Fatal(msg, ex);
        }
    }
}
