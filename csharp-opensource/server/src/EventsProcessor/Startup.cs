﻿using System.Globalization;
using Bit.Core;
using Bit.Core.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;

namespace Bit.EventsProcessor
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Options
            services.AddOptions();

            // Settings
            services.AddGlobalSettingsServices(Configuration);

            // Hosted Services
            services.AddHostedService<AzureQueueHostedService>();
        }

        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            IHostApplicationLifetime appLifetime,
            GlobalSettings globalSettings)
        {
            IdentityModelEventSource.ShowPII = true;
            app.UseSerilog(env, appLifetime, globalSettings);
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/alive", 
                    async context => await context.Response.WriteAsync(System.DateTime.UtcNow.ToString()));
            });
        }
    }
}
