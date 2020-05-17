using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    public class Request : BaseItem
    {
        private bool addressed;
        private int? assignmentCount;
        private List<Attachment> attachments;
        private RequestCategoryType? category;
        private Change change;
        private ConfigurationItem cI;
        private DateTime? completedAt;
        private RequestCompletionReasonType? completionReason;
        private Person createdBy;
        private DateTime? downtimeEndAt;
        private DateTime? downtimeStartAt;
        private DateTime? desiredCompletionAt;
        private Feedback feedback;
        private Request groupedInto;
        private RequestGroupingType? grouping;
        private RequestImpactType? impact;
        private string internalNote;
        private KnowledgeArticle knowledgeArticle;
        private MajorIncidentStatusType? majorIncidentStatus;
        private Person member;
        private bool newAssignment;
        private string nextTargetAt;
        private string note;
        private Organization organization;
        private Problem problem;
        private Project project;
        private int? reopenCount;
        private DateTime? resolutionTargetAt;
        private DateTime? responseTargetAt;
        private Person requestedBy;
        private Person requestedFor;
        private DateTime? requesterResolutionTargetAt;
        private bool reviewed;
        private RequestSatisfactionType? satisfaction;
        private ServiceInstance serviceInstance;
        private string source;
        private string sourceID;
        private RequestStatusType? status;
        private string subject;
        private Organization supplier;
        private string supplierRequestID;
        private string supportDomain;
        private Team team;
        private RequestTemplate template;
        private bool urgent;
        private DateTime? waitingUntil;
        private CustomFieldCollection customFields;

        #region addressed

        [JsonProperty("addressed")]
        public bool Addressed
        {
            get => addressed;
            set
            {
                if (addressed != value)
                    AddIncludedDuringSerialization("addressed");
                addressed = value;
            }
        }

        #endregion

        #region assignment_count

        [JsonProperty("assignment_count")]
        public int? AssignmentCount
        {
            get => assignmentCount;
            internal set => assignmentCount = value;
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

        #region completed_at

        [JsonProperty("completed_at")]
        public DateTime? CompletedAt
        {
            get => completedAt;
            set
            {
                if (completedAt != value)
                    AddIncludedDuringSerialization("completed_at");
                completedAt = value;
            }
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

        #region created_by

        [JsonProperty("created_by")]
        public Person CreatedBy
        {
            get => createdBy;
            set
            {
                if (createdBy?.ID != value?.ID)
                    AddIncludedDuringSerialization("created_by_id");
                createdBy = value;
            }
        }

        [JsonProperty(PropertyName = "created_by_id"), Sdk4meIgnoreInFieldSelection()]
        private long? CreatedByID
        {
            get => (createdBy != null ? createdBy.ID : (long?)null);
        }

        #endregion

        #region downtime_end_at

        [JsonProperty("downtime_end_at")]
        public DateTime? DowntimeEndAt
        {
            get => downtimeEndAt;
            set
            {
                if (downtimeEndAt != value)
                    AddIncludedDuringSerialization("downtime_end_at");
                downtimeEndAt = value;
            }
        }

        #endregion

        #region downtime_start_at

        [JsonProperty("downtime_start_at")]
        public DateTime? DowntimeStartAt
        {
            get => downtimeStartAt;
            set
            {
                if (downtimeStartAt != value)
                    AddIncludedDuringSerialization("downtime_start_at");
                downtimeStartAt = value;
            }
        }

        #endregion

        #region desired_completion_at

        [JsonProperty("desired_completion_at")]
        public DateTime? DesiredCompletionAt
        {
            get => desiredCompletionAt;
            set
            {
                if (desiredCompletionAt != value)
                    AddIncludedDuringSerialization("desired_completion_at");
                desiredCompletionAt = value;
            }
        }

        #endregion

        #region feedback

        [JsonProperty("feedback")]
        public Feedback Feedback
        {
            get => feedback;
            internal set => feedback = value;
        }

        #endregion

        #region grouped_into

        [JsonProperty("grouped_into")]
        public Request GroupedInto
        {
            get => groupedInto;
            set
            {
                if (groupedInto?.ID != value?.ID)
                    AddIncludedDuringSerialization("grouped_into_id");
                groupedInto = value;
            }
        }

        [JsonProperty(PropertyName = "grouped_into_id"), Sdk4meIgnoreInFieldSelection()]
        private long? GroupedIntoID
        {
            get => (groupedInto != null ? groupedInto.ID : (long?)null);
        }

        #endregion

        #region grouping

        [JsonProperty("grouping")]
        public RequestGroupingType? Grouping
        {
            get => grouping;
            internal set => grouping = value;
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

        #region internal_note

        [JsonProperty("internal_note"), Sdk4meIgnoreInFieldSelection()]
        public string InternalNote
        {
            get => internalNote;
            set
            {
                if (internalNote != value)
                    AddIncludedDuringSerialization("internal_note");
                internalNote = value;
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

        #region major_incident_status

        [JsonProperty("major_incident_status")]
        public MajorIncidentStatusType? MajorIncidentStatus
        {
            get => majorIncidentStatus;
            set
            {
                if (majorIncidentStatus != value)
                    AddIncludedDuringSerialization("major_incident_status");
                majorIncidentStatus = value;
            }
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

        #region next_target_at

        [JsonProperty("next_target_at")]
        public string NextTargetAt
        {
            get => nextTargetAt;
            internal set => nextTargetAt = value;
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

        #region organization

        [JsonProperty("organization")]
        public Organization Organization
        {
            get => organization;
            set
            {
                if (organization?.ID != value?.ID)
                    AddIncludedDuringSerialization("organization_id");
                organization = value;
            }
        }

        [JsonProperty(PropertyName = "organization_id"), Sdk4meIgnoreInFieldSelection()]
        private long? OrganizationID
        {
            get => (organization != null ? organization.ID : (long?)null);
        }

        #endregion

        #region problem

        [JsonProperty("problem")]
        public Problem Problem
        {
            get => problem;
            set
            {
                if (problem?.ID != value?.ID)
                    AddIncludedDuringSerialization("problem_id");
                problem = value;
            }
        }

        [JsonProperty(PropertyName = "problem_id"), Sdk4meIgnoreInFieldSelection()]
        private long? ProblemID
        {
            get => (problem != null ? problem.ID : (long?)null);
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

        #region reopen_count

        [JsonProperty("reopen_count")]
        public int? ReopenCount
        {
            get => reopenCount;
            internal set => reopenCount = value;
        }

        #endregion

        #region resolution_target_at

        [JsonProperty("resolution_target_at")]
        public DateTime? ResolutionTargetAt
        {
            get => resolutionTargetAt;
            internal set => resolutionTargetAt = value;
        }

        #endregion

        #region response_target_at

        [JsonProperty("response_target_at")]
        public DateTime? ResponseTargetAt
        {
            get => responseTargetAt;
            internal set => responseTargetAt = value;
        }

        #endregion

        #region requested_by

        [JsonProperty("requested_by")]
        public Person RequestedBy
        {
            get => requestedBy;
            set
            {
                if (requestedBy?.ID != value?.ID)
                    AddIncludedDuringSerialization("requested_by_id");
                requestedBy = value;
            }
        }

        [JsonProperty(PropertyName = "requested_by_id"), Sdk4meIgnoreInFieldSelection()]
        private long? RequestedByID
        {
            get => (requestedBy != null ? requestedBy.ID : (long?)null);
        }

        #endregion

        #region requested_for

        [JsonProperty("requested_for")]
        public Person RequestedFor
        {
            get => requestedFor;
            set
            {
                if (requestedFor?.ID != value?.ID)
                    AddIncludedDuringSerialization("requested_for_id");
                requestedFor = value;
            }
        }

        [JsonProperty(PropertyName = "requested_for_id"), Sdk4meIgnoreInFieldSelection()]
        private long? RequestedForID
        {
            get => (requestedFor != null ? requestedFor.ID : (long?)null);
        }

        #endregion

        #region requester_resolution_target_at

        [JsonProperty("requester_resolution_target_at")]
        public DateTime? RequesterResolutionTargetAt
        {
            get => requesterResolutionTargetAt;
            internal set => requesterResolutionTargetAt = value;
        }

        #endregion

        #region reviewed

        [JsonProperty("reviewed")]
        public bool Reviewed
        {
            get => reviewed;
            set
            {
                if (reviewed != value)
                    AddIncludedDuringSerialization("reviewed");
                reviewed = value;
            }
        }

        #endregion

        #region satisfaction

        [JsonProperty("satisfaction")]
        public RequestSatisfactionType? Satisfaction
        {
            get => satisfaction;
            internal set => satisfaction = value;
        }

        #endregion

        #region service_instance

        [JsonProperty("service_instance")]
        public ServiceInstance ServiceInstance
        {
            get => serviceInstance;
            set
            {
                if (serviceInstance?.ID != value?.ID)
                    AddIncludedDuringSerialization("service_instance_id");
                serviceInstance = value;
            }
        }

        [JsonProperty(PropertyName = "service_instance_id"), Sdk4meIgnoreInFieldSelection()]
        private long? ServiceInstanceID
        {
            get => (serviceInstance != null ? serviceInstance.ID : (long?)null);
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

        #region support_domain

        [JsonProperty("support_domain"), Sdk4meIgnoreInFieldSelection()]
        public string SupportDomain
        {
            get => supportDomain;
            set
            {
                if (supportDomain != value)
                    AddIncludedDuringSerialization("support_domain");
                supportDomain = value;
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
        public RequestTemplate Template
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
            cI?.ResetIncludedDuringSerialization();
            createdBy?.ResetIncludedDuringSerialization();
            groupedInto?.ResetIncludedDuringSerialization();
            knowledgeArticle?.ResetIncludedDuringSerialization();
            member?.ResetIncludedDuringSerialization();
            organization?.ResetIncludedDuringSerialization();
            problem?.ResetIncludedDuringSerialization();
            project?.ResetIncludedDuringSerialization();
            requestedBy?.ResetIncludedDuringSerialization();
            requestedFor?.ResetIncludedDuringSerialization();
            serviceInstance?.ResetIncludedDuringSerialization();
            supplier?.ResetIncludedDuringSerialization();
            team?.ResetIncludedDuringSerialization();
            template?.ResetIncludedDuringSerialization();
            base.ResetIncludedDuringSerialization();
        }
    }
}
