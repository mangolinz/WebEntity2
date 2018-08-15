using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebEntity2.Startup))]
namespace WebEntity2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
