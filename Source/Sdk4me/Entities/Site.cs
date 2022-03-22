using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/sites/">site</see> object.
    /// </summary>
    public class Site : CustomFieldsBaseItem
    {
        private string address;
        private List<Attachment> attachments;
        private string city;
        private string country;
        private bool disabled;
        private string name;
        private string pictureUri;
        private string remarks;
        private List<AttachmentReference> remarksAttachments;
        private string source;
        private string sourceID;
        private string state;
        private string timeZone;
        private UIExtension uiExtension;
        private string zip;

        #region Address

        /// <summary>
        /// The address lines of the street address.
        /// </summary>
        [JsonProperty("address")]
        public string Address
        {
            get => address;
            internal set => address = value;
        }

        #endregion

        #region Attachments

        /// <summary>
        /// Readonly aggregated Attachments.
        /// </summary>
        [JsonProperty("attachments")]
        public List<Attachment> Attachments
        {
            get => attachments;
            internal set => attachments = value;
        }

        #endregion

        #region City

        /// <summary>
        /// The city name of the street address.
        /// </summary>
        [JsonProperty("city")]
        public string City
        {
            get => city;
            internal set => city = value;
        }

        #endregion

        #region Country

        /// <summary>
        /// The 2-letter country code of the street address.
        /// </summary>
        [JsonProperty("country")]
        public string Country
        {
            get => country;
            internal set => country = value;
        }

        #endregion

        #region Disabled

        /// <summary>
        /// The Disabled box is checked when the site may no longer be related to other records.
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
        /// The Name field is used to enter the name of the site or facility.
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
        /// The hyperlink to the image file for the site.
        /// </summary>
        [JsonProperty("picture_uri")]
        public string PictureUri
        {
            get => pictureUri;
            set => pictureUri = SetValue("picture_uri", pictureUri, value);
        }

        #endregion

        #region Remarks

        /// <summary>
        /// The Remarks field is used to add any additional information about the site that might prove useful.
        /// </summary>
        [JsonProperty("remarks")]
        public string Remarks
        {
            get => remarks;
            set => remarks = SetValue("remarks", remarks, value);
        }

        #endregion

        #region Remarks attachment

        /// <summary>
        /// Write-only. Add a reference to an uploaded information attachment. Use <see cref="Attachments"/> to get the existing attachments.
        /// </summary>
        /// <param name="key">The attachment key.</param>
        /// <param name="fileSize">The attachment file size.</param>
        public void ReferenceRemarksAttachment(string key, long fileSize)
        {
            if (remarksAttachments == null)
                remarksAttachments = new List<AttachmentReference>();

            remarksAttachments.Add(new AttachmentReference()
            {
                Key = key,
                FileSize = fileSize,
                Inline = true
            });

            base.PropertySerializationCollection.Add("remarks_attachments");
        }

        [JsonProperty("remarks_attachments"), Sdk4meIgnoreInFieldSelection()]
        internal List<AttachmentReference> RemarksAttachments
        {
            get => remarksAttachments;
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

        #region State

        /// <summary>
        /// The state name of the street address.
        /// </summary>
        [JsonProperty("state")]
        public string State
        {
            get => state;
            internal set => state = value;
        }

        #endregion

        #region Time zone

        /// <summary>
        /// The Time zone field is used to select the time zone in which the site is located.
        /// </summary>
        [JsonProperty("time_zone")]
        public string TimeZone
        {
            get => timeZone;
            set => timeZone = SetValue("time_zone", timeZone, value);
        }

        #endregion

        #region UI Extension

        /// <summary>
        /// The UI extension field indicates the UI extension that is applied to the person.
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

        #region Zip

        /// <summary>
        /// The zip code of the street address.
        /// </summary>
        [JsonProperty("zip")]
        public string Zip
        {
            get => zip;
            internal set => zip = value;
        }

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            uiExtension?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
