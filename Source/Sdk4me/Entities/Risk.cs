using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/risks/">risk</see> object.
    /// </summary>
    public class Risk : CustomFieldsBaseItem
    {
        private List<Attachment> attachments;
        private DateTime? closedAt;
        private RiskClosureReason? closureReason;
        private Person manager;
        private DateTime? mitigationTargetAt;
        private string note;
        private List<AttachmentReference> noteAttachments;
        private TimeSpan? resolutionDuration;
        private string severity;
        private RiskStatus status;
        private string subject;
        private string source;
        private string sourceID;
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

        #region Closed at

        /// <summary>
        /// The Closed at field is automatically set to the date and time at which the risk is saved with the status “Closed”.
        /// </summary>
        [JsonProperty("closed_at")]
        public DateTime? ClosedAt
        {
            get => closedAt;
            internal set => closedAt = value;
        }

        #endregion

        #region Closure reason

        /// <summary>
        /// The Closure reason field is used to select the appropriate closure reason for the risk when it has been closed. 
        /// </summary>
        [JsonProperty("closure_reason")]
        public RiskClosureReason? ClosureReason
        {
            get => closureReason;
            set => closureReason = SetValue("closure_reason", closureReason, value);
        }

        #endregion

        #region Manager

        /// <summary>
        /// The Manager field is used to select the manager of the risk. This person is able to maintain the information about the risk.
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

        #region Mitigation target at

        /// <summary>
        /// The date by which the risk should have been mitigated.
        /// </summary>
        [JsonProperty("mitigation_target_at")]
        public DateTime? MitigationTargetAt
        {
            get => mitigationTargetAt;
            set => mitigationTargetAt = SetValue("mitigation_target_at", mitigationTargetAt, value);
        }

        #endregion

        #region Note

        /// <summary>
        /// The Note field is used to provide a description.
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

        #region Resolution duration

        /// <summary>
        /// The number of minutes it took to complete this risk, which is calculated as the difference between the created_at and closed_at values.
        /// </summary>
        public TimeSpan? ResolutionDuration => resolutionDuration;

        [JsonProperty("resolution_duration")]
        internal int? ResolutionDurationInMinutes
        {
            get => resolutionDuration != null ? Convert.ToInt32(resolutionDuration.Value.TotalMinutes) : (int?)null;
            set => resolutionDuration = value != null ? TimeSpan.FromMinutes(value.Value) : (TimeSpan?)null;
        }

        #endregion

        #region Severity

        /// <summary>
        /// The Severity field is used to select the severity of the risk.
        /// </summary>
        [JsonProperty("severity")]
        public string Severity
        {
            get => severity;
            set => severity = SetValue("severity", severity, value);
        }

        #endregion

        #region Status

        /// <summary>
        /// The Status field is used to select the current status of the risk. 
        /// </summary>
        [JsonProperty("status")]
        public RiskStatus Status
        {
            get => status;
            set => status = SetValue("status", status, value);
        }

        #endregion

        #region Subject

        /// <summary>
        /// The Subject field is used to enter the subject of the risk.
        /// </summary>
        [JsonProperty("subject")]
        public string Subject
        {
            get => subject;
            set => subject = SetValue("subject", subject, value);
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

        #region UI extension

        /// <summary>
        /// The UI extension field indicates the UI extension that is applied to the risk.
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

        internal override void ResetPropertySerializationCollection()
        {
            manager?.ResetPropertySerializationCollection();
            //severity?.ResetPropertySerializationCollection();
            uiExtension?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
