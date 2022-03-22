using Newtonsoft.Json;

namespace Sdk4me
{
    /// <summary>
    /// The archive and trash action details.
    /// </summary>
    public class ActionDetails
    {
        private long id;
        private string hypertextReference;
        private string displayName;

        #region ID

        [JsonProperty("id")]
        public long ID
        {
            get => id;
            internal set => id = value;
        }

        #endregion

        #region HREF

        [JsonProperty("href")]
        public string HypertextReference
        {
            get => hypertextReference;
            internal set => hypertextReference = value;
        }

        #endregion

        #region Display name

        [JsonProperty("display_name")]
        public string DisplayName
        {
            get => displayName;
            internal set => displayName = value;
        }

        #endregion
    }
}
