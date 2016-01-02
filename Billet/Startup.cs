using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Billet.Startup))]

namespace Billet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app){}
    }
}
