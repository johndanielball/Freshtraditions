using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FT.Startup))]
namespace FT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
