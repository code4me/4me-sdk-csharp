using Newtonsoft.Json;

namespace Sdk4me
{
    /// <summary>
    /// A custom field object.
    /// </summary>
    public sealed class CustomField
    {
        private string id;
        private object value;

        #region id

        /// <summary>
        /// The identifier of the <see cref="CustomField"/>.
        /// </summary>
        [JsonProperty("id")]
        public string ID
        {
            get => id;
            set => id = value;
        }

        #endregion

        #region value

        /// <summary>
        /// The value of the <see cref="CustomField"/>.
        /// </summary>
        [JsonProperty("value")]
        public object Value
        {
            get => value;
            set => this.value = value;
        }

        #endregion
    }
}
