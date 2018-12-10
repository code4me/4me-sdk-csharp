using Newtonsoft.Json;

namespace Sdk4me
{
    public class KnowledgeArticle : BaseItem
    {
        private string description;
        private string instructions;
        private string keywords;
        private string locale;
        private Service service;
        private string source;
        private string sourceID;
        private KnowledgeArticleStatusType? status;
        private string subject;
        private int timesApplied;

        #region description

        [JsonProperty("description")]
        public string Description
        {
            get => description;
            set
            {
                if (description != value)
                    AddIncludedDuringSerialization("description");
                description = value;
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

        #region keywords

        [JsonProperty("keywords")]
        public string Keywords
        {
            get => keywords;
            set
            {
                if (keywords != value)
                    AddIncludedDuringSerialization("keywords");
                keywords = value;
            }
        }

        #endregion

        #region locale

        [JsonProperty("locale"), Sdk4meIgnoreInFieldSelection()]
        public string Locale
        {
            get => locale;
            set
            {
                if (locale != value)
                    AddIncludedDuringSerialization("locale");
                locale = value;
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
        public KnowledgeArticleStatusType? Status
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

        internal override void ResetIncludedDuringSerialization()
        {
            service?.ResetIncludedDuringSerialization();
            base.ResetIncludedDuringSerialization();
        }
    }
}
