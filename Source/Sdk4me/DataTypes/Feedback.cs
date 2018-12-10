using Newtonsoft.Json;

namespace Sdk4me
{
    public class Feedback
    {
        private FeedbackItem requestedFor;
        private FeedbackItem requestedBy;

        #region requested_for

        [JsonProperty(PropertyName = "requested_for")]
        public FeedbackItem RequestedFor
        {
            get => requestedFor;
            internal set => requestedFor = value;
        }

        #endregion

        #region requested_by

        [JsonProperty(PropertyName = "requested_by")]
        public FeedbackItem RequestedBy
        {
            get => requestedBy;
            internal set => requestedBy = value;
        }

        #endregion
    }
}
