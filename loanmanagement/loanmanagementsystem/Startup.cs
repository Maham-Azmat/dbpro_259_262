using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(loanmanagementsystem.Startup))]
namespace loanmanagementsystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
