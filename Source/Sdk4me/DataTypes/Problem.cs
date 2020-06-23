using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    public class Problem : BaseItem
    {
        private DateTime? analysisTargetAt;
        private ProblemCategoryType? category;
        private Change change;
        private ProblemImpactType? impact;
        private KnowledgeArticle knowledgeArticle;
        private bool knownError;
        private Person manager;
        private Person member;
        private bool newAssignment;
        private string note;
        private Project project;
        private Service service;
        private DateTime? solvedAt;
        private string source;
        private string sourceID;
        private ProblemStatusType? status;
        private string subject;
        private Organization supplier;
        private string supplierRequestID;
        private Team team;
        private int? timeSpent;
        private EffortClass timeSpentEffortClass;
        private UIExtension uIExtension;
        private bool urgent;
        private DateTime? waitingUntil;
        private string workaround;
        private CustomFieldCollection customFields;

        #region analysis_target_at

        [JsonProperty("analysis_target_at")]
        public DateTime? AnalysisTargetAt
        {
            get => analysisTargetAt;
            set
            {
                if (analysisTargetAt != value)
                    AddIncludedDuringSerialization("analysis_target_at");
                analysisTargetAt = value;
            }
        }

        #endregion

        #region category

        [JsonProperty("category")]
        public ProblemCategoryType? Category
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

        #region change

        [JsonProperty("change")]
        public Change Change
        {
            get => change;
            set
            {
                if (change?.ID != value?.ID)
                    AddIncludedDuringSerialization("change_id");
                change = value;
            }
        }

        [JsonProperty(PropertyName = "change_id"), Sdk4meIgnoreInFieldSelection()]
        private long? ChangeID
        {
            get => (change != null ? change.ID : (long?)null);
        }

        #endregion

        #region impact

        [JsonProperty("impact")]
        public ProblemImpactType? Impact
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

        #region knowledge_article

        [JsonProperty("knowledge_article")]
        public KnowledgeArticle KnowledgeArticle
        {
            get => knowledgeArticle;
            set
            {
                if (knowledgeArticle?.ID != value?.ID)
                    AddIncludedDuringSerialization("knowledge_article_id");
                knowledgeArticle = value;
            }
        }

        [JsonProperty(PropertyName = "knowledge_article_id"), Sdk4meIgnoreInFieldSelection()]
        private long? KnowledgeArticleID
        {
            get => (knowledgeArticle != null ? knowledgeArticle.ID : (long?)null);
        }

        #endregion

        #region known_error

        [JsonProperty("known_error")]
        public bool KnownError
        {
            get => knownError;
            set
            {
                if (knownError != value)
                    AddIncludedDuringSerialization("known_error");
                knownError = value;
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

        #region new_assignment

        [JsonProperty("new_assignment")]
        public bool NewAssignment
        {
            get => newAssignment;
            internal set => newAssignment = value;
        }

        #endregion

        #region note

        [JsonProperty("note"), Sdk4meIgnoreInFieldSelection()]
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

        #region project

        [JsonProperty("project")]
        public Project Project
        {
            get => project;
            set
            {
                if (project?.ID != value?.ID)
                    AddIncludedDuringSerialization("project_id");
                project = value;
            }
        }

        [JsonProperty(PropertyName = "project_id"), Sdk4meIgnoreInFieldSelection()]
        private long? ProjectID
        {
            get => (project != null ? project.ID : (long?)null);
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

        #region solved_at

        [JsonProperty("solved_at")]
        public DateTime? SolvedAt
        {
            get => solvedAt;
            internal set => solvedAt = value;
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
        public ProblemStatusType? Status
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

        #region supplier_requestID

        [JsonProperty("supplier_requestID")]
        public string SupplierRequestID
        {
            get => supplierRequestID;
            set
            {
                if (supplierRequestID != value)
                    AddIncludedDuringSerialization("supplier_requestID");
                supplierRequestID = value;
            }
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

        #region time_spend

        [JsonProperty("time_spent"), Sdk4meIgnoreInFieldSelection()]
        public int? TimeSpent
        {
            get => timeSpent;
            set
            {
                if (timeSpent != value)
                    AddIncludedDuringSerialization("time_spent");
                timeSpent = value;
            }
        }

        #endregion

        #region time_spent_effort_class

        [JsonProperty("time_spent_effort_class"), Sdk4meIgnoreInFieldSelection()]
        public EffortClass TimeSpentEffortClass
        {
            get => timeSpentEffortClass;
            set
            {
                if (timeSpentEffortClass?.ID != value?.ID)
                    AddIncludedDuringSerialization("effort_class_id");
                timeSpentEffortClass = value;
            }
        }

        [JsonProperty(PropertyName = "time_spent_effort_class_id"), Sdk4meIgnoreInFieldSelection()]
        private long? TimeSpentEffortClassID
        {
            get => (timeSpentEffortClass != null ? timeSpentEffortClass.ID : (long?)null);
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

        #region waiting_until

        [JsonProperty("waiting_until")]
        public DateTime? WaitingUntil
        {
            get => waitingUntil;
            set
            {
                if (waitingUntil != value)
                    AddIncludedDuringSerialization("waiting_until");
                waitingUntil = value;
            }
        }

        #endregion

        #region workaround

        [JsonProperty("workaround")]
        public string Workaround
        {
            get => workaround;
            set
            {
                if (workaround != value)
                    AddIncludedDuringSerialization("workaround");
                workaround = value;
            }
        }

        #endregion

        #region custom_fields

        [JsonProperty("custom_fields")]
        private List<CustomField> CustomFieldsPrivate
        {
            get => customFields?.GetCustomFields();
            set
            {
                customFields = new CustomFieldCollection(value);
                customFields.Changed += CustomFields_Changed;
            }
        }

        [JsonIgnore(), Sdk4meIgnoreInFieldSelection()]
        public CustomFieldCollection CustomFields
        {
            get
            {
                if (customFields == null)
                {
                    customFields = new CustomFieldCollection();
                    customFields.Changed += CustomFields_Changed;
                }
                return customFields;
            }
        }

        private void CustomFields_Changed(object sender, EventArgs e)
        {
            AddIncludedDuringSerialization("custom_fields");
        }

        #endregion

        internal override void ResetIncludedDuringSerialization()
        {
            change?.ResetIncludedDuringSerialization();
            knowledgeArticle?.ResetIncludedDuringSerialization();
            manager?.ResetIncludedDuringSerialization();
            member?.ResetIncludedDuringSerialization();
            project?.ResetIncludedDuringSerialization();
            service?.ResetIncludedDuringSerialization();
            supplier?.ResetIncludedDuringSerialization();
            team?.ResetIncludedDuringSerialization();
            timeSpentEffortClass?.ResetIncludedDuringSerialization();
            uIExtension?.ResetIncludedDuringSerialization();
            base.ResetIncludedDuringSerialization();
        }
    }
}
