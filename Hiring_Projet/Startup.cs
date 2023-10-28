using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hiring_Projet.Startup))]
namespace Hiring_Projet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
