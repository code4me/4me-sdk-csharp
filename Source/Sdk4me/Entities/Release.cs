using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/releases/">release</see> object.
    /// </summary>
    public class Release : CustomFieldsBaseItem
    {
        private List<Attachment> attachments;
        private DateTime? completedAt;
        private ReleaseCompletionReason? completionReason;
        private DateTime? completionTargetAt;
        private ReleaseImpact? impact;
        private Person manager;
        private string note;
        private List<AttachmentReference> noteAttachments;
        private string source;
        private string sourceID;
        private ReleaseStatus status;
        private string subject;
        private UIExtension uiExtension;

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

        #region Completed at

        /// <summary>
        /// The Completed at field is automatically set to the date and time at which the release is set to the status “Completed”.
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
        /// The Completion reason field is automatically set based on the completion reason of the release’s workflows. Possible values are:
        /// </summary>
        [JsonProperty("completion_reason")]
        public ReleaseCompletionReason? CompletionReason
        {
            get => completionReason;
            internal set => completionReason = value;
        }

        #endregion

        #region Completion target at

        /// <summary>
        /// The Completion target field shows the target date and time of the last task of the workflows that are related to the release.
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
        /// The Impact field shows the maximum impact level that is selected in the tasks of the workflows that are related to the release. This indicates the maximum extent to which a “service instance”:/help/service_instance will be impacted by the implementation of the release. Possible values are:
        /// </summary>
        [JsonProperty("impact")]
        public ReleaseImpact? Impact
        {
            get => impact;
            internal set => impact = value;
        }

        #endregion

        #region Manager

        /// <summary>
        /// The Manager field is used to select the Person who is responsible for coordinating the implementation of the release. The person must have the release Manager role.
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
        /// The Note field is used to provide a high-level description of the result that should be accomplished by the implementation of the release’s workflows. It is also used to add any information that could prove useful for anyone affected by the release.
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
        /// The Status field is automatically set based on the status of the release’s workflows. Possible values are:
        /// </summary>
        [JsonProperty("status")]
        public ReleaseStatus Status
        {
            get => status;
            internal set => status = value;
        }

        #endregion

        #region Subject

        /// <summary>
        /// The Subject field is used to enter a short description of the objective of the release.
        /// </summary>
        [JsonProperty("subject")]
        public string Subject
        {
            get => subject;
            set => subject = SetValue("subject", subject, value);
        }

        #endregion

        #region UI extension

        /// <summary>
        /// The UI extension field indicates the UI extension that is applied to the release.
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
    }
}
