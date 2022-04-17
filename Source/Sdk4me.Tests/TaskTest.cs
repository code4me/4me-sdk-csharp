using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Sdk4me.Tests
{
    [TestClass]
    public class TaskTest
    {
        [TestMethod]
        public void Get()
        {
            Sdk4meClient client = Client.Get();
            List<Task> tasks = client.Tasks.Get("*");
            Assert.IsNotNull(tasks);
            Assert.IsInstanceOfType(tasks, typeof(List<Task>));
        }
    }
}
