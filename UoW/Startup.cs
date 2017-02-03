using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UoW.Startup))]
namespace UoW
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
