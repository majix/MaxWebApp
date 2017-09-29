using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MaxWebApp.Startup))]
namespace MaxWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
