using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
using Topshelf;
using Topshelf.Logging;

namespace notifyIpaddr
{
    public class ConfigureService
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
                                                                    .SetBasePath(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory))
                                                                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                                                    .AddEnvironmentVariables()    
                                                                    .Build();

        internal static void Configure()
        {

            HostFactory.Run(configure =>
            {
                configure.Service<NotifyService>(service =>
                {
                    service.ConstructUsing(s => new NotifyService(Configuration));                    
                    service.WhenStarted(s => s.Start());
                    service.WhenStopped(s => s.Stop());
                });

                //Setup Account that window service use to run.  
                configure.StartAutomatically();
                configure.RunAsLocalSystem();                
                configure.SetServiceName("Notify My IP");
                configure.SetDisplayName("Notify My IP");
                configure.SetDescription("");
            });
        }
    }
}
