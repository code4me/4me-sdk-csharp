using Newtonsoft.Json;

namespace Sdk4me
{
    public class ShortUniformResourceLocator : BaseItem
    {
        private string shortUrl;
        private string uri;

        #region short_url

        [JsonProperty("short_url")]
        public string ShortUrl
        {
            get => shortUrl;
            internal set => shortUrl = value;
        }

        #endregion

        #region uri

        [JsonProperty("uri")]
        public string Uri
        {
            get => uri;
            set
            {
                if (uri != value)
                    AddIncludedDuringSerialization("uri");
                uri = value;
            }
        }

        #endregion
    }
}
