using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Hangfire;

[assembly: OwinStartup(typeof(TableTap.Startup))]

namespace TableTap
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            {

                GlobalConfiguration.Configuration.UseSqlServerStorage("ConnectionString");

                app.UseHangfireDashboard();
                app.UseHangfireServer();
                
            }
        }
    }
}
