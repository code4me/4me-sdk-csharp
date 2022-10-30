using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/sprints/">sprint</see> object.
    /// </summary>
    public class Sprint : BaseItem
    {
        private List<Attachment> attachments;
        private string description;
        private List<AttachmentReference> descriptionAttachments;
        private DateTime? endAt;
        private int number;
        private ScrumWorkspace scrumWorkspace;
        private string source;
        private string sourceID;
        private DateTime? startAt;
        private SprintStatus status;

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

        #region Description

        /// <summary>
        /// The description of this sprint (e.g. goal of this sprint).
        /// </summary>
        [JsonProperty("description")]
        public string Description
        {
            get => description;
            set => description = SetValue("description", description, value);
        }

        #endregion

        #region Description attachments

        /// <summary>
        /// Write-only. Add a reference to an uploaded attachment. Use <see cref="Attachments"/> to get the existing attachments.
        /// </summary>
        /// <param name="key">The attachment key.</param>
        /// <param name="fileSize">The attachment file size.</param>
        public void ReferenceDescriptionAttachment(string key, long fileSize)
        {
            if (descriptionAttachments == null)
                descriptionAttachments = new List<AttachmentReference>();

            descriptionAttachments.Add(new AttachmentReference()
            {
                Key = key,
                FileSize = fileSize,
                Inline = true
            });

            base.PropertySerializationCollection.Add("description_attachments");
        }

        [JsonProperty("description_attachments"), Sdk4meIgnoreInFieldSelection()]
        internal List<AttachmentReference> DescriptionAttachments
        {
            get => descriptionAttachments;
        }

        #endregion

        #region End at

        /// <summary>
        /// The date and time the sprint ended, or will end.
        /// </summary>
        [JsonProperty("end_at")]
        public DateTime? EndAt
        {
            get => endAt;
            set => endAt = SetValue("end_at", endAt, value);
        }

        #endregion

        #region Number

        /// <summary>
        /// Sequence number of this sprint.
        /// </summary>
        [JsonProperty("number")]
        public int Number
        {
            get => number;
            set => number = SetValue("number", number, value);
        }

        #endregion

        #region Scrum workspace

        /// <summary>
        /// Scrum workspace this sprint belongs to.
        /// </summary>
        [JsonProperty("scrum_workspace")]
        public ScrumWorkspace ScrumWorkspace
        {
            get => scrumWorkspace;
            internal set => scrumWorkspace = SetValue("scrum_workspace_id", scrumWorkspace, value);
        }

        [JsonProperty("scrum_workspace_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ScrumWorkspaceID => scrumWorkspace?.ID;

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
        /// The date and time the sprint started, or will start.
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
        /// The current status of the sprint. 
        /// </summary>
        [JsonProperty("status")]
        public SprintStatus Status
        {
            get => status;
            internal set => status = value;
        }

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            scrumWorkspace?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
