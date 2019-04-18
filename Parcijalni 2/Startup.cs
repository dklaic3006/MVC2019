using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Parcijalni_2.Startup))]
namespace Parcijalni_2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
