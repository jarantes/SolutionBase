using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WEB_BASE.Startup))]
namespace WEB_BASE
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
