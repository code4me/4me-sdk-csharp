using Newtonsoft.Json;

namespace Sdk4me
{
    public class Attachment : BaseItem
    {
        private string name;
        private string uri;
        private bool inline;
        private long size;

        #region name

        [JsonProperty("name")]
        public string Name
        {
            get => name;
            internal set => name = value;
        }

        #endregion

        #region uri

        [JsonProperty("uri")]
        public string Uri
        {
            get => uri;
            internal set => uri = value;
        }

        #endregion

        #region inline

        [JsonProperty("inline")]
        public bool Inline
        {
            get => inline;
            internal set => inline = value;
        }

        #endregion

        #region size

        [JsonProperty("size")]
        public long Size
        {
            get => size;
            internal set => size = value;
        }

        #endregion
    }
}
