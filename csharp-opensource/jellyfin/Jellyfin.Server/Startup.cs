using Jellyfin.Server.Extensions;
using MediaBrowser.Controller;
using MediaBrowser.Controller.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Jellyfin.Server
{
    /// <summary>
    /// Startup configuration for the Kestrel webhost.
    /// </summary>
    public class Startup
    {
        private readonly IServerConfigurationManager _serverConfigurationManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup" /> class.
        /// </summary>
        /// <param name="serverConfigurationManager">The server configuration manager.</param>
        public Startup(IServerConfigurationManager serverConfigurationManager)
        {
            _serverConfigurationManager = serverConfigurationManager;
        }

        /// <summary>
        /// Configures the service collection for the webhost.
        /// </summary>
        /// <param name="services">The service collection.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCompression();
            services.AddHttpContextAccessor();
            services.AddJellyfinApi(_serverConfigurationManager.Configuration.BaseUrl.TrimStart('/'));

            services.AddJellyfinApiSwagger();

            // configure custom legacy authentication
            services.AddCustomAuthentication();

            services.AddJellyfinApiAuthorization();
        }

        /// <summary>
        /// Configures the app builder for the webhost.
        /// </summary>
        /// <param name="app">The application builder.</param>
        /// <param name="env">The webhost environment.</param>
        /// <param name="serverApplicationHost">The server application host.</param>
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            IServerApplicationHost serverApplicationHost)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWebSockets();

            app.UseResponseCompression();

            // TODO app.UseMiddleware<WebSocketMiddleware>();
            app.Use(serverApplicationHost.ExecuteWebsocketHandlerAsync);

            // TODO use when old API is removed: app.UseAuthentication();
            app.UseJellyfinApiSwagger();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Use(serverApplicationHost.ExecuteHttpHandlerAsync);
        }
    }
}
