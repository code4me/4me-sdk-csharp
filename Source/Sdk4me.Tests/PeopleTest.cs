using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Sdk4me.Tests
{
    [TestClass]
    public class PeopleTest
    {

        [TestMethod]
        public void GetMe()
        {
            Sdk4meClient client = Client.Get();
            Person me = client.Me.Get();
            Assert.IsInstanceOfType(me, typeof(Person));
            Assert.IsTrue(me.ID > 0);

            List<AccountPermission> permissions = client.People.GetAccountPermissions(me);
            Assert.IsNotNull(permissions);
            Assert.IsInstanceOfType(permissions, typeof(List<AccountPermission>));

            List<Address> addresses = client.People.GetAddresses(me, "*");
            Assert.IsNotNull(addresses);
            Assert.IsInstanceOfType(addresses, typeof(List<Address>));

            List<AuditTrail> auditTrail = client.People.GetAuditTrail(me);
            Assert.IsNotNull(auditTrail);
            Assert.IsInstanceOfType(auditTrail, typeof(List<AuditTrail>));

            List<ConfigurationItem> cis = client.People.GetConfigurationItemCoverage(me, "*");
            Assert.IsNotNull(cis);
            Assert.IsInstanceOfType(cis, typeof(List<ConfigurationItem>));

            cis = client.People.GetConfigurationItems(me, "*");
            Assert.IsNotNull(cis);
            Assert.IsInstanceOfType(cis, typeof(List<ConfigurationItem>));

            List<Contact> contacts = client.People.GetContacts(me, "*");
            Assert.IsNotNull(contacts);
            Assert.IsInstanceOfType(contacts, typeof(List<Contact>));

            List<Service> services = client.People.GetServiceCoverage(me, "*");
            Assert.IsNotNull(services);
            Assert.IsInstanceOfType(services, typeof(List<Service>));

            List<ServiceInstance> serviceInstances = client.People.GetServiceInstanceCoverage(me, "*");
            Assert.IsNotNull(serviceInstances);
            Assert.IsInstanceOfType(serviceInstances, typeof(List<ServiceInstance>));

            List<ServiceLevelAgreement> sla = client.People.GetServiceLevelAgreementCoverage(me, "*");
            Assert.IsNotNull(sla);
            Assert.IsInstanceOfType(sla, typeof(List<ServiceLevelAgreement>));

            List<SkillPool> skillPools = client.People.GetSkillPools(me, "*");
            Assert.IsNotNull(skillPools);
            Assert.IsInstanceOfType(skillPools, typeof(List<SkillPool>));

            List<Team> teams = client.People.GetTeams(me, "*");
            Assert.IsNotNull(teams);
            Assert.IsInstanceOfType(teams, typeof(List<Team>));
        }

        [TestMethod]
        public void GetPeople()
        {
            Sdk4meClient client = Client.Get();
            List<Person> people = client.People.Get("*");
            Assert.IsNotNull(people);
            Assert.IsTrue(people.Count > 0);
        }
    }
}