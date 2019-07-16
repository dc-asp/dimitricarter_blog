using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(dimitricarter_blog.Startup))]
namespace dimitricarter_blog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
