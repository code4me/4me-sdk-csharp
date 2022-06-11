using Newtonsoft.Json;

namespace Sdk4me
{
    /// <summary>
    /// A 4me inbox member object.
    /// </summary>
    public class InboxMember
    {
        /// <summary>
        /// The unique identifier.
        /// </summary>
        [JsonProperty("ID")]
        public long? ID { get; set; }

        /// <summary>
        /// The name of the member.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
