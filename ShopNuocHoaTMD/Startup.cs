using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShopNuocHoaTMD.Startup))]
namespace ShopNuocHoaTMD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
