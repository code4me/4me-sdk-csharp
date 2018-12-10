using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sdk4me
{
    public class BroadcastTranslation : BaseItem
    {
        private List<Attachment> attachments;
        private string locale;
        private string message;

        #region attachments

        [JsonProperty("attachments")]
        public List<Attachment> Attachments
        {
            get => attachments;
            internal set => attachments = value;
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

        #region message

        [JsonProperty("message")]
        public string Message
        {
            get => message;
            set
            {
                if (message != value)
                    AddIncludedDuringSerialization("message");
                message = value;
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
