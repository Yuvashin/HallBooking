using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectHall4.Startup))]
namespace ProjectHall4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
