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

        #region attachments

        [JsonProperty("attachments")]
        public List<Attachment> Attachments
        {
            get => attachments;
            internal set => attachments = value;
        }

        #endregion

        #region description

        [JsonProperty("description")]
        public string Description
        {
            get => description;
            set
            {
                if (description != value)
                    AddIncludedDuringSerialization("description");
                description = value;
            }
        }

        #endregion

        #region instructions

        [JsonProperty("instructions")]
        public string Instructions
        {
            get => instructions;
            set
            {
                if (instructions != value)
                    AddIncludedDuringSerialization("instructions");
                instructions = value;
            }
        }

        #endregion

        #region locale

        [JsonProperty("locale")]
        public string Locale
        {
            get => locale;
            set
            {
                if (locale != value)
                    AddIncludedDuringSerialization("locale");
                locale = value;
            }
        }

        #endregion

        #region subject

        [JsonProperty("subject")]
        public string Subject
        {
            get => subject;
            set
            {
                if (subject != value)
                    AddIncludedDuringSerialization("subject");
                subject = value;
            }
        }

        #endregion

        internal override void ResetIncludedDuringSerialization()
        {
            if (attachments != null)
                for (int i = 0; i < attachments.Count; i++)
                    attachments[i]?.ResetIncludedDuringSerialization();

            base.ResetIncludedDuringSerialization();
        }
    }
}
