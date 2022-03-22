using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/knowledge_articles/">knowledge article</see> object.
    /// </summary>
    public class KnowledgeArticle : BaseItem
    {
        private DateTime? archiveDate;
        private List<Attachment> attachments;
        private bool coveredSpecialists;
        private Person createdBy;
        private string description;
        private List<AttachmentReference> descriptionAttachments;
        private bool endUsers;
        private string instructions;
        private List<AttachmentReference> instructionsAttachments;
        private bool internalSpecialists;
        private bool keyContacts;
        private string keywords;
        private string locale;
        private Service service;
        private string source;
        private string sourceID;
        private KnowledgeArticleStatus status;
        private string subject;
        private int timesApplied;
        private Person updatedBy;

        #region Archive date

        /// <summary>
        /// The date until which the knowledge article will be active. The knowledge article will be archived at the beginning of this day. When the knowledge article is archived, its status will automatically be set to “Archived”.
        /// </summary>
        [JsonProperty("archive_date")]
        public DateTime? ArchiveDate
        {
            get => archiveDate;
            set => archiveDate = SetValue("archive_date", archiveDate, value);
        }

        #endregion

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

        #region Covered specialists

        /// <summary>
        /// The Covered specialists box is checked when the knowledge article needs to be available to the people who are a member of the support team of one of the service instances that are selected in the Coverage section of an active SLA for the service that is linked to the article.
        /// </summary>
        [JsonProperty("covered_specialists")]
        public bool CoveredSpecialists
        {
            get => coveredSpecialists;
            set => coveredSpecialists = SetValue("covered_specialists", coveredSpecialists, value);
        }

        #endregion

        #region Created by

        /// <summary>
        /// The Created by field is automatically set to the person who created the knowledge article.
        /// </summary>
        [JsonProperty("created_by")]
        public Person CreatedBy
        {
            get => createdBy;
            set => createdBy = SetValue("created_by_id", createdBy, value);
        }

        [JsonProperty("created_by_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? CreatedByID => createdBy?.ID;

        #endregion

        #region Description

        /// <summary>
        /// The Description field is used to describe the situation and/or environment in which the instructions of the knowledge article may be helpful.
        /// </summary>
        [JsonProperty("description")]
        public string Description
        {
            get => description;
            set => description = SetValue("description", description, value);
        }

        #endregion

        #region End users

        /// <summary>
        /// The End users box is checked when the knowledge article needs to be available to anyone who is covered by an active SLA for the service that is linked to the article.
        /// </summary>
        [JsonProperty("end_users")]
        public bool EndUsers
        {
            get => endUsers;
            set => endUsers = SetValue("end_users", endUsers, value);
        }

        #endregion

        #region Instructions

        /// <summary>
        /// The Instructions field is used to enter instructions for the service desk analysts, specialists and/or end users who are likely to look up the knowledge article to help them with their work or to resolve an issue.
        /// </summary>
        [JsonProperty("instructions")]
        public string Instructions
        {
            get => instructions;
            set => instructions = SetValue("instructions", instructions, value);
        }

        #endregion

        #region Instructions attachments

        /// <summary>
        /// Writeonly attachments The attachments used in the Instructions field.
        /// </summary>
        /// <param name="key">The attachment key.</param>
        /// <param name="fileSize">The attachment file size.</param>
        /// <param name="inline">True if this an in-line attachment; otherwise false.</param>
        public void ReferenceInstructionsAttachment(string key, long fileSize, bool inline = false)
        {
            if (instructionsAttachments == null)
                instructionsAttachments = new List<AttachmentReference>();

            instructionsAttachments.Add(new AttachmentReference()
            {
                Key = key,
                FileSize = fileSize,
                Inline = inline
            });

            base.PropertySerializationCollection.Add("instructions_attachments");
        }

        [JsonProperty("instructions_attachments"), Sdk4meIgnoreInFieldSelection()]
        internal List<AttachmentReference> InstructionsAttachments
        {
            get => instructionsAttachments;
        }

        #endregion

        #region Internal specialists

        /// <summary>
        /// The Internal specialists box is checked when the knowledge article needs to be available to the people who have the Specialist role of the account in which the article is registered.
        /// </summary>
        [JsonProperty("internal_specialists")]
        public bool InternalSpecialists
        {
            get => internalSpecialists;
            set => internalSpecialists = SetValue("internal_specialists", internalSpecialists, value);
        }

        #endregion

        #region Key contacts

        /// <summary>
        /// The Key contacts box is checked when the knowledge article needs to be available to the people who have the Key Contact role of the customer account of an active SLA for the service that is linked to the article.
        /// </summary>
        [JsonProperty("key_contacts")]
        public bool KeyContacts
        {
            get => keyContacts;
            set => keyContacts = SetValue("key_contacts", keyContacts, value);
        }

        #endregion

        #region Keywords

        /// <summary>
        /// The Keywords field contains a comma-separated list of words that can be used to find the knowledge article using search.
        /// </summary>
        [JsonProperty("keywords")]
        public string Keywords
        {
            get => keywords;
            set => keywords = SetValue("keywords", keywords, value);
        }

        #endregion

        #region Locale

        /// <summary>
        /// The language of the knowledge article.
        /// </summary>
        [JsonProperty("locale"), Sdk4meIgnoreInFieldSelection()]
        public string Locale
        {
            get => locale;
            set => locale = SetValue("locale", locale, value);
        }

        #endregion

        #region Service

        /// <summary>
        /// The Service field is used to select the service for which the knowledge article is made available.
        /// </summary>
        [JsonProperty("service")]
        public Service Service
        {
            get => service;
            set => service = SetValue("service_id", service, value);
        }

        [JsonProperty("service_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ServiceID => service?.ID;

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

        #region Status

        /// <summary>
        /// The Status field is used to select the current status of the knowledge article. 
        /// </summary>
        [JsonProperty("status")]
        public KnowledgeArticleStatus Status
        {
            get => status;
            set => status = SetValue("status", status, value);
        }

        #endregion

        #region Subject

        /// <summary>
        /// The Subject field is used to enter a short description of the knowledge article.
        /// </summary>
        [JsonProperty("subject")]
        public string Subject
        {
            get => subject;
            set => subject = SetValue("subject", subject, value);
        }

        #endregion

        #region Times applied

        /// <summary>
        /// The number of requests to which the knowledge article is linked as the last applied knowledge article.
        /// </summary>
        [JsonProperty("times_applied")]
        public int TimesApplied
        {
            get => timesApplied;
            internal set => timesApplied = value;
        }

        #endregion

        #region Updated by

        /// <summary>
        /// The Updated by field is automatically set to the person who last updated the knowledge article. If the knowledge article has no updates it contains the created_by value.
        /// </summary>
        [JsonProperty("updated_by")]
        public Person UpdatedBy
        {
            get => updatedBy;
            set => updatedBy = SetValue("updated_by_id", updatedBy, value);
        }

        [JsonProperty("updated_by_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? UpdatedByID => updatedBy?.ID;

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            createdBy?.ResetPropertySerializationCollection();
            service?.ResetPropertySerializationCollection();
            updatedBy?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
