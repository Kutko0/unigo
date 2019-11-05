using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Unigo.Startup))]
namespace Unigo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
