using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Your_IoT_Handprint.Startup))]
namespace Your_IoT_Handprint
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
