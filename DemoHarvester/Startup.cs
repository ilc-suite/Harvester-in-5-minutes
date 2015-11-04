using Ilc.InformationHarvester;
using DemoHarvester;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace DemoHarvester
{
    public class Startup : HarvesterStartupBase
    {
        public void Configuration(IAppBuilder app)
        {
            Initialize();
        }
    }
}