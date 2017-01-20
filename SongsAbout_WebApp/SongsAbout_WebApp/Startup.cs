using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using React;
using React.AspNet;
using React.Web;
using React.Web.Mvc;
using React.TinyIoC;
using Microsoft.Owin;
using Owin;



[assembly: OwinStartupAttribute(typeof(SongsAbout_WebApp.Startup))]
namespace SongsAbout_WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
