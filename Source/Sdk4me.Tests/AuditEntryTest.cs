using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Sdk4me.Tests
{
    [TestClass]
    public class AuditEntryTest
    {
        [TestMethod]
        public void Get()
        {
            Sdk4meClient client = Client.Get();

            List<AuditTrail> auditEntries = client.AuditEntries.Get(new Filter("CreatedAt", FilterCondition.GreaterThanOrEqualToAndLessThanOrEqualTo, new DateTime(2022,03,01), new DateTime(2022, 03, 30)));
            Assert.IsNotNull(auditEntries);
            Assert.IsInstanceOfType(auditEntries, typeof(List<AuditTrail>));
        }
    }
}
