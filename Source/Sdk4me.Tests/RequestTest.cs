using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Sdk4me.Tests
{
    [TestClass]
    public class RequestTest
    {
        [TestMethod]
        public void Get()
        {
            Sdk4meClient client = Client.Get();

            List<Request> requests = client.Requests.Get("*");
            Assert.IsNotNull(requests);
            Assert.IsInstanceOfType(requests, typeof(List<Request>));

            if (requests.Count == 0)
                return;
            Request request = requests[Random.Shared.Next(requests.Count)];
            Trace.WriteLine($"Continue relation tests on request: #{request.ID}");


            List<Note> notes = client.Requests.GetNotes(request, "*");
            Assert.IsNotNull(notes);
            Assert.IsInstanceOfType(notes, typeof(List<Note>));
            Assert.IsTrue(notes.Count > 1);

            List<ConfigurationItem> configurationItems = client.Requests.GetConfigurationItems(request, "*");
            Assert.IsNotNull(configurationItems);
            Assert.IsInstanceOfType(configurationItems, typeof(List<ConfigurationItem>));

            List<AffectedServiceLevelAgreement> affectedSLA = client.Requests.GetAffectedServiceLevelAgreements(request, "*");
            Assert.IsNotNull(affectedSLA);
            Assert.IsInstanceOfType(affectedSLA, typeof(List<AffectedServiceLevelAgreement>));

            List<Request> groupedRequests = client.Requests.GetGroupedRequests(request, "*");
            Assert.IsNotNull(groupedRequests);
            Assert.IsInstanceOfType(groupedRequests, typeof(List<Request>));
        }
    }
}
