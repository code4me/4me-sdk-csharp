using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/requests/">request</see> object.
    /// </summary>
    public class Request : CustomFieldsBaseItem
    {
        private bool addressed;
        private AgileBoard agileBoard;
        private AgileBoardColumn agileBoardColumn;
        private int? agileBoardColumnPosition;
        private int assignmentCount;
        private List<Attachment> attachments;
        private RequestCategory category;
        private Workflow workflow;
        private ConfigurationItem configurationItem;
        private DateTime? completedAt;
        private RequestCompletionReason? completionReason;
        private Person createdBy;
        private DateTime? downtimeEndAt;
        private DateTime? downtimeStartAt;
        private DateTime? desiredCompletionAt;
        private Feedback feedback;
        private Request groupedInto;
        private RequestGroupingType grouping;
        private RequestImpact? impact;
        private string internalNote;
        private List<AttachmentReference> internalNoteAttachments;
        private KnowledgeArticle knowledgeArticle;
        private RequestMajorIncidentStatus? majorIncidentStatus;
        private Person member;
        private bool newAssignment;
        private string nextTargetAt;
        private string note;
        private List<AttachmentReference> noteAttachments;
        private Organization organization;
        private TimeSpan? plannedEffort;
        private Problem problem;
        private ProductBacklog productBacklog;
        private int? productBacklogPosition;
        private Project project;
        private bool providerNotAccountable;
        private int reopenCount;
        private Reservation reservation;
        private TimeSpan? resolutionDuration;
        private DateTime? resolutionTargetAt;
        private DateTime? responseTargetAt;
        private Person requestedBy;
        private Person requestedFor;
        private DateTime? requesterResolutionTargetAt;
        private bool reviewed;
        private RequestSatisfaction? satisfaction;
        private ServiceInstance serviceInstance;
        private string source;
        private string sourceID;
        private RequestStatus status;
        private string subject;
        private Organization supplier;
        private string supplierRequestID;
        private string supportDomain;
        private Task task;
        private Team team;
        private RequestTemplate template;
        private TimeSpan? timeSpent;
        private EffortClass timeSpentEffortClass;
        private bool urgent;
        private DateTime? waitingUntil;

        #region Addressed

        /// <summary>
        /// When the Satisfaction field of the request is set to ‘Dissatisfied’, a person who has the Service Desk Manager role, can check the Addressed box to indicate that the requester has been conciliated.
        /// </summary>
        [JsonProperty("addressed")]
        public bool Addressed
        {
            get => addressed;
            set => addressed = SetValue("addressed", addressed, value);
        }

        #endregion

        #region Agile board

        /// <summary>
        /// The Agile board on which the request is placed.
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
        /// The column of the agile board on which the request is placed.
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
        /// The Position field is used to specify the position of the request, relative to the other items within the column of the agile board. The topmost item has position 1.
        /// </summary>
        [JsonProperty("agile_board_column_position")]
        public int? AgileBoardColumnPosition
        {
            get => agileBoardColumnPosition;
            set => agileBoardColumnPosition = SetValue("agile_board_column_position", agileBoardColumnPosition, value);
        }

        #endregion

        #region Assignment count

        /// <summary>
        /// The Assignment count field is automatically set to the number of times that the Team field of the request has been set to a Team that is registered in the Account from which the request data is retrieved.
        /// </summary>
        [JsonProperty("assignment_count")]
        public int AssignmentCount
        {
            get => assignmentCount;
            internal set => assignmentCount = value;
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
        /// The Category field is used to select the category of the request. 
        /// </summary>
        [JsonProperty("category")]
        public RequestCategory Category
        {
            get => category;
            set => category = SetValue("category", category, value);
        }

        #endregion

        #region Workflow

        /// <summary>
        /// he Workflow field is used to link the request to a workflow.
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

        #region Configuration item

        /// <summary>
        /// The Configuration item field is used to relate a CI to the request. When this field is used to update an existing request, all configuration items that are linked to this request will be replaced by the new configuration item.
        /// </summary>
        [JsonProperty("ci")]
        public ConfigurationItem ConfigurationItem
        {
            get => configurationItem;
            set => configurationItem = SetValue("ci_id", configurationItem, value);
        }

        [JsonProperty("ci_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ConfigurationItemID => configurationItem?.ID;

        #endregion

        #region Completed at

        /// <summary>
        /// The Completed at field is automatically set to the date and time at which the request is saved with the status “Completed”.
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
        /// The Completion reason field is used to select the appropriate completion reason for the request when it has been completed. 
        /// </summary>
        [JsonProperty("completion_reason")]
        public RequestCompletionReason? CompletionReason
        {
            get => completionReason;
            set => completionReason = SetValue("completion_reason", completionReason, value);
        }

        #endregion

        #region Created by

        /// <summary>
        /// The Created by field is automatically set to the person who submitted the request.
        /// </summary>
        [JsonProperty("created_by")]
        public Person CreatedBy
        {
            get => createdBy;
            set => createdBy = SetValue("created_by_id", createdBy, value);
        }

        [JsonProperty("created_by_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? CreatedByID => createdBy?.ID;

        #endregion

        #region Downtime end at

        /// <summary>
        /// The Downtime end field is used to specify the actual date and time at which the service became available again.
        /// </summary>
        [JsonProperty("downtime_end_at")]
        public DateTime? DowntimeEndAt
        {
            get => downtimeEndAt;
            set => downtimeEndAt = SetValue("downtime_end_at", downtimeEndAt, value);
        }

        #endregion

        #region Downtime start at

        /// <summary>
        /// The Downtime start field is used to specify the actual date and time at which the service outage started.
        /// </summary>
        [JsonProperty("downtime_start_at")]
        public DateTime? DowntimeStartAt
        {
            get => downtimeStartAt;
            set => downtimeStartAt = SetValue("downtime_start_at", downtimeStartAt, value);
        }

        #endregion

        #region Desired completion at

        /// <summary>
        /// The Desired completion field can be set to the date and time that has been agreed on for the completion of the request. The desired completion overwrites the automatically calculated resolution target of any affected SLA that is related to the request when the desired completion is later than the affected SLA’s resolution target. By default, the person selected in the Requested by field receives a notification based on the ‘Desired Completion Set for Request’ email template whenever the value in the Desired completion field is set, updated or removed.
        /// </summary>
        [JsonProperty("desired_completion_at")]
        public DateTime? DesiredCompletionAt
        {
            get => desiredCompletionAt;
            set => desiredCompletionAt = SetValue("desired_completion_at", desiredCompletionAt, value);
        }

        #endregion

        #region Feedback

        /// <summary>
        /// The Desired completion field can be set to the date and time that has been agreed on for the completion of the request. The desired completion overwrites the automatically calculated resolution target of any affected SLA that is related to the request when the desired completion is later than the affected SLA’s resolution target. By default, the person selected in the Requested by field receives a notification based on the ‘Desired Completion Set for Request’ email template whenever the value in the Desired completion field is set, updated or removed.
        /// </summary>
        [JsonProperty("feedback")]
        public Feedback Feedback
        {
            get => feedback;
            internal set => feedback = value;
        }

        #endregion

        #region Grouped into

        /// <summary>
        /// The Grouped into field displays the request group that is used to group the requests that have been submitted for the resolution of exactly the same incident, for the implementation of exactly the same change, for the provision of exactly the same information, etc.
        /// </summary>
        [JsonProperty("grouped_into")]
        public Request GroupedInto
        {
            get => groupedInto;
            set => groupedInto = SetValue("grouped_into_id", groupedInto, value);
        }

        [JsonProperty("grouped_into_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? GroupedIntoID => groupedInto?.ID;

        #endregion

        #region Grouping

        /// <summary>
        /// The request grouping type.
        /// </summary>
        [JsonProperty("grouping")]
        public RequestGroupingType Grouping
        {
            get => grouping;
            internal set => grouping = value;
        }

        #endregion

        #region Impact

        /// <summary>
        /// The Impact field is used to select the extent to which the service instance is impacted. 
        /// </summary>
        [JsonProperty("impact")]
        public RequestImpact? Impact
        {
            get => impact;
            set => impact = SetValue("impact", impact, value);
        }

        #endregion

        #region Internal note

        /// <summary>
        /// The Internal note field is used to provide information that is visible only for people who have the Auditor, Specialist or Account Administrator role of the account for which the internal note is intended. The X-4me-Account header can be included in an API PATCH request to add an internal note for a specific account (see Multiple Accounts).
        /// </summary>
        [JsonProperty("internal_note"), Sdk4meIgnoreInFieldSelection()]
        public string InternalNote
        {
            get => internalNote;
            set => internalNote = SetValue("internal_note", internalNote, value);
        }

        #endregion

        #region Internal note attachment

        /// <summary>
        /// Write-only. Add a reference to an uploaded internal note attachment. Use <see cref="Attachments"/> to get the existing attachments.
        /// </summary>
        /// <param name="key">The attachment key.</param>
        /// <param name="fileSize">The attachment file size.</param>
        /// <param name="inline">True if this an in-line attachment; otherwise false.</param>
        public void ReferenceInternalNoteAttachment(string key, long fileSize, bool inline = false)
        {
            if (internalNoteAttachments == null)
                internalNoteAttachments = new List<AttachmentReference>();

            internalNoteAttachments.Add(new AttachmentReference()
            {
                Key = key,
                FileSize = fileSize,
                Inline = inline
            });

            base.PropertySerializationCollection.Add("internal_note_attachments");
        }

        [JsonProperty("internal_note_attachments"), Sdk4meIgnoreInFieldSelection()]
        internal List<AttachmentReference> InternalNoteAttachments
        {
            get => internalNoteAttachments;
        }

        #endregion

        #region Knowledge article

        /// <summary>
        /// The Knowledge Article field is automatically set to the latest knowledge article that was applied to the request.
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

        #region Major incident status

        /// <summary>
        /// The Major Incident Status field is used to indicate the status in the major incident management process. 
        /// </summary>
        [JsonProperty("major_incident_status")]
        public RequestMajorIncidentStatus? MajorIncidentStatus
        {
            get => majorIncidentStatus;
            set => majorIncidentStatus = SetValue("major_incident_status", majorIncidentStatus, value);
        }

        #endregion

        #region Member

        /// <summary>
        /// The Member field is used to select the person to whom the request is to be assigned.
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
        /// The New assignment field is set to true when the request’s status is ‘Assigned’ or ‘Declined’.
        /// </summary>
        [JsonProperty("new_assignment")]
        public bool NewAssignment
        {
            get => newAssignment;
            internal set => newAssignment = value;
        }

        #endregion

        #region Next target at

        /// <summary>
        /// The Next target field value is empty when the status of the request is ‘Completed’. The next target equals the response target when a response target exists and the response target is less than the desired completion. Otherwise, the next target equals the desired completion when a desired completion exists. Otherwise, if the status is ‘Waiting for Customer’ the next target is clock_stopped when an affected SLA is linked to the request which Accountability field is set to provider or supplier. Otherwise, if the status is ‘Waiting for Customer’ the next target is best_effort. Otherwise the next target is the resolution target when a resolution target exists. In all other cases, the next target is best_effort.
        /// </summary>
        [JsonProperty("next_target_at")]
        public string NextTargetAt
        {
            get => nextTargetAt;
            internal set => nextTargetAt = value;
        }

        #endregion

        #region Note

        /// <summary>
        /// The Note field is used to provide any additional information that could prove useful for resolving the request and/or to provide a summary of the actions that have been taken since the last entry.
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

        #region Organization

        /// <summary>
        /// The Organization field is automatically set when the request is saved for the first time to the organization that the person, who is selected in the Requested for field, belongs.
        /// </summary>
        [JsonProperty("organization")]
        public Organization Organization
        {
            get => organization;
            set => organization = SetValue("organization_id", organization, value);
        }

        [JsonProperty("organization_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? OrganizationID => organization?.ID;

        #endregion

        #region Planned effort

        /// <summary>
        /// The Planned effort field is used to specify the number of minutes the member is expected to spend working on the request.
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

        #region Problem

        /// <summary>
        /// The Problem field is used to link the request to a problem.
        /// </summary>
        [JsonProperty("problem")]
        public Problem Problem
        {
            get => problem;
            set => problem = SetValue("problem_id", problem, value);
        }

        [JsonProperty("problem_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ProblemID => problem?.ID;

        #endregion

        #region Product backlog

        /// <summary>
        /// The Product backlog field is used to place the request on a product backlog. When a request is placed on a product backlog without specifying a <see cref="ProductBacklogPosition"/> it is placed at the bottom of the product backlog.
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
        /// The Product backlog position field is used to determine the relative position of the request on the product backlog (the top most item has position 1). When a request is placed on a product backlog without specifying a position it is placed at the bottom of the product backlog.
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

        #region Provider not accountable

        /// <summary>
        /// The Provider not accountable field value is used to indicate when the provider is currently not to be accountable.
        /// </summary>
        [JsonProperty("provider_not_accountable")]
        public bool ProviderNotAccountable
        {
            get => providerNotAccountable;
            set => providerNotAccountable = SetValue("provider_not_accountable", providerNotAccountable, value);
        }

        #endregion

        #region Reopen count

        /// <summary>
        /// The Reopen count field is automatically set to the number of times that the status of the request has changed from ‘Completed’ to a different value in the Account from which the request data is retrieved.
        /// </summary>
        [JsonProperty("reopen_count")]
        public int ReopenCount
        {
            get => reopenCount;
            internal set => reopenCount = value;
        }

        #endregion

        #region Reservation

        /// <summary>
        /// The Reservations field is used to link the request to a reservation.
        /// </summary>
        [JsonProperty("reservation"), Sdk4meIgnoreInFieldSelection()]
        public Reservation Reservation
        {
            get => reservation;
            set => reservation = SetValue("reservation_id", reservation, value);
        }

        [JsonProperty("reservation_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ReservationID => reservation?.ID;

        #endregion

        #region Resolution duration

        /// <summary>
        /// The number of minutes it took to complete this request, which is calculated as the difference between the created_at and completed_at values.
        /// </summary>
        public TimeSpan? ResolutionDuration
        {
            get => resolutionDuration;
        }

        [JsonProperty("resolution_duration")]
        internal int? ResolutionDurationInMinutes
        {
            get => resolutionDuration != null ? Convert.ToInt32(resolutionDuration.Value.TotalMinutes) : (int?)null;
            set => resolutionDuration = value != null ? TimeSpan.FromMinutes(value.Value) : (TimeSpan?)null;
        }

        #endregion

        #region Resolution target at

        /// <summary>
        /// The Resolution target field automatically indicates when the current assignment team needs to have completed the request. The target displayed in this field is the most stringent resolution target of the affected SLAs that are related to the request and for which the current assignment team is responsible.
        /// </summary>
        [JsonProperty("resolution_target_at")]
        public DateTime? ResolutionTargetAt
        {
            get => resolutionTargetAt;
            internal set => resolutionTargetAt = value;
        }

        #endregion

        #region Response target at

        /// <summary>
        /// The Response target field automatically indicates when the current assignment team needs to have responded to the request. The target displayed in this field is the most stringent response target of the affected SLAs that are related to the request and for which the current assignment team is responsible.
        /// </summary>
        [JsonProperty("response_target_at")]
        public DateTime? ResponseTargetAt
        {
            get => responseTargetAt;
            internal set => responseTargetAt = value;
        }

        #endregion

        #region Requested by

        /// <summary>
        /// The Requested by field is used to select the person who submitted the request.
        /// </summary>
        [JsonProperty("requested_by")]
        public Person RequestedBy
        {
            get => requestedBy;
            set => requestedBy = SetValue("requested_by_id", requestedBy, value);
        }

        [JsonProperty("requested_by_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? RequestedByID => requestedBy?.ID;

        #endregion

        #region Requested for

        /// <summary>
        /// The Requested for field is used to select the person for whom the request was submitted. The person selected in the Requested by field is automatically selected in this field, but another person can be selected if the request is submitted for another person.
        /// </summary>
        [JsonProperty("requested_for")]
        public Person RequestedFor
        {
            get => requestedFor;
            set => requestedFor = SetValue("requested_for_id", requestedFor, value);
        }

        [JsonProperty("requested_for_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? RequestedForID => requestedFor?.ID;

        #endregion

        #region Requester resolution target at

        /// <summary>
        /// The Requester resolution target field is automatically set to the most stringent resolution target of the request’s affected SLAs, which Accountability field is not set to sla_not_affected and which are linked to an SLA for which the person who is selected in the Requested for field has coverage.
        /// </summary>
        [JsonProperty("requester_resolution_target_at")]
        public DateTime? RequesterResolutionTargetAt
        {
            get => requesterResolutionTargetAt;
            internal set => requesterResolutionTargetAt = value;
        }

        #endregion

        #region Reviewed

        /// <summary>
        /// A request can be marked as reviewed by the problem manager of the service of the service instance that is linked to the request. Marking a request as reviewed excludes it from the ‘Requests for Problem Identification’ view.
        /// </summary>
        [JsonProperty("reviewed")]
        public bool Reviewed
        {
            get => reviewed;
            set => reviewed = SetValue("reviewed", reviewed, value);
        }

        #endregion

        #region Satisfaction

        /// <summary>
        /// The Satisfaction field is set when a requester uses the hyperlinks defined in the ‘Request Set to Completed’ email template to indicate whether or not he/she is satisfied with the manner in which a request has been handled. Valid values, apart from the default null, are:
        /// </summary>
        [JsonProperty("satisfaction")]
        public RequestSatisfaction? Satisfaction
        {
            get => satisfaction;
            internal set => satisfaction = value;
        }

        #endregion

        #region Service instance

        /// <summary>
        /// The Service instance field is used to select the Service Instance in which the cause of the incident resides, for which the workflow is requested, or about which information is needed.
        /// </summary>
        [JsonProperty("service_instance")]
        public ServiceInstance ServiceInstance
        {
            get => serviceInstance;
            set => serviceInstance = SetValue("service_instance_id", serviceInstance, value);
        }

        [JsonProperty("service_instance_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ServiceInstanceID => serviceInstance?.ID;

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
        /// The Status field is used to select the current status of the request. 
        /// </summary>
        [JsonProperty("status")]
        public RequestStatus Status
        {
            get => status;
            set => status = SetValue("status", status, value);
        }

        #endregion

        #region Subject

        /// <summary>
        /// The Subject field is used to enter a short description of the request.
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
        /// The Supplier field is used to select the supplier organization that has been asked to assist with the request. The supplier organization is automatically selected in this field after a service instance has been selected that is provided by an external service provider organization.
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
        /// The Supplier request ID field is used to enter the identifier under which the request has been registered at the supplier organization. If the supplier provided a link to the request, enter the entire URL in this field.
        /// </summary>
        [JsonProperty("supplier_requestID")]
        public string SupplierRequestID
        {
            get => supplierRequestID;
            set => supplierRequestID = SetValue("supplier_requestID", supplierRequestID, value);
        }

        #endregion

        #region Support domain

        /// <summary>
        /// Used to specify the support domain account ID in which the request is to be registered. This parameter needs to be specified when the current user’s Person record is registered in a directory account. The ID of a 4me account can be found in the ‘Account Overview’ section of the Settings console.
        /// </summary>
        [JsonProperty("support_domain"), Sdk4meIgnoreInFieldSelection()]
        public string SupportDomain
        {
            get => supportDomain;
            set => supportDomain = SetValue("support_domain", supportDomain, value);
        }

        #endregion

        #region Task

        /// <summary>
        /// The Task field is visible only when the request was automatically generated by a task. When visible, this field contains the task that caused the request to be generated.
        /// </summary>
        [JsonProperty("task")]
        public Task Task
        {
            get => task;
            set => task = SetValue("task_id", task, value);
        }

        [JsonProperty("task_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? TaskID => task?.ID;

        #endregion

        #region Team

        /// <summary>
        /// The Team field is used to select the Team to which the request is to be assigned. By default, the first line team of the service instance that is related to the request will be selected. If a first line team has not been specified for the service instance, the support team of the service instance will be selected instead.
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
        /// The Template field contains the link to the request template that was last applied to the request.
        /// </summary>
        [JsonProperty("template")]
        public RequestTemplate Template
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

        #region Effort class

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("time_spent_effort_class"), Sdk4meIgnoreInFieldSelection()]
        public EffortClass EffortClass
        {
            get => timeSpentEffortClass;
            set => timeSpentEffortClass = SetValue("time_spent_effort_class_id", timeSpentEffortClass, value);
        }

        [JsonProperty("time_spent_effort_class_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? EffortClassID => timeSpentEffortClass?.ID;

        #endregion

        #region Urgent

        /// <summary>
        /// When the request has been marked as urgent, the Urgent field is set to true.
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
        /// The Waiting until field is used to specify the date and time at which the status of the request is to be updated from waiting_for to assigned. This field is available only when the Status field is set to waiting_for.
        /// </summary>
        [JsonProperty("waiting_until")]
        public DateTime? WaitingUntil
        {
            get => waitingUntil;
            set => waitingUntil = SetValue("waiting_until", waitingUntil, value);
        }

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            configurationItem?.ResetPropertySerializationCollection();
            createdBy?.ResetPropertySerializationCollection();
            groupedInto?.ResetPropertySerializationCollection();
            knowledgeArticle?.ResetPropertySerializationCollection();
            member?.ResetPropertySerializationCollection();
            organization?.ResetPropertySerializationCollection();
            problem?.ResetPropertySerializationCollection();
            productBacklog?.ResetPropertySerializationCollection();
            project?.ResetPropertySerializationCollection();
            requestedBy?.ResetPropertySerializationCollection();
            requestedFor?.ResetPropertySerializationCollection();
            serviceInstance?.ResetPropertySerializationCollection();
            supplier?.ResetPropertySerializationCollection();
            task?.ResetPropertySerializationCollection();
            team?.ResetPropertySerializationCollection();
            template?.ResetPropertySerializationCollection();
            timeSpentEffortClass?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
