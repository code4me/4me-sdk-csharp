using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sdk4me
{
    public class ServiceOffering : BaseItem
    {
        private List<Attachment> attachments;
        private float? availability;
        private string charges;
        private string continuity;
        private string limitations;
        private string maximumRiskOfDataLoss;
        private string name;
        private string offlineBackupSchedule;
        private string penalties;
        private string performance;
        private string prerequisites;
        private string reliability;
        private ServiceOfferingFrequencyType? reportFrequency;
        private int? resolutionTargetHigh;
        private int? resolutionTargetLow;
        private int? resolutionTargetMedium;
        private int? resolutionTargetRfc;
        private int? resolutionTargetRfi;
        private int? resolutionTargetTop;
        private int? resolutionsWithinTarget;
        private int? responseTargetHigh;
        private int? responseTargetLow;
        private int? responseTargetMedium;
        private int? responseTargetRfc;
        private int? responseTargetRfi;
        private int? responseTargetTop;
        private int? responsesWithinTarget;
        private string restoreDuration;
        private ServiceOfferingFrequencyType? reviewFrequency;
        private Service service;
        private Calendar serviceHours;
        private string source;
        private string sourceID;
        private ServiceOfferingStatusType? status;
        private string summary;
        private Calendar supportHoursHigh;
        private Calendar supportHoursLow;
        private Calendar supportHoursMedium;
        private Calendar supportHoursRfc;
        private Calendar supportHoursRfi;
        private Calendar supportHoursTop;
        private string termination;
        private string timeZone;

        #region attachments

        [JsonProperty("attachments")]
        public List<Attachment> Attachments
        {
            get => attachments;
            internal set => attachments = value;
        }

        #endregion

        #region availability

        [JsonProperty("availability")]
        public float? Availability
        {
            get => availability;
            set
            {
                if (availability != value)
                    AddIncludedDuringSerialization("availability");
                availability = value;
            }
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

        #region continuity

        [JsonProperty("continuity")]
        public string Continuity
        {
            get => continuity;
            set
            {
                if (continuity != value)
                    AddIncludedDuringSerialization("continuity");
                continuity = value;
            }
        }

        #endregion

        #region limitations

        [JsonProperty("limitations")]
        public string Limitations
        {
            get => limitations;
            set
            {
                if (limitations != value)
                    AddIncludedDuringSerialization("limitations");
                limitations = value;
            }
        }

        #endregion

        #region maximum_risk_of_data_loss

        [JsonProperty("maximum_risk_of_data_loss")]
        public string MaximumRiskOfDataLoss
        {
            get => maximumRiskOfDataLoss;
            set
            {
                if (maximumRiskOfDataLoss != value)
                    AddIncludedDuringSerialization("maximum_risk_of_data_loss");
                maximumRiskOfDataLoss = value;
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

        #region offline_backup_schedule

        [JsonProperty("offline_backup_schedule")]
        public string OfflineBackupSchedule
        {
            get => offlineBackupSchedule;
            set
            {
                if (offlineBackupSchedule != value)
                    AddIncludedDuringSerialization("offline_backup_schedule");
                offlineBackupSchedule = value;
            }
        }

        #endregion

        #region penalties

        [JsonProperty("penalties")]
        public string Penalties
        {
            get => penalties;
            set
            {
                if (penalties != value)
                    AddIncludedDuringSerialization("penalties");
                penalties = value;
            }
        }

        #endregion

        #region performance

        [JsonProperty("performance")]
        public string Performance
        {
            get => performance;
            set
            {
                if (performance != value)
                    AddIncludedDuringSerialization("performance");
                performance = value;
            }
        }

        #endregion

        #region prerequisites

        [JsonProperty("prerequisites")]
        public string Prerequisites
        {
            get => prerequisites;
            set
            {
                if (prerequisites != value)
                    AddIncludedDuringSerialization("prerequisites");
                prerequisites = value;
            }
        }

        #endregion

        #region reliability

        [JsonProperty("reliability")]
        public string Reliability
        {
            get => reliability;
            set
            {
                if (reliability != value)
                    AddIncludedDuringSerialization("reliability");
                reliability = value;
            }
        }

        #endregion

        #region report_frequency

        [JsonProperty("report_frequency")]
        public ServiceOfferingFrequencyType? ReportFrequency
        {
            get => reportFrequency;
            set
            {
                if (reportFrequency != value)
                    AddIncludedDuringSerialization("report_frequency");
                reportFrequency = value;
            }
        }

        #endregion

        #region resolution_target_high

        [JsonProperty("resolution_target_high")]
        public int? ResolutionTargetHigh
        {
            get => resolutionTargetHigh;
            set
            {
                if (resolutionTargetHigh != value)
                    AddIncludedDuringSerialization("resolution_target_high");
                resolutionTargetHigh = value;
            }
        }

        #endregion

        #region resolution_target_low

        [JsonProperty("resolution_target_low")]
        public int? ResolutionTargetLow
        {
            get => resolutionTargetLow;
            set
            {
                if (resolutionTargetLow != value)
                    AddIncludedDuringSerialization("resolution_target_low");
                resolutionTargetLow = value;
            }
        }

        #endregion

        #region resolution_target_medium

        [JsonProperty("resolution_target_medium")]
        public int? ResolutionTargetMedium
        {
            get => resolutionTargetMedium;
            set
            {
                if (resolutionTargetMedium != value)
                    AddIncludedDuringSerialization("resolution_target_medium");
                resolutionTargetMedium = value;
            }
        }

        #endregion

        #region resolution_target_rfc

        [JsonProperty("resolution_target_rfc")]
        public int? ResolutionTargetRfc
        {
            get => resolutionTargetRfc;
            set
            {
                if (resolutionTargetRfc != value)
                    AddIncludedDuringSerialization("resolution_target_rfc");
                resolutionTargetRfc = value;
            }
        }

        #endregion

        #region resolution_target_rfi

        [JsonProperty("resolution_target_rfi")]
        public int? ResolutionTargetRfi
        {
            get => resolutionTargetRfi;
            set
            {
                if (resolutionTargetRfi != value)
                    AddIncludedDuringSerialization("resolution_target_rfi");
                resolutionTargetRfi = value;
            }
        }

        #endregion

        #region resolution_target_top

        [JsonProperty("resolution_target_top")]
        public int? ResolutionTargetTop
        {
            get => resolutionTargetTop;
            set
            {
                if (resolutionTargetTop != value)
                    AddIncludedDuringSerialization("resolution_target_top");
                resolutionTargetTop = value;
            }
        }

        #endregion

        #region resolutions_within_target

        [JsonProperty("resolutions_within_target")]
        public int? ResolutionsWithinTarget
        {
            get => resolutionsWithinTarget;
            set
            {
                if (resolutionsWithinTarget != value)
                    AddIncludedDuringSerialization("resolutions_within_target");
                resolutionsWithinTarget = value;
            }
        }

        #endregion

        #region response_target_high

        [JsonProperty("response_target_high")]
        public int? ResponseTargetHigh
        {
            get => responseTargetHigh;
            set
            {
                if (responseTargetHigh != value)
                    AddIncludedDuringSerialization("response_target_high");
                responseTargetHigh = value;
            }
        }

        #endregion

        #region response_target_low

        [JsonProperty("response_target_low")]
        public int? ResponseTargetLow
        {
            get => responseTargetLow;
            set
            {
                if (responseTargetLow != value)
                    AddIncludedDuringSerialization("response_target_low");
                responseTargetLow = value;
            }
        }

        #endregion

        #region response_target_medium

        [JsonProperty("response_target_medium")]
        public int? ResponseTargetMedium
        {
            get => responseTargetMedium;
            set
            {
                if (responseTargetMedium != value)
                    AddIncludedDuringSerialization("response_target_medium");
                responseTargetMedium = value;
            }
        }

        #endregion

        #region response_target_rfc

        [JsonProperty("response_target_rfc")]
        public int? ResponseTargetRfc
        {
            get => responseTargetRfc;
            set
            {
                if (responseTargetRfc != value)
                    AddIncludedDuringSerialization("response_target_rfc");
                responseTargetRfc = value;
            }
        }

        #endregion

        #region response_target_rfi

        [JsonProperty("response_target_rfi")]
        public int? ResponseTargetRfi
        {
            get => responseTargetRfi;
            set
            {
                if (responseTargetRfi != value)
                    AddIncludedDuringSerialization("response_target_rfi");
                responseTargetRfi = value;
            }
        }

        #endregion

        #region response_target_top

        [JsonProperty("response_target_top")]
        public int? ResponseTargetTop
        {
            get => responseTargetTop;
            set
            {
                if (responseTargetTop != value)
                    AddIncludedDuringSerialization("response_target_top");
                responseTargetTop = value;
            }
        }

        #endregion

        #region responses_within_target

        [JsonProperty("responses_within_target")]
        public int? ResponsesWithinTarget
        {
            get => responsesWithinTarget;
            set
            {
                if (responsesWithinTarget != value)
                    AddIncludedDuringSerialization("responses_within_target");
                responsesWithinTarget = value;
            }
        }

        #endregion

        #region restore_duration

        [JsonProperty("restore_duration")]
        public string RestoreDuration
        {
            get => restoreDuration;
            set
            {
                if (restoreDuration != value)
                    AddIncludedDuringSerialization("restore_duration");
                restoreDuration = value;
            }
        }

        #endregion

        #region review_frequency

        [JsonProperty("review_frequency")]
        public ServiceOfferingFrequencyType? ReviewFrequency
        {
            get => reviewFrequency;
            set
            {
                if (reviewFrequency != value)
                    AddIncludedDuringSerialization("review_frequency");
                reviewFrequency = value;
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

        #region service_hours

        [JsonProperty("service_hours")]
        public Calendar ServiceHours
        {
            get => serviceHours;
            set
            {
                if (serviceHours?.ID != value?.ID)
                    AddIncludedDuringSerialization("service_hours_id");
                serviceHours = value;
            }
        }

        [JsonProperty(PropertyName = "service_hours_id"), Sdk4meIgnoreInFieldSelection()]
        private long? ServiceHoursID
        {
            get => (serviceHours != null ? serviceHours.ID : (long?)null);
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

        #region status

        [JsonProperty("status")]
        public ServiceOfferingStatusType? Status
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

        #region summary

        [JsonProperty("summary")]
        public string Summary
        {
            get => summary;
            set
            {
                if (summary != value)
                    AddIncludedDuringSerialization("summary");
                summary = value;
            }
        }

        #endregion

        #region support_hours_high

        [JsonProperty("support_hours_high")]
        public Calendar SupportHoursHigh
        {
            get => supportHoursHigh;
            set
            {
                if (supportHoursHigh?.ID != value?.ID)
                    AddIncludedDuringSerialization("support_hours_high_id");
                supportHoursHigh = value;
            }
        }

        [JsonProperty(PropertyName = "support_hours_high_id"), Sdk4meIgnoreInFieldSelection()]
        private long? SupportHoursHighID
        {
            get => (supportHoursHigh != null ? supportHoursHigh.ID : (long?)null);
        }

        #endregion

        #region support_hours_low

        [JsonProperty("support_hours_low")]
        public Calendar SupportHoursLow
        {
            get => supportHoursLow;
            set
            {
                if (supportHoursLow?.ID != value?.ID)
                    AddIncludedDuringSerialization("support_hours_low_id");
                supportHoursLow = value;
            }
        }

        [JsonProperty(PropertyName = "support_hours_low_id"), Sdk4meIgnoreInFieldSelection()]
        private long? SupportHoursLowID
        {
            get => (supportHoursLow != null ? supportHoursLow.ID : (long?)null);
        }

        #endregion

        #region support_hours_medium

        [JsonProperty("support_hours_medium")]
        public Calendar SupportHoursMedium
        {
            get => supportHoursMedium;
            set
            {
                if (supportHoursMedium?.ID != value?.ID)
                    AddIncludedDuringSerialization("support_hours_medium_id");
                supportHoursMedium = value;
            }
        }

        [JsonProperty(PropertyName = "support_hours_medium_id"), Sdk4meIgnoreInFieldSelection()]
        private long? SupportHoursMediumID
        {
            get => (supportHoursMedium != null ? supportHoursMedium.ID : (long?)null);
        }

        #endregion

        #region support_hours_rfc

        [JsonProperty("support_hours_rfc")]
        public Calendar SupportHoursRfc
        {
            get => supportHoursRfc;
            set
            {
                if (supportHoursRfc?.ID != value?.ID)
                    AddIncludedDuringSerialization("support_hours_rfc_id");
                supportHoursRfc = value;
            }
        }

        [JsonProperty(PropertyName = "support_hours_rfc_id"), Sdk4meIgnoreInFieldSelection()]
        private long? SupportHoursRfcID
        {
            get => (supportHoursRfc != null ? supportHoursRfc.ID : (long?)null);
        }

        #endregion

        #region support_hours_rfi

        [JsonProperty("support_hours_rfi")]
        public Calendar SupportHoursRfi
        {
            get => supportHoursRfi;
            set
            {
                if (supportHoursRfi?.ID != value?.ID)
                    AddIncludedDuringSerialization("support_hours_rfi_id");
                supportHoursRfi = value;
            }
        }

        [JsonProperty(PropertyName = "support_hours_rfi_id"), Sdk4meIgnoreInFieldSelection()]
        private long? SupportHoursRfiID
        {
            get => (supportHoursRfi != null ? supportHoursRfi.ID : (long?)null);
        }

        #endregion

        #region support_hours_top

        [JsonProperty("support_hours_top")]
        public Calendar SupportHoursTop
        {
            get => supportHoursTop;
            set
            {
                if (supportHoursTop?.ID != value?.ID)
                    AddIncludedDuringSerialization("support_hours_top_id");
                supportHoursTop = value;
            }
        }

        [JsonProperty(PropertyName = "support_hours_top_id"), Sdk4meIgnoreInFieldSelection()]
        private long? SupportHoursTopID
        {
            get => (supportHoursTop != null ? supportHoursTop.ID : (long?)null);
        }

        #endregion

        #region termination

        [JsonProperty("termination")]
        public string Termination
        {
            get => termination;
            set
            {
                if (termination != value)
                    AddIncludedDuringSerialization("termination");
                termination = value;
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

            service?.ResetIncludedDuringSerialization();
            serviceHours?.ResetIncludedDuringSerialization();
            supportHoursHigh?.ResetIncludedDuringSerialization();
            supportHoursLow?.ResetIncludedDuringSerialization();
            supportHoursMedium?.ResetIncludedDuringSerialization();
            supportHoursRfc?.ResetIncludedDuringSerialization();
            supportHoursRfi?.ResetIncludedDuringSerialization();
            supportHoursTop?.ResetIncludedDuringSerialization();
            base.ResetIncludedDuringSerialization();
        }
    }
}
