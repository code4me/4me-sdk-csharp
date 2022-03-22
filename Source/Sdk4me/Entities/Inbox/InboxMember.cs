using Newtonsoft.Json;

namespace Sdk4me
{
    public class InboxMember
    {
        [JsonProperty("ID")]
        public long? ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
