using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Sdk4me.Tests
{
    [TestClass]
    public class UIExtensionTest
    {
        [TestMethod]
        public void Get()
        {
            Sdk4meClient client = Client.Get();
            List<UIExtension> extensions = client.UIExtensions.Get("*");
            Assert.IsNotNull(extensions);
            Assert.IsInstanceOfType(extensions, typeof(List<UIExtension>));
        }
    }
}
