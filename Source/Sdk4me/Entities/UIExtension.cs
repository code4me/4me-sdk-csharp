using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/ui_extensions/">user interface extension</see> object.
    /// </summary>
    public class UIExtension : BaseItem
    {
        private bool? activate;
        private UIExtensionVersion activeVersion;
        private UIExtensionCategory category;
        private string compiledCss;
        private string css;
        private bool disabled;
        private string description;
        private string html;
        private string javascript;
        private string localizedHtml;
        private string name;
        private List<string> phrases;
        private UIExtensionVersion preparedVersion;
        private string source;
        private string sourceID;
        private string title;

        #region Activate

        /// <summary>
        /// Set to true to promote the Prepared Version to the Active Version. If the was an Active Version, it will be Archived.
        /// </summary>
        [JsonProperty("activate")]
        public bool? Activate
        {
            get => activate;
            set => activate = SetValue("activate", activate, value);
        }

        #endregion

        #region Active version

        /// <summary>
        /// Readonly Optional reference to UI extension Version The version with Status active.
        /// </summary>
        [JsonProperty("active_version")]
        public UIExtensionVersion ActiveVersion
        {
            get => activeVersion;
            internal set => activeVersion = value;
        }

        #endregion

        #region Category

        /// <summary>
        /// The Category field is used to select the type of record in which the UI extension can be selected. 
        /// </summary>
        [JsonProperty("category")]
        public UIExtensionCategory Category
        {
            get => category;
            set => category = SetValue("category", category, value);
        }

        #endregion

        #region Compiled css

        /// <summary>
        /// The compiled CSS stylesheet of the Active Version (if available).
        /// </summary>
        [JsonProperty("compiled_css")]
        public string CompiledCss
        {
            get => compiledCss;
            internal set => compiledCss = value;
        }

        #endregion

        #region Css

        /// <summary>
        /// The CSS stylesheet; Shows the CSS stylesheet of the Active Version on retrieval and sets the CSS stylesheet of the Prepared Version if updated.
        /// </summary>
        [JsonProperty("css")]
        public string Css
        {
            get => css;
            set => css = SetValue("css", css, value);
        }

        #endregion

        #region Disabled

        /// <summary>
        /// The Disabled box is checked when the UI extension is inactive.
        /// </summary>
        [JsonProperty("disabled")]
        public bool Disabled
        {
            get => disabled;
            set => disabled = SetValue("disabled", disabled, value);
        }

        #endregion

        #region Description

        /// <summary>
        /// The Description field is used to enter a very short description of the UI extension.
        /// </summary>
        [JsonProperty("description")]
        public string Description
        {
            get => description;
            set => description = SetValue("description", description, value);
        }

        #endregion

        #region Html

        /// <summary>
        /// The HTML code; Shows the HTML code of the Active Version on retrieval and sets the HTML code of the Prepared Version if updated.
        /// </summary>
        [JsonProperty("html")]
        public string Html
        {
            get => html;
            set => html = SetValue("html", html, value);
        }

        #endregion

        #region Javascript

        /// <summary>
        /// The Javascript code; Shows the Javascript code of the Active Version on retrieval and sets the Javascript code of the Prepared Version if updated.
        /// </summary>
        [JsonProperty("javascript")]
        public string Javascript
        {
            get => javascript;
            set => javascript = SetValue("javascript", javascript, value);
        }

        #endregion

        #region Localized html

        /// <summary>
        /// The HTML code of the Active Version with all phrases translated in the current users locale (if available).
        /// </summary>
        [JsonProperty("localized_html")]
        public string LocalizedHtml
        {
            get => localizedHtml;
            internal set => localizedHtml = value;
        }

        #endregion

        #region Name

        /// <summary>
        /// The Name field is used to enter the name of the UI extension.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get => name;
            set => name = SetValue("name", name, value);
        }

        #endregion

        #region Phrases

        /// <summary>
        /// The translatable phrases used in the version with Status active.
        /// </summary>
        [JsonProperty("phrases")]
        public List<string> Phrases
        {
            get => phrases;
            internal set => phrases = value;
        }

        #endregion

        #region Prepared version

        /// <summary>
        /// Readonly reference to UI Extension Version The version with Status being prepared.
        /// </summary>
        [JsonProperty("prepared_version")]
        public UIExtensionVersion PreparedVersion
        {
            get => preparedVersion;
            internal set => preparedVersion = value;
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

        #region Title

        /// <summary>
        /// The Title field is used to enter the text that is to be displayed as the section header above the UI extension when the UI extension is presented within a form.
        /// </summary>
        [JsonProperty("title")]
        public string Title
        {
            get => title;
            set => title = SetValue("title", title, value);
        }

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            activeVersion?.ResetPropertySerializationCollection();
            preparedVersion?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
