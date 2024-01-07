using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Sdk4me.Tests
{
    [TestClass]
    public class BroadcastTest
    {
        [TestMethod]
        public void Get()
        {
            Sdk4meClient client = Client.Get();

            List<Broadcast> broadcasts = client.Broadcasts.Get("*");
            Assert.IsNotNull(broadcasts);
            Assert.IsInstanceOfType(broadcasts, typeof(List<Broadcast>));
        }
    }
}
