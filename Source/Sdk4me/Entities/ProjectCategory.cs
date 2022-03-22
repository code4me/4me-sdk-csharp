using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/project_categories/">project category</see> object.
    /// </summary>
    public class ProjectCategory : BaseItem
    {
        private List<Attachment> attachments;
        private string description;
        private bool disabled;
        private string information;
        private List<AttachmentReference> informationAttachments;
        private string name;
        private int? position;
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

        #region Description

        /// <summary>
        /// The Description field is used to enter a very short description of the project category, for example “More than 200 workdays or $200K”.
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
        /// The Disabled box is checked when the project category may not be related to any more projects.
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
        /// The Information field is used to add any additional information about the project category that might prove useful, especially for project managers when they need to decide which project category to select for a project.
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
        /// Write-only. Add a reference to an uploaded information attachment. Use <see cref="Attachments"/> to get the existing attachments.
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

        #region Name

        /// <summary>
        /// The Name field is used to enter the name of the project category. Ideally the name of a project category consists of a single word, such as “Large”.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get => name;
            set => name = SetValue("name", name, value);
        }

        #endregion

        #region Position

        /// <summary>
        /// The Position field dictates the position that the project category takes when it is displayed in a sorted list.
        /// </summary>
        [JsonProperty("position")]
        public int? Position
        {
            get => position;
            set => position = SetValue("position", position, value);
        }

        #endregion

        #region Reference

        /// <summary>
        /// The Reference field is automatically set to the Name field value, written in lower case characters and with all spaces replaced by the underscore character. This reference can be used to link the project category to a project using the 4me REST API or the 4me Import functionality.
        /// </summary>
        [JsonProperty("reference")]
        public string Reference
        {
            get => reference;
            internal set => reference = value;
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
