using Newtonsoft.Json;

namespace Sdk4me
{
    /// <summary>
    /// A 4me feedback item object.
    /// </summary>
    public class FeedbackItem
    {
        /// <summary>
        /// The feedback satisfied URL.
        /// </summary>
        [JsonProperty("satisfied_url")]
        public string SatisfiedUrl { get; internal set; }

        /// <summary>
        /// The feedback dissatisfied URL.
        /// </summary>
        [JsonProperty("dissatisfied_url")]
        public string DissatisfiedUrl { get; internal set; }
    }
}
