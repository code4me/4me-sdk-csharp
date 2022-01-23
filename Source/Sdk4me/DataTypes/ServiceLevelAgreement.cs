using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    public class ServiceLevelAgreement : BaseItem
    {
        private List<Attachment> attachments;
        private SLACoverageType? coverage;
        private Organization customer;
        private Person customerRep;
        private DateTime? expiryDate;
        private string name;
        private DateTime? noticeDate;
        private string remarks;
        private ServiceInstance serviceInstance;
        private Person serviceLevelManager;
        private ServiceOffering serviceOffering;
        private string source;
        private string sourceID;
        private DateTime? startDate;
        private ServiceLevelAgreementStatusType? status;

        #region attachments

        [JsonProperty("attachments")]
        public List<Attachment> Attachments
        {
            get => attachments;
            internal set => attachments = value;
        }

        #endregion

        #region coverage

        [JsonProperty("coverage")]
        public SLACoverageType? Coverage
        {
            get => coverage;
            set
            {
                if (coverage != value)
                    AddIncludedDuringSerialization("coverage");
                coverage = value;
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

        #region service_instance

        [JsonProperty("service_instance")]
        public ServiceInstance ServiceInstance
        {
            get => serviceInstance;
            set
            {
                if (serviceInstance?.ID != value?.ID)
                    AddIncludedDuringSerialization("service_instance_id");
                serviceInstance = value;
            }
        }

        [JsonProperty(PropertyName = "service_instance_id"), Sdk4meIgnoreInFieldSelection()]
        private long? ServiceInstanceID
        {
            get => (serviceInstance != null ? serviceInstance.ID : (long?)null);
        }

        #endregion

        #region service_level_manager

        [JsonProperty("service_level_manager")]
        public Person ServiceLevelManager
        {
            get => serviceLevelManager;
            set
            {
                if (serviceLevelManager?.ID != value?.ID)
                    AddIncludedDuringSerialization("service_level_manager_id");
                serviceLevelManager = value;
            }
        }

        [JsonProperty(PropertyName = "service_level_manager_id"), Sdk4meIgnoreInFieldSelection()]
        private long? ServiceLevelManagerID
        {
            get => (serviceLevelManager != null ? serviceLevelManager.ID : (long?)null);
        }

        #endregion

        #region service_offering

        [JsonProperty("service_offering")]
        public ServiceOffering ServiceOffering
        {
            get => serviceOffering;
            set
            {
                if (serviceOffering?.ID != value?.ID)
                    AddIncludedDuringSerialization("service_offering_id");
                serviceOffering = value;
            }
        }

        [JsonProperty(PropertyName = "service_offering_id"), Sdk4meIgnoreInFieldSelection()]
        private long? ServiceOfferingID
        {
            get => (serviceOffering != null ? serviceOffering.ID : (long?)null);
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
        public ServiceLevelAgreementStatusType? Status
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

        internal override void ResetIncludedDuringSerialization()
        {
            if (attachments != null)
                for (int i = 0; i < attachments.Count; i++)
                    attachments[i]?.ResetIncludedDuringSerialization();

            customer?.ResetIncludedDuringSerialization();
            customerRep?.ResetIncludedDuringSerialization();
            serviceInstance?.ResetIncludedDuringSerialization();
            serviceLevelManager?.ResetIncludedDuringSerialization();
            serviceOffering?.ResetIncludedDuringSerialization();
            base.ResetIncludedDuringSerialization();
        }
    }
}
