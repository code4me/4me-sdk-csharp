using Newtonsoft.Json;

namespace Sdk4me
{
    internal class StorageFacilityCloud
    {
        [JsonProperty("acl")]
        public string ACL { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("policy")]
        public string Policy { get; set; }

        [JsonProperty("success_action_status")]
        public string SuccessActionStatus { get; set; }

        [JsonProperty("x-amz-algorithm")]
        public string Algorithm { get; set; }

        [JsonProperty("x-amz-credential")]
        public string Credential { get; set; }

        [JsonProperty("x-amz-date")]
        public string Date { get; set; }

        [JsonProperty("x-amz-server-side-encryption")]
        public string ServerSideEncryption { get; set; }

        [JsonProperty("x-amz-signature")]
        public string Signature { get; set; }
    }
}
