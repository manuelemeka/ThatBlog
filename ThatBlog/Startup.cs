using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ThatBlog.Startup))]
namespace ThatBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
