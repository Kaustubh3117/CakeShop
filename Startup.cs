using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CakeShop.Startup))]
namespace CakeShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
