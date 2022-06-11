using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Sdk4me
{
    /// <summary>
    /// The base identity of a 4me object extended with the CustomField property.
    /// </summary>
    [DebuggerDisplay("{ID}")]
    public class CustomFieldsBaseItem : BaseItem
    {
        private CustomFieldCollection customFields;
        private List<AttachmentReference> customFieldsAttachments;

        #region Custom fields

        /// <summary>
        /// Gets or sets the custom fields.
        /// </summary>
        [JsonProperty("custom_fields")]
        internal List<CustomField> CustomFieldsList
        {
            get => customFields?.GetCustomFields();
            set
            {
                customFields = new CustomFieldCollection(value);
                customFields.Changed += CustomFields_Changed;
            }
        }

        /// <summary>
        /// Returns the custom fields.
        /// </summary>
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
            AddPropertySerializationItem("custom_fields");
        }

        #endregion

        #region Custom field attachment

        /// <summary>
        /// Write-only. Add a reference to an uploaded attachment. Use <see cref="Attachment"/> to get the existing attachments.
        /// </summary>
        /// <param name="key">The attachment key.</param>
        /// <param name="fileSize">The attachment file size.</param>
        public void ReferenceCustomFieldAttachment(string key, long fileSize)
        {
            if (customFieldsAttachments == null)
                customFieldsAttachments = new List<AttachmentReference>();

            customFieldsAttachments.Add(new AttachmentReference()
            {
                Key = key,
                FileSize = fileSize,
                Inline = false
            });

            base.PropertySerializationCollection.Add("custom_fields_attachments");
        }

        [JsonProperty("custom_fields_attachments"), Sdk4meIgnoreInFieldSelection()]
        internal List<AttachmentReference> CustomFieldAttachments
        {
            get => customFieldsAttachments;
        }

        #endregion
    }
}
