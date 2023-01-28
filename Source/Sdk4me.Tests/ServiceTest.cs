using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Sdk4me.Tests
{
    [TestClass]
    public class ServiceTest
    {
        [TestMethod]
        public void Get()
        {
            Sdk4meClient client = Client.Get();
            List<Service> services = client.Services.Get("*");
            Assert.IsNotNull(services);
            Assert.IsInstanceOfType(services, typeof(List<Service>));
        }
    }
}
