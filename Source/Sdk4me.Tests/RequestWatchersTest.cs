using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Sdk4me.Tests
{
    [TestClass]
    public class RequestWatchersTest
    {
        [TestMethod]
        public void Get()
        {
            Sdk4meClient client = Client.Get();

            Request request = client.Requests.Get(70571);
            List<RequestWatch> watches = client.Requests.GetWatches(request, "*");
            Assert.IsNotNull(watches);
            Assert.IsInstanceOfType(watches, typeof(List<RequestWatch>));
        }

        [TestMethod]
        public void AddUpdateRemove()
        {
            Sdk4meClient client = Client.Get();
            Request request = client.Requests.Get(70571);
            List<RequestWatch> watches = client.Requests.GetWatches(request, "*");
            if (watches.Count > 0)
            {
                client.Requests.DeleteAllWatches(request);
                watches = client.Requests.GetWatches(request, "*");
            }
            Assert.IsTrue(watches.Count == 0);

            RequestWatch requestWatch = client.Requests.AddWatch(request, new RequestWatch()
            {
                Person = client.People.Get(93)
            });
            requestWatch = client.Requests.AddWatch(request, new RequestWatch()
            {
                Person = client.People.Get(106)
            });

            bool result = client.Requests.DeleteWatch(request, requestWatch);
            Assert.IsTrue(result);

            result = client.Requests.DeleteAllWatches(request);
            Assert.IsTrue(result);
        }
    }
}
