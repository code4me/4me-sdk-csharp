using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sdk4me
{
    public class KnowledgeArticleTranslation : BaseItem
    {
        private List<Attachment> attachments;
        private string description;
        private string instructions;
        private string locale;
        private string subject;

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
        /// The Description field is used to describe the situation and/or environment in which the instructions of the knowledge article may be helpful in the language of the locale.
        /// </summary>
        [JsonProperty("description")]
        public string Description
        {
            get => description;
            set => description = SetValue("description", description, value);
        }

        #endregion

        #region Instructions

        /// <summary>
        /// The Instructions field is used to enter instructions in the language of the locale for the service desk analysts, specialists and/or end users who are likely to look up the knowledge article to help them with their work or to resolve an issue.
        /// </summary>
        [JsonProperty("instructions")]
        public string Instructions
        {
            get => instructions;
            set => instructions = SetValue("instructions", instructions, value);
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

        #region Subject

        /// <summary>
        /// The Subject field is used to enter a short description of the knowledge article in the language of the locale.
        /// </summary>
        [JsonProperty("subject")]
        public string Subject
        {
            get => subject;
            set => subject = SetValue("subject", subject, value);
        }

        #endregion
    }
}
