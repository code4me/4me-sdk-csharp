using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Sdk4me.Tests
{
    [TestClass]
    public class ServiceLevelAgreementNotificationSchemeTest
    {
        [TestMethod]
        public void Get()
        {
            Sdk4meClient client = Client.Get();
            List<ServiceLevelAgreementNotificationScheme> schemes = client.ServiceLevelAgreementNotificationSchemes.Get("*");
            Assert.IsNotNull(schemes);
            Assert.IsInstanceOfType(schemes, typeof(List<ServiceLevelAgreementNotificationScheme>));
        }

        [TestMethod]
        public void CreateUpdateAndDisable()
        {
            Sdk4meClient client = Client.Get();

            //get existing
            ServiceLevelAgreementNotificationScheme scheme = client.ServiceLevelAgreementNotificationSchemes.Get(new Filter("sourceID", FilterCondition.Equality, "100"), "*").FirstOrDefault();

            if (scheme == null) 
            {
                //add
                scheme = new()
                {
                    Name = "Skd4me.Tests",
                    Source = "SDK4me",
                    SourceID = "100"
                };
                scheme = client.ServiceLevelAgreementNotificationSchemes.Insert(scheme);
                Assert.IsNotNull(scheme);
                Assert.AreEqual(scheme.SourceID, "100");
            }
             
            //update and enable
            scheme.SourceID = "102";
            scheme.Disabled = false;
            scheme = client.ServiceLevelAgreementNotificationSchemes.Update(scheme);
            Assert.AreEqual(scheme.SourceID, "102");
            Assert.AreEqual(scheme.Disabled, false);

            //update and disable
            scheme.SourceID = "100";
            scheme.Disabled = true;
            scheme = client.ServiceLevelAgreementNotificationSchemes.Update(scheme);
            Assert.AreEqual(scheme.SourceID, "100");
            Assert.AreEqual(scheme.Disabled, true);
        }

        [TestMethod]

        public void AddAndDeleteRule()
        {
            Sdk4meClient client = Client.Get();

            //get existing
            ServiceLevelAgreementNotificationScheme scheme = client.ServiceLevelAgreementNotificationSchemes.Get(new Filter("sourceID", FilterCondition.Equality, "100"), "*").FirstOrDefault();
            Assert.IsNotNull(scheme);

            //add rule
            ServiceLevelAgreementNotificationRule rule = client.ServiceLevelAgreementNotificationSchemes.AddNotificationRule(scheme, new()
            {
                ThresholdPercentage = 50,
                NotifyCurrentAssignee = true,
                NotifyFirstLineTeamCoordinator = true,
                NotifyFirstLineTeamManager = true,
                NotifyServiceOwner = true,
                NotifySupportTeamCoordinator = true,
                NotifySupportTeamManager = true
            });
            Assert.IsNotNull(rule);

            //delete rule
            client.ServiceLevelAgreementNotificationSchemes.DeleteNotificationRule(scheme, rule);

            //delete all rules
            client.ServiceLevelAgreementNotificationSchemes.DeleteAllNotificationRules(scheme);
        }
    }
}
