using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AuctionLand.Web.Startup))]
namespace AuctionLand.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
