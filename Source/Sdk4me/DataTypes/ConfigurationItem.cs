using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    public class ConfigurationItem : BaseItem
    {
        private string assetID;
        private ConfigurationItemDepreciationMethodType? depreciationMethod;
        private Organization financialOwner;
        private string label;
        private DateTime? licenseExpiryDate;
        private ConfigurationitemLicenseType? licenseType;
        private string location;
        private string name;
        private int? numberOfCores;
        private int? numberOfLicenses;
        private int? numberOfProcessors;
        private string poNr;
        private Product product;
        private float? purchaseValue;
        private int? rate;
        private string remarks;
        private ConfigurationItemRuleSetType? ruleSet;
        private float? salvageValue;
        private string serialNr;
        private Service service;
        private Site site;
        private bool? siteLicense;
        private string source;
        private string sourceID;
        private DateTime? startDate;
        private ConfigurationItemStatusType? status;
        private Organization supplier;
        private Team supportTeam;
        private string systemID;
        private bool? temporaryLicense;
        private int? usefulLife;
        private DateTime? warrantyExpiryDate;
        private CustomFieldCollection customFields;

        #region assetID

        [JsonProperty("assetID")]
        public string AssetID
        {
            get => assetID;
            set
            {
                if (assetID != value)
                    AddIncludedDuringSerialization("assetID");
                assetID = value;
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

        #region label

        [JsonProperty("label")]
        public string Label
        {
            get => label;
            set
            {
                if (label != value)
                    AddIncludedDuringSerialization("label");
                label = value;
            }
        }

        #endregion

        #region license_expiry_date

        [JsonProperty("license_expiry_date")]
        public DateTime? LicenseExpiryDate
        {
            get => licenseExpiryDate;
            set
            {
                if (licenseExpiryDate != value)
                    AddIncludedDuringSerialization("license_expiry_date");
                licenseExpiryDate = value;
            }
        }

        #endregion

        #region license_type

        [JsonProperty("license_type")]
        public ConfigurationitemLicenseType? LicenseType
        {
            get => licenseType;
            set
            {
                if (licenseType != value)
                    AddIncludedDuringSerialization("license_type");
                licenseType = value;
            }
        }

        #endregion

        #region location

        [JsonProperty("location")]
        public string Location
        {
            get => location;
            set
            {
                if (location != value)
                    AddIncludedDuringSerialization("location");
                location = value;
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

        #region nr_of_cores

        [JsonProperty("nr_of_cores")]
        public int? NumberOfCores
        {
            get => numberOfCores;
            set
            {
                if (numberOfCores != value)
                    AddIncludedDuringSerialization("nr_of_cores");
                numberOfCores = value;
            }
        }

        #endregion

        #region nr_of_licenses

        [JsonProperty("nr_of_licenses")]
        public int? NumberOfLicenses
        {
            get => numberOfLicenses;
            set
            {
                if (numberOfLicenses != value)
                    AddIncludedDuringSerialization("nr_of_licenses");
                numberOfLicenses = value;
            }
        }

        #endregion

        #region nr_of_processors

        [JsonProperty("nr_of_processors")]
        public int? NumberOfProcessors
        {
            get => numberOfProcessors;
            set
            {
                if (numberOfProcessors != value)
                    AddIncludedDuringSerialization("nr_of_processors");
                numberOfProcessors = value;
            }
        }

        #endregion

        #region po_nr

        [JsonProperty("po_nr")]
        public string PoNr
        {
            get => poNr;
            set
            {
                if (poNr != value)
                    AddIncludedDuringSerialization("po_nr");
                poNr = value;
            }
        }

        #endregion

        #region product

        [JsonProperty("product")]
        public Product Product
        {
            get => product;
            set
            {
                if (product?.ID != value?.ID)
                    AddIncludedDuringSerialization("product_id");
                product = value;
            }
        }

        [JsonProperty(PropertyName = "product_id"), Sdk4meIgnoreInFieldSelection()]
        private long? ProductID
        {
            get => (product != null ? product.ID : (long?)null);
        }

        #endregion

        #region purchase_value

        [JsonProperty("purchase_value")]
        public float? PurchaseValue
        {
            get => purchaseValue;
            set
            {
                if (purchaseValue != value)
                    AddIncludedDuringSerialization("purchase_value");
                purchaseValue = value;
            }
        }

        #endregion

        #region rate

        [JsonProperty("rate")]
        public int? Rate
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
        public ConfigurationItemRuleSetType? RuleSet
        {
            get => ruleSet;
            internal set => ruleSet = value;
        }

        #endregion

        #region salvage_value

        [JsonProperty("salvage_value")]
        public float? SalvageValue
        {
            get => salvageValue;
            set
            {
                if (salvageValue != value)
                    AddIncludedDuringSerialization("salvage_value");
                salvageValue = value;
            }
        }

        #endregion

        #region serial_nr

        [JsonProperty("serial_nr")]
        public string SerialNr
        {
            get => serialNr;
            set
            {
                if (serialNr != value)
                    AddIncludedDuringSerialization("serial_nr");
                serialNr = value;
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

        #region site

        [JsonProperty("site")]
        public Site Site
        {
            get => site;
            set
            {
                if (site?.ID != value?.ID)
                    AddIncludedDuringSerialization("site_id");
                site = value;
            }
        }

        [JsonProperty(PropertyName = "site_id"), Sdk4meIgnoreInFieldSelection()]
        private long? SiteID
        {
            get => (site != null ? site.ID : (long?)null);
        }

        #endregion

        #region site_license

        [JsonProperty("site_license")]
        public bool? SiteLicense
        {
            get => siteLicense;
            set
            {
                if (siteLicense != value)
                    AddIncludedDuringSerialization("site_license");
                siteLicense = value;
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

        #region start_date

        [JsonProperty("start_date")]
        public DateTime? StartDate
        {
            get => startDate;
            set
            {
                if (startDate != value)
                    AddIncludedDuringSerialization("start_date");
                startDate = value;
            }
        }

        #endregion

        #region status

        [JsonProperty("status")]
        public ConfigurationItemStatusType? Status
        {
            get => status;
            set
            {
                if (status != value)
                    AddIncludedDuringSerialization("status");
                status = value;
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

        #region systemID

        [JsonProperty("systemID")]
        public string SystemID
        {
            get => systemID;
            set
            {
                if (systemID != value)
                    AddIncludedDuringSerialization("systemID");
                systemID = value;
            }
        }

        #endregion

        #region temporary_license

        [JsonProperty("temporary_license")]
        public bool? TemporaryLicense
        {
            get => temporaryLicense;
            set
            {
                if (temporaryLicense != value)
                    AddIncludedDuringSerialization("temporary_license");
                temporaryLicense = value;
            }
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

        #region warranty_expiry_date

        [JsonProperty("warranty_expiry_date")]
        public DateTime? WarrantyExpiryDate
        {
            get => warrantyExpiryDate;
            set
            {
                if (warrantyExpiryDate != value)
                    AddIncludedDuringSerialization("warranty_expiry_date");
                warrantyExpiryDate = value;
            }
        }

        #endregion

        #region custom_fields

        [JsonProperty("custom_fields")]
        private List<CustomField> CustomFieldsPrivate
        {
            get => customFields?.GetCustomFields();
            set
            {
                customFields = new CustomFieldCollection(value);
                customFields.Changed += CustomFields_Changed;
            }
        }

        [JsonIgnore(), Sdk4meIgnoreInFieldSelection()]
        public CustomFieldCollection CustomFields
        {
            get
            {
                if (customFields == null)
                {
                    customFields = new CustomFieldCollection();
                    customFields.Changed += CustomFields_Changed;
                }
                return customFields;
            }
        }

        private void CustomFields_Changed(object sender, EventArgs e)
        {
            AddIncludedDuringSerialization("custom_fields");
        }

        #endregion

        internal override void ResetIncludedDuringSerialization()
        {
            financialOwner?.ResetIncludedDuringSerialization();
            product?.ResetIncludedDuringSerialization();
            service?.ResetIncludedDuringSerialization();
            site?.ResetIncludedDuringSerialization();
            supplier?.ResetIncludedDuringSerialization();
            supportTeam?.ResetIncludedDuringSerialization();
            base.ResetIncludedDuringSerialization();
        }
    }
}
