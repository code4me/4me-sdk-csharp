using Newtonsoft.Json;

namespace Sdk4me
{
    public class TimeAllocation : BaseItem
    {
        private TimeAllocationCustomerCategoryType? customerCategory;
        private TimeAllocationDescriptionCategoryType? descriptionCategory;
        private bool disabled;
        private string group;
        private string localizedGroup;
        private string localizedName;
        private string name;
        private TimeAllocationServiceCategoryType? serviceCategory;
        private string source;
        private string sourceID;

        #region customer_category

        [JsonProperty("customer_category")]
        public TimeAllocationCustomerCategoryType? CustomerCategory
        {
            get => customerCategory;
            set
            {
                if (customerCategory != value)
                    AddIncludedDuringSerialization("customer_category");
                customerCategory = value;
            }
        }

        #endregion

        #region description_category

        [JsonProperty("description_category")]
        public TimeAllocationDescriptionCategoryType? DescriptionCategory
        {
            get => descriptionCategory;
            set
            {
                if (descriptionCategory != value)
                    AddIncludedDuringSerialization("description_category");
                descriptionCategory = value;
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

        #region service_category

        [JsonProperty("service_category")]
        public TimeAllocationServiceCategoryType? ServiceCategory
        {
            get => serviceCategory;
            set
            {
                if (serviceCategory != value)
                    AddIncludedDuringSerialization("service_category");
                serviceCategory = value;
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
