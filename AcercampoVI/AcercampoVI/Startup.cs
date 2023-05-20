using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AcercampoVI.Startup))]
namespace AcercampoVI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
