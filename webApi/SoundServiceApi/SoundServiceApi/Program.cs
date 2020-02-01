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
        /// appsetting.json�̃G�ZDI
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
                    webBuilder.UseUrls(configuration.GetSection(Const.s_LaunchUrls).Value) // ���[���`�̍ۂ�URL�w�� -> appsetting.json���擾
                              .UseStartup<Startup>();
                });
    }
}
