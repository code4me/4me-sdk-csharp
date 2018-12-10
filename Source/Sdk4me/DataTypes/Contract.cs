using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    public class Contract : BaseItem
    {
        private List<Attachment> attachments;
        private ContractCategoryType? category;
        private Organization customer;
        private Person customerRep;
        private DateTime? expiryDate;
        private string name;
        private DateTime? noticeDate;
        private string remarks;
        private string source;
        private string sourceID;
        private DateTime? startDate;
        private ContractStatusType? status;
        private Organization supplier;
        private Person supplierContact;
        private string timeZone;
        private UIExtension uIExtension;
        private CustomFieldCollection customFields;

        #region attachments

        [JsonProperty("attachments")]
        public List<Attachment> Attachments
        {
            get => attachments;
            internal set => attachments = value;
        }

        #endregion

        #region category

        [JsonProperty("category")]
        public ContractCategoryType? Category
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

        #region customer

        [JsonProperty("customer")]
        public Organization Customer
        {
            get => customer;
            set
            {
                if (customer?.ID != value?.ID)
                    AddIncludedDuringSerialization("customer_id");
                customer = value;
            }
        }

        [JsonProperty(PropertyName = "customer_id"), Sdk4meIgnoreInFieldSelection()]
        private long? CustomerID
        {
            get => (customer != null ? customer.ID : (long?)null);
        }

        #endregion

        #region customer_rep

        [JsonProperty("customer_rep")]
        public Person CustomerRep
        {
            get => customerRep;
            set
            {
                if (customerRep?.ID != value?.ID)
                    AddIncludedDuringSerialization("customer_rep_id");
                customerRep = value;
            }
        }

        [JsonProperty(PropertyName = "customer_rep_id"), Sdk4meIgnoreInFieldSelection()]
        private long? CustomerRepID
        {
            get => (customerRep != null ? customerRep.ID : (long?)null);
        }

        #endregion

        #region expiry_date

        [JsonProperty("expiry_date")]
        public DateTime? ExpiryDate
        {
            get => expiryDate;
            set
            {
                if (expiryDate != value)
                    AddIncludedDuringSerialization("expiry_date");
                expiryDate = value;
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

        #region notice_date

        [JsonProperty("notice_date")]
        public DateTime? NoticeDate
        {
            get => noticeDate;
            set
            {
                if (noticeDate != value)
                    AddIncludedDuringSerialization("notice_date");
                noticeDate = value;
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
        public ContractStatusType? Status
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

        #region supplier_contact

        [JsonProperty("supplier_contact")]
        public Person SupplierContact
        {
            get => supplierContact;
            set
            {
                if (supplierContact?.ID != value?.ID)
                    AddIncludedDuringSerialization("supplier_contact_id");
                supplierContact = value;
            }
        }

        [JsonProperty(PropertyName = "supplier_contact_id"), Sdk4meIgnoreInFieldSelection()]
        private long? SupplierContactID
        {
            get => (supplierContact != null ? supplierContact.ID : (long?)null);
        }

        #endregion

        #region time_zone

        [JsonProperty("time_zone")]
        public string TimeZone
        {
            get => timeZone;
            set
            {
                if (timeZone != value)
                    AddIncludedDuringSerialization("time_zone");
                timeZone = value;
            }
        }

        #endregion

        #region ui_extension

        [JsonProperty("ui_extension")]
        public UIExtension UIExtension
        {
            get => uIExtension;
            internal set => uIExtension = value;
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
            get => customFields;
        }

        private void CustomFields_Changed(object sender, EventArgs e)
        {
            AddIncludedDuringSerialization("custom_fields");
        }

        #endregion

        internal override void ResetIncludedDuringSerialization()
        {
            if (attachments != null)
                for (int i = 0; i < attachments.Count; i++)
                    attachments[i]?.ResetIncludedDuringSerialization();

            customer?.ResetIncludedDuringSerialization();
            CustomerRep?.ResetIncludedDuringSerialization();
            supplier?.ResetIncludedDuringSerialization();
            supplierContact?.ResetIncludedDuringSerialization();
            uIExtension?.ResetIncludedDuringSerialization();
            base.ResetIncludedDuringSerialization();
        }
    }
}
