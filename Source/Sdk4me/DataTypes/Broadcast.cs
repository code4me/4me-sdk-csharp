using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    public class Broadcast : BaseItem
    {
        private bool disabled;
        private DateTime? endAt;
        private string message;
        private BroadcastMessageType? messageType;
        private string source;
        private string sourceID;
        private List<ServiceInstance> serviceInstances;
        private DateTime? startAt;
        private List<Team> teams;
        private string timeZone;
        private List<BroadcastTranslation> translations;
        private BroadcastVisibilityType? visibility;

        #region disabled

        [JsonProperty("disabled")]
        public bool Disabled
        {
            get => disabled;
            set
            {
                if (disabled != value)
                    AddIncludedDuringSerialization("disabled");
                disabled = value;
            }
        }

        #endregion

        #region end_at

        [JsonProperty("end_at")]
        public DateTime? EndAt
        {
            get => endAt;
            set
            {
                if (endAt != value)
                    AddIncludedDuringSerialization("end_at");
                endAt = value;
            }
        }

        #endregion

        #region message

        [JsonProperty("message")]
        public string Message
        {
            get => message;
            set
            {
                if (message != value)
                    AddIncludedDuringSerialization("message");
                message = value;
            }
        }

        #endregion

        #region message_type

        [JsonProperty("message_type")]
        public BroadcastMessageType? MessageType
        {
            get => messageType;
            set
            {
                if (messageType != value)
                    AddIncludedDuringSerialization("message_type");
                messageType = value;
            }
        }

        #endregion

        #region source

        [JsonProperty("source")]
        public string Source
        {
            get => source;
            set
            {
                if (source != value)
                    AddIncludedDuringSerialization("source");
                source = value;
            }
        }

        #endregion

        #region sourceID

        [JsonProperty("sourceID")]
        public string SourceID
        {
            get => sourceID;
            set
            {
                if (sourceID != value)
                    AddIncludedDuringSerialization("sourceID");
                sourceID = value;
            }
        }

        #endregion

        #region service_instances

        [JsonProperty("service_instances")]
        public List<ServiceInstance> ServiceInstances
        {
            get => serviceInstances;
            set
            {
                if (serviceInstances != value)
                    AddIncludedDuringSerialization("service_instances");
                serviceInstances = value;
            }
        }

        #endregion

        #region start_at

        [JsonProperty("start_at")]
        public DateTime? StartAt
        {
            get => startAt;
            set
            {
                if (startAt != value)
                    AddIncludedDuringSerialization("start_at");
                startAt = value;
            }
        }

        #endregion

        #region teams

        [JsonProperty("teams")]
        public List<Team> Teams
        {
            get => teams;
            set
            {
                if (teams != value)
                    AddIncludedDuringSerialization("teams");
                teams = value;
            }
        }

        #endregion

        #region time_zone

        [JsonProperty("time_zone")]
        public string TimeZone
        {
            get => timeZone;
            set
            {
                if (timeZone != value)
                    AddIncludedDuringSerialization("time_zone");
                timeZone = value;
            }
        }

        #endregion

        #region translations

        [JsonProperty("translations")]
        public List<BroadcastTranslation> Translations
        {
            get => translations;
            internal set => translations = value;
        }

        #endregion

        #region visibility

        [JsonProperty("visibility")]
        public BroadcastVisibilityType? Visibility
        {
            get => visibility;
            set
            {
                if (visibility != value)
                    AddIncludedDuringSerialization("visibility");
                visibility = value;
            }
        }

        #endregion

        internal override void ResetIncludedDuringSerialization()
        {
            if (serviceInstances != null)
                for (int i = 0; i < serviceInstances.Count; i++)
                    serviceInstances[i]?.ResetIncludedDuringSerialization();

            if (teams != null)
                for (int i = 0; i < teams.Count; i++)
                    teams[i]?.ResetIncludedDuringSerialization();

            if (translations != null)
                for (int i = 0; i < translations.Count; i++)
                    translations[i]?.ResetIncludedDuringSerialization();

            base.ResetIncludedDuringSerialization();
        }
    }
}
