using Newtonsoft.Json;

namespace Sdk4me
{
    public class Product : BaseItem
    {
        private string brand;
        private string category;
        private ConfigurationItemDepreciationMethodType? depreciationMethod;
        private bool disabled;
        private Organization financialOwner;
        private string model;
        private string name;
        private string pictureUri;
        private string productID;
        private float? rate;
        private string remarks;
        private ProductRuleSetType? ruleSet;
        private Service service;
        private string source;
        private string sourceID;
        private Organization supplier;
        private Team supportTeam;
        private UIExtension uIExtension;
        private int? usefulLife;

        #region brand

        [JsonProperty("brand")]
        public string Brand
        {
            get => brand;
            set
            {
                if (brand != value)
                    AddIncludedDuringSerialization("brand");
                brand = value;
            }
        }

        #endregion

        #region category

        [JsonProperty("category")]
        public string Category
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

        #region depreciation_method

        [JsonProperty("depreciation_method")]
        public ConfigurationItemDepreciationMethodType? DepreciationMethod
        {
            get => depreciationMethod;
            set
            {
                if (depreciationMethod != value)
                    AddIncludedDuringSerialization("depreciation_method");
                depreciationMethod = value;
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

        #region financial_owner

        [JsonProperty("financial_owner")]
        public Organization FinancialOwner
        {
            get => financialOwner;
            set
            {
                if (financialOwner?.ID != value?.ID)
                    AddIncludedDuringSerialization("financial_owner_id");
                financialOwner = value;
            }
        }

        [JsonProperty(PropertyName = "financial_owner_id"), Sdk4meIgnoreInFieldSelection()]
        private long? FinancialOwnerID
        {
            get => (financialOwner != null ? financialOwner.ID : (long?)null);
        }

        #endregion

        #region model

        [JsonProperty("model")]
        public string Model
        {
            get => model;
            set
            {
                if (model != value)
                    AddIncludedDuringSerialization("model");
                model = value;
            }
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

        #region picture_uri

        [JsonProperty("picture_uri")]
        public string PictureUri
        {
            get => pictureUri;
            set
            {
                if (pictureUri != value)
                    AddIncludedDuringSerialization("picture_uri");
                pictureUri = value;
            }
        }

        #endregion

        #region productID

        [JsonProperty("productID")]
        public string ProductID
        {
            get => productID;
            set
            {
                if (productID != value)
                    AddIncludedDuringSerialization("productID");
                productID = value;
            }
        }

        #endregion

        #region rate

        [JsonProperty("rate")]
        public float? Rate
        {
            get => rate;
            set
            {
                if (rate != value)
                    AddIncludedDuringSerialization("rate");
                rate = value;
            }
        }

        #endregion

        #region remarks

        [JsonProperty("remarks")]
        public string Remarks
        {
            get => remarks;
            set
            {
                if (remarks != value)
                    AddIncludedDuringSerialization("remarks");
                remarks = value;
            }
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

        #region service

        [JsonProperty("service")]
        public Service Service
        {
            get => service;
            set
            {
                if (service?.ID != value?.ID)
                    AddIncludedDuringSerialization("service_id");
                service = value;
            }
        }

        [JsonProperty(PropertyName = "service_id"), Sdk4meIgnoreInFieldSelection()]
        private long? ServiceID
        {
            get => (service != null ? service.ID : (long?)null);
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

        #region supplier

        [JsonProperty("supplier")]
        public Organization Supplier
        {
            get => supplier;
            set
            {
                if (supplier?.ID != value?.ID)
                    AddIncludedDuringSerialization("supplier_id");
                supplier = value;
            }
        }

        [JsonProperty(PropertyName = "supplier_id"), Sdk4meIgnoreInFieldSelection()]
        private long? SupplierID
        {
            get => (supplier != null ? supplier.ID : (long?)null);
        }

        #endregion

        #region support_team

        [JsonProperty("support_team")]
        public Team SupportTeam
        {
            get => supportTeam;
            set
            {
                if (supportTeam?.ID != value?.ID)
                    AddIncludedDuringSerialization("support_team_id");
                supportTeam = value;
            }
        }

        [JsonProperty(PropertyName = "support_team_id"), Sdk4meIgnoreInFieldSelection()]
        private long? SupportTeamID
        {
            get => (supportTeam != null ? supportTeam.ID : (long?)null);
        }

        #endregion

        #region ui_extension

        [JsonProperty("ui_extension")]
        public UIExtension UIExtension
        {
            get => uIExtension;
            set
            {
                if (uIExtension?.ID != value?.ID)
                    AddIncludedDuringSerialization("ui_extension_id");
                uIExtension = value;
            }
        }

        [JsonProperty(PropertyName = "ui_extension_id"), Sdk4meIgnoreInFieldSelection()]
        private long? UIExtensionID
        {
            get => (uIExtension != null ? uIExtension.ID : (long?)null);
        }

        #endregion

        #region useful_life

        [JsonProperty("useful_life")]
        public int? UsefulLife
        {
            get => usefulLife;
            set
            {
                if (usefulLife != value)
                    AddIncludedDuringSerialization("useful_life");
                usefulLife = value;
            }
        }

        #endregion

        internal override void ResetIncludedDuringSerialization()
        {
            financialOwner?.ResetIncludedDuringSerialization();
            service?.ResetIncludedDuringSerialization();
            supplier?.ResetIncludedDuringSerialization();
            supportTeam?.ResetIncludedDuringSerialization();
            uIExtension?.ResetIncludedDuringSerialization();
            base.ResetIncludedDuringSerialization();
        }
    }
}
