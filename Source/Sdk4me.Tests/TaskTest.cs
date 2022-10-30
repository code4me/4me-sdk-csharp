using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;

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

            if (tasks.Count == 0)
                return;
            Task task = tasks[Random.Shared.Next(tasks.Count)];
            Trace.WriteLine($"Continue relation tests on request: #{task.ID}");

            List<SprintBacklogItem> sprintBacklogItems = client.Tasks.GetSprintBacklogItems(task, "*");
            Assert.IsNotNull(sprintBacklogItems);
            Assert.IsInstanceOfType(sprintBacklogItems, typeof(List<SprintBacklogItem>));
        }
    }
}
