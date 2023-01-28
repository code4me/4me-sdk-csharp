using Microsoft.VisualStudio.TestTools.UnitTesting;
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

            Request request = client.Requests.Get(70454);
            Trace.WriteLine($"Continue relation tests on request: #{request.ID}");

            client.Requests.AddNote(request, new NoteCreate()
            {
                Text = "A new note",
            }, true);

            List<Note> notes = client.Requests.GetNotes(request, "*");
            Assert.IsNotNull(notes);
            Assert.IsInstanceOfType(notes, typeof(List<Note>));
            Assert.IsTrue(notes.Count > 0);

            List<ConfigurationItem> configurationItems = client.Requests.GetConfigurationItems(request, "*");
            Assert.IsNotNull(configurationItems);
            Assert.IsInstanceOfType(configurationItems, typeof(List<ConfigurationItem>));

            List<AffectedServiceLevelAgreement> affectedSLA = client.Requests.GetAffectedServiceLevelAgreements(request, "*");
            Assert.IsNotNull(affectedSLA);
            Assert.IsInstanceOfType(affectedSLA, typeof(List<AffectedServiceLevelAgreement>));

            List<Request> groupedRequests = client.Requests.GetGroupedRequests(request, "*");
            Assert.IsNotNull(groupedRequests);
            Assert.IsInstanceOfType(groupedRequests, typeof(List<Request>));

            List<SprintBacklogItem> sprintBacklogItems = client.Requests.GetSprintBacklogItems(request, "*");
            Assert.IsNotNull(sprintBacklogItems);
            Assert.IsInstanceOfType(sprintBacklogItems, typeof(List<SprintBacklogItem>));
        }
    }
}
