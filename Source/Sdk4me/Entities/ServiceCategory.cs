using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/service_categories/">service category</see> object.
    /// </summary>
    public class ServiceCategory : BaseItem
    {
        private List<Attachment> attachments;
        private string description;
        private List<AttachmentReference> descriptionAttachments;
        private string localizedDescription;
        private string localizedName;
        private string name;
        private string pictureUri;
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
        /// The Description field is used to enter a high-level description of the type of services that are included in the service category.
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

        #region Localized description

        /// <summary>
        /// Translated Description in the current language, defaults to description in case no translation is provided.
        /// </summary>
        [JsonProperty("localized_description"), Sdk4meIgnoreInFieldSelection()]
        public string LocalizedDescription
        {
            get => localizedDescription;
            internal set => localizedDescription = value;
        }

        #endregion

        #region Localized name

        /// <summary>
        /// Translated Name in the current language, defaults to name in case no translation is provided.
        /// </summary>
        [JsonProperty("localized_name"), Sdk4meIgnoreInFieldSelection()]
        public string LocalizedName
        {
            get => localizedName;
            internal set => localizedName = value;
        }

        #endregion

        #region Name

        /// <summary>
        /// The Name field is used to enter the name of the service category.
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
        /// The hyperlink to the image file for the service category.
        /// </summary>
        [JsonProperty("picture_uri")]
        public string PictureUri
        {
            get => pictureUri;
            set => pictureUri = SetValue("picture_uri", pictureUri, value);
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
    }
}
