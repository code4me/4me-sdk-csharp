using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Sdk4me.Tests
{
    [TestClass]
    public class ServiceInstanceCoverageTest
    {
        [TestMethod]
        public void Get()
        {
            Sdk4meClient client = Client.Get();
            List<ServiceInstance> serviceInstances = client.ServiceInstances.Get("*");
            Assert.IsNotNull(serviceInstances);
            Assert.IsInstanceOfType(serviceInstances, typeof(List<ServiceInstance>));

            if (serviceInstances.Count == 0)
                return;
            ServiceInstance serviceInstance = serviceInstances[Random.Shared.Next(serviceInstances.Count)];
            Trace.WriteLine($"Continue relation tests on service instances: {serviceInstance.Name}");

            serviceInstances = client.ServiceInstances.GetChildServiceInstances(serviceInstance, "*");
            Assert.IsNotNull(serviceInstances);
            Assert.IsInstanceOfType(serviceInstances, typeof(List<ServiceInstance>));

            serviceInstances = client.ServiceInstances.GetParentServiceInstances(serviceInstance, "*");
            Assert.IsNotNull(serviceInstances);
            Assert.IsInstanceOfType(serviceInstances, typeof(List<ServiceInstance>));

            List<ServiceLevelAgreement> serviceLevelAgreements = client.ServiceInstances.GetServiceLevelAgreements(serviceInstance, "*");
            Assert.IsNotNull(serviceLevelAgreements);
            Assert.IsInstanceOfType(serviceLevelAgreements, typeof(List<ServiceLevelAgreement>));

            List<ConfigurationItem> configurationItems = client.ServiceInstances.GetConfigurationItems(serviceInstance, "*");
            Assert.IsNotNull(configurationItems);
            Assert.IsInstanceOfType(configurationItems, typeof(List<ConfigurationItem>));
        }
    }
}
