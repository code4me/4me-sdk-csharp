using Newtonsoft.Json;

namespace Sdk4me
{
    /// <summary>
    /// A 4me inbox for object.
    /// </summary>
    public class InboxFor
    {
        /// <summary>
        /// The organization of the requester.
        /// </summary>
        [JsonProperty("organization")]
        public Organization Organization { get; internal set; }

        /// <summary>
        /// The requester of the request.
        /// </summary>
        [JsonProperty("requester")]
        public Person Requester { get; internal set; }
    }
}
