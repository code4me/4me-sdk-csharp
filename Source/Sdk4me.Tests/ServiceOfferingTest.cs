using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Sdk4me.Tests
{
    [TestClass]
    public class ServiceOfferingTest
    {
        [TestMethod]
        public void Get()
        {
            Sdk4meClient client = Client.Get();
            List<ServiceOffering> serviceOfferings = client.ServiceOfferings.Get("*");
            Assert.IsNotNull(serviceOfferings);
            Assert.IsInstanceOfType(serviceOfferings, typeof(List<ServiceOffering>));

            List<StandardServiceRequest> serviceRequests = client.ServiceOfferings.GetStandardServiceRequests(serviceOfferings.First(x => x.ID == 27));
            Assert.IsTrue(serviceRequests.Any());
        }
    }
}
