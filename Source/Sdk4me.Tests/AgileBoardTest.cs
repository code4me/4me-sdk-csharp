using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Sdk4me.Tests
{
    [TestClass]
    public class AgileBoardTest
    {
        [TestMethod]
        public void Get()
        {
            Sdk4meClient client = Client.Get();
            List<AgileBoard> agileBoards = client.AgileBoards.Get("*");
            Assert.IsNotNull(agileBoards);
            Assert.IsInstanceOfType(agileBoards, typeof(List<AgileBoard>));

            if (agileBoards.Count == 0)
                return;
            AgileBoard agileBoard = agileBoards[Random.Shared.Next(agileBoards.Count)];
            Trace.WriteLine($"Continue relation tests on agile board: {agileBoard.Name}");

            List<AgileBoardColumn> agileBoardColumns = client.AgileBoards.GetColumns(agileBoard, "*");
            Assert.IsNotNull(agileBoardColumns);
            Assert.IsInstanceOfType(agileBoardColumns, typeof(List<AgileBoardColumn>));
        }
    }
}
