using Newtonsoft.Json;

namespace Sdk4me
{
    /// <summary>
    /// A 4me feedback object.
    /// </summary>
    public class Feedback
    {
        [JsonProperty("requested_by")]
        public FeedbackItem RequestedBy { get; internal set; }

        [JsonProperty("requested_for")]
        public FeedbackItem RequestedFor { get; internal set; }
    }
}
