using Newtonsoft.Json;
using System.Diagnostics;

namespace Sdk4me
{
    [DebuggerDisplay("{Name}")]
    public class Attachment
    {
        private long size;

        [JsonProperty("name")]
        public string Name { get; internal set; }

        [JsonProperty("uri")]
        public string Uri { get; internal set; }

        [JsonProperty("key")]
        public string Key { get; internal set; }

        [JsonProperty("inline")]
        public bool Inline { get; internal set; }

        [JsonProperty("size")]
        public long? SizeValue
        {
            get => size;
            internal set => size = value ?? 0;
        }

        public long Size
        {
            get => size;
            internal set => size = value;
        }
    }
}
