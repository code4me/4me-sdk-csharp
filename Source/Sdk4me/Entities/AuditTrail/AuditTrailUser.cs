using Newtonsoft.Json;

namespace Sdk4me
{
    /// <summary>
    /// A 4me audit trail user object.
    /// </summary>
    public class AuditTrailUser
    {
        /// <summary>
        /// The unique identifier.
        /// </summary>
        [JsonProperty("id"), Sdk4meIgnoreInFieldSelection()]
        public long ID { get; internal set; }

        /// <summary>
        /// The account of the user.
        /// </summary>
        [JsonProperty("account"), Sdk4meIgnoreInFieldSelection()]
        public AccountReference Account { get; internal set; }

        /// <summary>
        /// The display name of the user.
        /// </summary>
        [JsonProperty("display_name"), Sdk4meIgnoreInFieldSelection()]
        public string DisplayName { get; internal set; }

        /// <summary>
        /// The sourceID of the user.
        /// </summary>
        [JsonProperty("sourceID"), Sdk4meIgnoreInFieldSelection()]
        public string SourceID { get; internal set; }
    }
}
