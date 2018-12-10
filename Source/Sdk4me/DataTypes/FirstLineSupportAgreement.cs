using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    public class FirstLineSupportAgreement : BaseItem
    {
        private List<Attachment> attachments;
        private string charges;
        private Organization customer;
        private Person customerRep;
        private DateTime? expiryDate;
        private int? firstCallResolutions;
        private string name;
        private DateTime? noticeDate;
        private Organization provider;
        private string remarks;
        private Team serviceDeskTeam;
        private string source;
        private string sourceID;
        private DateTime? startDate;
        private FirstLineSupportAgreementStatusType? status;
        private Calendar supportHours;
        private string targetDetails;
        private string timeZone;

        #region attachments

        [JsonProperty("attachments")]
        public List<Attachment> Attachments
        {
            get => attachments;
            internal set => attachments = value;
        }

        #endregion

        #region charges

        [JsonProperty("charges")]
        public string Charges
        {
            get => charges;
            set
            {
                if (charges != value)
                    AddIncludedDuringSerialization("charges");
                charges = value;
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

        #region first_call_resolutions

        [JsonProperty("first_call_resolutions")]
        public int? FirstCallResolutions
        {
            get => firstCallResolutions;
            set
            {
                if (firstCallResolutions != value)
                    AddIncludedDuringSerialization("first_call_resolutions");
                firstCallResolutions = value;
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

        #region provider

        [JsonProperty("provider")]
        public Organization Provider
        {
            get => provider;
            set
            {
                if (provider?.ID != value?.ID)
                    AddIncludedDuringSerialization("provider_id");
                provider = value;
            }
        }

        [JsonProperty(PropertyName = "provider_id"), Sdk4meIgnoreInFieldSelection()]
        private long? ProviderID
        {
            get => (provider != null ? provider.ID : (long?)null);
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

        #region service_desk_team

        [JsonProperty("service_desk_team")]
        public Team ServiceDeskTeam
        {
            get => serviceDeskTeam;
            set
            {
                if (serviceDeskTeam?.ID != value?.ID)
                    AddIncludedDuringSerialization("service_desk_team_id");
                serviceDeskTeam = value;
            }
        }

        [JsonProperty(PropertyName = "service_desk_team_id"), Sdk4meIgnoreInFieldSelection()]
        private long? ServiceDeskTeamID
        {
            get => (serviceDeskTeam != null ? serviceDeskTeam.ID : (long?)null);
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
        public FirstLineSupportAgreementStatusType? Status
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

        #region support_hours

        [JsonProperty("support_hours")]
        public Calendar SupportHours
        {
            get => supportHours;
            set
            {
                if (supportHours?.ID != value?.ID)
                    AddIncludedDuringSerialization("support_hours_id");
                supportHours = value;
            }
        }

        [JsonProperty(PropertyName = "support_hours_id"), Sdk4meIgnoreInFieldSelection()]
        private long? SupportHoursID
        {
            get => (supportHours != null ? supportHours.ID : (long?)null);
        }

        #endregion

        #region target_details

        [JsonProperty("target_details")]
        public string TargetDetails
        {
            get => targetDetails;
            set
            {
                if (targetDetails != value)
                    AddIncludedDuringSerialization("target_details");
                targetDetails = value;
            }
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

        internal override void ResetIncludedDuringSerialization()
        {
            if (attachments != null)
                for (int i = 0; i < attachments.Count; i++)
                    attachments[i]?.ResetIncludedDuringSerialization();

            customer?.ResetIncludedDuringSerialization();
            customerRep?.ResetIncludedDuringSerialization();
            provider?.ResetIncludedDuringSerialization();
            serviceDeskTeam?.ResetIncludedDuringSerialization();
            supportHours?.ResetIncludedDuringSerialization();
            base.ResetIncludedDuringSerialization();
        }
    }
}
