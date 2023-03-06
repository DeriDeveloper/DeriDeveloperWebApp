using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using DeriLibrary.TelegramBot;

namespace DeriDeveloperWebApp
{
    public class Program
    {
        static WorkerDB WorkerDB;

        public static void Main(string[] args)
        {
            try
            {
                DeriLibrary.Console.Worker.NotifyMessageCall($"Запуск приложения по пути: {DeriLibrary.Console.Worker.GetEnvironmentCurrentDirectory()}");



				CreateHostBuilder(args).Build().Run();
            }
            catch (Exception error)
            {
                Console.WriteLine(error.ToString());   
            }
            Console.ReadLine();
        }

        

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.Configure<KestrelServerOptions>(context.Configuration.GetSection("Kestrel"));
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    //webBuilder.UseWebRoot("static");
                    webBuilder.UseUrls($"http://0.0.0.0:80/");


                    webBuilder.UseKestrel(options =>
                    {
                        
                            options.Listen(IPAddress.Loopback, 80); //HTTP port
                        
                    });

                    /*webBuilder.UseKestrel(opts =>
                    {
                        opts.Listen(IPAddress.Broadcast, port: 7030);
                    });*/
                });
    }
}
