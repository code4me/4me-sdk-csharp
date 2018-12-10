using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    public class UIExtensionVersion : BaseItem
    {
        private DateTime? activatedAt;
        private DateTime? archivedAt;
        private string cSS;
        private string compiledCSS;
        private string hTML;
        private string localizedHTML;
        private string javascript;
        private string name;
        private List<string> phrases;
        private UIExtensionStatusType? status;
        private int? versionNr;
        private string viewAuditPath;

        #region activated_at

        [JsonProperty("activated_at")]
        public DateTime? ActivatedAt
        {
            get => activatedAt;
            internal set => activatedAt = value;
        }

        #endregion

        #region archived_at

        [JsonProperty("archived_at")]
        public DateTime? ArchivedAt
        {
            get => archivedAt;
            internal set => archivedAt = value;
        }

        #endregion

        #region css

        [JsonProperty("css")]
        public string CSS
        {
            get => cSS;
            internal set => cSS = value;
        }

        #endregion

        #region compiled_css

        [JsonProperty("compiled_css")]
        public string CompiledCSS
        {
            get => compiledCSS;
            internal set => compiledCSS = value;
        }

        #endregion

        #region html

        [JsonProperty("html")]
        public string HTML
        {
            get => hTML;
            internal set => hTML = value;
        }

        #endregion

        #region localized_html

        [JsonProperty("localized_html"), Sdk4meIgnoreInFieldSelection()]
        public string LocalizedHTML
        {
            get => localizedHTML;
            internal set => localizedHTML = value;
        }

        #endregion

        #region javascript

        [JsonProperty("javascript")]
        public string Javascript
        {
            get => javascript;
            internal set => javascript = value;
        }

        #endregion

        #region name

        [JsonProperty("name")]
        public string Name
        {
            get => name;
            internal set => name = value;
        }

        #endregion

        #region phrases

        [JsonProperty("phrases")]
        public List<string> Phrases
        {
            get => phrases;
            internal set => phrases = value;
        }

        #endregion

        #region status

        [JsonProperty("status")]
        public UIExtensionStatusType? Status
        {
            get => status;
            internal set => status = value;
        }

        #endregion

        #region version_nr

        [JsonProperty("version_nr")]
        public int? VersionNr
        {
            get => versionNr;
            internal set => versionNr = value;
        }

        #endregion

        #region view_audit_path

        [JsonProperty("view_audit_path")]
        public string ViewAuditPath
        {
            get => viewAuditPath;
            internal set => viewAuditPath = value;
        }

        #endregion
    }
}
