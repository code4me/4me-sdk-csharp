using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Sdk4me.Tests
{
    [TestClass]
    public class AffectedServiceLevelAgreementTest
    {
        [TestMethod]
        public void Get()
        {
            Sdk4meClient client = Client.Get();
            List<AffectedServiceLevelAgreement> affectedServiceLevelAgreements = client.AffectedServiceLevelAgreements.Get("*");
            Assert.IsNotNull(affectedServiceLevelAgreements);
            Assert.IsInstanceOfType(affectedServiceLevelAgreements, typeof(List<AffectedServiceLevelAgreement>));
        }
    }
}
