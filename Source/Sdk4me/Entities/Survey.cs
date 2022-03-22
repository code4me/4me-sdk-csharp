using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/surveys/">survey</see> object.
    /// </summary>
    public class Survey : BaseItem
    {
        private List<Attachment> attachments;
        private string completion;
        private List<AttachmentReference> completionAttachments;
        private bool disabled;
        private string introduction;
        private List<AttachmentReference> introductionAttachments;
        private string name;
        private string source;
        private string sourceID;

        #region Attachments

        /// <summary>
        /// Readonly aggregated Attachments
        /// </summary>
        [JsonProperty("attachments"), Sdk4meIgnoreInFieldSelection()]
        public List<Attachment> Attachments
        {
            get => attachments;
            internal set => attachments = value;
        }

        #endregion

        #region Completion

        /// <summary>
        /// The Completion field is used to enter content shown to respondents on completion of the survey.
        /// </summary>
        [JsonProperty("completion")]
        public string Completion
        {
            get => completion;
            set => completion = SetValue("completion", completion, value);
        }

        #endregion

        #region Completion attachments

        /// <summary>
        /// Write-only. Add a reference to an uploaded attachment. Use <see cref="Attachments"/> to get the existing attachments.
        /// </summary>
        /// <param name="key">The attachment key.</param>
        /// <param name="fileSize">The attachment file size.</param>
        public void ReferenceCompletionAttachments(string key, long fileSize)
        {
            if (completionAttachments == null)
                completionAttachments = new List<AttachmentReference>();

            completionAttachments.Add(new AttachmentReference()
            {
                Key = key,
                FileSize = fileSize,
                Inline = true
            });

            base.PropertySerializationCollection.Add("completion_attachments");
        }

        [JsonProperty("completion_attachments"), Sdk4meIgnoreInFieldSelection()]
        internal List<AttachmentReference> CompletionAttachments
        {
            get => completionAttachments;
        }

        #endregion

        #region Disabled

        /// <summary>
        /// The Disabled box is checked when the survey may no longer be related to services and users should not be asked to use it to rate services it is linked to.
        /// </summary>
        [JsonProperty("disabled")]
        public bool Disabled
        {
            get => disabled;
            set => disabled = SetValue("disabled", disabled, value);
        }

        #endregion

        #region Introduction

        /// <summary>
        /// The Introduction field is used to enter content shown to respondents before the first question of the survey.
        /// </summary>
        [JsonProperty("introduction")]
        public string Introduction
        {
            get => introduction;
            set => introduction = SetValue("introduction", introduction, value);
        }

        #endregion

        #region Introduction attachments

        /// <summary>
        /// Write-only. Add a reference to an uploaded attachment. Use <see cref="Attachments"/> to get the existing attachments.
        /// </summary>
        /// <param name="key">The attachment key.</param>
        /// <param name="fileSize">The attachment file size.</param>
        public void ReferenceIntroductionAttachment(string key, long fileSize)
        {
            if (introductionAttachments == null)
                introductionAttachments = new List<AttachmentReference>();

            introductionAttachments.Add(new AttachmentReference()
            {
                Key = key,
                FileSize = fileSize,
                Inline = true
            });

            base.PropertySerializationCollection.Add("introduction_attachments");
        }

        [JsonProperty("introduction_attachments"), Sdk4meIgnoreInFieldSelection()]
        internal List<AttachmentReference> IntroductionAttachments
        {
            get => introductionAttachments;
        }

        #endregion

        #region Name

        /// <summary>
        /// The Name field is used to enter the name of the survey.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get => name;
            set => name = SetValue("name", name, value);
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
