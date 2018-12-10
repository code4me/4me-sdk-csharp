using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    public class ServiceInstance : BaseItem
    {
        private List<Attachment> attachments;
        private Team firstLineTeam;
        private ServiceInstanceImpactType? impact;
        private string name;
        private string remarks;
        private Service service;
        private string source;
        private string sourceID;
        private ServiceInstanceStatusType? status;
        private Team supportTeam;

        #region attachments

        [JsonProperty("attachments")]
        public List<Attachment> Attachments
        {
            get => attachments;
            internal set => attachments = value;
        }

        #endregion

        #region first_line_team

        [JsonProperty("first_line_team")]
        public Team FirstLineTeam
        {
            get => firstLineTeam;
            set
            {
                if (firstLineTeam?.ID != value?.ID)
                    AddIncludedDuringSerialization("first_line_team_id");
                firstLineTeam = value;
            }
        }

        [JsonProperty(PropertyName = "first_line_team_id"), Sdk4meIgnoreInFieldSelection()]
        private long? FirstLineTeamID
        {
            get => (firstLineTeam != null ? firstLineTeam.ID : (long?)null);
        }

        #endregion

        #region impact

        [JsonProperty("impact")]
        public ServiceInstanceImpactType? Impact
        {
            get => impact;
            internal set => impact = value;
        }

        #endregion

        #region name

        [JsonProperty("name")]
        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                    AddIncludedDuringSerialization("name");
                name = value;
            }
        }

        #endregion

        #region remarks

        [JsonProperty("remarks")]
        public string Remarks
        {
            get => remarks;
            set
            {
                if (remarks != value)
                    AddIncludedDuringSerialization("remarks");
                remarks = value;
            }
        }

        #endregion

        #region service

        [JsonProperty("service")]
        public Service Service
        {
            get => service;
            set
            {
                if (service?.ID != value?.ID)
                    AddIncludedDuringSerialization("service_id");
                service = value;
            }
        }

        [JsonProperty(PropertyName = "service_id"), Sdk4meIgnoreInFieldSelection()]
        private long? ServiceID
        {
            get => (service != null ? service.ID : (long?)null);
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

        #region status

        [JsonProperty("status")]
        public ServiceInstanceStatusType? Status
        {
            get => status;
            set
            {
                if (status != value)
                    AddIncludedDuringSerialization("status");
                status = value;
            }
        }

        #endregion

        #region support_team

        [JsonProperty("support_team")]
        public Team SupportTeam
        {
            get => supportTeam;
            set
            {
                if (supportTeam?.ID != value?.ID)
                    AddIncludedDuringSerialization("support_team_id");
                supportTeam = value;
            }
        }

        [JsonProperty(PropertyName = "support_team_id"), Sdk4meIgnoreInFieldSelection()]
        private long? SupportTeamID
        {
            get => (supportTeam != null ? supportTeam.ID : (long?)null);
        }

        #endregion

        internal override void ResetIncludedDuringSerialization()
        {
            if (attachments != null)
                for (int i = 0; i < attachments.Count; i++)
                    attachments[i]?.ResetIncludedDuringSerialization();

            firstLineTeam?.ResetIncludedDuringSerialization();
            service?.ResetIncludedDuringSerialization();
            supportTeam?.ResetIncludedDuringSerialization();
            base.ResetIncludedDuringSerialization();
        }
    }
}
