using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sdk4me
{
    public class UIExtension : BaseItem
    {
        private bool? activate;
        private UIExtensionVersion activeVersion;
        private UIExtensionCategoryType category;
        private string compiledCSS;
        private string cSS;
        private bool disabled;
        private string hTML;
        private string javascript;
        private string localizedHtml;
        private string name;
        private List<string> phrases;
        private UIExtensionVersion preparedVersion;
        private string source;
        private string sourceID;
        private string title;

        #region activate

        [JsonProperty("activate")]
        public bool? Activate
        {
            get => activate;
            set
            {
                if (activate != value)
                    AddIncludedDuringSerialization("activate");
                activate = value;
            }
        }

        #endregion

        #region active_version

        [JsonProperty("active_version")]
        public UIExtensionVersion ActiveVersion
        {
            get => activeVersion;
            internal set => activeVersion = value;
        }

        #endregion

        #region category

        [JsonProperty("category")]
        public UIExtensionCategoryType Category
        {
            get => category;
            set
            {
                if (category != value)
                    AddIncludedDuringSerialization("category");
                category = value;
            }
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

        #region css

        [JsonProperty("css")]
        public string CSS
        {
            get => cSS;
            set
            {
                if (cSS != value)
                    AddIncludedDuringSerialization("css");
                cSS = value;
            }
        }

        #endregion

        #region disabled

        [JsonProperty("disabled")]
        public bool Disabled
        {
            get => disabled;
            set
            {
                if (disabled != value)
                    AddIncludedDuringSerialization("disabled");
                disabled = value;
            }
        }

        #endregion

        #region html

        [JsonProperty("html")]
        public string HTML
        {
            get => hTML;
            set
            {
                if (hTML != value)
                    AddIncludedDuringSerialization("html");
                hTML = value;
            }
        }

        #endregion

        #region javascript

        [JsonProperty("javascript")]
        public string Javascript
        {
            get => javascript;
            set
            {
                if (javascript != value)
                    AddIncludedDuringSerialization("javascript");
                javascript = value;
            }
        }

        #endregion

        #region localized_html

        [JsonProperty("localized_html"), Sdk4meIgnoreInFieldSelection()]
        public string LocalizedHtml
        {
            get => localizedHtml;
            internal set => localizedHtml = value;
        }

        #endregion

        #region name

        [JsonProperty("name")]
        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                    AddIncludedDuringSerialization("name");
                name = value;
            }
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

        #region prepared_version

        [JsonProperty("prepared_version")]
        public UIExtensionVersion PreparedVersion
        {
            get => preparedVersion;
            internal set => preparedVersion = value;
        }

        #endregion

        #region source

        [JsonProperty("source")]
        public string Source
        {
            get => source;
            set
            {
                if (source != value)
                    AddIncludedDuringSerialization("source");
                source = value;
            }
        }

        #endregion

        #region sourceID

        [JsonProperty("sourceID")]
        public string SourceID
        {
            get => sourceID;
            set
            {
                if (sourceID != value)
                    AddIncludedDuringSerialization("sourceID");
                sourceID = value;
            }
        }

        #endregion

        #region title

        [JsonProperty("title")]
        public string Title
        {
            get => title;
            set
            {
                if (title != value)
                    AddIncludedDuringSerialization("title");
                title = value;
            }
        }

        #endregion

        internal override void ResetIncludedDuringSerialization()
        {
            activeVersion?.ResetIncludedDuringSerialization();
            preparedVersion?.ResetIncludedDuringSerialization();
            base.ResetIncludedDuringSerialization();
        }
    }
}
