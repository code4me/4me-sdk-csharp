using Newtonsoft.Json;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/knowledge_article_templates/">knowledge article templates</see> object.
    /// </summary>
    public class KnowledgeArticleTemplate : BaseItem
    {
        private bool disabled;
        private Service service;
        private string source;
        private string sourceID;
        private string subject;
        private UIExtension uiExtension;

        #region Disabled

        /// <summary>
        /// The Disabled box is checked when the knowledge article template may no longer be related to other records.
        /// </summary>
        [JsonProperty("disabled")]
        public bool Disabled
        {
            get => disabled;
            set => disabled = SetValue("disabled", disabled, value);
        }

        #endregion

        #region Service

        /// <summary>
        /// The Service field is used to select the service for which the knowledge article template is made available.
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

        #region Subject

        /// <summary>
        /// The Subject field is used to enter a short description of the knowledge article template.
        /// </summary>
        [JsonProperty("subject")]
        public string Subject
        {
            get => subject;
            set => subject = SetValue("subject", subject, value);
        }

        #endregion

        #region UI Extension

        /// <summary>
        /// The UI extension field indicates the UI extension that is applied to the knowledge article template.
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

        internal override void ResetPropertySerializationCollection()
        {
            service?.ResetPropertySerializationCollection();
            uiExtension?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
