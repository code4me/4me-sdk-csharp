using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sdk4me.Tests
{
    [TestClass]
    public class EventTest
    {
        [TestMethod]
        public void Create()
        {
            Sdk4meClient client = Client.Get();
            Request request = client.Events.Create(new RequestEvent()
            {
                Subject = "An API event",
                Source = "api",
                SourceID = "1",
                Note = "A public note",
                InternalNote = "An internal note"
            });
            Assert.IsNotNull(request);
        }
    }
}
