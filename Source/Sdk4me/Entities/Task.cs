using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/tasks/">task</see> object.
    /// </summary>
    public class Task : CustomFieldsBaseItem
    {
        private AgileBoard agileBoard;
        private AgileBoardColumn agileBoardColumn;
        private int? agileBoardColumnPosition;
        private DateTime? anticipatedAssignmentAt;
        private DateTime? assignedAt;
        private List<Attachment> attachments;
        private TaskCategory category;
        private Workflow workflow;
        private DateTime? completionTargetAt;
        private Task failureTask;
        private DateTime? finishedAt;
        private TaskImpact? impact;
        private string instructions;
        private Person manager;
        private Person member;
        private bool newAssignment;
        private string note;
        private List<AttachmentReference> noteAttachments;
        private WorkflowPhase phase;
        private TimeSpan plannedDuration;
        private TimeSpan? plannedEffort;
        private int rejectionCount;
        private Request request;
        private RequestTemplate requestTemplate;
        private ServiceInstance requestServiceInstance;
        private int? requiredApprovals;
        private TimeSpan? resolutionDuration;
        private SkillPool skillPool;
        private string source;
        private string sourceID;
        private DateTime? startAt;
        private TaskStatus status;
        private string subject;
        private Organization supplier;
        private string supplierRequestID;
        private Team team;
        private TaskTemplate template;
        private TimeSpan? timeSpent;
        private EffortClass timeSpentEffortClass;
        private bool urgent;
        private DateTime? waitingUntil;
        private bool workHoursAre24x7;

        #region Agile board

        /// <summary>
        /// The Agile board on which the task is placed.
        /// </summary>
        [JsonProperty("agile_board")]
        public AgileBoard AgileBoard
        {
            get => agileBoard;
            set => agileBoard = SetValue("agile_board_id", agileBoard, value);
        }

        [JsonProperty("agile_board_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? AgileBoardID => agileBoard?.ID;

        #endregion

        #region Agile board column

        /// <summary>
        /// The column of the agile board on which the task is placed.
        /// </summary>
        [JsonProperty("agile_board_column")]
        public AgileBoardColumn AgileBoardColumn
        {
            get => agileBoardColumn;
            set => agileBoardColumn = SetValue("agile_board_column_id", agileBoardColumn, value);
        }

        [JsonProperty("agile_board_column_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? AgileBoardColumnID => agileBoardColumn?.ID;

        #endregion

        #region Agile board column position

        /// <summary>
        /// The Position field is used to specify the position of the task, relative to the other items within the column of the agile board. The topmost item has position 1.
        /// </summary>
        [JsonProperty("agile_board_column_position")]
        public int? AgileBoardColumnPosition
        {
            get => agileBoardColumnPosition;
            set => agileBoardColumnPosition = SetValue("agile_board_column_position", agileBoardColumnPosition, value);
        }

        #endregion

        #region Anticipated assignment at

        /// <summary>
        /// The Anticipated assignment field shows the date and time at which the task is currently expected to be assigned.
        /// </summary>
        [JsonProperty("anticipated_assignment_at")]
        public DateTime? AnticipatedAssignmentAt
        {
            get => anticipatedAssignmentAt;
            internal set => anticipatedAssignmentAt = value;
        }

        #endregion

        #region Assigned at

        /// <summary>
        /// The Assigned field is automatically set to the current date and time when the task is assigned.
        /// </summary>
        [JsonProperty("assigned_at")]
        public DateTime? AssignedAt
        {
            get => assignedAt;
            set => assignedAt = SetValue("assigned_at", assignedAt, value);
        }

        #endregion

        #region Attachments

        /// <summary>
        /// Readonly aggregated Attachments
        /// </summary>
        [JsonProperty("attachments")]
        public List<Attachment> Attachments
        {
            get => attachments;
            internal set => attachments = value;
        }

        #endregion

        #region Category

        /// <summary>
        /// The Category field is used to select the category of the task. Risk & impact tasks are used to help plan workflows. Approval tasks are used to collect approvals for workflows. These can be used at various stages in the life of the workflow. Implementation tasks are added to workflows for development, installation, configuration, test, transfer and administrative work that needs to be completed for the implementation of the workflow. 
        /// </summary>
        [JsonProperty("category")]
        public TaskCategory Category
        {
            get => category;
            set => category = SetValue("category", category, value);
        }

        #endregion

        #region Workflow

        /// <summary>
        /// The Workflow field shows the ID and subject of the workflow to which the task belongs.
        /// </summary>
        [JsonProperty("workflow")]
        public Workflow Workflow
        {
            get => workflow;
            set => workflow = SetValue("workflow_id", workflow, value);
        }

        [JsonProperty("workflow_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? WorkflowID => workflow?.ID;

        #endregion

        #region Completion target at

        /// <summary>
        /// The Completion target field shows the date and time at which the task is expected to be completed.
        /// </summary>
        [JsonProperty("completion_target_at")]
        public DateTime? CompletionTargetAt
        {
            get => completionTargetAt;
            internal set => completionTargetAt = value;
        }

        #endregion

        #region Failure task

        /// <summary>
        /// The task that will be assigned in case this task is failed or rejected.
        /// </summary>
        [JsonProperty("failure_task")]
        public Task FailureTask
        {
            get => failureTask;
            set => failureTask = SetValue("failure_task_id", failureTask, value);
        }

        [JsonProperty("failure_task_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? FailureTaskID => failureTask?.ID;

        #endregion

        #region Finished at

        /// <summary>
        /// The Finished field is automatically set to the date and time at which the task is saved with the status “Failed”, “Rejected”, “Completed”, “Approved” or “Canceled”.
        /// </summary>
        [JsonProperty("finished_at")]
        public DateTime? FinishedAt
        {
            get => finishedAt;
            set => finishedAt = SetValue("finished_at", finishedAt, value);
        }

        #endregion

        #region Impact

        /// <summary>
        /// The Impact field is used to select the extent to which the Service Instances related to the task will be impacted by the completion of the task. 
        /// </summary>
        [JsonProperty("impact")]
        public TaskImpact? Impact
        {
            get => impact;
            set => impact = SetValue("impact", impact, value);
        }

        #endregion

        #region Instructions

        /// <summary>
        /// The Instructions field is used to provide instructions for the person to whom the task will be assigned.
        /// </summary>
        [JsonProperty("instructions")]
        public string Instructions
        {
            get => instructions;
            set => instructions = SetValue("instructions", instructions, value);
        }

        #endregion

        #region Manager

        /// <summary>
        /// The Manager field shows the person who is selected in the Manager field of the workflow that this task belongs to.
        /// </summary>
        [JsonProperty("manager")]
        public Person Manager
        {
            get => manager;
            set => manager = SetValue("manager_id", manager, value);
        }

        [JsonProperty("manager_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ManagerID => manager?.ID;

        #endregion

        #region Member

        /// <summary>
        /// The Member field is used to select the person to whom the task is to be assigned. This field’s value is null in case of an approval task with multiple approvers (see Approvals).
        /// </summary>
        [JsonProperty("member")]
        public Person Member
        {
            get => member;
            set => member = SetValue("member_id", member, value);
        }

        [JsonProperty("member_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? MemberID => member?.ID;

        #endregion

        #region New assignment

        /// <summary>
        /// default: false
        /// </summary>
        [JsonProperty("new_assignment")]
        public bool NewAssignment
        {
            get => newAssignment;
            internal set => newAssignment = value;
        }

        #endregion

        #region Note

        /// <summary>
        /// The Note field is used to provide information for the person to whom the task is assigned. It is also used to provide a summary of the actions that have been taken to date and the results of these actions.
        /// </summary>
        [JsonProperty("note"), Sdk4meIgnoreInFieldSelection()]
        public string Note
        {
            get => note;
            set => note = SetValue("note", note, value);
        }

        #endregion

        #region Note attachment

        /// <summary>
        /// Write-only. Add a reference to an uploaded note attachment. Use <see cref="Attachments"/> to get the existing attachments.
        /// </summary>
        /// <param name="key">The attachment key.</param>
        /// <param name="fileSize">The attachment file size.</param>
        /// <param name="inline">True if this an in-line attachment; otherwise false.</param>
        public void ReferenceNoteAttachment(string key, long fileSize, bool inline = false)
        {
            if (noteAttachments == null)
                noteAttachments = new List<AttachmentReference>();

            noteAttachments.Add(new AttachmentReference()
            {
                Key = key,
                FileSize = fileSize,
                Inline = inline
            });

            base.PropertySerializationCollection.Add("note_attachments");
        }

        [JsonProperty("note_attachments"), Sdk4meIgnoreInFieldSelection()]
        internal List<AttachmentReference> NoteAttachments
        {
            get => noteAttachments;
        }

        #endregion

        #region Phase

        /// <summary>
        /// The Phase field is used to select the phase of the workflow to which the task belongs.
        /// </summary>
        [JsonProperty("phase")]
        public WorkflowPhase Phase
        {
            get => phase;
            set => phase = SetValue("phase_id", phase, value);
        }

        [JsonProperty("phase_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? PhaseID => phase?.ID;

        #endregion

        #region Planned duration

        /// <summary>
        /// The Planned duration field is used to enter the number of minutes it is expected to take for the task to be completed following its assignment, or following its fixed start date and time if the Start no earlier than field is filled out.
        /// </summary>
        public TimeSpan PlannedDuration
        {
            get => plannedDuration;
            set => plannedDuration = SetValue("planned_duration", plannedDuration, value);
        }

        [JsonProperty("planned_duration")]
        internal int? PlannedDurationInMinutes
        {
            get => Convert.ToInt32(plannedDuration.TotalMinutes);
            set => plannedDuration = TimeSpan.FromMinutes(value.Value);
        }

        #endregion

        #region Planned effort

        /// <summary>
        /// The Planned effort field is used to specify the number of minutes the member is expected to spend working on the task.
        /// </summary>
        public TimeSpan? PlannedEffort
        {
            get => plannedEffort;
            set => plannedEffort = SetValue("planned_effort", plannedEffort, value);
        }

        [JsonProperty("planned_effort")]
        internal int? PlannedEffortInMinutes
        {
            get => plannedEffort != null ? Convert.ToInt32(plannedEffort.Value.TotalMinutes) : (int?)null;
            set => plannedEffort = value != null ? TimeSpan.FromMinutes(value.Value) : (TimeSpan?)null;
        }

        #endregion

        #region Rejection count

        /// <summary>
        /// The Rejection count field is incremented on (each) rejection of an approval task.
        /// </summary>
        [JsonProperty("rejection_count")]
        public int RejectionCount
        {
            get => rejectionCount;
            internal set => rejectionCount = value;
        }

        #endregion

        #region Request

        /// <summary>
        /// The Request field is visible only after a request has been generated by the task. This field shows the Request that was generated. As soon as this request has been completed with the completion reason “Solved”, the task’s status is set to “Completed”.
        /// </summary>
        [JsonProperty("request")]
        public Request Request
        {
            get => request;
            set => request = SetValue("request_id", request, value);
        }

        [JsonProperty("request_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? RequestID => request?.ID;

        #endregion

        #region Request template

        /// <summary>
        /// The Request template field is used to select the Request template that must be used to generate a new request when the status of the task is set to “Assigned”, “Accepted” or “In Progress”.
        /// </summary>
        [JsonProperty("request_template")]
        public RequestTemplate RequestTemplate
        {
            get => requestTemplate;
            set => requestTemplate = SetValue("request_template_id", requestTemplate, value);
        }

        [JsonProperty("request_template_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? RequestTemplateID => requestTemplate?.ID;

        #endregion

        #region Request service instance

        /// <summary>
        /// The Service instance field is used to select the Service instance that must be applied to the new request that is generated when the status of the task is set to “Assigned”, “Accepted” or “In Progress”.
        /// </summary>
        [JsonProperty("request_service_instance")]
        public ServiceInstance RequestServiceInstance
        {
            get => requestServiceInstance;
            set => requestServiceInstance = SetValue("request_service_instance_id", requestServiceInstance, value);
        }

        [JsonProperty("request_service_instance_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? RequestServiceInstanceID => requestServiceInstance?.ID;

        #endregion

        #region Required approvals

        /// <summary>
        /// The Required approvals field is used in approval tasks to specify the number of approvers who need to have provided their approval before the status of the task gets updated to “Approved”.
        /// </summary>
        [JsonProperty("required_approvals")]
        public int? RequiredApprovals
        {
            get => requiredApprovals;
            set => requiredApprovals = SetValue("required_approvals", requiredApprovals, value);
        }

        #endregion

        #region Resolution duration

        /// <summary>
        /// The number of minutes it took to complete this problem, which is calculated as the difference between the assigned_at and finished_at values.
        /// </summary>
        public TimeSpan? ResolutionDuration => resolutionDuration;

        [JsonProperty("resolution_duration")]
        internal int? ResolutionDurationInMinutes
        {
            get => resolutionDuration != null ? Convert.ToInt32(resolutionDuration.Value.TotalMinutes) : (int?)null;
            set => resolutionDuration = value != null ? TimeSpan.FromMinutes(value.Value) : (TimeSpan?)null;
        }

        #endregion

        #region Skill pool

        /// <summary>
        /// The Skill Pool field is used to select the skill pool to whom the task is to be assigned.
        /// </summary>
        [JsonProperty("skill_pool")]
        public SkillPool SkillPool
        {
            get => skillPool;
            set => skillPool = SetValue("skill_pool_id", skillPool, value);
        }

        [JsonProperty("skill_pool_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? SkillPoolID => skillPool?.ID;

        #endregion

        #region Source

        /// <summary>
        /// See source
        /// </summary>
        [JsonProperty("source")]
        public string Source
        {
            get => source;
            set => source = SetValue("source", source, value);
        }

        #endregion

        #region SourceID

        /// <summary>
        /// See source
        /// </summary>
        [JsonProperty("sourceID")]
        public string SourceID
        {
            get => sourceID;
            set => sourceID = SetValue("sourceID", sourceID, value);
        }

        #endregion

        #region Start at

        /// <summary>
        /// The Start no earlier than field is only used when work on the task may not start before a specific date and time.
        /// </summary>
        [JsonProperty("start_at")]
        public DateTime? StartAt
        {
            get => startAt;
            set => startAt = SetValue("start_at", startAt, value);
        }

        #endregion

        #region Status

        /// <summary>
        /// The Status field is used to select the current status of the task. 
        /// </summary>
        [JsonProperty("status")]
        public TaskStatus Status
        {
            get => status;
            set => status = SetValue("status", status, value);
        }

        #endregion

        #region Subject

        /// <summary>
        /// The Subject field is used to enter a short description of the objective of the task.
        /// </summary>
        [JsonProperty("subject")]
        public string Subject
        {
            get => subject;
            set => subject = SetValue("subject", subject, value);
        }

        #endregion

        #region Supplier

        /// <summary>
        /// The Supplier field is used to select the supplier organization that has been asked to assist with the completion of the task.
        /// </summary>
        [JsonProperty("supplier")]
        public Organization Supplier
        {
            get => supplier;
            set => supplier = SetValue("supplier_id", supplier, value);
        }

        [JsonProperty("supplier_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? SupplierID => supplier?.ID;

        #endregion

        #region Supplier requestID

        /// <summary>
        /// The Supplier request ID field is used to enter the identifier under which the request to help with the execution of the task has been registered at the supplier organization.
        /// </summary>
        [JsonProperty("supplier_requestID")]
        public string SupplierRequestID
        {
            get => supplierRequestID;
            set => supplierRequestID = SetValue("supplier_requestID", supplierRequestID, value);
        }

        #endregion

        #region Team

        /// <summary>
        /// The Team field is used to select the Team to which the task is to be assigned.
        /// </summary>
        [JsonProperty("team")]
        public Team Team
        {
            get => team;
            set => team = SetValue("team_id", team, value);
        }

        [JsonProperty("team_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? TeamID => team?.ID;

        #endregion

        #region Template

        /// <summary>
        /// The Template field contains the link to the task template that was used to register the task.
        /// </summary>
        [JsonProperty("template")]
        public TaskTemplate Template
        {
            get => template;
            set => template = SetValue("template_id", template, value);
        }

        [JsonProperty("template_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? TemplateID => template?.ID;

        #endregion

        #region Time spent

        /// <summary>
        /// The Time spent field is used to enter the time that you have spent working on the request since you started to work on it or, if you already entered some time for this request, since you last added your time spent in it.
        /// </summary>
        public TimeSpan? TimeSpent
        {
            get => timeSpent;
            set => timeSpent = SetValue("time_spent", timeSpent, value);
        }

        [JsonProperty("time_spent"), Sdk4meIgnoreInFieldSelection()]
        internal int? TimeSpentInMinutes
        {
            get => timeSpent != null ? Convert.ToInt32(timeSpent.Value.TotalMinutes) : (int?)null;
            set => timeSpent = value != null ? TimeSpan.FromMinutes(value.Value) : (TimeSpan?)null;
        }

        #endregion

        #region Time spent effort class

        /// <summary>
        /// The Effort class field is used to select the effort class that best reflects the type of effort for which time spent is being registered.
        /// </summary>
        [JsonProperty("time_spent_effort_class"), Sdk4meIgnoreInFieldSelection()]
        public EffortClass TimeSpentEffortClass
        {
            get => timeSpentEffortClass;
            set => timeSpentEffortClass = SetValue("time_spent_effort_class_id", timeSpentEffortClass, value);
        }

        [JsonProperty("time_spent_effort_class_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? TimeSpentEffortClassID => timeSpentEffortClass?.ID;

        #endregion

        #region Urgent

        /// <summary>
        /// When the task has been marked as urgent, the Urgent field is set to true.
        /// </summary>
        [JsonProperty("urgent")]
        public bool Urgent
        {
            get => urgent;
            set => urgent = SetValue("urgent", urgent, value);
        }

        #endregion

        #region Waiting until

        /// <summary>
        /// The Waiting until field is used to specify the date and time at which the status of the task is to be updated from waiting_for to assigned. This field is available only when the Status field is set to waiting_for.
        /// </summary>
        [JsonProperty("waiting_until")]
        public DateTime? WaitingUntil
        {
            get => waitingUntil;
            set => waitingUntil = SetValue("waiting_until", waitingUntil, value);
        }

        #endregion

        #region Work hours are 24x7

        /// <summary>
        /// When set to true, the completion target of the task is calculated using a 24x7 calendar rather than normal business hours.
        /// </summary>
        [JsonProperty("work_hours_are_24x7")]
        public bool WorkHoursAre24x7
        {
            get => workHoursAre24x7;
            set => workHoursAre24x7 = SetValue("work_hours_are_24x7", workHoursAre24x7, value);
        }

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            workflow?.ResetPropertySerializationCollection();
            failureTask?.ResetPropertySerializationCollection();
            manager?.ResetPropertySerializationCollection();
            member?.ResetPropertySerializationCollection();
            phase?.ResetPropertySerializationCollection();
            request?.ResetPropertySerializationCollection();
            requestTemplate?.ResetPropertySerializationCollection();
            supplier?.ResetPropertySerializationCollection();
            team?.ResetPropertySerializationCollection();
            timeSpentEffortClass?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
