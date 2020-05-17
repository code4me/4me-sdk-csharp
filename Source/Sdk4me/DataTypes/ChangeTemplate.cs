using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sdk4me
{
    public class ChangeTemplate : BaseItem
    {
        private ChangeCategoryType? category;
        private Person changeManager;
        private string changeType;
        private bool disabled;
        private ChangeImpactType? impact;
        private string instructions;
        private ChangeJustificationType? justification;
        private string note;
        private Service service;
        private string source;
        private string sourceID;
        private string subject;
        private int timesApplied;
        private UIExtension uIExtension;

        #region category

        [JsonProperty("category")]
        public ChangeCategoryType? Category
        {
            get => category;
            set
            {
                if (category != value)
                    AddIncludedDuringSerialization("category");
                category = value;
            }
        }

        #endregion

        #region change_manager

        [JsonProperty("change_manager")]
        public Person ChangeManager
        {
            get => changeManager;
            set
            {
                if (changeManager?.ID != value?.ID)
                    AddIncludedDuringSerialization("change_manager_id");
                changeManager = value;
            }
        }

        [JsonProperty(PropertyName = "change_manager_id"), Sdk4meIgnoreInFieldSelection()]
        private long? ChangeManagerID
        {
            get => (changeManager != null ? changeManager.ID : (long?)null);
        }

        #endregion

        #region change_type

        [JsonProperty("change_type")]
        public string ChangeType
        {
            get => changeType;
            set
            {
                if (changeType != value)
                    AddIncludedDuringSerialization("change_type");
                changeType = value;
            }
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

        #region impact

        [JsonProperty("impact")]
        public ChangeImpactType? Impact
        {
            get => impact;
            set
            {
                if (impact != value)
                    AddIncludedDuringSerialization("impact");
                impact = value;
            }
        }

        #endregion

        #region instructions

        [JsonProperty("instructions")]
        public string Instructions
        {
            get => instructions;
            set
            {
                if (instructions != value)
                    AddIncludedDuringSerialization("instructions");
                instructions = value;
            }
        }

        #endregion

        #region justification

        [JsonProperty("justification")]
        public ChangeJustificationType? Justification
        {
            get => justification;
            set
            {
                if (justification != value)
                    AddIncludedDuringSerialization("justification");
                justification = value;
            }
        }

        #endregion

        #region note

        [JsonProperty("note")]
        public string Note
        {
            get => note;
            set
            {
                if (note != value)
                    AddIncludedDuringSerialization("note");
                note = value;
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

        #region subject

        [JsonProperty("subject")]
        public string Subject
        {
            get => subject;
            set
            {
                if (subject != value)
                    AddIncludedDuringSerialization("subject");
                subject = value;
            }
        }

        #endregion

        #region times_applied

        [JsonProperty("times_applied")]
        public int TimesApplied
        {
            get => timesApplied;
            internal set => timesApplied = value;
        }

        #endregion

        #region ui_extension

        [JsonProperty("ui_extension")]
        public UIExtension UIExtension
        {
            get => uIExtension;
            set
            {
                if (uIExtension?.ID != value?.ID)
                    AddIncludedDuringSerialization("ui_extension_id");
                uIExtension = value;
            }
        }

        [JsonProperty(PropertyName = "ui_extension_id"), Sdk4meIgnoreInFieldSelection()]
        private long? UIExtensionID
        {
            get => (uIExtension != null ? uIExtension.ID : (long?)null);
        }

        #endregion

        internal override void ResetIncludedDuringSerialization()
        {
            changeManager?.ResetIncludedDuringSerialization();
            service?.ResetIncludedDuringSerialization();
            uIExtension?.ResetIncludedDuringSerialization();
            base.ResetIncludedDuringSerialization();
        }
    }
}
