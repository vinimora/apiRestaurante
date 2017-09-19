using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ApiRestaurante.Startup))]
namespace ApiRestaurante
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
