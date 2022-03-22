using Newtonsoft.Json;

namespace Sdk4me
{
    public class InboxFor
    {
        [JsonProperty("organization")]
        public Organization Organization { get; internal set; }

        [JsonProperty("requester")]
        public Person Requester { get; internal set; }
    }
}
