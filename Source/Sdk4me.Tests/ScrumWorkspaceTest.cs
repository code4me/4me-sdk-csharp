using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdk4me.Tests
{
    [TestClass]
    public class ScrumWorkspaceTest
    {
        [TestMethod]
        public void Get()
        {
            Sdk4meClient client = Client.Get();
            List<ScrumWorkspace> scrumWorkspaces = client.ScrumWorkspaces.Get("*");
            Assert.IsNotNull(scrumWorkspaces);
            Assert.IsInstanceOfType(scrumWorkspaces, typeof(List<ScrumWorkspace>));
        }
    }
}
