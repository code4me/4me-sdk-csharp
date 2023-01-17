using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Sdk4me.Tests
{
    [TestClass]
    public class FirstLineSupportAgreementTest
    {
        [TestMethod]
        public void Get()
        {
            Sdk4meClient client = Client.Get();

            List<FirstLineSupportAgreement> archive = client.FirstLineSupportAgreements.Get("*");
            Assert.IsNotNull(archive);
            Assert.IsInstanceOfType(archive, typeof(List<FirstLineSupportAgreement>));
        }
    }
}
