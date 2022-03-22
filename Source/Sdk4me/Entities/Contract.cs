using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/contracts/">contract</see> object.
    /// </summary>
    public class Contract : CustomFieldsBaseItem
    {
        private List<Attachment> attachments;
        private ContractCategory category;
        private Organization customer;
        private Person customerRep;
        private DateTime? expiryDate;
        private string name;
        private DateTime? noticeDate;
        private string remarks;
        private List<AttachmentReference> remarksAttachments;
        private string source;
        private string sourceID;
        private DateTime? startDate;
        private ContractStatus status;
        private Organization supplier;
        private Person supplierContact;
        private string timeZone;
        private UIExtension uiExtension;

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

        #region Category

        /// <summary>
        /// The Category field is used to select the appropriate category for the contract. 
        /// </summary>
        [JsonProperty("category")]
        public ContractCategory Category
        {
            get => category;
            set => category = SetValue("category", category, value);
        }

        #endregion

        #region Customer

        /// <summary>
        /// The Customer field is used to select the organization that pays for the contract.
        /// </summary>
        [JsonProperty("customer")]
        public Organization Customer
        {
            get => customer;
            set => customer = SetValue("customer_id", customer, value);
        }

        [JsonProperty("customer_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? CustomerID => customer?.ID;

        #endregion

        #region Customer rep

        /// <summary>
        /// The Customer representative field is used to select the person who represents the customer of the contract.
        /// </summary>
        [JsonProperty("customer_rep")]
        public Person CustomerRep
        {
            get => customerRep;
            set => customerRep = SetValue("customer_rep_id", customerRep, value);
        }

        [JsonProperty("customer_rep_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? CustomerRepID => customerRep?.ID;

        #endregion

        #region Expiry date

        /// <summary>
        /// The Expiry date field is used to specify the date through which the contract will be active. The contract expires at the end of this day if it is not renewed before then. When the contract has expired, its status will automatically be set to “Expired”.
        /// </summary>
        [JsonProperty("expiry_date")]
        public DateTime? ExpiryDate
        {
            get => expiryDate;
            set => expiryDate = SetValue("expiry_date", expiryDate, value);
        }

        #endregion

        #region Name

        /// <summary>
        /// The Name field is used to enter the name of the contract.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get => name;
            set => name = SetValue("name", name, value);
        }

        #endregion

        #region Notice date

        /// <summary>
        /// The Notice date field is used to specify the last day on which the supplier organization can still be contacted to terminate the contract to ensure that it expires on the intended expiry date.
        /// </summary>
        [JsonProperty("notice_date")]
        public DateTime? NoticeDate
        {
            get => noticeDate;
            set => noticeDate = SetValue("notice_date", noticeDate, value);
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

        #region Start date

        /// <summary>
        /// The Start date field is used to specify the first day during which the contract is active.
        /// </summary>
        [JsonProperty("start_date")]
        public DateTime? StartDate
        {
            get => startDate;
            set => startDate = SetValue("start_date", startDate, value);
        }

        #endregion

        #region Status

        /// <summary>
        /// The Status field displays the current status of the contract. The available options are:
        /// </summary>
        [JsonProperty("status")]
        public ContractStatus Status
        {
            get => status;
            set => status = SetValue("status", status, value);
        }

        #endregion

        #region Supplier

        /// <summary>
        /// The Supplier field is used to select the organization that has provided the contract to the customer.
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

        #region Supplier contact

        /// <summary>
        /// The Supplier contact field is used to select the person who represents the supplier of the contract.
        /// </summary>
        [JsonProperty("supplier_contact")]
        public Person SupplierContact
        {
            get => supplierContact;
            set => supplierContact = SetValue("supplier_contact_id", supplierContact, value);
        }

        [JsonProperty("supplier_contact_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? SupplierContactID => supplierContact?.ID;

        #endregion

        #region Time zone

        /// <summary>
        /// The Time zone field is used to select the time zone that applies to the start date, notice date and expiry date of the contract.
        /// </summary>
        [JsonProperty("time_zone")]
        public string TimeZone
        {
            get => timeZone;
            set => timeZone = SetValue("time_zone", timeZone, value);
        }

        #endregion

        #region UI extension

        /// <summary>
        /// The UI extension field indicates the UI extension that is applied to the contract.
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

        internal override void ResetPropertySerializationCollection()
        {
            customer?.ResetPropertySerializationCollection();
            customerRep?.ResetPropertySerializationCollection();
            supplier?.ResetPropertySerializationCollection();
            supplierContact?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
