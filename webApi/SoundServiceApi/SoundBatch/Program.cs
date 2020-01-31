using Common;
using Common.CF_Logger;
using SoundBatch.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoundBatch
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = CF_LoggerFactory.GetCFLogger();
            logger.Info(Const.I001(Const.N001));
            try
            {
                new RegisterContentsInfo().Update();
            }
            catch(Exception ex)
            {
                logger.Error(Const.E001, ex);
            }
        }
    }
}
