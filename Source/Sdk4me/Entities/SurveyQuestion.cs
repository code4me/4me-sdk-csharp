using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/surveys/survey_questions/">survey question</see> object.
    /// </summary>
    public class SurveyQuestion : BaseItem
    {
        private List<Attachment> attachments;
        private bool disabled;
        private string guidance;
        private List<AttachmentReference> guidanceAttachment;
        private int? position;
        private string question;
        private string source;
        private string sourceID;
        private SurveyQuestionType type;
        private int? weight;

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

        #region Disabled

        /// <summary>
        /// The Disabled box is checked when the question will not be shown to users completing the survey.
        /// </summary>
        [JsonProperty("disabled")]
        public bool Disabled
        {
            get => disabled;
            set => disabled = SetValue("disabled", disabled, value);
        }

        #endregion

        #region Guidance

        /// <summary>
        /// The Guidance field is used for additional information to aid in answering the question.
        /// </summary>
        [JsonProperty("guidance")]
        public string Guidance
        {
            get => guidance;
            set => guidance = SetValue("guidance", guidance, value);
        }

        #endregion

        #region Guidance attachments

        /// <summary>
        /// Write-only. Add a reference to an uploaded attachment. Use <see cref="Attachments"/> to get the existing attachments.
        /// </summary>
        /// <param name="key">The attachment key.</param>
        /// <param name="fileSize">The attachment file size.</param>
        public void ReferenceGuidanceAttachment(string key, long fileSize)
        {
            if (guidanceAttachment == null)
                guidanceAttachment = new List<AttachmentReference>();

            guidanceAttachment.Add(new AttachmentReference()
            {
                Key = key,
                FileSize = fileSize,
                Inline = true
            });

            base.PropertySerializationCollection.Add("guidance_attachments");
        }

        [JsonProperty("guidance_attachments"), Sdk4meIgnoreInFieldSelection()]
        internal List<AttachmentReference> GuidanceAttachments
        {
            get => guidanceAttachment;
        }

        #endregion

        #region Position

        /// <summary>
        /// The Position field is used to specify the position of the question, relative to the other questions of the survey. The first question has position 1.
        /// </summary>
        [JsonProperty("position")]
        public int? Position
        {
            get => position;
            set => position = SetValue("position", position, value);
        }

        #endregion

        #region Question

        /// <summary>
        /// The question to pose to the user.
        /// </summary>
        [JsonProperty("question")]
        public string Question
        {
            get => question;
            set => question = SetValue("question", question, value);
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

        #region Type

        /// <summary>
        /// The Type field is used to select the type of the question. 
        /// </summary>
        [JsonProperty("type")]
        public SurveyQuestionType Type
        {
            get => type;
            set => type = SetValue("type", type, value);
        }

        #endregion

        #region Weight

        /// <summary>
        /// The Weight field is only used for rating question. It is used to specify the relative weight of the question compared to the others in the survey.
        /// </summary>
        [JsonProperty("weight")]
        public int? Weight
        {
            get => weight;
            set => weight = SetValue("weight", weight, value);
        }

        #endregion
    }
}
