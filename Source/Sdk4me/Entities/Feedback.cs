using Newtonsoft.Json;

namespace Sdk4me
{
    /// <summary>
    /// A 4me feedback object.
    /// </summary>
    public class Feedback
    {
        /// <summary>
        /// The person for whom the request as created.
        /// </summary>
        [JsonProperty("requested_by")]
        public FeedbackItem RequestedBy { get; internal set; }

        /// <summary>
        /// The person for whom the request was created.
        /// </summary>
        [JsonProperty("requested_for")]
        public FeedbackItem RequestedFor { get; internal set; }
    }
}
