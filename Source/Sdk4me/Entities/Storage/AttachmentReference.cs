using Newtonsoft.Json;

namespace Sdk4me
{
    public class AttachmentReference
    {
        [JsonProperty("key")]
        public string Key { get; internal set; }

        [JsonProperty("inline")]
        public bool Inline { get; internal set; }

        [JsonProperty("filesize")]
        public long FileSize { get; internal set; }
    }
}
