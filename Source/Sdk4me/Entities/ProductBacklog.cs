﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/product_backlogs/">product backlog</see> object.
    /// </summary>
    public class ProductBacklog : BaseItem
    {
        private List<Attachment> attachments;
        private bool disabled;
        private string name;
        private string pictureUri;
        private string description;
        private List<AttachmentReference> descriptionAttachments;
        private Person productOwner;
        private string source;
        private string sourceID;

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
        /// The Description field is used to enter a high-level description of the product backlog.
        /// </summary>
        [JsonProperty("description")]
        public string Description
        {
            get => description;
            set => description = SetValue("description", description, value);
        }

        #endregion

        #region Description attachment

        /// <summary>
        /// Write-only. Add a reference to an uploaded description attachment. Use <see cref="Attachments"/> to get the existing attachments.
        /// </summary>
        /// <param name="key">The attachment key.</param>
        /// <param name="fileSize">The attachment file size.</param>
        /// <param name="inline">True if this an in-line attachment; otherwise false.</param>
        public void ReferenceDescriptionAttachment(string key, long fileSize, bool inline = false)
        {
            if (descriptionAttachments == null)
                descriptionAttachments = new List<AttachmentReference>();

            descriptionAttachments.Add(new AttachmentReference()
            {
                Key = key,
                FileSize = fileSize,
                Inline = inline
            });

            base.PropertySerializationCollection.Add("description_attachments");
        }

        [JsonProperty("description_attachments"), Sdk4meIgnoreInFieldSelection()]
        internal List<AttachmentReference> DescriptionAttachment
        {
            get => descriptionAttachments;
        }

        #endregion

        #region Disabled

        /// <summary>
        /// The Disabled box is checked when the product backlog may no longer be related to other records.
        /// </summary>
        [JsonProperty("disabled")]
        public bool Disabled
        {
            get => disabled;
            set => disabled = SetValue("disabled", disabled, value);
        }

        #endregion

        #region Name

        /// <summary>
        /// The Name field is used to enter the name of the product backlog.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get => name;
            set => name = SetValue("name", name, value);
        }

        #endregion

        #region Picture uri

        /// <summary>
        /// The hyperlink to the image file for the product backlog.
        /// </summary>
        [JsonProperty("picture_uri")]
        public string PictureUri
        {
            get => pictureUri;
            set => pictureUri = SetValue("picture_uri", pictureUri, value);
        }

        #endregion

        #region Product owner

        /// <summary>
        /// The Product owner field is used to select the person responsible for maximizing the value of the work done based on this product backlog.
        /// </summary>
        [JsonProperty("product_owner")]
        public Person ProductOwner
        {
            get => productOwner;
            set => productOwner = SetValue("product_owner_id", productOwner, value);
        }

        [JsonProperty("product_owner_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ProductOwnerID => productOwner?.ID;

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

        internal override void ResetPropertySerializationCollection()
        {
            productOwner?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
