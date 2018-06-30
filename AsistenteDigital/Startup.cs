using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AsistenteDigital.Startup))]
namespace AsistenteDigital
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
