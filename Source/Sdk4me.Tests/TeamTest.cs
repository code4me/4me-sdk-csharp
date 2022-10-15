using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdk4me.Tests
{
    [TestClass]

    public class TeamTest
    {
        [TestMethod]
        public void Get()
        {
            Sdk4meClient client = Client.Get();
            List<Team> teams = client.Teams.Get("*");
            Assert.IsNotNull(teams);
            Assert.IsInstanceOfType(teams, typeof(List<Team>));
        }
    }
}
