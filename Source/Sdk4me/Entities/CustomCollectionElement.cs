using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/custom_collection_elements/">custom collection element</see> object.
    /// </summary>
    public class CustomCollectionElement : BaseItem
    {
        private List<Attachment> attachments;
        private List<AttachmentReference> informationAttachments;
        private string customCollection;
        private string description;
        private bool disabled;
        private string information;
        private string localizedDescription;
        private string localizedName;
        private string name;
        private string pictureUri;
        private string reference;
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

        #region Custom collection

        /// <summary>
        /// The Custom collection the custom collection belongs to.
        /// </summary>
        [JsonProperty("custom_collection")]
        public string CustomCollection
        {
            get => customCollection;
            internal set => customCollection = value;
        }

        #endregion

        #region Description

        /// <summary>
        /// The Description field is used to enter a very short description of the custom collection element.
        /// </summary>
        [JsonProperty("description")]
        public string Description
        {
            get => description;
            set => description = SetValue("description", description, value);
        }

        #endregion

        #region Disabled

        /// <summary>
        /// The Disabled box is checked when the custom collection element may not be selected in suggest boxes for custom fields.
        /// </summary>
        [JsonProperty("disabled")]
        public bool Disabled
        {
            get => disabled;
            set => disabled = SetValue("disabled", disabled, value);
        }

        #endregion

        #region Information

        /// <summary>
        /// The Information field is used to add any additional information about the custom collection element that might prove useful.
        /// </summary>
        [JsonProperty("information")]
        public string Information
        {
            get => information;
            set => information = SetValue("information", information, value);
        }

        #endregion

        #region Information attachment

        /// <summary>
        /// Write-only. Add a reference to an uploaded attachment. Use <see cref="Attachments"/> to get the existing attachments.
        /// </summary>
        /// <param name="key">The attachment key.</param>
        /// <param name="fileSize">The attachment file size.</param>
        /// <param name="inline">True if this an in-line attachment; otherwise false.</param>
        public void ReferenceInformationAttachment(string key, long fileSize, bool inline = false)
        {
            if (informationAttachments == null)
                informationAttachments = new List<AttachmentReference>();

            informationAttachments.Add(new AttachmentReference()
            {
                Key = key,
                FileSize = fileSize,
                Inline = inline
            });

            base.PropertySerializationCollection.Add("information_attachments");
        }

        [JsonProperty("information_attachments"), Sdk4meIgnoreInFieldSelection()]
        internal List<AttachmentReference> InformationAttachments
        {
            get => informationAttachments;
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
        /// The Name field is used to enter the name of the custom collection element. Ideally the name of a custom collection element consists of a single word.
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
        /// The hyperlink to the image file for the custom collection element.
        /// </summary>
        [JsonProperty("picture_uri")]
        public string PictureUri
        {
            get => pictureUri;
            set => pictureUri = SetValue("picture_uri", pictureUri, value);
        }

        #endregion

        #region Reference

        /// <summary>
        /// The Reference field defaults to the Name field value, written in lower case characters and with all spaces replaced by the underscore character. This reference can be used in automation rules.
        /// </summary>
        [JsonProperty("reference")]
        public string Reference
        {
            get => reference;
            set => reference = SetValue("reference", reference, value);
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
