using Newtonsoft.Json;
using Sdk4me.Extensions;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/broadcasts/">broadcast</see> object.
    /// </summary>
    public class Broadcast : BaseItem
    {
        private List<Organization> customers;
        private bool disabled;
        private DateTime? endAt;
        private string message;
        private BroadcastMessageType messageType;
        private string source;
        private string sourceID;
        private List<ServiceInstance> serviceInstances;
        private DateTime startAt;
        private List<Team> teams;
        private string timeZone;
        private List<BroadcastTranslation> translations;
        private BroadcastVisibility visibility;

        #region Customers

        /// <summary>
        /// The Customers field is used to select one or more customer organizations when the broadcast is to be displayed for the specialists of the account in requests that were received from the selected organizations. This field is available only when the “Specialists in requests from the following customers” visibility option is selected.
        /// </summary>
        [JsonProperty("customers")]
        public List<Organization> Customers
        {
            get => customers;
            set => customers = SetValue("customers", customers, value);
        }

        #endregion

        #region Disabled

        /// <summary>
        /// The Disabled box is checked when the message should not be broadcasted.
        /// </summary>
        [JsonProperty("disabled")]
        public bool Disabled
        {
            get => disabled;
            set => disabled = SetValue("disabled", disabled, value);
        }

        #endregion

        #region End at

        /// <summary>
        /// The End field is used to select the end date and time of the broadcast. This field is left empty when the message is to be broadcasted until the Disabled box is checked.
        /// </summary>
        [JsonProperty("end_at")]
        public DateTime? EndAt
        {
            get => endAt;
            set => endAt = SetValue("end_at", endAt, value);
        }

        #endregion

        #region Message

        /// <summary>
        /// The Message field is used to enter the information that is to be broadcasted.
        /// </summary>
        [JsonProperty("message")]
        public string Message
        {
            get => message;
            set => message = SetValue("message", message, value);
        }

        #endregion

        #region Message type

        /// <summary>
        /// The Message type field is used to select the appropriate icon for the message. The selected icon is displayed alongside the message when the broadcast is presented. 
        /// </summary>
        [JsonProperty("message_type")]
        public BroadcastMessageType MessageType
        {
            get => messageType;
            set => messageType = SetValue("message_type", messageType, value);
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

        #region Service instances

        /// <summary>
        /// The Service instances table field is used to select the service instances for which the people, who are covered for them by an active SLA, need to see the broadcast. This table field is available only when the “People covered for the following service instance(s)” visibility option is selected.
        /// </summary>
        [JsonProperty("service_instances")]
        public List<ServiceInstance> ServiceInstances
        {
            get => serviceInstances;
            set => serviceInstances = SetValue("service_instances", serviceInstances, value);
        }

        #endregion

        #region Start at

        /// <summary>
        /// The Start field is used to specify the start date and time of the broadcast.
        /// </summary>
        [JsonProperty("start_at")]
        public DateTime StartAt
        {
            get => startAt;
            set => startAt = SetValue("start_at", startAt, value);
        }

        #endregion

        #region Teams

        /// <summary>
        /// The Teams table field is used to select the teams which members need to see the broadcast. This table field is available only when the “Members of the following team(s)” visibility option is selected.
        /// </summary>
        [JsonProperty("teams")]
        public List<Team> Teams
        {
            get => teams;
            set => teams = SetValue("teams", teams, value);
        }

        #endregion

        #region Time zone

        /// <summary>
        /// The Time zone field is used to select the time zone that applies to the dates and times specified in the Start and End fields.
        /// </summary>
        [JsonProperty("time_zone")]
        public string TimeZone
        {
            get => timeZone;
            set => timeZone = SetValue("time_zone", timeZone, value);
        }

        #endregion

        #region Translations

        /// <summary>
        /// Array of references to Broadcast Translations
        /// </summary>
        [JsonProperty("translations")]
        public List<BroadcastTranslation> Translations
        {
            get => translations;
            internal set => translations = SetValue("translations", translations, value);
        }

        #endregion

        #region Visibility

        /// <summary>
        /// The Visible for options are used to define the target audience of the broadcast.
        /// </summary>
        [JsonProperty("visibility")]
        public BroadcastVisibility Visibility
        {
            get => visibility;
            set => visibility = SetValue("visibility", visibility, value);
        }

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            customers?.ResetPropertySerializationCollection();
            serviceInstances?.ResetPropertySerializationCollection();
            teams?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
