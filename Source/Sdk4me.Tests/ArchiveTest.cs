using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Sdk4me.Tests
{
    [TestClass]
    public class ArchiveTest
    {
        [TestMethod]
        public void Get()
        {
            Sdk4meClient client = Client.Get();

            List<Archive> archive = client.Archive.Get();
            Assert.IsNotNull(archive);
            Assert.IsInstanceOfType(archive, typeof(List<Archive>));
        }
    }
}
