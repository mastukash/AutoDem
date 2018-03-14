using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutoDem.Startup))]
namespace AutoDem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
