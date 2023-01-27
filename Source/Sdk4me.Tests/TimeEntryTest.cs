using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Sdk4me.Tests
{
    [TestClass]
    public class TimeEntryTest
    {
        [TestMethod]
        public void Get()
        {
            Sdk4meClient client = Client.Get();
            List<TimeEntry> timeEntries = client.TimeEntries.Get("*");
            Console.WriteLine($"Count: {timeEntries.Count}");
            Assert.IsNotNull(timeEntries);
            Assert.IsInstanceOfType(timeEntries, typeof(List<TimeEntry>));
        }
    }
}
