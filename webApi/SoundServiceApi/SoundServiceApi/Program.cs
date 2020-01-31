using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SoundServiceApi
{
    public class Program
    {
        public static IConfigurationRoot configuration;
        public static void Main(string[] args)
        {
            // Dev用
            configuration = new ConfigurationBuilder().SetBasePath(Environment.CurrentDirectory).AddJsonFile(@"appsettings.json", false).Build();
            // デプロイ用
            //configuration = new ConfigurationBuilder().SetBasePath($@"{Environment.CurrentDirectory}\netcoreapp3.1").AddJsonFile(@"appsettings.json", false).Build();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls(configuration.GetSection("LaunchUrls").Value)
                              .UseStartup<Startup>();
                });
    }
}
