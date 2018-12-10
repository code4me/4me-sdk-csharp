using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sdk4me
{
    internal class WebResponseException
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("errors")]
        public List<List<string>> Errors { get; set; }


        public string GetCompleteMessage()
        {
            string retval = Message ?? "";


            return retval;
        }
    }
}
