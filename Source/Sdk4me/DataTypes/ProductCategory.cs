using Newtonsoft.Json;

namespace Sdk4me
{
    public class ProductCategory : BaseItem
    {
        private bool disabled;
        private string group;
        private string localizedGroup;
        private string localizedName;
        private string name;
        private string reference;
        private ProductRuleSetType? ruleSet;
        private string source;
        private string sourceID;

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

        #region group

        [JsonProperty("group")]
        public string Group
        {
            get => group;
            set
            {
                if (group != value)
                    AddIncludedDuringSerialization("group");
                group = value;
            }
        }

        #endregion

        #region localized_group

        [JsonProperty("localized_group"), Sdk4meIgnoreInFieldSelection()]
        public string LocalizedGroup
        {
            get => localizedGroup;
            internal set => localizedGroup = value;
        }

        #endregion

        #region localized_name

        [JsonProperty("localized_name"), Sdk4meIgnoreInFieldSelection()]
        public string LocalizedName
        {
            get => localizedName;
            internal set => localizedName = value;
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

        #region reference

        [JsonProperty("reference")]
        public string Reference
        {
            get => reference;
            internal set => reference = value;
        }

        #endregion

        #region rule_set

        [JsonProperty("rule_set")]
        public ProductRuleSetType? RuleSet
        {
            get => ruleSet;
            set
            {
                if (ruleSet != value)
                    AddIncludedDuringSerialization("rule_set");
                ruleSet = value;
            }
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
    }
}
