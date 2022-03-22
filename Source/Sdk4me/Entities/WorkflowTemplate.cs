using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/workflow_templates/">workflow template</see> object.
    /// </summary>
    public class WorkflowTemplate : BaseItem
    {
        private bool assignRelationsToWorkflowManager;
        private List<Attachment> attachments;
        private WorkflowCategory? category;
        private Person workflowManager;
        private string workflowType;
        private bool disabled;
        private WorkflowImpact? impact;
        private string instructions;
        private List<AttachmentReference> instructionsAttachments;
        private WorkflowJustification? justification;
        private string note;
        private List<AttachmentReference> noteAttachments;
        private Service service;
        private string source;
        private string sourceID;
        private string subject;
        private int timesApplied;
        private UIExtension uiExtension;

        #region Assign relations to workflow manager

        /// <summary>
        /// Whether relations like Requests and Problems are assigned to the workflow manager when the relations are linked to the workflow.
        /// </summary>
        [JsonProperty("assign_relations_to_workflow_manager")]
        public bool AssignRelationsToWorkflowManager
        {
            get => assignRelationsToWorkflowManager;
            set => assignRelationsToWorkflowManager = SetValue("assign_relations_to_workflow_manager", assignRelationsToWorkflowManager, value);
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
        /// The Category field is used to select the category that needs to be selected in the Category field of a new workflow when it is being created based on the template. 
        /// </summary>
        [JsonProperty("category")]
        public WorkflowCategory? Category
        {
            get => category;
            set => category = SetValue("category", category, value);
        }

        #endregion

        #region Workflow manager

        /// <summary>
        /// The Workflow manager field is used to select the Person who will be responsible for coordinating the workflows that will be generated automatically in accordance with the recurrence schedule.
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

        #region Workflow type

        /// <summary>
        /// The Type field is used to select the type of a new workflow when it is being created based on the template. It contains the value of the Reference field of a Workflow Type.
        /// </summary>
        [JsonProperty("workflow_type")]
        public string WorkflowType
        {
            get => workflowType;
            set => workflowType = SetValue("workflow_type", workflowType, value);
        }

        #endregion

        #region Disabled

        /// <summary>
        /// The Disabled box is checked when the workflow template may not be used to help register new workflows.
        /// </summary>
        [JsonProperty("disabled")]
        public bool Disabled
        {
            get => disabled;
            set => disabled = SetValue("disabled", disabled, value);
        }

        #endregion

        #region Impact

        /// <summary>
        /// The Impact field shows the maximum impact level that is selected in the task templates that are a part of the workflow template. 
        /// </summary>
        [JsonProperty("impact")]
        public WorkflowImpact? Impact
        {
            get => impact;
            internal set => impact = value;
        }

        #endregion

        #region Instructions

        /// <summary>
        /// The Instructions field is used to enter the information that needs to be shown when a new workflow is being created based on the template. This field typically contains instructions about how to register the workflow.
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

        #region Justification

        /// <summary>
        /// The Justification field is used to select the justification that needs to be selected in the Justification field of a new workflow when it is being created based on the template. This field is required when there are request templates linked to the workflow template. 
        /// </summary>
        [JsonProperty("justification")]
        public WorkflowJustification? Justification
        {
            get => justification;
            set => justification = SetValue("justification", justification, value);
        }

        #endregion

        #region Note

        /// <summary>
        /// The Note field is used to enter the information that needs to be copied to the Note field of a new workflow when it is being created based on the template.
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

        #region Service

        /// <summary>
        /// The Service field is used to select the Service that should be selected in the Service field of a new workflow when it is being created based on the template.
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

        #region Subject

        /// <summary>
        /// The Subject field is used to enter a short description that needs to be copied to the Subject field of a new Workflow when it is being created based on the template.
        /// </summary>
        [JsonProperty("subject")]
        public string Subject
        {
            get => subject;
            set => subject = SetValue("subject", subject, value);
        }

        #endregion

        #region Times applied

        /// <summary>
        /// The number of times the workflow template is used to create a Workflow.
        /// </summary>
        [JsonProperty("times_applied")]
        public int TimesApplied
        {
            get => timesApplied;
            internal set => timesApplied = value;
        }

        #endregion

        #region UI extension

        /// <summary>
        /// The UI extension field is used to select the UI extension that is to be added to a new workflow when it is being created based on the template.
        /// </summary>
        [JsonProperty("ui_extension")]
        public UIExtension UiExtension
        {
            get => uiExtension;
            set => uiExtension = SetValue("ui_extension_id", uiExtension, value);
        }

        [JsonProperty("ui_extension_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? UiExtensionID => uiExtension?.ID;

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            workflowManager?.ResetPropertySerializationCollection();
            service?.ResetPropertySerializationCollection();
            uiExtension?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
