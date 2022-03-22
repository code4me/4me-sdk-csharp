using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/request_templates/">request template</see> object.
    /// </summary>
    public class RequestTemplate : BaseItem
    {
        private bool assetSelection;
        private bool assignAfterWorkflowCompletion;
        private bool assignToSelf;
        private List<Attachment> attachments;
        private RequestCategory? category;
        private Person workflowManager;
        private WorkflowTemplate workflowTemplate;
        private ConfigurationItem configurationItem;
        private RequestCompletionReason? completionReason;
        private bool copySubjectToRequests;
        private TimeSpan? desiredCompletion;
        private bool disabled;
        private EffortClass effortClass;
        private bool endUsers;
        private RequestImpact? impact;
        private string instructions;
        private List<AttachmentReference> instructionsAttachments;
        private string keywords;
        private string localizedKeywords;
        private string localizedNote;
        private string localizedRegistrationHints;
        private string localizedSubject;
        private Person member;
        private string note;
        private List<AttachmentReference> noteAttachments;
        private TimeSpan? plannedEffort;
        private string registrationHints;
        private List<AttachmentReference> registrationHintsAttachments;
        private Service service;
        private string source;
        private string sourceID;
        private bool specialists;
        private RequestStatus? status;
        private string subject;
        private Organization supplier;
        private Calendar supportHours;
        private Team team;
        private string timeZone;
        private int timesApplied;
        private UIExtension uiExtension;
        private bool urgent;

        #region Asset selection

        /// <summary>
        /// The Asset Selection box is checked when, after selecting the request template in Self Service, the user needs to be able to select a configuration item in the Asset field..
        /// </summary>
        [JsonProperty("asset_selection")]
        public bool AssetSelection
        {
            get => assetSelection;
            set => assetSelection = SetValue("asset_selection", assetSelection, value);
        }

        #endregion

        #region Assign after workflow completion

        /// <summary>
        /// Whether the request will be assigned to the provided team after the workflow is completed. When false the request will be completed after the workflow completes.
        /// </summary>
        [JsonProperty("assign_after_workflow_completion")]
        public bool AssignAfterWorkflowCompletion
        {
            get => assignAfterWorkflowCompletion;
            set => assignAfterWorkflowCompletion = SetValue("assign_after_workflow_completion", assignAfterWorkflowCompletion, value);
        }

        #endregion

        #region Assign to self

        /// <summary>
        /// The Assign to self box is checked to ensure that the person who is registering a new request based on the template is selected in its Member field.
        /// </summary>
        [JsonProperty("assign_to_self")]
        public bool AssignToSelf
        {
            get => assignToSelf;
            set => assignToSelf = SetValue("assign_to_self", assignToSelf, value);
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
        /// The Category field is used to select the category that needs to be selected in the Category field of a new request when it is being created based on the template. 
        /// </summary>
        [JsonProperty("category")]
        public RequestCategory? Category
        {
            get => category;
            set => category = SetValue("category", category, value);
        }

        #endregion

        #region Workflow manager

        /// <summary>
        /// The Workflow manager field is used to relate a Workflow Manager to the request template. Required when a Workflow Template is defined, and the Service does not define a Workflow Manager.
        /// </summary>
        [JsonProperty("workflow_manager")]
        public Person WorkflowManager
        {
            get => workflowManager;
            set => workflowManager = SetValue("workflow_manager_id", workflowManager, value);
        }

        [JsonProperty("workflow_manager_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? WorkflowManagerID => workflowManager?.ID;

        #endregion

        #region Workflow template

        /// <summary>
        /// The Workflow template field is used to relate a Workflow Template to the request template. Required when the Status is set to Workflow Pending.
        /// </summary>
        [JsonProperty("workflow_template")]
        public WorkflowTemplate WorkflowTemplate
        {
            get => workflowTemplate;
            set => workflowTemplate = SetValue("workflow_template_id", workflowTemplate, value);
        }

        [JsonProperty("workflow_template_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? WorkflowTemplateID => workflowTemplate?.ID;

        #endregion

        #region Configuration item

        /// <summary>
        /// The Configuration item field is used to select the CI that needs to be copied to the Configuration item field of a new request when it is being created based on the template.
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

        #region Completion reason

        /// <summary>
        /// The Completion reason field is used to select the completion reason that needs to be selected in the Completion reason field of a new request when it is being created based on the template. 
        /// </summary>
        [JsonProperty("completion_reason")]
        public RequestCompletionReason? CompletionReason
        {
            get => completionReason;
            set => completionReason = SetValue("completion_reason", completionReason, value);
        }

        #endregion

        #region Copy subject to requests

        /// <summary>
        /// The Copy subject to requests box is checked when the subject of the request template needs to become the subject of a request when the template is applied, provided that the Subject field of this request is empty.
        /// </summary>
        [JsonProperty("copy_subject_to_requests")]
        public bool CopySubjectToRequests
        {
            get => copySubjectToRequests;
            set => copySubjectToRequests = SetValue("copy_subject_to_requests", copySubjectToRequests, value);
        }

        #endregion

        #region Desired completion

        /// <summary>
        /// The Desired completion field is used to enter the number of hours and minutes within which requests that are based on the request template are to be resolved.
        /// </summary>
        public TimeSpan? DesiredCompletion
        {
            get => desiredCompletion;
            set => desiredCompletion = SetValue("desired_completion", desiredCompletion, value);
        }

        [JsonProperty("desired_completion")]
        internal int? DesiredCompletionInMinutes
        {
            get => desiredCompletion != null ? Convert.ToInt32(desiredCompletion.Value.TotalMinutes) : (int?)null;
            set => desiredCompletion = value != null ? TimeSpan.FromMinutes(value.Value) : (TimeSpan?)null;
        }

        #endregion

        #region Disabled

        /// <summary>
        /// The Disabled box is checked when the request template may not be used to help register new requests.
        /// </summary>
        [JsonProperty("disabled")]
        public bool Disabled
        {
            get => disabled;
            set => disabled = SetValue("disabled", disabled, value);
        }

        #endregion

        #region Effort class

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("effort_class")]
        public EffortClass EffortClass
        {
            get => effortClass;
            set => effortClass = SetValue("effort_class_id", effortClass, value);
        }

        [JsonProperty("effort_class_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? EffortClassID => effortClass?.ID;

        #endregion

        #region End users

        /// <summary>
        /// The End users box is checked when the request template is shown to end users in Self Service.
        /// </summary>
        [JsonProperty("end_users")]
        public bool EndUsers
        {
            get => endUsers;
            set => endUsers = SetValue("end_users", endUsers, value);
        }

        #endregion

        #region Impact

        /// <summary>
        /// The Impact field is used to select the impact level that needs to be selected in the Impact field of a new request when it is being created based on the template. 
        /// </summary>
        [JsonProperty("impact")]
        public RequestImpact? Impact
        {
            get => impact;
            set => impact = SetValue("impact", impact, value);
        }

        #endregion

        #region Instructions

        /// <summary>
        /// The Instructions field is used to enter instructions for the support staff who will work on requests that are based on the template.
        /// </summary>
        [JsonProperty("instructions")]
        public string Instructions
        {
            get => instructions;
            set => instructions = SetValue("instructions", instructions, value);
        }

        #endregion

        #region Instructions attachments

        /// <summary>
        /// Writeonly attachments. Add an inline attachments to be used in the Instructions field.
        /// </summary>
        /// <param name="key">The attachment key.</param>
        /// <param name="fileSize">The attachment file size.</param>
        /// <param name="inline">True if this an in-line attachment; otherwise false.</param>
        public void ReferenceInstructionsAttachment(string key, long fileSize)
        {
            if (instructionsAttachments == null)
                instructionsAttachments = new List<AttachmentReference>();

            instructionsAttachments.Add(new AttachmentReference()
            {
                Key = key,
                FileSize = fileSize,
                Inline = true
            });

            base.PropertySerializationCollection.Add("instructions_attachments");
        }

        [JsonProperty("instructions_attachments"), Sdk4meIgnoreInFieldSelection()]
        internal List<AttachmentReference> InstructionsAttachments
        {
            get => instructionsAttachments;
        }

        #endregion

        #region Keywords

        /// <summary>
        /// The Keywords field contains a comma-separated list of words that can be used to find the request template using search.
        /// </summary>
        [JsonProperty("keywords")]
        public string Keywords
        {
            get => keywords;
            set => keywords = SetValue("keywords", keywords, value);
        }

        #endregion

        #region Localized keywords

        /// <summary>
        /// Translated Keywords in the current language, defaults to keywords in case no translation is provided.
        /// </summary>
        [JsonProperty("localized_keywords"), Sdk4meIgnoreInFieldSelection()]
        public string LocalizedKeywords
        {
            get => localizedKeywords;
            internal set => localizedKeywords = value;
        }

        #endregion

        #region Localized note

        /// <summary>
        /// Translated Note in the current language, defaults to note in case no translation is provided.
        /// </summary>
        [JsonProperty("localized_note"), Sdk4meIgnoreInFieldSelection()]
        public string LocalizedNote
        {
            get => localizedNote;
            internal set => localizedNote = value;
        }

        #endregion

        #region Localized registration hints

        /// <summary>
        /// Translated Registration hints in the current language, defaults to registration_hints in case no translation is provided.
        /// </summary>
        [JsonProperty("localized_registration_hints"), Sdk4meIgnoreInFieldSelection()]
        public string LocalizedRegistrationHints
        {
            get => localizedRegistrationHints;
            internal set => localizedRegistrationHints = value;
        }

        #endregion

        #region Localized subject

        /// <summary>
        /// Translated Subject in the current language, defaults to subject in case no translation is provided.
        /// </summary>
        [JsonProperty("localized_subject"), Sdk4meIgnoreInFieldSelection()]
        public string LocalizedSubject
        {
            get => localizedSubject;
            internal set => localizedSubject = value;
        }

        #endregion

        #region Member

        /// <summary>
        /// The Member field is used to select the Person who should be selected in the Member field of a new request when it is being created based on the template.
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

        #region Note

        /// <summary>
        /// The Note field is used to enter the information that needs to be copied to the Note field of a new request when it is being created based on the template.
        /// </summary>
        [JsonProperty("note")]
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
        public void ReferenceNoteAttachment(string key, long fileSize)
        {
            if (noteAttachments == null)
                noteAttachments = new List<AttachmentReference>();

            noteAttachments.Add(new AttachmentReference()
            {
                Key = key,
                FileSize = fileSize,
                Inline = true
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
        /// The Planned effort field is used to specify the number of minutes the member is expected to spend working on a request that was created based on the template.
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

        #region Registration hints

        /// <summary>
        /// The Registration hints field is used to enter the information that needs to be displayed after the template has been applied to a new or existing request. This field typically contains step-by-step instructions about how to complete the registration of a request that is based on the template.
        /// </summary>
        [JsonProperty("registration_hints")]
        public string RegistrationHints
        {
            get => registrationHints;
            set => registrationHints = SetValue("registration_hints", registrationHints, value);
        }

        #endregion

        #region Note attachment

        /// <summary>
        /// Write-only. Add a reference to an uploaded note attachment. Use <see cref="Attachments"/> to get the existing attachments.
        /// </summary>
        /// <param name="key">The attachment key.</param>
        /// <param name="fileSize">The attachment file size.</param>
        public void ReferenceRegistrationHintAttachment(string key, long fileSize)
        {
            if (registrationHintsAttachments == null)
                registrationHintsAttachments = new List<AttachmentReference>();

            registrationHintsAttachments.Add(new AttachmentReference()
            {
                Key = key,
                FileSize = fileSize,
                Inline = true
            });

            base.PropertySerializationCollection.Add("registration_hints_attachments");
        }

        [JsonProperty("registration_hints_attachments"), Sdk4meIgnoreInFieldSelection()]
        internal List<AttachmentReference> RegistrationHintAttachments
        {
            get => registrationHintsAttachments;
        }

        #endregion

        #region Service

        /// <summary>
        /// The Service field is used to select the Service for which the request template is made available.
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

        #region Specialists

        /// <summary>
        /// The Specialists box is checked when the request template is shown to Specialists.
        /// </summary>
        [JsonProperty("specialists")]
        public bool Specialists
        {
            get => specialists;
            set => specialists = SetValue("specialists", specialists, value);
        }

        #endregion

        #region Status

        /// <summary>
        /// The Status field is used to select the status value that needs to be selected in the Status field of a new request when it is being created based on the template. 
        /// </summary>
        [JsonProperty("status")]
        public RequestStatus? Status
        {
            get => status;
            set => status = SetValue("status", status, value);
        }

        #endregion

        #region Subject

        /// <summary>
        /// The Subject field is used to enter a short description that needs to be copied to the Subject field of a new Request when it is being created based on the template.
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
        /// The Supplier field is used to select the supplier organization that should be selected in the Supplier field of a new request when it is being created based on the template.
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

        #region Support hours

        /// <summary>
        /// The Support hours field is used to select a calendar that is to be used to calculate the desired completion for requests that are based on the request template.
        /// </summary>
        [JsonProperty("support_hours")]
        public Calendar SupportHours
        {
            get => supportHours;
            set => supportHours = SetValue("support_hours_id", supportHours, value);
        }

        [JsonProperty("support_hours_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? SupportHoursID => supportHours?.ID;

        #endregion

        #region Team

        /// <summary>
        /// The Team field is used to select the Team that should be selected in the Team field of a new request when it is being created based on the template. Required when assign_after_workflow_completion is set to true.
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

        #region Time zone

        /// <summary>
        /// The Time zone field is used to select the time zone that applies to the selected support hours.
        /// </summary>
        [JsonProperty("time_zone")]
        public string TimeZone
        {
            get => timeZone;
            set => timeZone = SetValue("time_zone", timeZone, value);
        }

        #endregion

        #region Times applied

        /// <summary>
        /// The number of times the request template is used to create a Request.
        /// </summary>
        [JsonProperty("times_applied")]
        public int TimesApplied
        {
            get => timesApplied;
            internal set => timesApplied = value;
        }

        #endregion

        #region UI Extension

        /// <summary>
        /// The UI extension field indicates the UI extension that is applied to the person.
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
        /// The Mark as urgent box is checked when a new request that is created based on the template is to be marked as urgent.
        /// </summary>
        [JsonProperty("urgent")]
        public bool Urgent
        {
            get => urgent;
            set => urgent = SetValue("urgent", urgent, value);
        }

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            effortClass?.ResetPropertySerializationCollection();
            workflowManager?.ResetPropertySerializationCollection();
            workflowTemplate?.ResetPropertySerializationCollection();
            configurationItem?.ResetPropertySerializationCollection();
            member?.ResetPropertySerializationCollection();
            service?.ResetPropertySerializationCollection();
            supplier?.ResetPropertySerializationCollection();
            supportHours?.ResetPropertySerializationCollection();
            team?.ResetPropertySerializationCollection();
            uiExtension?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
