using Newtonsoft.Json;

namespace Sdk4me
{
    public class Team : BaseItem
    {
        private Person configurationManager;
        private Person coordinator;
        private bool disabled;
        private string inboundEmailLocalPart;
        private Person manager;
        private string name;
        private string pictureUri;
        private string remarks;
        private string source;
        private string sourceID;
        private string timeZone;
        private Calendar workHours;

        #region configuration_manager

        [JsonProperty("configuration_manager")]
        public Person ConfigurationManager
        {
            get => configurationManager;
            set
            {
                if (configurationManager?.ID != value?.ID)
                    AddIncludedDuringSerialization("configuration_manager_id");
                configurationManager = value;
            }
        }

        [JsonProperty(PropertyName = "configuration_manager_id"), Sdk4meIgnoreInFieldSelection()]
        private long? ConfigurationManagerID
        {
            get => (configurationManager != null ? configurationManager.ID : (long?)null);
        }

        #endregion

        #region coordinator

        [JsonProperty("coordinator")]
        public Person Coordinator
        {
            get => coordinator;
            set
            {
                if (coordinator?.ID != value?.ID)
                    AddIncludedDuringSerialization("coordinator_id");
                coordinator = value;
            }
        }

        [JsonProperty(PropertyName = "coordinator_id"), Sdk4meIgnoreInFieldSelection()]
        private long? CoordinatorID
        {
            get => (coordinator != null ? coordinator.ID : (long?)null);
        }

        #endregion

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

        #region inbound_email_local_part

        [JsonProperty("inbound_email_local_part")]
        public string InboundEmailLocalPart
        {
            get => inboundEmailLocalPart;
            set
            {
                if (inboundEmailLocalPart != value)
                    AddIncludedDuringSerialization("inbound_email_local_part");
                inboundEmailLocalPart = value;
            }
        }

        #endregion

        #region manager

        [JsonProperty("manager")]
        public Person Manager
        {
            get => manager;
            set
            {
                if (manager?.ID != value?.ID)
                    AddIncludedDuringSerialization("manager_id");
                manager = value;
            }
        }

        [JsonProperty(PropertyName = "manager_id"), Sdk4meIgnoreInFieldSelection()]
        private long? ManagerID
        {
            get => (manager != null ? manager.ID : (long?)null);
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

        #region picture_uri

        [JsonProperty("picture_uri")]
        public string PictureUri
        {
            get => pictureUri;
            set
            {
                if (pictureUri != value)
                    AddIncludedDuringSerialization("picture_uri");
                pictureUri = value;
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

        #region work_hours

        [JsonProperty("work_hours")]
        public Calendar WorkHours
        {
            get => workHours;
            set
            {
                if (workHours?.ID != value?.ID)
                    AddIncludedDuringSerialization("work_hours_id");
                workHours = value;
            }
        }

        [JsonProperty(PropertyName = "work_hours_id"), Sdk4meIgnoreInFieldSelection()]
        private long? WorkHoursID
        {
            get => (workHours != null ? workHours.ID : (long?)null);
        }

        #endregion

        internal override void ResetIncludedDuringSerialization()
        {
            configurationManager?.ResetIncludedDuringSerialization();
            coordinator?.ResetIncludedDuringSerialization();
            manager?.ResetIncludedDuringSerialization();
            workHours?.ResetIncludedDuringSerialization();
            base.ResetIncludedDuringSerialization();
        }
    }
}
