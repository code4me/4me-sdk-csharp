using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me note creation object.
    /// </summary>
    public class NoteCreate : BaseItem
    {
        private List<AttachmentReference> attachments;
        private bool _internal;
        private bool suppressNoteAddedNotifications;
        private string text = string.Empty;

        #region Attachment

        /// <summary>
        /// Write-only. Add a reference to an uploaded note attachment. Use <see cref="Attachment"/> to get the existing attachments.
        /// </summary>
        /// <param name="key">The attachment key.</param>
        /// <param name="fileSize">The attachment file size.</param>
        /// <param name="inline">True if this an in-line attachment; otherwise false.</param>
        public void ReferenceAttachment(string key, long fileSize, bool inline = false)
        {
            if (attachments == null)
                attachments = new List<AttachmentReference>();

            attachments.Add(new AttachmentReference()
            {
                Key = key,
                FileSize = fileSize,
                Inline = inline
            });

            base.PropertySerializationCollection.Add("attachments");
        }

        [JsonProperty("attachments"), Sdk4meIgnoreInFieldSelection()]
        internal List<AttachmentReference> Attachments
        {
            get => attachments;
        }

        #endregion

        #region Internal

        /// <summary>
        /// <para>True when the note is internal; otherwise false.</para>
        /// <br>Public notes belong to the account in which the author’s person record is registered.</br>
        /// <br>Internal notes belong to the account in which specialists are allowed to see the internal note.</br>
        /// </summary>
        [JsonProperty("internal")]
        internal bool Internal
        {
            get => _internal;
            set => _internal = SetValue("internal", _internal, value);
        }

        #endregion

        #region Suppress note added notifications

        /// <summary>
        /// Set to the value true to suppress the ‘Note Added’ notifications from being created. Other notifications, such as ‘Watchlist Item Updated’ and ‘Person Mentioned’, will still be created if applicable.
        /// </summary>
        [JsonProperty("suppress_note_added_notifications")]
        public bool SuppressNoteAddedNotifications
        {
            get => suppressNoteAddedNotifications;
            set => suppressNoteAddedNotifications = SetValue("suppress_note_added_notifications", suppressNoteAddedNotifications, value);
        }

        #endregion

        #region Text

        /// <summary>
        /// Required text (max 64KB), default: <see cref="string.Empty"/>.
        /// </summary>
        [JsonProperty("text")]
        public string Text
        {
            get => text;
            set => text = SetValue("text", text, value);
        }

        #endregion
    }
}
