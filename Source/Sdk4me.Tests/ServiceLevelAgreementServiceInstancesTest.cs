using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Sdk4me.Tests
{
    [TestClass]
    public class ServiceLevelAgreementServiceInstancesTest
    {
        [TestMethod]
        public void Get()
        {
            Sdk4meClient client = Client.Get();
            ServiceLevelAgreement sla = client.ServiceLevelAgreements.Get(313);
            Assert.IsNotNull(sla);

            List<ServiceLevelAgreementServiceInstanceRelation> relations = client.ServiceLevelAgreements.GetServiceInstances(sla, "*");
            Assert.IsNotNull(relations);

            ServiceLevelAgreementServiceInstanceRelation relation = relations.Where(x => x.ServiceInstance.ID == 87).FirstOrDefault();
            Assert.IsNotNull(relation);

            bool result = client.ServiceLevelAgreements.DeleteServiceInstance(sla, relation);
            Assert.AreEqual(true, result);

            relation = client.ServiceLevelAgreements.AddServiceInstance(sla, new ServiceLevelAgreementServiceInstanceRelation()
            {
                ImpactRelation = ServiceLevelAgreementServiceInstanceRelationStatus.Down,
                ServiceInstance = new ServiceInstance() { ID = 87 }
            });
            Assert.IsNotNull(relation);
        }
    }
}
