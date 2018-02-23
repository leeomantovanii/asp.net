using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(testeIdentity.Startup))]
namespace testeIdentity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
