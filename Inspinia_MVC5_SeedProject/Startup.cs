using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TFG.WebClient.Startup))]
namespace TFG.WebClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
