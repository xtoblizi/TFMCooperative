using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TFMCooperativeSociety.Startup))]
namespace TFMCooperativeSociety
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
