using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Sdk4me.Tests
{
    [TestClass]
    public class TaskTemplateTest
    {
        [TestMethod]
        public void Get()
        {
            Sdk4meClient client = Client.Get();
            List<TaskTemplate> taskTemplates = client.TaskTemplates.Get("*");
            Assert.IsNotNull(taskTemplates);
            Assert.IsInstanceOfType(taskTemplates, typeof(List<TaskTemplate>));
        }
    }
}
