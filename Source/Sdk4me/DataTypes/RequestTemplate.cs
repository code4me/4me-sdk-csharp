using Newtonsoft.Json;

namespace Sdk4me
{
    public class RequestTemplate : BaseItem
    {
        private bool assetSelection;
        private bool assignToSelf;
        private RequestCategoryType? category;
        private Person changeManager;
        private ChangeTemplate changeTemplate;
        private ConfigurationItem cI;
        private RequestCompletionReasonType? completionReason;
        private bool copySubjectToRequest;
        private int? desiredCompletion;
        private bool disabled;
        private EffortClass effortClass;
        private bool endUsers;
        private RequestImpactType? impact;
        private string instructions;
        private string keywords;
        private string localizedNote;
        private string localizedSubject;
        private Person member;
        private string note;
        private string registrationHints;
        private Service service;
        private string source;
        private string sourceID;
        private bool specialists;
        private RequestStatusType? status;
        private string subject;
        private Organization supplier;
        private Calendar supportHours;
        private Team team;
        private string timeZone;
        private int? timesApplied;
        private UIExtension uIExtension;
        private bool urgent;

        #region asset_selection

        [JsonProperty("asset_selection")]
        public bool AssetSelection
        {
            get => assetSelection;
            set
            {
                if (assetSelection != value)
                    AddIncludedDuringSerialization("asset_selection");
                assetSelection = value;
            }
        }

        #endregion

        #region assign_to_self

        [JsonProperty("assign_to_self")]
        public bool AssignToSelf
        {
            get => assignToSelf;
            set
            {
                if (assignToSelf != value)
                    AddIncludedDuringSerialization("assign_to_self");
                assignToSelf = value;
            }
        }

        #endregion

        #region category

        [JsonProperty("category")]
        public RequestCategoryType? Category
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

        #region change_template

        [JsonProperty("change_template")]
        public ChangeTemplate ChangeTemplate
        {
            get => changeTemplate;
            set
            {
                if (changeTemplate?.ID != value?.ID)
                    AddIncludedDuringSerialization("change_template_id");
                changeTemplate = value;
            }
        }

        [JsonProperty(PropertyName = "change_template_id"), Sdk4meIgnoreInFieldSelection()]
        private long? ChangeTemplateID
        {
            get => (changeTemplate != null ? changeTemplate.ID : (long?)null);
        }

        #endregion

        #region ci

        [JsonProperty("ci")]
        public ConfigurationItem CI
        {
            get => cI;
            set
            {
                if (cI?.ID != value?.ID)
                    AddIncludedDuringSerialization("ci_id");
                cI = value;
            }
        }

        [JsonProperty(PropertyName = "ci_id"), Sdk4meIgnoreInFieldSelection()]
        private long? CIID
        {
            get => (cI != null ? cI.ID : (long?)null);
        }

        #endregion

        #region completion_reason

        [JsonProperty("completion_reason")]
        public RequestCompletionReasonType? CompletionReason
        {
            get => completionReason;
            set
            {
                if (completionReason != value)
                    AddIncludedDuringSerialization("completion_reason");
                completionReason = value;
            }
        }

        #endregion

        #region copy_subject_to_request

        [JsonProperty("copy_subject_to_request"), Sdk4meIgnoreInFieldSelection()]
        public bool CopySubjectToRequest
        {
            get => copySubjectToRequest;
            set
            {
                if (copySubjectToRequest != value)
                    AddIncludedDuringSerialization("copy_subject_to_request");
                copySubjectToRequest = value;
            }
        }

        #endregion

        #region desired_completion

        [JsonProperty("desired_completion")]
        public int? DesiredCompletion
        {
            get => desiredCompletion;
            set
            {
                if (desiredCompletion != value)
                    AddIncludedDuringSerialization("desired_completion");
                desiredCompletion = value;
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

        #region effort_class

        [JsonProperty("effort_class")]
        public EffortClass EffortClass
        {
            get => effortClass;
            set
            {
                if (effortClass?.ID != value?.ID)
                    AddIncludedDuringSerialization("effort_class_id");
                effortClass = value;
            }
        }

        [JsonProperty(PropertyName = "effort_class_id"), Sdk4meIgnoreInFieldSelection()]
        private long? EffortClassID
        {
            get => (effortClass != null ? effortClass.ID : (long?)null);
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
                    AddIncludedDuringSerialization("end_users");
                endUsers = value;
            }
        }

        #endregion

        #region impact

        [JsonProperty("impact")]
        public RequestImpactType? Impact
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

        #region localized_note

        [JsonProperty("localized_note"), Sdk4meIgnoreInFieldSelection()]
        public string LocalizedNote
        {
            get => localizedNote;
            internal set => localizedNote = value;
        }

        #endregion

        #region localized_subject

        [JsonProperty("localized_subject"), Sdk4meIgnoreInFieldSelection()]
        public string LocalizedSubject
        {
            get => localizedSubject;
            internal set => localizedSubject = value;
        }

        #endregion

        #region member

        [JsonProperty("member")]
        public Person Member
        {
            get => member;
            set
            {
                if (member?.ID != value?.ID)
                    AddIncludedDuringSerialization("member_id");
                member = value;
            }
        }

        [JsonProperty(PropertyName = "member_id"), Sdk4meIgnoreInFieldSelection()]
        private long? MemberID
        {
            get => (member != null ? member.ID : (long?)null);
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

        #region registration_hints

        [JsonProperty("registration_hints")]
        public string RegistrationHints
        {
            get => registrationHints;
            set
            {
                if (registrationHints != value)
                    AddIncludedDuringSerialization("registration_hints");
                registrationHints = value;
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

        #region specialists

        [JsonProperty("specialists")]
        public bool Specialists
        {
            get => specialists;
            set
            {
                if (specialists != value)
                    AddIncludedDuringSerialization("specialists");
                specialists = value;
            }
        }

        #endregion

        #region status

        [JsonProperty("status")]
        public RequestStatusType? Status
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

        #region supplier

        [JsonProperty("supplier")]
        public Organization Supplier
        {
            get => supplier;
            set
            {
                if (supplier?.ID != value?.ID)
                    AddIncludedDuringSerialization("supplier_id");
                supplier = value;
            }
        }

        [JsonProperty(PropertyName = "supplier_id"), Sdk4meIgnoreInFieldSelection()]
        private long? SupplierID
        {
            get => (supplier != null ? supplier.ID : (long?)null);
        }

        #endregion

        #region support_hours

        [JsonProperty("support_hours")]
        public Calendar SupportHours
        {
            get => supportHours;
            set
            {
                if (supportHours?.ID != value?.ID)
                    AddIncludedDuringSerialization("support_hours_id");
                supportHours = value;
            }
        }

        [JsonProperty(PropertyName = "support_hours_id"), Sdk4meIgnoreInFieldSelection()]
        private long? SupportHoursID
        {
            get => (supportHours != null ? supportHours.ID : (long?)null);
        }

        #endregion

        #region team

        [JsonProperty("team")]
        public Team Team
        {
            get => team;
            set
            {
                if (team?.ID != value?.ID)
                    AddIncludedDuringSerialization("team_id");
                team = value;
            }
        }

        [JsonProperty(PropertyName = "team_id"), Sdk4meIgnoreInFieldSelection()]
        private long? TeamID
        {
            get => (team != null ? team.ID : (long?)null);
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

        #region times_applied

        [JsonProperty("times_applied")]
        public int? TimesApplied
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

        #region urgent

        [JsonProperty("urgent")]
        public bool Urgent
        {
            get => urgent;
            set
            {
                if (urgent != value)
                    AddIncludedDuringSerialization("urgent");
                urgent = value;
            }
        }

        #endregion

        internal override void ResetIncludedDuringSerialization()
        {
            changeManager?.ResetIncludedDuringSerialization();
            changeTemplate?.ResetIncludedDuringSerialization();
            cI?.ResetIncludedDuringSerialization();
            effortClass?.ResetIncludedDuringSerialization();
            member?.ResetIncludedDuringSerialization();
            service?.ResetIncludedDuringSerialization();
            supplier?.ResetIncludedDuringSerialization();
            supportHours?.ResetIncludedDuringSerialization();
            team?.ResetIncludedDuringSerialization();
            uIExtension?.ResetIncludedDuringSerialization();
            base.ResetIncludedDuringSerialization();
        }
    }
}
