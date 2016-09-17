using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LabASP1.Startup))]
namespace LabASP1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
