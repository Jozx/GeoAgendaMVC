using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GeoAgenda.Startup))]
namespace GeoAgenda
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
