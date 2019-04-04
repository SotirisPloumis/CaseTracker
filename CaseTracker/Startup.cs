using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CaseTracker.Startup))]
namespace CaseTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
