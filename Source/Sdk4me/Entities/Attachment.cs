using Newtonsoft.Json;
using System.Diagnostics;

namespace Sdk4me
{
    /// <summary>
    /// A 4me attachment object.
    /// </summary>
    [DebuggerDisplay("{Name}")]
    public class Attachment
    {
        private long size;

        /// <summary>
        /// The name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; internal set; }

        /// <summary>
        /// The uniform resource identifier.
        /// </summary>
        [JsonProperty("uri")]
        public string Uri { get; internal set; }

        /// <summary>
        /// The key name.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; internal set; }

        /// <summary>
        /// Inline attachment.
        /// </summary>
        [JsonProperty("inline")]
        public bool Inline { get; internal set; }

        /// <summary>
        /// The attachment size.
        /// </summary>
        [JsonProperty("size")]
        public long? SizeValue
        {
            get => size;
            internal set => size = value ?? 0;
        }

        /// <summary>
        /// The attachment size.
        /// </summary>
        public long Size
        {
            get => size;
            internal set => size = value;
        }
    }
}
