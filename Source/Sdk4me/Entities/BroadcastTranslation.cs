using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/broadcasts/translations/">broadcast translation</see> object.
    /// </summary>
    public class BroadcastTranslation : BaseItem
    {
        private List<Attachment> attachments;
        private List<AttachmentReference> messageAttachments;
        private string locale;
        private string message;

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

        #region Locale

        /// <summary>
        /// Optional string (max 5)
        /// </summary>
        [JsonProperty("locale")]
        public string Locale
        {
            get => locale;
            set => locale = SetValue("locale", locale, value);
        }

        #endregion

        #region Message

        /// <summary>
        /// The Message field is used to enter the information that is to be broadcasted.
        /// </summary>
        [JsonProperty("message")]
        public string Message
        {
            get => message;
            set => message = SetValue("message", message, value);
        }

        #endregion

        #region Message attachment

        /// <summary>
        /// Write-only. Add a reference to an uploaded attachment. Use <see cref="Attachments"/> to get the existing attachments.
        /// </summary>
        /// <param name="key">The attachment key.</param>
        /// <param name="fileSize">The attachment file size.</param>
        public void ReferenceMessageAttachment(string key, long fileSize)
        {
            if (messageAttachments == null)
                messageAttachments = new List<AttachmentReference>();

            messageAttachments.Add(new AttachmentReference()
            {
                Key = key,
                FileSize = fileSize,
                Inline = true
            });

            base.PropertySerializationCollection.Add("message_attachments");
        }

        [JsonProperty("message_attachments"), Sdk4meIgnoreInFieldSelection()]
        internal List<AttachmentReference> MessageAttachments
        {
            get => messageAttachments;
        }

        #endregion
    }
}
