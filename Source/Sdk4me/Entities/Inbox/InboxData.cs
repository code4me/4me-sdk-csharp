using Newtonsoft.Json;
using System.Diagnostics;

namespace Sdk4me
{
    [DebuggerDisplay("{ID}")]
    public class InboxData
    {
        [JsonProperty("id")]
        public long ID { get; internal set; }

        [JsonProperty("href")]
        public string HypertextReference { get; internal set; }

        [JsonProperty("for")]
        public InboxFor For { get; internal set; }

        [JsonProperty("subject")]
        public string Subject { get; internal set; }

        [JsonProperty("team")]
        public Team Team { get; internal set; }

        [JsonProperty("next_target_at")]
        public string NextTargetAt { get; internal set; }

        [JsonProperty("new_assignment")]
        public bool NewAssignment { get; internal set; }

        [JsonProperty("member")]
        public InboxMember Member { get; internal set; }

        [JsonProperty("status")]
        public string Status { get; internal set; }

        [JsonProperty("impact")]
        public string Impact { get; internal set; }

        public bool HasMember()
        {
            return Member != null && Member.ID == null;
        }
    }
}
