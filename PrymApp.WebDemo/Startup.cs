using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PrymApp.WebDemo.Startup))]
namespace PrymApp.WebDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
