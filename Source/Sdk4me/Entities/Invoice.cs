using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/invoices/">invoice</see> object.
    /// </summary>
    public class Invoice : BaseItem
    {
        private float amount;
        private bool amortize;
        private DateTime? amortizationStart;
        private DateTime? amortizationEnd;
        private List<Attachment> attachments;
        private Workflow workflow;
        private Contract contract;
        private string currency;
        private InvoiceDepreciationMethod depreciationMethod;
        private DateTime? depreciationStart;
        private string description;
        private FirstLineSupportAgreement flsa;
        private DateTime invoiceDate;
        private string invoiceNr;
        private string invoiceType;
        private string poNr;
        private Project project;
        private float quantity;
        private int? rate;
        private string remarks;
        private List<AttachmentReference> remarksAttachments;
        private float? salvageValue;
        private string salvageValueCurrency;
        private ServiceLevelAgreement sla;
        private Service service;
        private string source;
        private string sourceID;
        private Organization supplier;
        private float? unitPrice;
        private int? usefulLife;

        #region Amount

        /// <summary>
        /// The Amount field contains the product of the Unit price field value and the Quantity field value.
        /// </summary>
        [JsonProperty("amount")]
        public float Amount
        {
            get => amount;
            internal set => amount = value;
        }

        #endregion

        #region Amortize

        /// <summary>
        /// Whether the invoice amount is to be amortized over time.
        /// </summary>
        [JsonProperty("amortize")]
        public bool Amortize
        {
            get => amortize;
            set => amortize = SetValue("amortize", amortize, value);
        }

        #endregion

        #region Amortization start

        /// <summary>
        /// The start date of the period over which the invoice is to be amortized.
        /// </summary>
        [JsonProperty("amortization_start")]
        public DateTime? AmortizationStart
        {
            get => amortizationStart;
            set => amortizationStart = SetValue("amortization_start", amortizationStart, value);
        }

        #endregion

        #region Amortization end

        /// <summary>
        /// The end date of the period over which the invoice is to be amortized.
        /// </summary>
        [JsonProperty("amortization_end")]
        public DateTime? AmortizationEnd
        {
            get => amortizationEnd;
            set => amortizationEnd = SetValue("amortization_end", amortizationEnd, value);
        }

        #endregion

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

        #region Workflow

        /// <summary>
        /// The workflow linked to this invoice.
        /// </summary>
        [JsonProperty("workflow"), Sdk4meIgnoreInFieldSelection()]
        public Workflow Workflow
        {
            get => workflow;
            set => workflow = SetValue("workflow_id", workflow, value);
        }

        [JsonProperty("workflow_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? WorkflowID => workflow?.ID;

        #endregion

        #region Contract

        /// <summary>
        /// The contract linked to this invoice.
        /// </summary>
        [JsonProperty("contract"), Sdk4meIgnoreInFieldSelection()]
        public Contract Contract
        {
            get => contract;
            set => contract = SetValue("contract_id", contract, value);
        }

        [JsonProperty("contract_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ContractID => contract?.ID;

        #endregion

        #region Currency

        /// <summary>
        /// The currency of the Amount field value of the invoice. For valid values, see the list of currencies in the Currency field of the Account API.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency
        {
            get => currency;
            set => currency = SetValue("currency", currency, value);
        }

        #endregion

        #region Depreciation method

        /// <summary>
        /// Whether or not the invoice should be depreciated and if so, which depreciation method is to be applied. When creating a new invoice and a value is not specified for this field, and the invoice is related to a configuration item, the value is set to the depreciation method of the product of the configuration item. 
        /// </summary>
        [JsonProperty("depreciation_method")]
        public InvoiceDepreciationMethod DepreciationMethod
        {
            get => depreciationMethod;
            set => depreciationMethod = SetValue("depreciation_method", depreciationMethod, value);
        }

        #endregion

        #region Depreciation start

        /// <summary>
        /// The date on which to start depreciating the asset.
        /// </summary>
        [JsonProperty("depreciation_start")]
        public DateTime? DepreciationStart
        {
            get => depreciationStart;
            set => depreciationStart = SetValue("depreciation_start", depreciationStart, value);
        }

        #endregion

        #region Description

        /// <summary>
        /// The Description field is used to enter a short description of what was acquired.
        /// </summary>
        [JsonProperty("description")]
        public string Description
        {
            get => description;
            set => description = SetValue("description", description, value);
        }

        #endregion

        #region First line support agreement

        /// <summary>
        /// The first line support agreement linked to this invoice.
        /// </summary>
        [JsonProperty("flsa"), Sdk4meIgnoreInFieldSelection()]
        public FirstLineSupportAgreement Flsa
        {
            get => flsa;
            set => flsa = SetValue("flsa_id", flsa, value);
        }

        [JsonProperty("flsa_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? FlsaID => flsa?.ID;

        #endregion

        #region Invoice date

        /// <summary>
        /// The Invoice date field is used to specify the date on which the invoice was sent out by the supplier.
        /// </summary>
        [JsonProperty("invoice_date")]
        public DateTime InvoiceDate
        {
            get => invoiceDate;
            set => invoiceDate = SetValue("invoice_date", invoiceDate, value);
        }

        #endregion

        #region Invoice number

        /// <summary>
        /// The Invoice number field is used to enter the invoice number that the supplier specified on the invoice.
        /// </summary>
        [JsonProperty("invoice_nr")]
        public string InvoiceNr
        {
            get => invoiceNr;
            set => invoiceNr = SetValue("invoice_nr", invoiceNr, value);
        }

        #endregion

        #region Invoice type

        /// <summary>
        /// The type of the record that is linked to the invoice. One of: workflow, project, sla, flsa, cis, contract
        /// </summary>
        [JsonProperty("invoice_type")]
        public string InvoiceType
        {
            get => invoiceType;
            internal set => invoiceType = value;
        }

        #endregion

        #region PO number

        /// <summary>
        /// The PO number field is used to enter the number of the purchase order that was sent to supplier.
        /// </summary>
        [JsonProperty("po_nr")]
        public string PoNr
        {
            get => poNr;
            set => poNr = SetValue("po_nr", poNr, value);
        }

        #endregion

        #region Project

        /// <summary>
        /// The Project field is set to the project for which the costs specified in the Amount field were incurred.
        /// </summary>
        [JsonProperty("project")]
        public Project Project
        {
            get => project;
            set => project = SetValue("project_id", project, value);
        }

        [JsonProperty("project_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ProjectID => project?.ID;

        #endregion

        #region Quantity

        /// <summary>
        /// The Quantity field is used to enter the number of units that were acquired.
        /// </summary>
        [JsonProperty("quantity")]
        public float Quantity
        {
            get => quantity;
            set => quantity = SetValue("quantity", quantity, value);
        }

        #endregion

        #region Rate

        /// <summary>
        /// The Rate field is used to specify the yearly rate that should be applied to calculate the depreciation of the linked configuration items using the reducing balance (or diminishing value) method. When creating a new invoice and a value is not specified for this field, it is set to the rate of the product that the configuration items belong to.
        /// </summary>
        [JsonProperty("rate")]
        public int? Rate
        {
            get => rate;
            set => rate = SetValue("rate", rate, value);
        }

        #endregion

        #region Remarks

        /// <summary>
        /// The Remarks field is used to add any additional information about the contract that might prove useful.
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

        #region Salvage value

        /// <summary>
        /// The value of this invoice at the end of its useful life (i.e. at the end of its depreciation period). When a value is not specified for this field, it is set to zero.
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
        /// The currency of the Salvage value field value of the invoice. For valid values, see the list of currencies in the Currency field of the Account API.
        /// </summary>
        [JsonProperty("salvage_value_currency")]
        public string SalvageValueCurrency
        {
            get => salvageValueCurrency;
            set => salvageValueCurrency = SetValue("salvage_value_currency", salvageValueCurrency, value);
        }

        #endregion

        #region SLA

        /// <summary>
        /// The service level agreement linked to this invoice.
        /// </summary>
        [JsonProperty("sla"), Sdk4meIgnoreInFieldSelection()]
        public ServiceLevelAgreement Sla
        {
            get => sla;
            set => sla = SetValue("sla_id", sla, value);
        }

        [JsonProperty("sla_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? SlaID => sla?.ID;

        #endregion

        #region Service

        /// <summary>
        /// The Service field is automatically set to the “service”:/help/service that is linked to the workflow, service level agreement, project or configuration item.
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
        /// The Supplier field is used to select the organization from which the invoice was received.
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

        #region Unit price

        /// <summary>
        /// The Unit price field is used to enter the amount that the supplier has charged per unit that was acquired.
        /// </summary>
        [JsonProperty("unit_price")]
        public float? UnitPrice
        {
            get => unitPrice;
            set => unitPrice = SetValue("unit_price", unitPrice, value);
        }

        #endregion

        #region Useful life

        /// <summary>
        /// The Useful life field is used to enter the number of years within which the linked configuration items are to be depreciated. When creating a new invoice and a value is not specified for this field, it is set to the useful life of the product that the configuration items belong to.
        /// </summary>
        [JsonProperty("useful_life")]
        public int? UsefulLife
        {
            get => usefulLife;
            set => usefulLife = SetValue("useful_life", usefulLife, value);
        }

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            workflow?.ResetPropertySerializationCollection();
            contract?.ResetPropertySerializationCollection();
            flsa?.ResetPropertySerializationCollection();
            project?.ResetPropertySerializationCollection();
            sla?.ResetPropertySerializationCollection();
            service?.ResetPropertySerializationCollection();
            supplier?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
