using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/workflows/">workflow</see> object.
    /// </summary>
    public class Workflow : CustomFieldsBaseItem
    {
        private int actualEffort;
        private int actualVsPlannedEffortPercentage;
        private List<Attachment> attachments;
        private WorkflowCategory? category;
        private string workflowType;
        private DateTime? completedAt;
        private WorkflowCompletionReason? completionReason;
        private DateTime? completionTargetAt;
        private WorkflowImpact impact;
        private WorkflowJustification? justification;
        private Person manager;
        private string note;
        private List<AttachmentReference> noteAttachments;
        private TimeSpan plannedEffort;
        private Project project;
        private Release release;
        private TimeSpan? resolutionDuration;
        private Service service;
        private string source;
        private string sourceID;
        private DateTime? startAt;
        private WorkflowStatus? status;
        private string subject;
        private WorkflowTemplate template;

        #region Actual effort

        /// <summary>
        /// The Actual effort field shows the total time that has already been spent on the workflow. This is the sum of the time spent on each of the workflow’s tasks and the planned effort of the related requests and problems.
        /// </summary>
        [JsonProperty("actual_effort")]
        public int ActualEffort
        {
            get => actualEffort;
            internal set => actualEffort = value;
        }

        #endregion

        #region Actual vs planned effort percentage

        /// <summary>
        /// The actual effort as a percentage of the planned effort.
        /// </summary>
        [JsonProperty("actual_vs_planned_effort_percentage")]
        public int ActualVsPlannedEffortPercentage
        {
            get => actualVsPlannedEffortPercentage;
            internal set => actualVsPlannedEffortPercentage = value;
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
        /// The Category field is used to select the category of the workflow. A workflow is either planned or unplanned. Select the category “Emergency” for workflows that were not planned. Workflows that were planned by applying a standard workflow template are automatically set to the category “Standard”. When a workflow template is used that is not approved as a standard workflow, then the option “Non-Standard” is automatically selected in this field. 
        /// </summary>
        [JsonProperty("category")]
        public WorkflowCategory? Category
        {
            get => category;
            set => category = SetValue("category", category, value);
        }

        #endregion

        #region Workflow type

        /// <summary>
        /// The Type field is used to indicate whether the workflow needs to be implemented following the procedure steps for application changes or for infrastructure changes. 
        /// </summary>
        [JsonProperty("workflow_type")]
        public string WorkflowType
        {
            get => workflowType;
            set => workflowType = SetValue("workflow_type", workflowType, value);
        }

        #endregion

        #region Completed at

        /// <summary>
        /// The Completed at field is automatically set to the date and time at which the workflow is saved with the status “Completed”.
        /// </summary>
        [JsonProperty("completed_at")]
        public DateTime? CompletedAt
        {
            get => completedAt;
            internal set => completedAt = value;
        }

        #endregion

        #region Completion reason

        /// <summary>
        /// The Completion reason field is used to select the appropriate completion reason for the workflow when it has been completed. It is automatically set to “Complete” when all tasks related to the workflow have reached the status “Completed”, “Approved” or “Canceled”. 
        /// </summary>
        [JsonProperty("completion_reason")]
        public WorkflowCompletionReason? CompletionReason
        {
            get => completionReason;
            set => completionReason = SetValue("completion_reason", completionReason, value);
        }

        #endregion

        #region Completion target at

        /// <summary>
        /// The Completion target field shows the target date and time of the last task of the workflow.
        /// </summary>
        [JsonProperty("completion_target_at")]
        public DateTime? CompletionTargetAt
        {
            get => completionTargetAt;
            internal set => completionTargetAt = value;
        }

        #endregion

        #region Impact

        /// <summary>
        /// The Impact field shows the maximum impact level that is selected in the tasks that are a part of the workflow. This indicates the maximum extent to which the service is impacted when the implementation tasks that are related to the workflow are executed. 
        /// </summary>
        [JsonProperty("impact")]
        public WorkflowImpact Impact
        {
            get => impact;
            internal set => impact = value;
        }

        #endregion

        #region Justification

        /// <summary>
        /// The Justification field is used to select the reason why the workflow was requested. 
        /// </summary>
        [JsonProperty("justification")]
        public WorkflowJustification? Justification
        {
            get => justification;
            set => justification = SetValue("justification", justification, value);
        }

        #endregion

        #region Manager

        /// <summary>
        /// The Manager field is used to select the Person who is responsible for coordinating the implementation of the workflow. If a manager is not specified for a new workflow, the API user is selected in the Manager field by default.
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
        /// The Note field is used to provide a high-level description of the result that should be accomplished by the implementation of the workflow. It is also used to add any information that could prove useful for anyone affected by the workflow, including the people whose approval is needed and the specialists who are helping to implement it.
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

        #region Planned effort

        /// <summary>
        /// The Planned effort field shows the total planned effort of the workflow. This is the sum of the planned effort (or planned duration if the planned effort is empty) of the workflow’s tasks and the planned effort of the related requests and problems.
        /// </summary>
        public TimeSpan PlannedEffort => plannedEffort;

        [JsonProperty("planned_effort")]
        internal int PlannedEffortInMinutes
        {
            get => Convert.ToInt32(plannedEffort.TotalMinutes);
            set => plannedEffort = TimeSpan.FromMinutes(value);
        }

        #endregion

        #region Project

        /// <summary>
        /// The Project field is set to the project for which the costs specified in the Amount field were incurred.
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

        #region Release

        /// <summary>
        /// The Release field is used to select the release that the workflow is a part of.
        /// </summary>
        [JsonProperty("release")]
        public Release Release
        {
            get => release;
            set => release = SetValue("release_id", release, value);
        }

        [JsonProperty("release_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ReleaseID => release?.ID;

        #endregion

        #region Resolution duration

        /// <summary>
        /// The number of minutes it took to complete this workflow, which is calculated as the difference between the created_at and completed_at values.
        /// </summary>
        public TimeSpan? ResolutionDuration => resolutionDuration;

        [JsonProperty("resolution_duration")]
        internal int? ResolutionDurationInMinutes
        {
            get => resolutionDuration != null ? Convert.ToInt32(resolutionDuration.Value.TotalMinutes) : (int?)null;
            set => resolutionDuration = value != null ? TimeSpan.FromMinutes(value.Value) : (TimeSpan?)null;
        }

        #endregion

        #region Service

        /// <summary>
        /// The Service field is used to select the Service that will directly be affected by the workflow implementation, or in case of an emergency workflow, the service that was directly affected by the workflow implementation.
        /// </summary>
        [JsonProperty("service")]
        public Service Service
        {
            get => service;
            set => service = SetValue("service_id", service, value);
        }

        [JsonProperty("service_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ServiceID => service?.ID;

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
        /// The Start at field is used to specify the date and time at which the Status field of the first tasks of the workflow will automatically be set to “Assigned”.
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
        /// The Status field is automatically set based on the status of the workflow’s tasks. 
        /// </summary>
        [JsonProperty("status")]
        public WorkflowStatus? Status
        {
            get => status;
            set => status = SetValue("status", status, value);
        }

        #endregion

        #region Subject

        /// <summary>
        /// The Subject field is used to enter a short description of the objective of the workflow.
        /// </summary>
        [JsonProperty("subject")]
        public string Subject
        {
            get => subject;
            set => subject = SetValue("subject", subject, value);
        }

        #endregion

        #region Template

        /// <summary>
        /// The Template field contains the link to the workflow template that was used to register the workflow.
        /// </summary>
        [JsonProperty("template")]
        public WorkflowTemplate Template
        {
            get => template;
            set => template = SetValue("template_id", template, value);
        }

        [JsonProperty("template_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? TemplateID => template?.ID;

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            manager?.ResetPropertySerializationCollection();
            project?.ResetPropertySerializationCollection();
            release?.ResetPropertySerializationCollection();
            service?.ResetPropertySerializationCollection();
            template?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
