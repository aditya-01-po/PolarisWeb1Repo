using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IndividualAcc.Startup))]
namespace IndividualAcc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
