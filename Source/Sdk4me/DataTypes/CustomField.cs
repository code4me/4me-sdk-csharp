using Newtonsoft.Json;
using System.Diagnostics;

namespace Sdk4me
{
    [Sdk4meSerializeAllProperties(), DebuggerDisplay("{ID}:{Value}")]
    public class CustomField
    {
        private string id;
        private string value;

        #region id
    
        [JsonProperty(PropertyName = "id")]
        public string ID
        {
            get => id;
            set => id = value;
        }

        #endregion

        #region value

        [JsonProperty(PropertyName = "value")]
        public string Value
        {
            get => this.value;
            set => this.value = value;
        }

        #endregion
    }
}
