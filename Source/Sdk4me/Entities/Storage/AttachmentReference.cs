using Newtonsoft.Json;

namespace Sdk4me
{
    /// <summary>
    /// An 4me <see href="https://developer.4me.com/v1/general/data_types/#attachments">attachment reference</see> object.
    /// </summary>
    public class AttachmentReference
    {
        /// <summary>
        /// The attachment key.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; internal set; }

        /// <summary>
        /// True when inline; otherwise false.
        /// </summary>
        [JsonProperty("inline")]
        public bool Inline { get; internal set; }

        /// <summary>
        /// The file size.
        /// </summary>
        [JsonProperty("filesize")]
        public long FileSize { get; internal set; }
    }
}
