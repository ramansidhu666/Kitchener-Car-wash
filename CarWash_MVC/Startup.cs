using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarWash_MVC.Startup))]
namespace CarWash_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
