using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Team3Store.WebUI.Startup))]
namespace Team3Store.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
