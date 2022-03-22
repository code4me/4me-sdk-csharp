using Newtonsoft.Json;

namespace Sdk4me
{
    internal class AttachmentDestroy
    {
        [JsonProperty("key")]
        internal string Key { get; set; }

        [JsonProperty("_destroy")]
        internal bool Destory { get; set; } = true;
    }
}
