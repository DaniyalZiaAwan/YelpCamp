using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(YelpCamps.Startup))]
namespace YelpCamps
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
