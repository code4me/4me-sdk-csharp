using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Sdk4me.Tests
{
    [TestClass]
    public class InvoiceTest
    {
        [TestMethod]
        public void Get()
        {
            Sdk4meClient client = Client.Get();

            List<Invoice> invoices = client.Invoices.Get("*");
            Assert.IsNotNull(invoices);
            Assert.IsInstanceOfType(invoices, typeof(List<Invoice>));
        }
    }
}
