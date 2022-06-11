using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/people/addresses/">people address</see> object.
    /// </summary>
    public class RequestDissatisfied : BaseItem
    {
        private string note;
        private bool reopen;
        private List<AttachmentReference> noteAttachments;

        #region Created at (override)

        /// <summary>
        /// The creation date and time; which is obsolete for this object.
        /// </summary>
        [JsonProperty("created_at"), Sdk4meIgnoreInFieldSelection()]
        public override DateTime? CreatedAt
        {
            get => base.CreatedAt;
            internal set => base.CreatedAt = null;
        }

        #endregion

        #region Updated at (override)

        /// <summary>
        /// The updated date and time; which is obsolete for this object.
        /// </summary>
        [JsonProperty("updated_at"), Sdk4meIgnoreInFieldSelection()]
        public override DateTime? UpdatedAt
        {
            get => base.UpdatedAt;
            internal set => base.UpdatedAt = null;
        }

        #endregion

        #region Note

        /// <summary>
        /// The Note field is used to provide any additional information that could prove useful for resolving the request.
        /// </summary>
        [JsonProperty("note")]
        public string Note
        {
            get => note;
            set => note = SetValue("note", note, value);
        }

        #endregion

        #region Reopen

        /// <summary>
        /// Set to the value true if the user wants to reopen the request.
        /// </summary>
        [JsonProperty("reopen")]
        public bool Reopen
        {
            get => reopen;
            set => reopen = SetValue("reopen", reopen, value);
        }

        #endregion

        #region Note attachment

        /// <summary>
        /// Write-only. Add a reference to an uploaded internal note attachment. Use <see cref="Attachment"/> to get the existing attachments.
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
    }
}
