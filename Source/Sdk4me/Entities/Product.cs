using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/products/">product</see> object.
    /// </summary>
    public class Product : CustomFieldsBaseItem
    {
        private List<Attachment> attachments;
        private string brand;
        private string category;
        private ProductDepreciationMethod? depreciationMethod;
        private bool disabled;
        private Organization financialOwner;
        private string model;
        private string name;
        private string pictureUri;
        private string productID;
        private int? rate;
        private string recurrence;
        private string remarks;
        private List<AttachmentReference> remarksAttachments;
        private ProductRuleSet ruleSet;
        private float? salvageValue;
        private string salvageValueCurrency;
        private Service service;
        private string source;
        private string sourceID;
        private Organization supplier;
        private Team supportTeam;
        private UIExtension uiExtension;
        private int? usefulLife;
        private WorkflowTemplate workflowTemplate;
        private Person workflowManager;

        #region Attachments

        /// <summary>
        /// Readonly aggregated Attachments
        /// </summary>
        [JsonProperty("attachments")]
        public List<Attachment> Attachments
        {
            get => attachments;
            internal set => attachments = value;
        }

        #endregion

        #region Brand

        /// <summary>
        /// The Brand field is used to select a previously entered brand name or to enter a new one. The brand name is typically the name of the product’s manufacturer.
        /// </summary>
        [JsonProperty("brand")]
        public string Brand
        {
            get => brand;
            set => brand = SetValue("brand", brand, value);
        }

        #endregion

        #region Category

        /// <summary>
        /// The Category field is used to select the appropriate product category for the product.
        /// </summary>
        [JsonProperty("category")]
        public string Category
        {
            get => category;
            set => category = SetValue("category", category, value);
        }

        #endregion

        #region Depreciation method

        /// <summary>
        /// The Depreciation method field is used to specify whether or not configuration items that are based on the product are typically depreciated and if so, which depreciation method is normally applied. 
        /// </summary>
        [JsonProperty("depreciation_method")]
        public ProductDepreciationMethod? DepreciationMethod
        {
            get => depreciationMethod;
            set => depreciationMethod = SetValue("depreciation_method", depreciationMethod, value);
        }

        #endregion

        #region Disabled

        /// <summary>
        /// The Disabled box is checked when the product may no longer be used to register new configuration items.
        /// </summary>
        [JsonProperty("disabled")]
        public bool Disabled
        {
            get => disabled;
            set => disabled = SetValue("disabled", disabled, value);
        }

        #endregion

        #region Financial owner

        /// <summary>
        /// The Financial owner field is used to select the internal organization which budget is normally used to obtain the product.
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

        #region Model

        /// <summary>
        /// The Model field is used to enter the model of the product.
        /// </summary>
        [JsonProperty("model")]
        public string Model
        {
            get => model;
            set => model = SetValue("model", model, value);
        }

        #endregion

        #region Name

        /// <summary>
        /// The Name field is used to enter the name of the product. Fill out the Brand, Model, Product ID (optional) and Category fields to automatically generate a name based on the values entered in these fields.
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
        /// The hyperlink to the image file for the product.
        /// </summary>
        [JsonProperty("picture_uri")]
        public string PictureUri
        {
            get => pictureUri;
            set => pictureUri = SetValue("picture_uri", pictureUri, value);
        }

        #endregion

        #region ProductID

        /// <summary>
        /// The Product ID field is used to enter the unique identifier of the product that is used by the manufacturer.
        /// </summary>
        [JsonProperty("productID")]
        public string ProductID
        {
            get => productID;
            set => productID = SetValue("productID", productID, value);
        }

        #endregion

        #region Rate

        /// <summary>
        /// The Rate field is used to specify the yearly rate that should normally be applied to calculate the depreciation of configuration items that are based on the product using the reducing balance (or diminishing value) method.
        /// </summary>
        [JsonProperty("rate")]
        public int? Rate
        {
            get => rate;
            set => rate = SetValue("rate", rate, value);
        }

        #endregion

        #region Recurrence

        /// <summary>
        /// The recurrence settings hash, missing in case the reservation has no recurrence defined.<br>See <see href="https://developer.4me.com/v1/recurrences/">Recurrence</see> for the fields in the recurrence hash.</br> 
        /// </summary>
        [JsonProperty("recurrence")]
        public string Recurrence
        {
            get => recurrence;
            set => recurrence = SetValue("recurrence", recurrence, value);
        }

        #endregion

        #region Remarks

        /// <summary>
        /// The Remarks field is used to enter any additional information about the product that might prove useful.
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
        /// Write-only. Add a reference to an uploaded information attachment. Use <see cref="Attachments"/> to get the existing attachments.
        /// </summary>
        /// <param name="key">The attachment key.</param>
        /// <param name="fileSize">The attachment file size.</param>
        public void ReferenceRemarksAttachment(string key, long fileSize)
        {
            if (remarksAttachments == null)
                remarksAttachments = new List<AttachmentReference>();

            remarksAttachments.Add(new AttachmentReference()
            {
                Key = key,
                FileSize = fileSize,
                Inline = true
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
        /// The Rule set field is automatically set to the rule set of the related product category. 
        /// </summary>
        [JsonProperty("rule_set")]
        public ProductRuleSet RuleSet
        {
            get => ruleSet;
            internal set => ruleSet = value;
        }

        #endregion

        #region Salvage value

        /// <summary>
        /// The Salvage value field is used to enter the value for the configuration items based on this product at the end of its useful life (i.e. at the end of its depreciation period). When a value is not specified for this field, it is set to zero.
        /// </summary>
        [JsonProperty("salvage_value")]
        public float? SalvageValue
        {
            get => salvageValue;
            set => salvageValue = SetValue("salvage_value", salvageValue, value);
        }

        #endregion

        #region Salvage value currency

        /// <summary>
        /// The currency of the Salvage value field value of the configuration items based on this product. For valid values, see the list of currencies in the Currency field of the Account API.
        /// </summary>
        [JsonProperty("salvage_value_currency")]
        public string SalvageValueCurrency
        {
            get => salvageValueCurrency;
            set => salvageValueCurrency = SetValue("salvage_value_currency", salvageValueCurrency, value);
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

        #region Supplier

        /// <summary>
        /// The Supplier field is used to select the Organization from which the product is typically obtained. If the product is developed internally, select the internal organization that develops it. Note that a lease company should be selected in this field if the product is normally leased.
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

        #region UI extension

        /// <summary>
        /// The UI extension field is used to select the UI extension that is to be added to the configuration items that are based on the product.
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

        #region Useful life

        /// <summary>
        /// The Useful life field is used to enter the number of years within which configuration items that are based on the product are typically depreciated.
        /// </summary>
        [JsonProperty("useful_life")]
        public int? UsefulLife
        {
            get => usefulLife;
            set => usefulLife = SetValue("useful_life", usefulLife, value);
        }

        #endregion

        #region Workflow template

        /// <summary>
        /// The workflow template that is used to periodically maintain configuration items created from the product.
        /// </summary>
        [JsonProperty("workflow_template")]
        public WorkflowTemplate WorkflowTemplate
        {
            get => workflowTemplate;
            set => workflowTemplate = SetValue("workflow_template_id", workflowTemplate, value);
        }

        [JsonProperty("workflow_template_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? WorkflowTemplateID => workflowTemplate?.ID;

        #endregion

        #region Workflow manager

        /// <summary>
        /// The person who will be responsible for coordinating the workflows that will be generated automatically in accordance with the recurrence schedule.
        /// </summary>
        [JsonProperty("workflow_manager")]
        public Person WorkflowManager
        {
            get => workflowManager;
            set => workflowManager = SetValue("workflow_manager_id", workflowManager, value);
        }

        [JsonProperty("workflow_manager_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? WorkflowManagerID => workflowManager?.ID;

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            financialOwner?.ResetPropertySerializationCollection();
            service?.ResetPropertySerializationCollection();
            supplier?.ResetPropertySerializationCollection();
            supportTeam?.ResetPropertySerializationCollection();
            uiExtension?.ResetPropertySerializationCollection();
            WorkflowTemplate?.ResetPropertySerializationCollection();
            WorkflowManager?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
