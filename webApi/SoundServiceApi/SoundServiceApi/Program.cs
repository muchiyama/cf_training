using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SoundServiceApi
{
    public class Program
    {
        /// <summary>
        /// appsetting.jsonのエセDI
        /// </summary>
        public static IConfigurationRoot configuration;

        public static void Main(string[] args)
        {
            configuration = new ConfigurationBuilder().SetBasePath(Environment.CurrentDirectory).AddJsonFile(@"appsettings.json", false).Build();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls(configuration.GetSection(Const.s_LaunchUrls).Value) // ローンチの際のURL指定 -> appsetting.jsonより取得
                              .UseStartup<Startup>();
                });
    }
}
