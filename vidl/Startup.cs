using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(vidl.Startup))]
namespace vidl
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
