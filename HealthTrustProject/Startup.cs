using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HealthTrustProject.Startup))]
namespace HealthTrustProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
