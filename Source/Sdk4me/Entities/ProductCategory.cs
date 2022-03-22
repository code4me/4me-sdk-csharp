using Newtonsoft.Json;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/product_categories/">product category</see> object.
    /// </summary>
    public class ProductCategory : BaseItem
    {
        private bool disabled;
        private string group;
        private string localizedGroup;
        private string localizedName;
        private string name;
        private string pictureUri;
        private string reference;
        private ProductRuleSet? ruleSet;
        private string source;
        private string sourceID;
        private UIExtension uiExtension;

        #region Disabled

        /// <summary>
        /// The Disabled box is checked when the product category may not be related to any more products.
        /// </summary>
        [JsonProperty("disabled")]
        public bool Disabled
        {
            get => disabled;
            set => disabled = SetValue("disabled", disabled, value);
        }

        #endregion

        #region Group

        /// <summary>
        /// The Group field is used to include the product category in a group.
        /// </summary>
        [JsonProperty("group")]
        public string Group
        {
            get => group;
            set => group = SetValue("group", group, value);
        }

        #endregion

        #region Localized group

        /// <summary>
        /// Translated Group in the current language, defaults to group in case no translation is provided.
        /// </summary>
        [JsonProperty("localized_group"), Sdk4meIgnoreInFieldSelection()]
        public string LocalizedGroup
        {
            get => localizedGroup;
            internal set => localizedGroup = value;
        }

        #endregion

        #region Localized name

        /// <summary>
        /// Translated Name in the current language, defaults to name in case no translation is provided.
        /// </summary>
        [JsonProperty("localized_name"), Sdk4meIgnoreInFieldSelection()]
        public string LocalizedName
        {
            get => localizedName;
            internal set => localizedName = value;
        }

        #endregion

        #region Name

        /// <summary>
        /// The Name field is used to enter the name of the product category.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get => name;
            set => name = SetValue("name", name, value);
        }

        #endregion

        #region Picture uri

        /// <summary>
        /// The hyperlink to the image file for the product category.
        /// </summary>
        [JsonProperty("picture_uri")]
        public string PictureUri
        {
            get => pictureUri;
            set => pictureUri = SetValue("picture_uri", pictureUri, value);
        }

        #endregion

        #region Reference

        /// <summary>
        /// The Reference field is automatically set to the concatenation of the Group field value and the Name field value, separated by a forward slash, written in lower case characters and with all spaces replaced by an underscore character.
        /// </summary>
        [JsonProperty("reference")]
        public string Reference
        {
            get => reference;
            internal set => reference = value;
        }

        #endregion

        #region Rule set

        /// <summary>
        /// The Rule set field is used to select a set of rules that are to be applied to the products to which the product category is related, as well as the configuration items that are related to those products. The selected rule set dictates which fields are available for these product and configuration items. 
        /// </summary>
        [JsonProperty("rule_set")]
        public ProductRuleSet? RuleSet
        {
            get => ruleSet;
            set => ruleSet = SetValue("rule_set", ruleSet, value);
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

        #region UI extension

        /// <summary>
        /// The UI extension field is used to select the UI extension that is to be added to the products that are based on the product category.
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
    }
}
