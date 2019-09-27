using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    public class ProjectTask : BaseItem
    {
        private DateTime? anticipatedAssignmentAt;
        private DateTime? assignedAt;
        private List<Attachment> attachments;
        private ProjectCategoryType? category;
        private DateTime? completionTargetAt;
        private DateTime? deadline;
        private DateTime? finishedAt;
        private string instructions;
        private Person manager;
        private string note;
        private ProjectPhase phase;
        private int? plannedDurationInMinutes;
        private int? plannedEffortInMinutes;
        private Project project;
        private int? requiredApprovals;
        private string source;
        private string sourceID;
        private DateTime? startAt;
        private ProjectTaskStatusType? status;
        private string subject;
        private Organization supplier;
        private string supplierRequestID;
        private ProjectTaskTemplate template;
        private bool urgent;
        private bool workHoursAre24x7;
        private CustomFieldCollection customFields;

        #region anticipated_assignment_at

        [JsonProperty("anticipated_assignment_at")]
        public DateTime? AnticipatedAssignmentAt
        {
            get => anticipatedAssignmentAt;
            internal set => anticipatedAssignmentAt = value;
        }

        #endregion

        #region assigned_at

        [JsonProperty("assigned_at")]
        public DateTime? AssignedAt
        {
            get => assignedAt;
            internal set => assignedAt = value;
        }

        #endregion

        #region attachments

        [JsonProperty("attachments")]
        public List<Attachment> Attachments
        {
            get => attachments;
            internal set => attachments = value;
        }

        #endregion

        #region category

        [JsonProperty("category")]
        public ProjectCategoryType? Category
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

        #region completion_target_at

        [JsonProperty("completion_target_at")]
        public DateTime? CompletionTargetAt
        {
            get => completionTargetAt;
            internal set => completionTargetAt = value;
        }

        #endregion

        #region deadline

        [JsonProperty("deadline")]
        public DateTime? Deadline
        {
            get => deadline;
            set
            {
                if (deadline != value)
                    AddIncludedDuringSerialization("deadline");
                deadline = value;
            }
        }

        #endregion

        #region finished_at

        [JsonProperty("finished_at")]
        public DateTime? FinishedAt
        {
            get => finishedAt;
            set
            {
                if (finishedAt != value)
                    AddIncludedDuringSerialization("finished_at");
                finishedAt = value;
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

        #region manager

        [JsonProperty("manager")]
        public Person Manager
        {
            get => manager;
            internal set => manager = value;
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

        #region phase

        [JsonProperty("phase")]
        public ProjectPhase Phase
        {
            get => phase;
            internal set => phase = value;
        }

        #endregion

        #region planned_duration_in_minutes

        [JsonProperty("planned_duration_in_minutes")]
        public int? PlannedDurationInMinutes
        {
            get => plannedDurationInMinutes;
            set
            {
                if (plannedDurationInMinutes != value)
                    AddIncludedDuringSerialization("planned_duration_in_minutes");
                plannedDurationInMinutes = value;
            }
        }

        #endregion

        #region planned_effort_in_minutes

        [JsonProperty("planned_effort_in_minutes")]
        public int? PlannedEffortInMinutes
        {
            get => plannedEffortInMinutes;
            set
            {
                if (plannedEffortInMinutes != value)
                    AddIncludedDuringSerialization("planned_effort_in_minutes");
                plannedEffortInMinutes = value;
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

        #region required_approvals

        [JsonProperty("required_approvals")]
        public int? RequiredApprovals
        {
            get => requiredApprovals;
            set
            {
                if (requiredApprovals != value)
                    AddIncludedDuringSerialization("required_approvals");
                requiredApprovals = value;
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
        public ProjectTaskStatusType? Status
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

        #region template

        [JsonProperty("template")]
        public ProjectTaskTemplate Template
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

        #region work_hours_are_24x7

        [JsonProperty("work_hours_are_24x7")]
        public bool WorkHoursAre24x7
        {
            get => workHoursAre24x7;
            set
            {
                if (workHoursAre24x7 != value)
                    AddIncludedDuringSerialization("work_hours_are_24x7");
                workHoursAre24x7 = value;
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
            if (attachments != null)
                for (int i = 0; i < attachments.Count; i++)
                    attachments[i]?.ResetIncludedDuringSerialization();

            manager?.ResetIncludedDuringSerialization();
            phase?.ResetIncludedDuringSerialization();
            project?.ResetIncludedDuringSerialization();
            supplier?.ResetIncludedDuringSerialization();
            template?.ResetIncludedDuringSerialization();
            base.ResetIncludedDuringSerialization();
        }
    }
}
