using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Sdk4me.Tests
{
    [TestClass]
    public class ServiceLevelAgreementTest
    {
        [TestMethod]
        public void Get()
        {
            Sdk4meClient client = Client.Get();
            List<ServiceLevelAgreement> serviceLevelAgreements = client.ServiceLevelAgreements.Get("*");
            Assert.IsNotNull(serviceLevelAgreements);
            Assert.IsInstanceOfType(serviceLevelAgreements, typeof(List<ServiceLevelAgreement>));

            if (serviceLevelAgreements.Count == 0)
                return;

            ServiceLevelAgreement serviceLevelAgreement = serviceLevelAgreements[Random.Shared.Next(serviceLevelAgreements.Count)];
            Trace.WriteLine($"Continue relation tests on service level agreement: {serviceLevelAgreement.Name}");

            List<EffortClassRateID> effortClassChargeID = client.ServiceLevelAgreements.GetEffortClassRateIDs(serviceLevelAgreement, "*");
            Assert.IsNotNull(effortClassChargeID);
            Assert.IsInstanceOfType(effortClassChargeID, typeof(List<EffortClassRateID>));

            List<StandardServiceRequestActivityID> standardServiceRequestActivityIDs = client.ServiceLevelAgreements.GetStandardServiceRequestActivityIDs(serviceLevelAgreement, "*");
            Assert.IsNotNull(standardServiceRequestActivityIDs);
            Assert.IsInstanceOfType(standardServiceRequestActivityIDs, typeof(List<StandardServiceRequestActivityID>));

            List<Person> people = client.ServiceLevelAgreements.GetCustomerRepresentatives(serviceLevelAgreement, "*");
            Assert.IsNotNull(people);
            Assert.IsInstanceOfType(people, typeof(List<Person>));

            List<Organization> organizations = client.ServiceLevelAgreements.GetOrganizations(serviceLevelAgreement, "*");
            Assert.IsNotNull(organizations);
            Assert.IsInstanceOfType(organizations, typeof(List<Organization>));

            List<Site> sites = client.ServiceLevelAgreements.GetSites(serviceLevelAgreement, "*");
            Assert.IsNotNull(sites);
            Assert.IsInstanceOfType(sites, typeof(List<Site>));

            List<SkillPool> skillPools = client.ServiceLevelAgreements.GetSkillPools(serviceLevelAgreement, "*");
            Assert.IsNotNull(skillPools);
            Assert.IsInstanceOfType(skillPools, typeof(List<SkillPool>));
        }
    }
}
