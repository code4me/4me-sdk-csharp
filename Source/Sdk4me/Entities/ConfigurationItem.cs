using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/configuration_items/">configuration item</see> object.
    /// </summary>
    public class ConfigurationItem : CustomFieldsBaseItem
    {
        private List<string> alternateNames;
        private string assetID;
        private List<Attachment> attachments;
        private Organization financialOwner;
        private DateTime? inUseSince;
        private string label;
        private DateTime? licenseExpiryDate;
        private ConfigurationitemLicenseType? licenseType;
        private string location;
        private string name;
        private int? nrOfCores;
        private int? nrOfLicenses;
        private int? nrOfProcessors;
        private Product product;
        private string remarks;
        private List<AttachmentReference> remarksAttachments;
        private ConfigurationItemRuleSet ruleSet;
        private string serialNr;
        private Service service;
        private Site site;
        private bool? siteLicense;
        private string source;
        private string sourceID;
        private ConfigurationItemStatus status;
        private Organization supplier;
        private Team supportTeam;
        private string systemID;
        private bool? temporaryLicense;
        private DateTime? warrantyExpiryDate;

        #region Alternate names

        /// <summary>
        /// Alternate names a software configuration item is also known by.
        /// </summary>
        [JsonProperty("alternate_names")]
        public List<string> AlternateNames
        {
            get => alternateNames;
            set => alternateNames = SetValue("alternate_names", alternateNames, value);
        }

        #endregion

        #region AssetID

        /// <summary>
        /// The asset identifier.
        /// </summary>
        [JsonProperty("assetID")]
        public string AssetID
        {
            get => assetID;
            set => assetID = SetValue("assetID", assetID, value);
        }

        #endregion

        #region Attachments

        /// <summary>
        /// Readonly aggregated Attachments.
        /// </summary>
        [JsonProperty("attachments")]
        public List<Attachment> Attachments
        {
            get => attachments;
            internal set => attachments = value;
        }

        #endregion

        #region Financial owner

        /// <summary>
        /// The Financial owner field is used to select the internal organization which budget is used to pay for the configuration item. If the CI is leased or rented, the organization that pays the lease or rent is selected in this field. When creating a new CI and a value is not specified for this field, it is set to the financial owner of the CI’s product.
        /// </summary>
        [JsonProperty("financial_owner")]
        public Organization FinancialOwner
        {
            get => financialOwner;
            set => financialOwner = SetValue("financial_owner_id", financialOwner, value);
        }

        [JsonProperty("financial_owner_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? FinancialOwnerID => financialOwner?.ID;

        #endregion

        #region In use since

        /// <summary>
        /// The In use since field is used to specify the date on which the expense for the configuration item (CI) was incurred or, if the CI is depreciated over time, the date on which the depreciation was started. This is typically the invoice date.
        /// </summary>
        [JsonProperty("in_use_since")]
        public DateTime? InUseSince
        {
            get => inUseSince;
            set => inUseSince = SetValue("in_use_since", inUseSince, value);
        }

        #endregion

        #region Label

        /// <summary>
        /// The Label field is used to specify the label that is attached to the configuration item (CI). A label is automatically generated using the same prefix of other CIs of the same product category, followed by the next available number as the suffix.
        /// </summary>
        [JsonProperty("label")]
        public string Label
        {
            get => label;
            set => label = SetValue("label", label, value);
        }

        #endregion

        #region License expiry date

        /// <summary>
        /// The License expiry date field is used to specify the date through which the temporary software license certificate is valid. The license certificate expires at the end of this day.
        /// </summary>
        [JsonProperty("license_expiry_date")]
        public DateTime? LicenseExpiryDate
        {
            get => licenseExpiryDate;
            set => licenseExpiryDate = SetValue("license_expiry_date", licenseExpiryDate, value);
        }

        #endregion

        #region License type

        /// <summary>
        /// The License type field is used to select the type of license that the license certificate covers. 
        /// </summary>
        [JsonProperty("license_type")]
        public ConfigurationitemLicenseType? LicenseType
        {
            get => licenseType;
            set => licenseType = SetValue("license_type", licenseType, value);
        }

        #endregion

        #region Location

        /// <summary>
        /// The Location field is used to enter the name or number of the room in which the CI is located, if it concerns a hardware CI.
        /// </summary>
        [JsonProperty("location")]
        public string Location
        {
            get => location;
            set => location = SetValue("location", location, value);
        }

        #endregion

        #region Name

        /// <summary>
        /// The Name field is used to enter the name of the configuration item (CI). When creating a new CI and a value is not specified for this field, it is set to the name of the CI’s product.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get => name;
            set => name = SetValue("name", name, value);
        }

        #endregion

        #region Number of cores

        /// <summary>
        /// The Number of cores field is used to enter the total number of processor cores that are installed in the server.
        /// </summary>
        [JsonProperty("nr_of_cores")]
        public int? NumberOfCores
        {
            get => nrOfCores;
            set => nrOfCores = SetValue("nr_of_cores", nrOfCores, value);
        }

        #endregion

        #region Number of licenses

        /// <summary>
        /// The Number of licenses field is used to enter the number of licenses that the license certificate covers.
        /// </summary>
        [JsonProperty("nr_of_licenses")]
        public int? NumberOfLicenses
        {
            get => nrOfLicenses;
            set => nrOfLicenses = SetValue("nr_of_licenses", nrOfLicenses, value);
        }

        #endregion

        #region Number of processors

        /// <summary>
        /// The Number of processors field is used to enter the number of processors that are installed in the server.
        /// </summary>
        [JsonProperty("nr_of_processors")]
        public int? NumberOfProcessors
        {
            get => nrOfProcessors;
            set => nrOfProcessors = SetValue("nr_of_processors", nrOfProcessors, value);
        }

        #endregion

        #region Product

        /// <summary>
        /// The Product field can be used to relate the configuration item to a different product.
        /// </summary>
        [JsonProperty("product")]
        public Product Product
        {
            get => product;
            set => product = SetValue("product_id", product, value);
        }

        [JsonProperty("product_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ProductID => product?.ID;

        #endregion

        #region Remarks

        /// <summary>
        /// The Remarks field is used to add any additional information about the configuration item that might prove useful. When creating a new CI and a value is not specified for this field, it is set to the remarks of the CI’s product.
        /// </summary>
        [JsonProperty("remarks")]
        public string Remarks
        {
            get => remarks;
            set => remarks = SetValue("remarks", remarks, value);
        }

        #endregion

        #region Remarks attachment

        /// <summary>
        /// Write-only. Add a reference to an uploaded attachment. Use <see cref="Attachments"/> to get the existing attachments.
        /// </summary>
        /// <param name="key">The attachment key.</param>
        /// <param name="fileSize">The attachment file size.</param>
        /// <param name="inline">True if this an in-line attachment; otherwise false.</param>
        public void ReferenceRemarksAttachment(string key, long fileSize, bool inline = false)
        {
            if (remarksAttachments == null)
                remarksAttachments = new List<AttachmentReference>();

            remarksAttachments.Add(new AttachmentReference()
            {
                Key = key,
                FileSize = fileSize,
                Inline = inline
            });

            base.PropertySerializationCollection.Add("remarks_attachments");
        }

        [JsonProperty("remarks_attachments"), Sdk4meIgnoreInFieldSelection()]
        internal List<AttachmentReference> RemarksAttachments
        {
            get => remarksAttachments;
        }

        #endregion

        #region Rule set

        /// <summary>
        /// The Rule set field is automatically set to the rule set of the related product’s product category, except when the CI is a license certificate, in which case the rule set is license_certificate. 
        /// </summary>
        [JsonProperty("rule_set")]
        public ConfigurationItemRuleSet RuleSet
        {
            get => ruleSet;
            internal set => ruleSet = value;
        }

        #endregion

        #region Serial number

        /// <summary>
        /// The serial number.
        /// </summary>
        [JsonProperty("serial_nr")]
        public string SerialNr
        {
            get => serialNr;
            set => serialNr = SetValue("serial_nr", serialNr, value);
        }

        #endregion

        #region Service

        /// <summary>
        /// The Service field is used to select the Service which service instance(s) the configuration item is, or will be, a part of.
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

        #region Site

        /// <summary>
        /// The Site field is used to select the Site at which the CI is located, if it concerns a hardware CI.
        /// </summary>
        [JsonProperty("site")]
        public Site Site
        {
            get => site;
            set => site = SetValue("site_id", site, value);
        }

        [JsonProperty("site_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? SiteID => site?.ID;

        #endregion

        #region Site license

        /// <summary>
        /// The Site license box is checked for license certificates that may only be used at one or more specific locations.
        /// </summary>
        [JsonProperty("site_license")]
        public bool? SiteLicense
        {
            get => siteLicense;
            set => siteLicense = SetValue("site_license", siteLicense, value);
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

        #region Status

        /// <summary>
        /// The Status field is used to select the appropriate status for the configuration item (CI). 
        /// </summary>
        [JsonProperty("status")]
        public ConfigurationItemStatus Status
        {
            get => status;
            set => status = SetValue("status", status, value);
        }

        #endregion

        #region Supplier

        /// <summary>
        /// The Supplier field is used to select the supplier from which the configuration item (CI) has been obtained. When creating a new CI and a value is not specified for this field, it is set to the supplier of the CI’s product.
        /// </summary>
        [JsonProperty("supplier")]
        public Organization Supplier
        {
            get => supplier;
            set => supplier = SetValue("supplier_id", supplier, value);
        }

        [JsonProperty("supplier_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? SupplierID => supplier?.ID;

        #endregion

        #region Support team

        /// <summary>
        /// The Support team field is used to select the Team responsible for supporting the configuration item and maintaining its information in the configuration management database (CMDB). When creating a new CI and a value is not specified for this field, it is set to the support team of the CI’s product. Optional when status of CI equals “Removed”, required otherwise.
        /// </summary>
        [JsonProperty("support_team")]
        public Team SupportTeam
        {
            get => supportTeam;
            set => supportTeam = SetValue("support_team_id", supportTeam, value);
        }

        [JsonProperty("support_team_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? SupportTeamID => supportTeam?.ID;

        #endregion

        #region SystemID

        /// <summary>
        /// The system identifier.
        /// </summary>
        [JsonProperty("systemID")]
        public string SystemID
        {
            get => systemID;
            set => systemID = SetValue("systemID", systemID, value);
        }

        #endregion

        #region Temporary license

        /// <summary>
        /// The Temporary license box is checked for license certificates that are not valid indefinitely.
        /// </summary>
        [JsonProperty("temporary_license")]
        public bool? TemporaryLicense
        {
            get => temporaryLicense;
            set => temporaryLicense = SetValue("temporary_license", temporaryLicense, value);
        }

        #endregion

        #region Warranty expiry date

        /// <summary>
        /// The Warranty expiry date field is used to specify the date through which the warranty coverage for the configuration item is valid. The warranty expires at the end of this day.
        /// </summary>
        [JsonProperty("warranty_expiry_date")]
        public DateTime? WarrantyExpiryDate
        {
            get => warrantyExpiryDate;
            set => warrantyExpiryDate = SetValue("warranty_expiry_date", warrantyExpiryDate, value);
        }

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            financialOwner?.ResetPropertySerializationCollection();
            product?.ResetPropertySerializationCollection();
            service?.ResetPropertySerializationCollection();
            supplier?.ResetPropertySerializationCollection();
            supportTeam?.ResetPropertySerializationCollection();
            site?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
