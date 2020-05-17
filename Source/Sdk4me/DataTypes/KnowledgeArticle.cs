using Newtonsoft.Json;

namespace Sdk4me
{
    public class KnowledgeArticle : BaseItem
    {
        private bool coveredSpecialists;
        private Person createdBy;
        private string description;
        private bool endUsers;
        private string instructions;
        private bool internalSpecialists;
        private bool keyContacts;
        private string keywords;
        private string locale;
        private Service service;
        private string source;
        private string sourceID;
        private KnowledgeArticleStatusType? status;
        private string subject;
        private int timesApplied;

        #region covered_specialists

        [JsonProperty("covered_specialists")]
        public bool CoveredSpecialists
        {
            get => coveredSpecialists;
            set
            {
                if (coveredSpecialists != value)
                    AddIncludedDuringSerialization("disabled");
                coveredSpecialists = value;
            }
        }

        #endregion

        #region created_by

        [JsonProperty("created_by")]
        public Person CreatedBy
        {
            get => createdBy;
            internal set => createdBy = value;
        }

        #endregion

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

        #region end_users

        [JsonProperty("end_users")]
        public bool EndUsers
        {
            get => endUsers;
            set
            {
                if (endUsers != value)
                    AddIncludedDuringSerialization("disabled");
                endUsers = value;
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

        #region internal_specialists

        [JsonProperty("internal_specialists")]
        public bool InternalSpecialists
        {
            get => internalSpecialists;
            set
            {
                if (internalSpecialists != value)
                    AddIncludedDuringSerialization("disabled");
                internalSpecialists = value;
            }
        }

        #endregion

        #region key_contacts

        [JsonProperty("key_contacts")]
        public bool KeyContacts
        {
            get => keyContacts;
            set
            {
                if (keyContacts != value)
                    AddIncludedDuringSerialization("disabled");
                keyContacts = value;
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
