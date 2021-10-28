using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoAnCN.Startup))]
namespace DoAnCN
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
