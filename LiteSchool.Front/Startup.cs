using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LiteSchool.Front.Startup))]
namespace LiteSchool.Front
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
