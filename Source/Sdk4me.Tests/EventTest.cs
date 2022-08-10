using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Sdk4me.Tests
{
    [TestClass]
    public class EventTest
    {
        [TestMethod]
        public void Create()
        {
            Sdk4meClient client = Client.Get();

            Team team = client.Teams.Get().FirstOrDefault();

            Request request = client.Events.Create(new RequestEvent()
            {
                Subject = "An API event",
                Source = "api",
                SourceID = "1",
                Note = "A public note",
                InternalNote = "An internal note",
                Team = client.Teams.Get().FirstOrDefault()
            });
            Assert.IsNotNull(request);
        }
    }
}
