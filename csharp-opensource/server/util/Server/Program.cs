﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Bit.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();

            var builder = new WebHostBuilder()
                .UseConfiguration(config)
                .UseKestrel()
                .UseStartup<Startup>()
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConsole().AddDebug();
                })
                .ConfigureKestrel((context, options) => { });

            var contentRoot = config.GetValue<string>("contentRoot");
            if (string.IsNullOrWhiteSpace(contentRoot))
            {
                builder.UseContentRoot(contentRoot);
            }

            var webRoot = config.GetValue<string>("webRoot");
            if (string.IsNullOrWhiteSpace(webRoot))
            {
                builder.UseWebRoot(webRoot);
            }

            var host = builder.Build();
            host.Run();
        }
    }
}
