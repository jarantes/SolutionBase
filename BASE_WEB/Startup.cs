using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BASE_WEB.Startup))]
namespace BASE_WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
