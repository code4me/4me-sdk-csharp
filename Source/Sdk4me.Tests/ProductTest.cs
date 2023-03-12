using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Sdk4me.Tests
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void Get()
        {
            Sdk4meClient client = Client.Get();

            List<Product> products = client.Products.Get("*");
            Assert.IsNotNull(products);
            Assert.IsInstanceOfType(products, typeof(List<Product>));
        }
    }
}
