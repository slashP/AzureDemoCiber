using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AzureDemoCiber.Startup))]
namespace AzureDemoCiber
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
