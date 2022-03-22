using Newtonsoft.Json;

namespace Sdk4me
{
    public class AuditTrailUser
    {
        [JsonProperty("id"), Sdk4meIgnoreInFieldSelection()]
        public long ID { get; internal set; }

        [JsonProperty("account"), Sdk4meIgnoreInFieldSelection()]
        public AccountReference Account { get; internal set; }

        [JsonProperty("display_name"), Sdk4meIgnoreInFieldSelection()]
        public string DisplayName { get; internal set; }

        [JsonProperty("sourceID"), Sdk4meIgnoreInFieldSelection()]
        public string SourceID { get; internal set; }
    }
}
