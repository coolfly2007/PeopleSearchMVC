using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PeopleSearchMvc.Startup))]
namespace PeopleSearchMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
