using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SongsAbout.Web.Startup))]
namespace SongsAbout.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

    }
  
}
