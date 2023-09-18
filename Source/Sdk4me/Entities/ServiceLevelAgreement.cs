using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/service_level_agreements/">service level agreement</see> object.
    /// </summary>
    public class ServiceLevelAgreement : BaseItem
    {
        private string activityidLow;
        private string activityidMedium;
        private string activityidHigh;
        private string activityidTop;
        private string activityidRfc;
        private string activityidRfi;
        private List<Attachment> attachments;
        private string agreementID;
        private ServiceLevelCoverage? coverage;
        private Organization customer;
        private AccountReference customerAccount;
        private List<Person> customerRepresentatives;
        private DateTime? expiryDate;
        private string name;
        private DateTime? noticeDate;
        private string remarks;
        private List<AttachmentReference> remarksAttachments;
        private ServiceInstance serviceInstance;
        private Person serviceLevelManager;
        private ServiceOffering serviceOffering;
        private string source;
        private string sourceID;
        private DateTime? startDate;
        private ServiceLevelAgreementStatus? status;
        private bool useKnowledgeFromServiceProvider;

        #region Activityid low

        /// <summary>
        /// Represents the activityID for low incidents. The Activity ID is the unique identifier by which an activity that is performed in the context of a service offering is known in the billing system of the service provider.
        /// </summary>
        [JsonProperty("activityID_low")]
        public string ActivityidLow
        {
            get => activityidLow;
            set => activityidLow = SetValue("activityID_low", activityidLow, value);
        }

        #endregion

        #region Activityid medium

        /// <summary>
        /// Represents the activityID for medium incidents. The Activity ID is the unique identifier by which an activity that is performed in the context of a service offering is known in the billing system of the service provider.
        /// </summary>
        [JsonProperty("activityID_medium")]
        public string ActivityidMedium
        {
            get => activityidMedium;
            set => activityidMedium = SetValue("activityID_medium", activityidMedium, value);
        }

        #endregion

        #region Activityid high

        /// <summary>
        /// Represents the activityID for high incidents. The Activity ID is the unique identifier by which an activity that is performed in the context of a service offering is known in the billing system of the service provider.
        /// </summary>
        [JsonProperty("activityID_high")]
        public string ActivityidHigh
        {
            get => activityidHigh;
            set => activityidHigh = SetValue("activityID_high", activityidHigh, value);
        }

        #endregion

        #region Activityid top

        /// <summary>
        /// Represents the activityID for top incidents. The Activity ID is the unique identifier by which an activity that is performed in the context of a service offering is known in the billing system of the service provider.
        /// </summary>
        [JsonProperty("activityID_top")]
        public string ActivityidTop
        {
            get => activityidTop;
            set => activityidTop = SetValue("activityID_top", activityidTop, value);
        }

        #endregion

        #region Activityid rfc

        /// <summary>
        /// Represents the activityID for RFCs. The Activity ID is the unique identifier by which an activity that is performed in the context of a service offering is known in the billing system of the service provider.
        /// </summary>
        [JsonProperty("activityID_rfc")]
        public string ActivityidRfc
        {
            get => activityidRfc;
            set => activityidRfc = SetValue("activityID_rfc", activityidRfc, value);
        }

        #endregion

        #region Activityid rfi

        /// <summary>
        /// Represents the activityID for RFIs. The Activity ID is the unique identifier by which an activity that is performed in the context of a service offering is known in the billing system of the service provider.
        /// </summary>
        [JsonProperty("activityID_rfi")]
        public string ActivityidRfi
        {
            get => activityidRfi;
            set => activityidRfi = SetValue("activityID_rfi", activityidRfi, value);
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

        #region AgreementID

        /// <summary>
        /// The Agreement ID is the unique identifier by which all the activities that are performed through the coverage of the SLA are known in the billing system of the service provider.
        /// </summary>
        [JsonProperty("agreementID")]
        public string AgreementID
        {
            get => agreementID;
            set => agreementID = SetValue("agreementID", agreementID, value);
        }

        #endregion

        #region Coverage

        /// <summary>
        /// The Coverage field is used to specify how people who are to be covered by the service level agreement are to be selected. 
        /// </summary>
        [JsonProperty("coverage")]
        public ServiceLevelCoverage? Coverage
        {
            get => coverage;
            set => coverage = SetValue("coverage", coverage, value);
        }

        #endregion

        #region Customer

        /// <summary>
        /// The Customer field is used to select the Organization that pays for the service level agreement.
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

        #region Customer account

        /// <summary>
        /// This field is used to specify the Account which service level managers are allowed to update the parts of the SLA that are intended to be maintained by the service level managers of the customer. More importantly, this field is used to specify whether specialists of the customer are allowed to see the requests that include this SLA in their Affected SLAs section.
        /// </summary>
        [JsonProperty("customer_account")]
        public AccountReference CustomerAccount
        {
            get => customerAccount;
            set => customerAccount = SetValue("customer_account_id", customerAccount, value);
        }

        [JsonProperty("customer_account_id"), Sdk4meIgnoreInFieldSelection()]
        internal string CustomerAccountID => customerAccount.ID;

        #endregion

        #region Customer Representatives

        /// <summary>
        /// <br>Writeonly references to People</br>
        /// <br>This method is used add a person to the list of customer representatives of the SLA.</br>
        /// <br>In general, it is preferred to use the specific customer representatives methods of the <see cref="ServiceLevelAgreementHandler"/> to retrieve and manipulate the SLA's customer representatives.</br>
        /// <br>However, since it is required to specify at least one customer representative when a SLA is activated, this method must be used when creating a new, active, SLA.</br>
        /// </summary>
        /// <param name="person">Add a person the write-only customer representatives list.</param>
        public void AddCustomerRepresentative(Person person)
        {
            if (person != null)
            {
                if (customerRepresentatives == null)
                {
                    customerRepresentatives = new List<Person> { person };
                }
                else
                {
                    if (!customerRepresentatives.Any(x => x.ID == person.ID))
                        customerRepresentatives.Add(person);
                }
                base.PropertySerializationCollection.Add("customer_representative_ids");
            }
        }

        [JsonProperty("customer_representative_ids"), Sdk4meIgnoreInFieldSelection()]
        internal List<long> CustomerRepresentativeIDs
        {
            get => customerRepresentatives.Select(customerRepresentatives => customerRepresentatives.ID).ToList();
        }

        #endregion

        #region Expiry date

        /// <summary>
        /// The Expiry date field is used to specify the date through which the service level agreement (SLA) will be active. The SLA expires at the end of this day if it is not renewed before then. When the SLA has expired, its status will automatically be set to “Expired”.
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
        /// The Name field is used to enter the name of the service level agreement.
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
        /// The Notice date field is used to specify the last day on which the service provider organization can still be contacted to terminate the service level agreement (SLA) to ensure that it expires on the intended expiry date. The Notice date field is left empty, and the Expiry date field is filled out, when the SLA is to expire on a specific date and no notice needs to be given to terminate it.
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
        /// The Remarks field is used to add any additional information about the service level agreement that might prove useful.
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

        #region Service instance

        /// <summary>
        /// The Service instance field is used to select the Service Instance that will be used to provide the service to the customer of the service level agreement. Only service instances that are linked to the same service as the selected service offering can be selected.
        /// </summary>
        [JsonProperty("service_instance")]
        public ServiceInstance ServiceInstance
        {
            get => serviceInstance;
            set => serviceInstance = SetValue("service_instance_id", serviceInstance, value);
        }

        [JsonProperty("service_instance_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ServiceInstanceID => serviceInstance?.ID;

        #endregion

        #region Service level manager

        /// <summary>
        /// The Service level manager field is used to select the person of the service provider organization who acts as the service level manager for the customer of the service level agreement.
        /// </summary>
        [JsonProperty("service_level_manager")]
        public Person ServiceLevelManager
        {
            get => serviceLevelManager;
            set => serviceLevelManager = SetValue("service_level_manager_id", serviceLevelManager, value);
        }

        [JsonProperty("service_level_manager_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ServiceLevelManagerID => serviceLevelManager?.ID;

        #endregion

        #region Service offering

        /// <summary>
        /// The Service offering field is used to select the Service Offering that specifies the conditions that apply to the service level agreement.
        /// </summary>
        [JsonProperty("service_offering")]
        public ServiceOffering ServiceOffering
        {
            get => serviceOffering;
            set => serviceOffering = SetValue("service_offering_id", serviceOffering, value);
        }

        [JsonProperty("service_offering_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ServiceOfferingID => serviceOffering?.ID;

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
        /// The Start date field is used to specify the first day during which the service level agreement (SLA) is active.
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
        /// The Status field displays the current status of the service level agreement (SLA). 
        /// </summary>
        [JsonProperty("status")]
        public ServiceLevelAgreementStatus? Status
        {
            get => status;
            set => status = SetValue("status", status, value);
        }

        #endregion

        #region Use knowledge from service provider

        /// <summary>
        /// The Use knowledge from service provider box is checked when the knowledge articles for the service instance that is selected in the Service instance field need to be made available to the people who are covered by an active SLA for the service instances selected in the Service instances table field.
        /// </summary>
        [JsonProperty("use_knowledge_from_service_provider")]
        public bool UseKnowledgeFromServiceProvider
        {
            get => useKnowledgeFromServiceProvider;
            set => useKnowledgeFromServiceProvider = SetValue("use_knowledge_from_service_provider", useKnowledgeFromServiceProvider, value);
        }

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            customer?.ResetPropertySerializationCollection();
            serviceInstance?.ResetPropertySerializationCollection();
            serviceLevelManager?.ResetPropertySerializationCollection();
            serviceOffering?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
