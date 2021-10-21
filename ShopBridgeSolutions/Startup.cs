using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShopBridgeSolutions.Startup))]
namespace ShopBridgeSolutions
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
