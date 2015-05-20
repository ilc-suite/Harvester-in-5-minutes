using DemoHarvester.DataCube;
using Ilc.InformationHarvester;
using Ilc.WcfService;

namespace DemoHarvester
{
    [OneWayFaultServiceBehavior]
    public class DemoHarvesterHarvester : InformationHarvester
    {
        public DemoHarvesterHarvester()
            : base(new DemoHarvesterDataCube())
        {
        }
    }
}