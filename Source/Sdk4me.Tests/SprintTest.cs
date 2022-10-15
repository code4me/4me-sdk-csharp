using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Sdk4me.Tests
{
    [TestClass]
    public class SprintTest
    {
        [TestMethod]
        public void Get()
        {
            Sdk4meClient client = Client.Get();
            List<Sprint> sprints = client.Sprints.Get("*");
            Assert.IsNotNull(sprints);
            Assert.IsInstanceOfType(sprints, typeof(List<Sprint>));

            if (sprints.FirstOrDefault() is Sprint sprint)
            {
                List<SprintBacklogItem> sprintBacklogItems = client.Sprints.GetBacklogItems(sprint);
                Assert.IsNotNull(sprintBacklogItems);
                Assert.IsInstanceOfType(sprintBacklogItems, typeof(List<SprintBacklogItem>));

                List<AuditTrail> auditTrails = client.Sprints.GetAuditTrail(sprint);
                Assert.IsNotNull(auditTrails);
                Assert.IsInstanceOfType(auditTrails, typeof(List<AuditTrail>));
            }
        }
    }
}
