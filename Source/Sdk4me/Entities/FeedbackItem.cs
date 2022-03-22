using Newtonsoft.Json;

namespace Sdk4me
{
    /// <summary>
    /// A 4me feedback item object.
    /// </summary>
    public class FeedbackItem
    {
        [JsonProperty("satisfied_url")]
        public string SatisfiedUrl { get; internal set; }

        [JsonProperty("dissatisfied_url")]
        public string DissatisfiedUrl { get; internal set; }
    }
}
