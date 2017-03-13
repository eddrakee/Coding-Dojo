using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace Dojodachi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // for session
            services.AddSession();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder App, ILoggerFactory LoggerFactory)
        {
            LoggerFactory.AddConsole();
            App.UseDeveloperExceptionPage();
            App.UseStaticFiles();
            // for session
            App.UseSession();
            App.UseMvc();
        }
    }
}