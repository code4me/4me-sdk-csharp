using Newtonsoft.Json;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/sla_notification_schemes/">service level agreement notification scheme</see> object.
    /// </summary>
    public class ServiceLevelAgreementNotificationScheme : BaseItem
    {
        private bool disabled;
        private string name;
        private string source;
        private string sourceID;

        #region Disabled

        /// <summary>
        /// The Disabled box is checked when the SLA notification scheme may no longer be related to any more service offerings.
        /// </summary>
        [JsonProperty("disabled")]
        public bool Disabled
        {
            get => disabled;
            set => disabled = SetValue("disabled", disabled, value);
        }

        #endregion

        #region Name

        /// <summary>
        /// The Name field is used to enter the name of the SLA notification scheme.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get => name;
            set => name = SetValue("name", name, value);
        }

        #endregion

        #region Source

        /// <summary>
        /// See source
        /// </summary>
        [JsonProperty("source")]
        public string Source
        {
            get => source;
            set => source = SetValue("source", source, value);
        }

        #endregion

        #region SourceID

        /// <summary>
        /// See source
        /// </summary>
        [JsonProperty("sourceID")]
        public string SourceID
        {
            get => sourceID;
            set => sourceID = SetValue("sourceID", sourceID, value);
        }

        #endregion
    }
}
