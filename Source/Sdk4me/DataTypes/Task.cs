using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    public class Task : BaseItem
    {
        private DateTime? anticipatedAssignmentAt;
        private DateTime? assignedAt;
        private List<Attachment> attachments;
        private TaskCategoryType? category;
        private Change change;
        private DateTime? completionTargetAt;
        private DateTime? finishedAt;
        private TaskImpactType? impact;
        private string instructions;
        private Person manager;
        private Person member;
        private string note;
        private int? plannedDuration;
        private int? plannedEffort;
        private int? requiredApprovals;
        private string source;
        private string sourceID;
        private DateTime? startAt;
        private TaskStatusType? status;
        private string subject;
        private Organization supplier;
        private string supplierRequestID;
        private Team team;
        private TaskTemplate template;
        private bool urgent;
        private DateTime? waitingUntil;
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
            set
            {
                if (assignedAt != value)
                    AddIncludedDuringSerialization("assigned_at");
                assignedAt = value;
            }
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
        public TaskCategoryType? Category
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

        #region completion_target_at

        [JsonProperty("completion_target_at")]
        public DateTime? CompletionTargetAt
        {
            get => completionTargetAt;
            internal set => completionTargetAt = value;
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

        #region impact

        [JsonProperty("impact")]
        public TaskImpactType? Impact
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

        #region planned_duration

        [JsonProperty("planned_duration")]
        public int? PlannedDuration
        {
            get => plannedDuration;
            set
            {
                if (plannedDuration != value)
                    AddIncludedDuringSerialization("planned_duration");
                plannedDuration = value;
            }
        }

        #endregion

        #region planned_effort

        [JsonProperty("planned_effort")]
        public int? PlannedEffort
        {
            get => plannedEffort;
            set
            {
                if (plannedEffort != value)
                    AddIncludedDuringSerialization("planned_effort");
                plannedEffort = value;
            }
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
        public TaskStatusType? Status
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

        #region template

        [JsonProperty("template")]
        public TaskTemplate Template
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

            change?.ResetIncludedDuringSerialization();
            manager?.ResetIncludedDuringSerialization();
            member?.ResetIncludedDuringSerialization();
            supplier?.ResetIncludedDuringSerialization();
            team?.ResetIncludedDuringSerialization();
            template?.ResetIncludedDuringSerialization();
            base.ResetIncludedDuringSerialization();
        }
    }
}
