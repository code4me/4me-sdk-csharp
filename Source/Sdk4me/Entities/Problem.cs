using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/problems/">problem</see> object.
    /// </summary>
    public class Problem : CustomFieldsBaseItem
    {
        private AgileBoard agileBoard;
        private AgileBoardColumn agileBoardColumn;
        private int? agileBoardColumnPosition;
        private DateTime? analysisTargetAt;
        private List<Attachment> attachments;
        private ProblemCategory? category;
        private Workflow workflow;
        private ProblemImpact impact;
        private KnowledgeArticle knowledgeArticle;
        private bool knownError;
        private Person manager;
        private Person member;
        private bool newAssignment;
        private string note;
        private List<AttachmentReference> noteAttachments;
        private TimeSpan? plannedEffort;
        private ProductBacklog productBacklog;
        private int? productBacklogPosition;
        private Project project;
        private TimeSpan? resolutionDuration;
        private Service service;
        private DateTime? solvedAt;
        private string source;
        private string sourceID;
        private ProblemStatus? status;
        private string subject;
        private Organization supplier;
        private string supplierRequestID;
        private Team team;
        private TimeSpan? timeSpent;
        private EffortClass timeSpentEffortClass;
        private UIExtension uiExtension;
        private bool urgent;
        private DateTime? waitingUntil;
        private string workaround;
        private List<AttachmentReference> workaroundAttachments;

        #region Agile board

        /// <summary>
        /// The Agile board on which the problem is placed.
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
        /// The column of the agile board on which the problem is placed.
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
        /// The Position field is used to specify the position of the problem, relative to the other items within the column of the agile board. The topmost item has position 1.
        /// </summary>
        [JsonProperty("agile_board_column_position")]
        public int? AgileBoardColumnPosition
        {
            get => agileBoardColumnPosition;
            set => agileBoardColumnPosition = SetValue("agile_board_column_position", agileBoardColumnPosition, value);
        }

        #endregion

        #region Analysis target at

        /// <summary>
        /// The Analysis target field is used to specify when the current assignee needs to have completed the root cause analysis of the problem.
        /// </summary>
        [JsonProperty("analysis_target_at")]
        public DateTime? AnalysisTargetAt
        {
            get => analysisTargetAt;
            set => analysisTargetAt = SetValue("analysis_target_at", analysisTargetAt, value);
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
        /// The Category field is used to select the category of the problem. 
        /// </summary>
        [JsonProperty("category")]
        public ProblemCategory? Category
        {
            get => category;
            set => category = SetValue("category", category, value);
        }

        #endregion

        #region Workflow

        /// <summary>
        /// The Workflow field is used to relate the problem to the Workflow that will implement the proposed permanent solution for the problem.
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

        #region Impact

        /// <summary>
        /// The Impact field is used to select the extent to which the service is impacted when an incident occurs that is caused by the problem. 
        /// </summary>
        [JsonProperty("impact")]
        public ProblemImpact Impact
        {
            get => impact;
            set => impact = SetValue("impact", impact, value);
        }

        #endregion

        #region Knowledge article

        /// <summary>
        /// The Knowledge article field is used to select the knowledge article which instructions should be followed to resolve incidents caused by this problem until a structural solution has been implemented.
        /// </summary>
        [JsonProperty("knowledge_article")]
        public KnowledgeArticle KnowledgeArticle
        {
            get => knowledgeArticle;
            set => knowledgeArticle = SetValue("knowledge_article_id", knowledgeArticle, value);
        }

        [JsonProperty("knowledge_article_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? KnowledgeArticleID => knowledgeArticle?.ID;

        #endregion

        #region Known error

        /// <summary>
        /// The Known error box is checked when the underlying cause of the problem has been found and a temporary workaround has been proposed.
        /// </summary>
        [JsonProperty("known_error")]
        public bool KnownError
        {
            get => knownError;
            set => knownError = SetValue("known_error", knownError, value);
        }

        #endregion

        #region Manager

        /// <summary>
        /// The Manager field is used to select the Person who is responsible for coordinating the problem through root cause analysis, the proposal of a structural solution and ultimately its closure.
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
        /// The Member field is used to select the person to whom the problem is to be assigned.
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
        /// default: true
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
        /// The Note field is used to provide a detailed description of the symptoms that are caused by the problem.
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
        /// The Planned effort field is used to specify the number of minutes the member is expected to spend working on the problem.
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

        #region Product backlog

        /// <summary>
        /// The Product backlog field is used to place the problem on a product backlog. When a problem is placed on a product backlog without specifying a product_backlog_position it is placed at the bottom of the product backlog.
        /// </summary>
        [JsonProperty("product_backlog")]
        public ProductBacklog ProductBacklog
        {
            get => productBacklog;
            set => productBacklog = SetValue("product_backlog_id", productBacklog, value);
        }

        [JsonProperty("product_backlog_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ProductBacklogID => productBacklog?.ID;

        #endregion

        #region Product backlog position

        /// <summary>
        /// The Product backlog position field is used to determine the relative position of the problem on the product backlog (the top most item has position 1). When a problem is placed on a product backlog without specifying a product_backlog_position it is placed at the bottom of the product backlog.
        /// </summary>
        [JsonProperty("product_backlog_position")]
        public int? ProductBacklogPosition
        {
            get => productBacklogPosition;
            set => productBacklogPosition = SetValue("product_backlog_position", productBacklogPosition, value);
        }

        #endregion

        #region Project

        /// <summary>
        /// The Project field is used to link the problem to a project.
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

        #region Resolution duration

        /// <summary>
        /// The number of minutes it took to complete this problem, which is calculated as the difference between the created_at and solved_at values.
        /// </summary>
        public TimeSpan? ResolutionDuration
        {
            get => resolutionDuration;
            set => resolutionDuration = SetValue("resolution_duration", resolutionDuration, value);
        }

        [JsonProperty("resolution_duration"), Sdk4meIgnoreInFieldSelection()]
        internal int? ResolutionDurationInMinutes
        {
            get => resolutionDuration != null ? Convert.ToInt32(resolutionDuration.Value.TotalMinutes) : (int?)null;
            set => resolutionDuration = value != null ? TimeSpan.FromMinutes(value.Value) : (TimeSpan?)null;
        }

        #endregion

        #region Service

        /// <summary>
        /// The Service field is used to select the service in which instance(s) the problem resides.
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

        #region Solved at

        /// <summary>
        /// The Solved at field is automatically set to the date and time at which the problem is saved with the status “Solved”.
        /// </summary>
        [JsonProperty("solved_at")]
        public DateTime? SolvedAt
        {
            get => solvedAt;
            internal set => solvedAt = value;
        }

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

        #region Status

        /// <summary>
        /// The Status field is used to select the current status of the problem. 
        /// </summary>
        [JsonProperty("status")]
        public ProblemStatus? Status
        {
            get => status;
            set => status = SetValue("status", status, value);
        }

        #endregion

        #region Subject

        /// <summary>
        /// The Subject field is used to enter a short description of the symptoms that the problem causes.
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
        /// The Supplier field is used to select the supplier organization that has been asked for a solution to the problem.
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
        /// Optional string (max 255)
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
        /// The Team field is used to select the Team to which the problem is to be assigned. After a service has been selected in the Service field, the support team of the service is automatically selected in this field.
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

        #region Time spent

        /// <summary>
        /// The Time spent field is used to enter the time that you have spent working on the problem since you started to work on it or, if you already entered some time for this problem, since you last added your time spent in it.
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

        #region UI extension

        /// <summary>
        /// The UI extension field indicates the UI extension that is applied to the problem.
        /// </summary>
        [JsonProperty("ui_extension")]
        public UIExtension UIExtension
        {
            get => uiExtension;
            set => uiExtension = SetValue("ui_extension_id", uiExtension, value);
        }

        [JsonProperty("ui_extension_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? UIExtensionID => uiExtension?.ID;

        #endregion

        #region Urgent

        /// <summary>
        /// When the problem has been marked as urgent, the Urgent field is set to true.
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
        /// The Waiting until field is used to specify the date and time at which the status of the problem is to be updated from waiting_for to assigned. This field is available only when the Status field is set to waiting_for.
        /// </summary>
        [JsonProperty("waiting_until")]
        public DateTime? WaitingUntil
        {
            get => waitingUntil;
            set => waitingUntil = SetValue("waiting_until", waitingUntil, value);
        }

        #endregion

        #region Workaround

        /// <summary>
        /// The Workaround field is used to describe the temporary workaround that should be applied to resolve incidents caused by this problem until a structural solution has been implemented.
        /// </summary>
        [JsonProperty("workaround")]
        public string Workaround
        {
            get => workaround;
            set => workaround = SetValue("workaround", workaround, value);
        }

        #endregion

        #region Workaround attachments

        /// <summary>
        /// Write-only. Add a reference to an uploaded attachment. Use <see cref="Attachments"/> to get the existing attachments.
        /// </summary>
        /// <param name="key">The attachment key.</param>
        /// <param name="fileSize">The attachment file size.</param>
        public void ReferenceWorkaroundAttachment(string key, long fileSize)
        {
            if (workaroundAttachments == null)
                workaroundAttachments = new List<AttachmentReference>();

            workaroundAttachments.Add(new AttachmentReference()
            {
                Key = key,
                FileSize = fileSize,
                Inline = true
            });

            base.PropertySerializationCollection.Add("workaround_attachments");
        }

        [JsonProperty("workaround_attachments"), Sdk4meIgnoreInFieldSelection()]
        internal List<AttachmentReference> WorkaroundAttachments
        {
            get => workaroundAttachments;
        }

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            workflow?.ResetPropertySerializationCollection();
            knowledgeArticle?.ResetPropertySerializationCollection();
            manager?.ResetPropertySerializationCollection();
            member?.ResetPropertySerializationCollection();
            productBacklog?.ResetPropertySerializationCollection();
            project?.ResetPropertySerializationCollection();
            service?.ResetPropertySerializationCollection();
            supplier?.ResetPropertySerializationCollection();
            team?.ResetPropertySerializationCollection();
            timeSpentEffortClass?.ResetPropertySerializationCollection();
            uiExtension?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
