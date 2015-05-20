using Ilc.InformationHarvester;
using DemoHarvester.DataCube;
using Ilc.WcfService;

namespace DemoHarvester
{
    [FaultServiceBehavior]
    public class DemoHarvesterService : HarvesterService
    {
        public DemoHarvesterService()
            : base(new DemoHarvesterDataCube())
        {
        }
    }
}