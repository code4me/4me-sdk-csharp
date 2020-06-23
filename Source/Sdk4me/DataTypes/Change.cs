using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    public class Change : BaseItem
    {
        private int actualEffort;
        private ChangeCategoryType? category;
        private string changeType;
        private DateTime? completedAt;
        private ChangeCompletionReasonType? completionReason;
        private DateTime? completionTargetAt;
        private int? effortIndication;
        private ChangeImpactType impact;
        private ChangeJustificationType? justification;
        private Person manager;
        private string note;
        private int plannedEffort;
        private Project project;
        private Release release;
        private int remainingEffort;
        private Service service;
        private string source;
        private string sourceID;
        private DateTime? startAt;
        private ChangeStatusType? status;
        private string subject;
        private ChangeTemplate template;
        private CustomFieldCollection customFields;

        #region actual_effort

        [JsonProperty("actual_effort")]
        public int ActualEffort
        {
            get => actualEffort;
            internal set => actualEffort = value;
        }

        #endregion

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

        #region completed_at

        [JsonProperty("completed_at")]
        public DateTime? CompletedAt
        {
            get => completedAt;
            internal set => completedAt = value;
        }

        #endregion

        #region completion_reason

        [JsonProperty("completion_reason")]
        public ChangeCompletionReasonType? CompletionReason
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

        #region completion_target_at

        [JsonProperty("completion_target_at")]
        public DateTime? CompletionTargetAt
        {
            get => completionTargetAt;
            internal set => completionTargetAt = value;
        }

        #endregion

        #region effort_indication

        [JsonProperty("effort_indication")]
        public int? EffortIndication
        {
            get => effortIndication;
            internal set => effortIndication = value;
        }

        #endregion

        #region impact

        [JsonProperty("impact")]
        public ChangeImpactType Impact
        {
            get => impact;
            internal set => impact = value;
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

        #region planned_effort

        [JsonProperty("planned_effort")]
        public int PlannedEffort
        {
            get => plannedEffort;
            internal set => plannedEffort = value;
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

        #region release

        [JsonProperty("release")]
        public Release Release
        {
            get => release;
            set
            {
                if (release?.ID != value?.ID)
                    AddIncludedDuringSerialization("release_id");
                release = value;
            }
        }

        [JsonProperty(PropertyName = "release_id"), Sdk4meIgnoreInFieldSelection()]
        private long? ReleaseID
        {
            get => (release != null ? release.ID : (long?)null);
        }

        #endregion

        #region remaining_effort

        [JsonProperty("remaining_effort")]
        public int RemainingEffort
        {
            get => remainingEffort;
            internal set => remainingEffort = value;
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

        #region status

        [JsonProperty("status")]
        public ChangeStatusType? Status
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

        #region template

        [JsonProperty("template")]
        public ChangeTemplate Template
        {
            get => template;
            set
            {
                if (template?.ID != value?.ID)
                    AddIncludedDuringSerialization("template_id");
                template = value;
            }
        }

        [JsonProperty(PropertyName = "template_id"), Sdk4meIgnoreInFieldSelection()]
        private long? TemplateID
        {
            get => (template != null ? template.ID : (long?)null);
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
            manager?.ResetIncludedDuringSerialization();
            project?.ResetIncludedDuringSerialization();
            release?.ResetIncludedDuringSerialization();
            service?.ResetIncludedDuringSerialization();
            template?.ResetIncludedDuringSerialization();
            base.ResetIncludedDuringSerialization();
        }
    }
}
