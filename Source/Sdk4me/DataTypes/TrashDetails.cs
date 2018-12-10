using Newtonsoft.Json;

namespace Sdk4me
{
    public class TrashDetails
    {
        private long id;
        private string hypertextReference;
        private string displayName;

        [JsonProperty("id")]
        public long ID
        {
            get => id;
            internal set => id = value;
        }

        [JsonProperty("href")]
        public string HypertextReference
        {
            get => hypertextReference;
            internal set => hypertextReference = value;
        }

        [JsonProperty("display_name")]
        public string DisplayName
        {
            get => displayName;
            internal set => displayName = value;
        }
    }
}
