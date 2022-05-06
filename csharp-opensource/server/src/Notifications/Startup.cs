﻿using System.Collections.Generic;
using System.Globalization;
using Bit.Core;
using Bit.Core.Utilities;
using IdentityModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;

namespace Bit.Notifications
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
            var globalSettings = services.AddGlobalSettingsServices(Configuration);

            // Identity
            services.AddIdentityAuthenticationServices(globalSettings, Environment, config =>
            {
                config.AddPolicy("Application", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim(JwtClaimTypes.AuthenticationMethod, "Application");
                    policy.RequireClaim(JwtClaimTypes.Scope, "api");
                });
                config.AddPolicy("Internal", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim(JwtClaimTypes.Scope, "internal");
                });
            });

            // SignalR
            var signalRServerBuilder = services.AddSignalR().AddMessagePackProtocol(options =>
            {
                options.FormatterResolvers = new List<MessagePack.IFormatterResolver>()
                {
                    MessagePack.Resolvers.ContractlessStandardResolver.Instance
                };
            });
            if (CoreHelpers.SettingHasValue(globalSettings.Notifications?.RedisConnectionString))
            {
                signalRServerBuilder.AddStackExchangeRedis(globalSettings.Notifications.RedisConnectionString,
                    options =>
                    {
                        options.Configuration.ChannelPrefix = "Notifications";
                    });
            }
            services.AddSingleton<IUserIdProvider, SubjectUserIdProvider>();
            services.AddSingleton<ConnectionCounter>();

            // Mvc
            services.AddMvc();

            services.AddHostedService<HeartbeatHostedService>();
            if (!globalSettings.SelfHosted)
            {
                // Hosted Services
                Jobs.JobsHostedService.AddJobsServices(services);
                services.AddHostedService<Jobs.JobsHostedService>();
                if (CoreHelpers.SettingHasValue(globalSettings.Notifications?.ConnectionString))
                {
                    services.AddHostedService<AzureQueueHostedService>();
                }
            }
        }

        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            IHostApplicationLifetime appLifetime,
            GlobalSettings globalSettings)
        {
            IdentityModelEventSource.ShowPII = true;
            app.UseSerilog(env, appLifetime, globalSettings);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Add routing
            app.UseRouting();

            // Add Cors
            app.UseCors(policy => policy.SetIsOriginAllowed(h => true)
                .AllowAnyMethod().AllowAnyHeader().AllowCredentials());

            // Add authentication to the request pipeline.
            app.UseAuthentication();
            app.UseAuthorization();

            // Add endpoints to the request pipeline.
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<NotificationsHub>("/hub", options =>
                {
                    options.ApplicationMaxBufferSize = 2048; // client => server messages are not even used
                    options.TransportMaxBufferSize = 4096;
                });
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
