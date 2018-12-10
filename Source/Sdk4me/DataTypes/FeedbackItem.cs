using Newtonsoft.Json;

namespace Sdk4me
{
    public class FeedbackItem
    {
        private string satisfiedUrl;
        private string dissatisfiedUrl;

        #region satisfied_url

        [JsonProperty(PropertyName = "satisfied_url")]
        public string SatisfiedUrl
        {
            get => satisfiedUrl;
            internal set => satisfiedUrl = value;
        }

        #endregion

        #region dissatisfied_url

        [JsonProperty(PropertyName = "dissatisfied_url")]
        public string DissatisfiedUrl
        {
            get => dissatisfiedUrl;
            internal set => dissatisfiedUrl = value;
        }

        #endregion
    }
}
