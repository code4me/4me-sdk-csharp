using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sdk4me
{
    internal class StorageFacility
    {
        [JsonProperty("size_limit")]
        public long SizeLimit { get; set; }

        [JsonProperty("allowed_extensions")]
        public List<string> AllowedExtensions { get; set; }

        [JsonProperty("provider")]
        public string Provider { get; set; }

        [JsonProperty("upload_uri")]
        public string UploadUri { get; set; }

        [JsonProperty("s3")]
        public StorageFacilityCloud Cloud { get; set; }
    }
}
