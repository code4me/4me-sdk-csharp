using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/ui_extensions/versions/">user interface extension version</see> object.
    /// </summary>
    public class UIExtensionVersion : BaseItem
    {
        private DateTime? activatedAt;
        private DateTime? archivedAt;
        private string css;
        private string compiledCss;
        private string html;
        private string localizedHtml;
        private string javascript;
        private string name;
        private List<string> phrases;
        private UIExtensionVersionStatus status;
        private int versionNr;
        private string viewAuditPath;

        #region Activated at

        /// <summary>
        /// The date and time at which this version of the UI extension was activated.
        /// </summary>
        [JsonProperty("activated_at")]
        public DateTime? ActivatedAt
        {
            get => activatedAt;
            internal set => activatedAt = value;
        }

        #endregion

        #region Archived at

        /// <summary>
        /// The date and time at which this version of the UI extension was archived.
        /// </summary>
        [JsonProperty("archived_at")]
        public DateTime? ArchivedAt
        {
            get => archivedAt;
            internal set => archivedAt = value;
        }

        #endregion

        #region Css

        /// <summary>
        /// The CSS stylesheet.
        /// </summary>
        [JsonProperty("css")]
        public string Css
        {
            get => css;
            internal set => css = value;
        }

        #endregion

        #region Compiled css

        /// <summary>
        /// The compiled CSS stylesheet (only available when a single version is retrieved).
        /// </summary>
        [JsonProperty("compiled_css"), Sdk4meIgnoreInFieldSelection()]
        public string CompiledCss
        {
            get => compiledCss;
            internal set => compiledCss = value;
        }

        #endregion

        #region Html

        /// <summary>
        /// The HTML code.
        /// </summary>
        [JsonProperty("html")]
        public string Html
        {
            get => html;
            internal set => html = value;
        }

        #endregion

        #region Localized html

        /// <summary>
        /// The HTML code with all phrases translated in the current users locale (only available when a single version is retrieved).
        /// </summary>
        [JsonProperty("localized_html"), Sdk4meIgnoreInFieldSelection()]
        public string LocalizedHtml
        {
            get => localizedHtml;
            internal set => localizedHtml = value;
        }

        #endregion

        #region Javascript

        /// <summary>
        /// The Javascript code.
        /// </summary>
        [JsonProperty("javascript")]
        public string Javascript
        {
            get => javascript;
            internal set => javascript = value;
        }

        #endregion

        #region Name

        /// <summary>
        /// The Name of the UI extension at the time this version was created.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get => name;
            internal set => name = value;
        }

        #endregion

        #region Phrases

        /// <summary>
        /// The translatable phrases found in the HTML code.
        /// </summary>
        [JsonProperty("phrases")]
        public List<string> Phrases
        {
            get => phrases;
            internal set => phrases = value;
        }

        #endregion

        #region Status

        /// <summary>
        /// The Status field indicates the location in the life-cycle.
        /// </summary>
        [JsonProperty("status")]
        public UIExtensionVersionStatus Status
        {
            get => status;
            internal set => status = value;
        }

        #endregion

        #region Version number

        /// <summary>
        /// The version number (1..) of this version of the UI extension.
        /// </summary>
        [JsonProperty("version_nr")]
        public int VersionNr
        {
            get => versionNr;
            internal set => versionNr = value;
        }

        #endregion

        #region View audit path

        /// <summary>
        /// The URI to the Audit Lines of this version of the UI extension.
        /// </summary>
        [JsonProperty("view_audit_path"), Sdk4meIgnoreInFieldSelection()]
        public string ViewAuditPath
        {
            get => viewAuditPath;
            internal set => viewAuditPath = value;
        }

        #endregion
    }
}
