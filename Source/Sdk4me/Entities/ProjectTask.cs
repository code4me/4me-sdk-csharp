using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/project_tasks/">project task</see> object.
    /// </summary>
    public class ProjectTask : CustomFieldsBaseItem
    {
        private AgileBoard agileBoard;
        private AgileBoardColumn agileBoardColumn;
        private int? agileBoardColumnPosition;
        private DateTime? anticipatedAssignmentAt;
        private DateTime? assignedAt;
        private List<Attachment> attachments;
        private ProjectTaskCategory? category;
        private DateTime? completionTargetAt;
        private DateTime? deadline;
        private DateTime? finishedAt;
        private string instructions;
        private Person manager;
        private string note;
        private List<AttachmentReference> noteAttachments;
        private ProjectPhase phase;
        private TimeSpan plannedDuration;
        private TimeSpan? plannedEffort;
        private Project project;
        private int? requiredApprovals;
        private TimeSpan? resolutionDuration;
        private SkillPool skillPool;
        private string source;
        private string sourceID;
        private DateTime? startAt;
        private ProjectTaskStatus? status;
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
        /// The Agile board on which the project task is placed.
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
        /// The column of the agile board on which the project task is placed.
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
        /// The Position field is used to specify the position of the project task, relative to the other items within the column of the agile board. The topmost item has position 1.
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
        /// The Anticipated assignment field shows the date and time at which the project task is currently expected to be assigned.
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
        /// The Assigned field is automatically set to the current date and time when the project task is assigned.
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
        /// The Category field is used to select the category of the project task. Activity tasks are used to assign project-related work to people. Approval tasks are used to collect approvals for projects. Milestones are used to mark specific points along a project’s implementation plan. 
        /// </summary>
        [JsonProperty("category")]
        public ProjectTaskCategory? Category
        {
            get => category;
            set => category = SetValue("category", category, value);
        }

        #endregion

        #region Completion target at

        /// <summary>
        /// The Completion target field shows the date and time at which the project task is expected to be completed.
        /// </summary>
        [JsonProperty("completion_target_at")]
        public DateTime? CompletionTargetAt
        {
            get => completionTargetAt;
            internal set => completionTargetAt = value;
        }

        #endregion

        #region Deadline

        /// <summary>
        /// The Deadline field is used to specify the date and time at which the milestone needs to have been reached.
        /// </summary>
        [JsonProperty("deadline")]
        public DateTime? Deadline
        {
            get => deadline;
            set => deadline = SetValue("deadline", deadline, value);
        }

        #endregion

        #region Finished at

        /// <summary>
        /// The Finished field is automatically set to the date and time at which the project task is saved with the status “Failed”, “Rejected”, “Completed”, “Approved” or “Canceled”.
        /// </summary>
        [JsonProperty("finished_at")]
        public DateTime? FinishedAt
        {
            get => finishedAt;
            set => finishedAt = SetValue("finished_at", finishedAt, value);
        }

        #endregion

        #region Instructions

        /// <summary>
        /// The Instructions field is used to provide instructions for the person(s) to whom the project task will be assigned.
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
        /// The Manager field shows the person who is selected in the Manager field of the project that this project task belongs to.
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

        #region Note

        /// <summary>
        /// The Note field is used to provide information for the person to whom the project task is assigned. It is also used to provide a summary of the actions that have been taken to date and the results of these actions.
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
        /// The Phase field is used to select the phase of the project to which the project task belongs.
        /// </summary>
        [JsonProperty("phase")]
        public ProjectPhase Phase
        {
            get => phase;
            set => phase = SetValue("phase_id", phase, value);
        }

        [JsonProperty("phase_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? PhaseID => phase?.ID;

        #endregion

        #region Planned duration

        /// <summary>
        /// The Planned duration field is used to enter the number of minutes it is expected to take for the project task to be completed following its assignment, or following its fixed start date and time if the Start no earlier than field is filled out.
        /// </summary>
        public TimeSpan PlannedDuration
        {
            get => plannedDuration;
            set => plannedDuration = SetValue("planned_duration", plannedDuration, value);
        }

        [JsonProperty("planned_duration")]
        internal int PlannedDurationInMinutes
        {
            get => Convert.ToInt32(plannedDuration.TotalMinutes);
            set => plannedDuration = TimeSpan.FromMinutes(value);
        }

        #endregion

        #region Planned effort

        /// <summary>
        /// The Planned effort field is used to specify the number of minutes the team is expected to spend working on the project task.
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

        #region Project

        /// <summary>
        /// The Project field shows the ID and subject of the project to which the project task belongs.
        /// </summary>
        [JsonProperty("project")]
        public Project Project
        {
            get => project;
            set => project = SetValue("project_id", project, value);
        }

        [JsonProperty("project_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ProjectID => project?.ID;

        #endregion

        #region Required approvals

        /// <summary>
        /// The Required approvals field is used to specify the number of assignees who need to have provided their approval before the status of the project task gets updated to “Approved”.
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
        /// The Skill Pool field is used to select the skill pool to whom the project task is to be assigned.
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
        /// The Start no earlier than field is only used when work on the project task may not start before a specific date and time.
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
        /// The Status field is used to select the current status of the project task. 
        /// </summary>
        [JsonProperty("status")]
        public ProjectTaskStatus? Status
        {
            get => status;
            set => status = SetValue("status", status, value);
        }

        #endregion

        #region Subject

        /// <summary>
        /// The Subject field is used to enter a short description of the objective of the project task.
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
        /// The Supplier field is used to select the supplier organization that has been asked to assist with the completion of the project task.
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
        /// The Supplier request ID field is used to enter the identifier under which the request to help with the execution of the project task has been registered at the supplier organization.
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
        /// The Team field is used to select the Team to which the project task is to be assigned.
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
        /// The Template field contains the link to the project task template that was used to register the project task.
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
        /// The Time spent field is used to enter the time that you have spent working on the project task since you started to work on it or, if you already entered some time for this project task, since you last added your time spent in it.
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
        /// The project task can be marked as urgent by setting the Urgent field to true.
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
        /// The Waiting until field is used to specify the date and time at which the status of the project task is to be updated from waiting_for to assigned. This field is available only when the Status field is set to waiting_for.
        /// </summary>
        [JsonProperty("waiting_until"), Sdk4meIgnoreInFieldSelection()]
        public DateTime? WaitingUntil
        {
            get => waitingUntil;
            set => waitingUntil = SetValue("waiting_until", waitingUntil, value);
        }

        #endregion

        #region Work hours are 24x7

        /// <summary>
        /// When set to true, the completion target of the project task is calculated using a 24x7 calendar rather than normal business hours.
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
            manager?.ResetPropertySerializationCollection();
            phase?.ResetPropertySerializationCollection();
            project?.ResetPropertySerializationCollection();
            supplier?.ResetPropertySerializationCollection();
            team?.ResetPropertySerializationCollection();
            template?.ResetPropertySerializationCollection();
            timeSpentEffortClass?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
