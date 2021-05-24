using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(POVTAS_OSU.Startup))]
namespace POVTAS_OSU
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
