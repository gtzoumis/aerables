using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(aerables.Startup))]
namespace aerables
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
