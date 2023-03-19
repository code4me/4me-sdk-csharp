using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/service_offerings/">service offering</see> object.
    /// </summary>
    public class ServiceOffering : BaseItem
    {
        private List<Attachment> attachments;
        private float? availability;
        private ChargeType? chargeTypeHigh;
        private ChargeType? chargeTypeLow;
        private ChargeType? chargeTypeMedium;
        private ChargeType? chargeTypeRfc;
        private ChargeType? chargeTypeRfi;
        private ChargeType? chargeTypeTop;
        private string charges;
        private List<AttachmentReference> chargesAttachments;
        private string continuity;
        private EffortClass defaultEffortClass;
        private string limitations;
        private string name;
        private string penalties;
        private List<AttachmentReference> penaltiesAttachments;
        private string performance;
        private string prerequisites;
        private List<AttachmentReference> prerequisitesAttachments;
        private float? rateHigh;
        private string rateHighCurrency;
        private float? rateLow;
        private string rateLowCurrency;
        private float? rateMedium;
        private string rateMediumCurrency;
        private float? rateRfc;
        private string rateRfcCurrency;
        private float? rateRfi;
        private string rateRfiCurrency;
        private float? rateTop;
        private string rateTopCurrency;
        private int? recoveryTimeObjective;
        private int? recoveryPointObjective;
        private int? reliability;
        private ServiceOfferingFrequency? reportFrequency;
        private TimeSpan? resolutionTargetHigh;
        private int? resolutionTargetHighInDays;
        private TimeSpan? resolutionTargetLow;
        private int? resolutionTargetLowInDays;
        private TimeSpan? resolutionTargetMedium;
        private int? resolutionTargetMediumInDays;
        private TimeSpan? resolutionTargetRfc;
        private int? resolutionTargetRfcInDays;
        private TimeSpan? resolutionTargetRfi;
        private int? resolutionTargetRfiInDays;
        private TimeSpan? resolutionTargetTop;
        private int? resolutionTargetTopInDays;
        private int? resolutionsWithinTarget;
        private TimeSpan? responseTargetHigh;
        private int? responseTargetHighInDays;
        private TimeSpan? responseTargetLow;
        private int? responseTargetLowInDays;
        private TimeSpan? responseTargetMedium;
        private int? responseTargetMediumInDays;
        private TimeSpan? responseTargetRfc;
        private int? responseTargetRfcInDays;
        private TimeSpan? responseTargetRfi;
        private int? responseTargetRfiInDays;
        private TimeSpan? responseTargetTop;
        private int? responseTargetTopInDays;
        private int? responsesWithinTarget;
        private ServiceOfferingFrequency? reviewFrequency;
        private Service service;
        private Calendar serviceHours;
        private string source;
        private string sourceID;
        private ServiceOfferingStatus? status;
        private string summary;
        private List<AttachmentReference> summaryAttachments;
        private Calendar supportHoursHigh;
        private Calendar supportHoursLow;
        private Calendar supportHoursMedium;
        private Calendar supportHoursRfc;
        private Calendar supportHoursRfi;
        private Calendar supportHoursTop;
        private string termination;
        private List<AttachmentReference> terminationAttachments;
        private string timeZone;

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

        #region Availability

        /// <summary>
        /// The Availability field is used to specify the duration, expressed as percentage of the total number of service hours, during which the service is to be available to customers with an active SLA that is based on the service offering.
        /// </summary>
        [JsonProperty("availability")]
        public float? Availability
        {
            get => availability;
            set => availability = SetValue("availability", availability, value);
        }

        #endregion

        #region Charge type high

        /// <summary>
        /// Defines how a high incident must be charged: as a Fixed Price or in Time and Materials.
        /// </summary>
        [JsonProperty("charge_type_high")]
        public ChargeType? ChargeTypeHigh
        {
            get => chargeTypeHigh;
            set => chargeTypeHigh = SetValue("charge_type_high", chargeTypeHigh, value);
        }

        #endregion

        #region Charge type low

        /// <summary>
        /// Defines how a low incident must be charged: as a Fixed Price or in Time and Materials.
        /// </summary>
        [JsonProperty("charge_type_low")]
        public ChargeType? ChargeTypeLow
        {
            get => chargeTypeLow;
            set => chargeTypeLow = SetValue("charge_type_low", chargeTypeLow, value);
        }

        #endregion

        #region Charge type medium

        /// <summary>
        /// Defines how a medium incident must be charged: as a Fixed Price or in Time and Materials.
        /// </summary>
        [JsonProperty("charge_type_medium")]
        public ChargeType? ChargeTypeMedium
        {
            get => chargeTypeMedium;
            set => chargeTypeMedium = SetValue("charge_type_medium", chargeTypeMedium, value);
        }

        #endregion

        #region Charge type rfc

        /// <summary>
        /// Defines how a RFC must be charged: as a Fixed Price or in Time and Materials.
        /// </summary>
        [JsonProperty("charge_type_rfc")]
        public ChargeType? ChargeTypeRfc
        {
            get => chargeTypeRfc;
            set => chargeTypeRfc = SetValue("charge_type_rfc", chargeTypeRfc, value);
        }

        #endregion

        #region Charge type rfi

        /// <summary>
        /// Defines how a RFI must be charged: as a Fixed Price or in Time and Materials.
        /// </summary>
        [JsonProperty("charge_type_rfi")]
        public ChargeType? ChargeTypeRfi
        {
            get => chargeTypeRfi;
            set => chargeTypeRfi = SetValue("charge_type_rfi", chargeTypeRfi, value);
        }

        #endregion

        #region Charge type top

        /// <summary>
        /// Defines how a top incident must be charged: as a Fixed Price or in Time and Materials.
        /// </summary>
        [JsonProperty("charge_type_top")]
        public ChargeType? ChargeTypeTop
        {
            get => chargeTypeTop;
            set => chargeTypeTop = SetValue("charge_type_top", chargeTypeTop, value);
        }

        #endregion

        #region Charges

        /// <summary>
        /// The Charges field is used to describe the amount that the service provider will charge the customer for the delivery of the service per charge driver, per charge term.
        /// </summary>
        [JsonProperty("charges")]
        public string Charges
        {
            get => charges;
            set => charges = SetValue("charges", charges, value);
        }

        #endregion

        #region Charges attachment

        /// <summary>
        /// Write-only. Add a reference to an uploaded charges attachment. Use <see cref="Attachments"/> to get the existing attachments.
        /// </summary>
        /// <param name="key">The attachment key.</param>
        /// <param name="fileSize">The attachment file size.</param>
        /// <param name="inline">True if this an in-line attachment; otherwise false.</param>
        public void ReferenceChargesAttachment(string key, long fileSize, bool inline = false)
        {
            if (chargesAttachments == null)
                chargesAttachments = new List<AttachmentReference>();

            chargesAttachments.Add(new AttachmentReference()
            {
                Key = key,
                FileSize = fileSize,
                Inline = inline
            });

            base.PropertySerializationCollection.Add("charges_attachments");
        }

        [JsonProperty("charges_attachments"), Sdk4meIgnoreInFieldSelection()]
        internal List<AttachmentReference> ChargesAttachments
        {
            get => chargesAttachments;
        }

        #endregion

        #region Continuity

        /// <summary>
        /// The Continuity measures field is used to specify the continuity measures for the service offering.
        /// </summary>
        [JsonProperty("continuity")]
        public string Continuity
        {
            get => continuity;
            set => continuity = SetValue("continuity", continuity, value);
        }

        #endregion

        #region Default effort class

        /// <summary>
        /// The default effort class.
        /// </summary>
        [JsonProperty("default_effort_class")]
        public EffortClass DefaultEffortClass
        {
            get => defaultEffortClass;
            set => defaultEffortClass = SetValue("default_effort_class", defaultEffortClass, value);
        }

        #endregion

        #region Limitations

        /// <summary>
        /// The Limitations field is used to specify the limitations that apply to the service level agreements that are based on the service offering.
        /// </summary>
        [JsonProperty("limitations")]
        public string Limitations
        {
            get => limitations;
            set => limitations = SetValue("limitations", limitations, value);
        }

        #endregion

        #region Name

        /// <summary>
        /// The Name field is used to enter the name of the service offering using the following syntax:
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get => name;
            set => name = SetValue("name", name, value);
        }

        #endregion

        #region Penalties

        /// <summary>
        /// The Penalties field is used to specify what the penalties will be for the service provider organization if a service level target has been violated.
        /// </summary>
        [JsonProperty("penalties")]
        public string Penalties
        {
            get => penalties;
            set => penalties = SetValue("penalties", penalties, value);
        }

        #endregion

        #region Penalties attachment

        /// <summary>
        /// Write-only. Add a reference to an uploaded penalties attachment. Use <see cref="Attachments"/> to get the existing attachments.
        /// </summary>
        /// <param name="key">The attachment key.</param>
        /// <param name="fileSize">The attachment file size.</param>
        /// <param name="inline">True if this an in-line attachment; otherwise false.</param>
        public void ReferencePenaltiesAttachment(string key, long fileSize, bool inline = false)
        {
            if (penaltiesAttachments == null)
                penaltiesAttachments = new List<AttachmentReference>();

            penaltiesAttachments.Add(new AttachmentReference()
            {
                Key = key,
                FileSize = fileSize,
                Inline = inline
            });

            base.PropertySerializationCollection.Add("penalties_attachments");
        }

        [JsonProperty("penalties_attachments"), Sdk4meIgnoreInFieldSelection()]
        internal List<AttachmentReference> PenaltiesAttachment
        {
            get => penaltiesAttachments;
        }

        #endregion

        #region Performance

        /// <summary>
        /// The Performance field is used to describe the transaction(s) and the maximum time these transaction(s) can take to complete.
        /// </summary>
        [JsonProperty("performance")]
        public string Performance
        {
            get => performance;
            set => performance = SetValue("performance", performance, value);
        }

        #endregion

        #region Prerequisites

        /// <summary>
        /// The Prerequisites field is used to specify which requirements need to be met by the customer in order for the customer to be able to benefit from the service. The service provider cannot be held accountable for violations of the service level targets caused by a failure of the customer to meet one or more of these prerequisites.
        /// </summary>
        [JsonProperty("prerequisites")]
        public string Prerequisites
        {
            get => prerequisites;
            set => prerequisites = SetValue("prerequisites", prerequisites, value);
        }

        #endregion

        #region Prerequisites attachment

        /// <summary>
        /// Write-only. Add a reference to an uploaded prerequisites attachment. Use <see cref="Attachments"/> to get the existing attachments.
        /// </summary>
        /// <param name="key">The attachment key.</param>
        /// <param name="fileSize">The attachment file size.</param>
        /// <param name="inline">True if this an in-line attachment; otherwise false.</param>
        public void ReferencePrerequisitesAttachment(string key, long fileSize, bool inline = false)
        {
            if (prerequisitesAttachments == null)
                prerequisitesAttachments = new List<AttachmentReference>();

            prerequisitesAttachments.Add(new AttachmentReference()
            {
                Key = key,
                FileSize = fileSize,
                Inline = inline
            });

            base.PropertySerializationCollection.Add("prerequisites_attachments");
        }

        [JsonProperty("prerequisites_attachments"), Sdk4meIgnoreInFieldSelection()]
        internal List<AttachmentReference> PrerequisitesAttachments
        {
            get => prerequisitesAttachments;
        }

        #endregion

        #region Rate high

        /// <summary>
        /// Defines the fixed price rate for a high incident.
        /// </summary>
        [JsonProperty("rate_high")]
        public float? RateHigh
        {
            get => rateHigh;
            set => rateHigh = SetValue("rate_high", rateHigh, value);
        }

        #endregion

        #region Rate high currency

        /// <summary>
        /// Defines the currency for the fixed price rate of a high incident.
        /// </summary>
        [JsonProperty("rate_high_currency")]
        public string RateHighCurrency
        {
            get => rateHighCurrency;
            set => rateHighCurrency = SetValue("rate_high_currency", rateHighCurrency, value);
        }

        #endregion

        #region Rate low

        /// <summary>
        /// Defines the fixed price rate for a low incident.
        /// </summary>
        [JsonProperty("rate_low")]
        public float? RateLow
        {
            get => rateLow;
            set => rateLow = SetValue("rate_low", rateLow, value);
        }

        #endregion

        #region Rate low currency

        /// <summary>
        /// Defines the currency for the fixed price rate of a low incident.
        /// </summary>
        [JsonProperty("rate_low_currency")]
        public string RateLowCurrency
        {
            get => rateLowCurrency;
            set => rateLowCurrency = SetValue("rate_low_currency", rateLowCurrency, value);
        }

        #endregion

        #region Rate medium

        /// <summary>
        /// Defines the fixed price rate for a medium incident.
        /// </summary>
        [JsonProperty("rate_medium")]
        public float? RateMedium
        {
            get => rateMedium;
            set => rateMedium = SetValue("rate_medium", rateMedium, value);
        }

        #endregion

        #region Rate medium currency

        /// <summary>
        /// Defines the currency for the fixed price rate of a medium incident.
        /// </summary>
        [JsonProperty("rate_medium_currency")]
        public string RateMediumCurrency
        {
            get => rateMediumCurrency;
            set => rateMediumCurrency = SetValue("rate_medium_currency", rateMediumCurrency, value);
        }

        #endregion

        #region Rate rfc

        /// <summary>
        /// Defines the fixed price rate for a RFC.
        /// </summary>
        [JsonProperty("rate_rfc")]
        public float? RateRfc
        {
            get => rateRfc;
            set => rateRfc = SetValue("rate_rfc", rateRfc, value);
        }

        #endregion

        #region Rate rfc currency

        /// <summary>
        /// Defines the currency for the fixed price rate of a RFC.
        /// </summary>
        [JsonProperty("rate_rfc_currency")]
        public string RateRfcCurrency
        {
            get => rateRfcCurrency;
            set => rateRfcCurrency = SetValue("rate_rfc_currency", rateRfcCurrency, value);
        }

        #endregion

        #region Rate rfi

        /// <summary>
        /// Defines the fixed price rate for a RFI.
        /// </summary>
        [JsonProperty("rate_rfi")]
        public float? RateRfi
        {
            get => rateRfi;
            set => rateRfi = SetValue("rate_rfi", rateRfi, value);
        }

        #endregion

        #region Rate rfi currency

        /// <summary>
        /// Defines the currency for the fixed price rate of a RFI.
        /// </summary>
        [JsonProperty("rate_rfi_currency")]
        public string RateRfiCurrency
        {
            get => rateRfiCurrency;
            set => rateRfiCurrency = SetValue("rate_rfi_currency", rateRfiCurrency, value);
        }

        #endregion

        #region Rate top

        /// <summary>
        /// Defines the fixed price rate for a top incident.
        /// </summary>
        [JsonProperty("rate_top")]
        public float? RateTop
        {
            get => rateTop;
            set => rateTop = SetValue("rate_top", rateTop, value);
        }

        #endregion

        #region Rate top currency

        /// <summary>
        /// Defines the currency for the fixed price rate of a top incident.
        /// </summary>
        [JsonProperty("rate_top_currency")]
        public string RateTopCurrency
        {
            get => rateTopCurrency;
            set => rateTopCurrency = SetValue("rate_top_currency", rateTopCurrency, value);
        }

        #endregion

        #region Recovery time objective

        /// <summary>
        /// The Recovery Time Objective (RTO) field is used to specify the targeted duration of time and a service level within which a business process must be restored after a disaster (or disruption) in order to avoid unacceptable consequences associated with a break in business continuity.
        /// </summary>
        [JsonProperty("recovery_time_objective")]
        public int? RecoveryTimeObjective
        {
            get => recoveryTimeObjective;
            set => recoveryTimeObjective = SetValue("recovery_time_objective", recoveryTimeObjective, value);
        }

        #endregion

        #region Recovery point objective

        /// <summary>
        /// The Recovery Point Objective (RPO) field is used to specify the maximum targeted period in which data (transactions) might be lost from an IT service due to a major incident.
        /// </summary>
        [JsonProperty("recovery_point_objective")]
        public int? RecoveryPointObjective
        {
            get => recoveryPointObjective;
            set => recoveryPointObjective = SetValue("recovery_point_objective", recoveryPointObjective, value);
        }

        #endregion

        #region Reliability

        /// <summary>
        /// The Reliability field is used to specify the maximum number of times per month that the service may become unavailable to customers with an active SLA that is based on the service offering.
        /// </summary>
        [JsonProperty("reliability")]
        public int? Reliability
        {
            get => reliability;
            set => reliability = SetValue("reliability", reliability, value);
        }

        #endregion

        #region Report frequency

        /// <summary>
        /// The Report frequency field is used to specify how often the representative of a customer of an active SLA that is based on the service offering will receive a report comparing the service level targets specified in the service offering with the actual level of service provided. 
        /// </summary>
        [JsonProperty("report_frequency")]
        public ServiceOfferingFrequency? ReportFrequency
        {
            get => reportFrequency;
            set => reportFrequency = SetValue("report_frequency", reportFrequency, value);
        }

        #endregion

        #region Resolution target high

        /// <summary>
        /// This Resolution target field is used to enter the number of hours and minutes within which a request with the impact value “High – Service Degraded for Several Users” is to be resolved when it affects an active SLA that is based on the service offering.
        /// </summary>
        public TimeSpan? ResolutionTargetHigh
        {
            get => resolutionTargetHigh;
            set => resolutionTargetHigh = SetValue("resolution_target_high", resolutionTargetHigh, value);
        }

        [JsonProperty("resolution_target_high")]
        internal int? ResolutionTargetHighInMinutes
        {
            get => resolutionTargetHigh != null ? Convert.ToInt32(resolutionTargetHigh.Value.TotalMinutes) : (int?)null;
            set => resolutionTargetHigh = value != null ? TimeSpan.FromMinutes(value.Value) : (TimeSpan?)null;
        }

        #endregion

        #region Resolution target high in days

        /// <summary>
        /// This Resolution target field is used to enter the number of business days within which a request with the impact value “High – Service Degraded for Several Users” is to be resolved when it affects an active SLA that is based on the service offering.
        /// </summary>
        [JsonProperty("resolution_target_high_in_days")]
        public int? ResolutionTargetHighInDays
        {
            get => resolutionTargetHighInDays;
            set => resolutionTargetHighInDays = SetValue("resolution_target_high_in_days", resolutionTargetHighInDays, value);
        }

        #endregion

        #region Resolution target low

        /// <summary>
        /// This Resolution target field is used to enter the number of hours and minutes within which a request with the impact value “Low – Service Degraded for One User” is to be resolved when it affects an active SLA that is based on the service offering.
        /// </summary>
        public TimeSpan? ResolutionTargetLow
        {
            get => resolutionTargetLow;
            set => resolutionTargetLow = SetValue("resolution_target_low", resolutionTargetLow, value);
        }

        [JsonProperty("resolution_target_low")]
        internal int? ResolutionTargetLowInMinutes
        {
            get => resolutionTargetLow != null ? Convert.ToInt32(resolutionTargetLow.Value.TotalMinutes) : (int?)null;
            set => resolutionTargetLow = value != null ? TimeSpan.FromMinutes(value.Value) : (TimeSpan?)null;
        }

        #endregion

        #region Resolution target low in days

        /// <summary>
        /// This Resolution target field is used to enter the number of business days within which a request with the impact value “Low – Service Degraded for One User” is to be resolved when it affects an active SLA that is based on the service offering.
        /// </summary>
        [JsonProperty("resolution_target_low_in_days")]
        public int? ResolutionTargetLowInDays
        {
            get => resolutionTargetLowInDays;
            set => resolutionTargetLowInDays = SetValue("resolution_target_low_in_days", resolutionTargetLowInDays, value);
        }

        #endregion

        #region Resolution target medium

        /// <summary>
        /// This Resolution target field is used to enter the number of hours and minutes within which a request with the impact value “Medium – Service Down for One User” is to be resolved when it affects an active SLA that is based on the service offering.
        /// </summary>
        public TimeSpan? ResolutionTargetMedium
        {
            get => resolutionTargetMedium;
            set => resolutionTargetMedium = SetValue("resolution_target_medium", resolutionTargetMedium, value);
        }

        [JsonProperty("resolution_target_medium")]
        internal int? ResolutionTargetMediumInMinutes
        {
            get => resolutionTargetMedium != null ? Convert.ToInt32(resolutionTargetMedium.Value.TotalMinutes) : (int?)null;
            set => resolutionTargetMedium = value != null ? TimeSpan.FromMinutes(value.Value) : (TimeSpan?)null;
        }

        #endregion

        #region Resolution target medium in days

        /// <summary>
        /// This Resolution target field is used to enter the number of business days within which a request with the impact value “Medium – Service Down for One User” is to be resolved when it affects an active SLA that is based on the service offering.
        /// </summary>
        [JsonProperty("resolution_target_medium_in_days")]
        public int? ResolutionTargetMediumInDays
        {
            get => resolutionTargetMediumInDays;
            set => resolutionTargetMediumInDays = SetValue("resolution_target_medium_in_days", resolutionTargetMediumInDays, value);
        }

        #endregion

        #region Resolution target rfc

        /// <summary>
        /// This Resolution target field is used to enter the number of hours and minutes within which a request with the category “RFC – Request for Change” is to be resolved when it affects an active SLA that is based on the service offering.
        /// </summary>
        public TimeSpan? ResolutionTargetRfc
        {
            get => resolutionTargetRfc;
            set => resolutionTargetRfc = SetValue("resolution_target_rfc", resolutionTargetRfc, value);
        }

        [JsonProperty("resolution_target_rfc")]
        internal int? ResolutionTargetRfcInMinutes
        {
            get => resolutionTargetRfc != null ? Convert.ToInt32(resolutionTargetRfc.Value.TotalMinutes) : (int?)null;
            set => resolutionTargetRfc = value != null ? TimeSpan.FromMinutes(value.Value) : (TimeSpan?)null;
        }

        #endregion

        #region Resolution target rfc in days

        /// <summary>
        /// This Resolution target field is used to enter the number of business days within which a request with the category “RFC – Request for Change” is to be resolved when it affects an active SLA that is based on the service offering.
        /// </summary>
        [JsonProperty("resolution_target_rfc_in_days")]
        public int? ResolutionTargetRfcInDays
        {
            get => resolutionTargetRfcInDays;
            set => resolutionTargetRfcInDays = SetValue("resolution_target_rfc_in_days", resolutionTargetRfcInDays, value);
        }

        #endregion

        #region Resolution target rfi

        /// <summary>
        /// This Resolution target field is used to enter the number of hours and minutes within which a request with the category “RFI – Request for Information” is to be resolved when it affects an active SLA that is based on the service offering.
        /// </summary>
        public TimeSpan? ResolutionTargetRfi
        {
            get => resolutionTargetRfi;
            set => resolutionTargetRfi = SetValue("resolution_target_rfi", resolutionTargetRfi, value);
        }

        [JsonProperty("resolution_target_rfi")]
        internal int? ResolutionTargetRfiInMinutes
        {
            get => resolutionTargetRfi != null ? Convert.ToInt32(resolutionTargetRfi.Value.TotalMinutes) : (int?)null;
            set => resolutionTargetRfi = value != null ? TimeSpan.FromMinutes(value.Value) : (TimeSpan?)null;
        }

        #endregion

        #region Resolution target rfi in days

        /// <summary>
        /// This Resolution target field is used to enter the number of business days within which a request with the category “RFI – Request for Information” is to be resolved when it affects an active SLA that is based on the service offering.
        /// </summary>
        [JsonProperty("resolution_target_rfi_in_days")]
        public int? ResolutionTargetRfiInDays
        {
            get => resolutionTargetRfiInDays;
            set => resolutionTargetRfiInDays = SetValue("resolution_target_rfi_in_days", resolutionTargetRfiInDays, value);
        }

        #endregion

        #region Resolution target top

        /// <summary>
        /// This Resolution target field is used to enter the number of hours and minutes within which a request with the impact value “Top – Service Down for Several Users” is to be resolved when it affects an active SLA that is based on the service offering.
        /// </summary>
        public TimeSpan? ResolutionTargetTop
        {
            get => resolutionTargetTop;
            set => resolutionTargetTop = SetValue("resolution_target_top", resolutionTargetTop, value);
        }

        [JsonProperty("resolution_target_top")]
        internal int? ResolutionTargetTopInMinutes
        {
            get => resolutionTargetTop != null ? Convert.ToInt32(resolutionTargetTop.Value.TotalMinutes) : (int?)null;
            set => resolutionTargetTop = value != null ? TimeSpan.FromMinutes(value.Value) : (TimeSpan?)null;
        }

        #endregion

        #region Resolution target top in days

        /// <summary>
        /// This Resolution target field is used to enter the number of business days within which a request with the impact value “Top – Service Down for Several Users” is to be resolved when it affects an active SLA that is based on the service offering.
        /// </summary>
        [JsonProperty("resolution_target_top_in_days")]
        public int? ResolutionTargetTopInDays
        {
            get => resolutionTargetTopInDays;
            set => resolutionTargetTopInDays = SetValue("resolution_target_top_in_days", resolutionTargetTopInDays, value);
        }

        #endregion

        #region Resolutions within target

        /// <summary>
        /// The Resolutions within target field is used to enter the minimum percentage of incidents that is to be resolved before their resolution target.
        /// </summary>
        [JsonProperty("resolutions_within_target")]
        public int? ResolutionsWithinTarget
        {
            get => resolutionsWithinTarget;
            set => resolutionsWithinTarget = SetValue("resolutions_within_target", resolutionsWithinTarget, value);
        }

        #endregion

        #region Response target high

        /// <summary>
        /// This Response target field is used to enter the number of hours and minutes within which a response needs to have been provided for a request with the impact “High – Service Degraded for Several Users” when it affects an active SLA that is based on the service offering.
        /// </summary>
        public TimeSpan? ResponseTargetHigh
        {
            get => responseTargetHigh;
            set => responseTargetHigh = SetValue("response_target_high", responseTargetHigh, value);
        }

        [JsonProperty("response_target_high")]
        internal int? ResponseTargetHighInMinutes
        {
            get => responseTargetHigh != null ? Convert.ToInt32(responseTargetHigh.Value.TotalMinutes) : (int?)null;
            set => responseTargetHigh = value != null ? TimeSpan.FromMinutes(value.Value) : (TimeSpan?)null;
        }

        #endregion

        #region Response target high in days

        /// <summary>
        /// This Response target field is used to enter the number of business days within which a response needs to have been provided for a request with the impact “High – Service Degraded for Several Users” when it affects an active SLA that is based on the service offering.
        /// </summary>
        [JsonProperty("response_target_high_in_days")]
        public int? ResponseTargetHighInDays
        {
            get => responseTargetHighInDays;
            set => responseTargetHighInDays = SetValue("response_target_high_in_days", responseTargetHighInDays, value);
        }

        #endregion

        #region Response target low

        /// <summary>
        /// This Response target field is used to enter the number of hours and minutes within which a response needs to have been provided for a request with the impact “Low – Service Degraded for One User” when it affects an active SLA that is based on the service offering.
        /// </summary>
        public TimeSpan? ResponseTargetLow
        {
            get => responseTargetLow;
            set => responseTargetLow = SetValue("response_target_low", responseTargetLow, value);
        }

        [JsonProperty("response_target_low")]
        internal int? ResponseTargetLowInMinutes
        {
            get => responseTargetLow != null ? Convert.ToInt32(responseTargetLow.Value.TotalMinutes) : (int?)null;
            set => responseTargetLow = value != null ? TimeSpan.FromMinutes(value.Value) : (TimeSpan?)null;
        }

        #endregion

        #region Response target low in days

        /// <summary>
        /// This Response target field is used to enter the number of business days within which a response needs to have been provided for a request with the impact “Low – Service Degraded for One User” when it affects an active SLA that is based on the service offering.
        /// </summary>
        [JsonProperty("response_target_low_in_days")]
        public int? ResponseTargetLowInDays
        {
            get => responseTargetLowInDays;
            set => responseTargetLowInDays = SetValue("response_target_low_in_days", responseTargetLowInDays, value);
        }

        #endregion

        #region Response target medium

        /// <summary>
        /// This Response target field is used to enter the number of hours and minutes within which a response needs to have been provided for a request with the impact “Medium – Service Down for One User” when it affects an active SLA that is based on the service offering.
        /// </summary>
        public TimeSpan? ResponseTargetMedium
        {
            get => responseTargetMedium;
            set => responseTargetMedium = SetValue("response_target_medium", responseTargetMedium, value);
        }

        [JsonProperty("response_target_medium")]
        internal int? ResponseTargetMediumInMinutes
        {
            get => responseTargetMedium != null ? Convert.ToInt32(responseTargetMedium.Value.TotalMinutes) : (int?)null;
            set => responseTargetMedium = value != null ? TimeSpan.FromMinutes(value.Value) : (TimeSpan?)null;
        }

        #endregion

        #region Response target medium in days

        /// <summary>
        /// This Response target field is used to enter the number of business days within which a response needs to have been provided for a request with the impact “Medium – Service Down for One User” when it affects an active SLA that is based on the service offering.
        /// </summary>
        [JsonProperty("response_target_medium_in_days")]
        public int? ResponseTargetMediumInDays
        {
            get => responseTargetMediumInDays;
            set => responseTargetMediumInDays = SetValue("response_target_medium_in_days", responseTargetMediumInDays, value);
        }

        #endregion

        #region Response target rfc

        /// <summary>
        /// This Response target field is used to enter the number of hours and minutes within which a response needs to have been provided for a request with the category “RFC – Request for Change” when it affects an active SLA that is based on the service offering.
        /// </summary>
        public TimeSpan? ResponseTargetRfc
        {
            get => responseTargetRfc;
            set => responseTargetRfc = SetValue("response_target_rfc", responseTargetRfc, value);
        }

        [JsonProperty("response_target_rfc")]
        internal int? ResponseTargetRfcInMinutes
        {
            get => responseTargetRfc != null ? Convert.ToInt32(responseTargetRfc.Value.TotalMinutes) : (int?)null;
            set => responseTargetRfc = value != null ? TimeSpan.FromMinutes(value.Value) : (TimeSpan?)null;
        }

        #endregion

        #region Response target rfc in days

        /// <summary>
        /// This Response target field is used to enter the number of business days within which a response needs to have been provided for a request with the category “RFC – Request for Change” when it affects an active SLA that is based on the service offering.
        /// </summary>
        [JsonProperty("response_target_rfc_in_days")]
        public int? ResponseTargetRfcInDays
        {
            get => responseTargetRfcInDays;
            set => responseTargetRfcInDays = SetValue("response_target_rfc_in_days", responseTargetRfcInDays, value);
        }

        #endregion

        #region Response target rfi

        /// <summary>
        /// This Response target field is used to enter the number of hours and minutes within which a response needs to have been provided for a request with the category “RFI – Request for Information” when it affects an active SLA that is based on the service offering.
        /// </summary>
        public TimeSpan? ResponseTargetRfi
        {
            get => responseTargetRfi;
            set => responseTargetRfi = SetValue("response_target_rfi", responseTargetRfi, value);
        }

        [JsonProperty("response_target_rfi")]
        internal int? ResponseTargetRfiInMinutes
        {
            get => responseTargetRfi != null ? Convert.ToInt32(responseTargetRfi.Value.TotalMinutes) : (int?)null;
            set => responseTargetRfi = value != null ? TimeSpan.FromMinutes(value.Value) : (TimeSpan?)null;
        }

        #endregion

        #region Response target rfi in days

        /// <summary>
        /// This Response target field is used to enter the number of business days within which a response needs to have been provided for a request with the category “RFI – Request for Information” when it affects an active SLA that is based on the service offering.
        /// </summary>
        [JsonProperty("response_target_rfi_in_days")]
        public int? ResponseTargetRfiInDays
        {
            get => responseTargetRfiInDays;
            set => responseTargetRfiInDays = SetValue("response_target_rfi_in_days", responseTargetRfiInDays, value);
        }

        #endregion

        #region Response target top

        /// <summary>
        /// This Response target field is used to enter the number of hours and minutes within which a response needs to have been provided for a request with the impact “Top – Service Down for Several Users” when it affects an active SLA that is based on the service offering.
        /// </summary>
        public TimeSpan? ResponseTargetTop
        {
            get => responseTargetTop;
            set => responseTargetTop = SetValue("response_target_top", responseTargetTop, value);
        }

        [JsonProperty("response_target_top")]
        internal int? ResponseTargetTopInMinutes
        {
            get => responseTargetTop != null ? Convert.ToInt32(responseTargetTop.Value.TotalMinutes) : (int?)null;
            set => responseTargetTop = value != null ? TimeSpan.FromMinutes(value.Value) : (TimeSpan?)null;
        }

        #endregion

        #region Response target top in days

        /// <summary>
        /// This Response target field is used to enter the number of business days within which a response needs to have been provided for a request with the impact “Top – Service Down for Several Users” when it affects an active SLA that is based on the service offering.
        /// </summary>
        [JsonProperty("response_target_top_in_days")]
        public int? ResponseTargetTopInDays
        {
            get => responseTargetTopInDays;
            set => responseTargetTopInDays = SetValue("response_target_top_in_days", responseTargetTopInDays, value);
        }

        #endregion

        #region Responses within target

        /// <summary>
        /// The Responses within target field is used to enter the minimum percentage of incidents that is to be responded to before their response target.
        /// </summary>
        [JsonProperty("responses_within_target")]
        public int? ResponsesWithinTarget
        {
            get => responsesWithinTarget;
            set => responsesWithinTarget = SetValue("responses_within_target", responsesWithinTarget, value);
        }

        #endregion

        #region Review frequency

        /// <summary>
        /// The Review frequency field is used to specify how often an active SLA that is based on the service offering will be reviewed with the representative of its customer. 
        /// </summary>
        [JsonProperty("review_frequency")]
        public ServiceOfferingFrequency? ReviewFrequency
        {
            get => reviewFrequency;
            set => reviewFrequency = SetValue("review_frequency", reviewFrequency, value);
        }

        #endregion

        #region Service

        /// <summary>
        /// The Service field is used to select the Service for which the service offering is being prepared.
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

        #region Service hours

        /// <summary>
        /// The Service hours field is used to select a Calendar that defines the hours during which the service is supposed to be available.
        /// </summary>
        [JsonProperty("service_hours")]
        public Calendar ServiceHours
        {
            get => serviceHours;
            set => serviceHours = SetValue("service_hours_id", serviceHours, value);
        }

        [JsonProperty("service_hours_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ServiceHoursID => serviceHours?.ID;

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
        /// The Status field is used to select the current status of the service offering. 
        /// </summary>
        [JsonProperty("status")]
        public ServiceOfferingStatus? Status
        {
            get => status;
            set => status = SetValue("status", status, value);
        }

        #endregion

        #region Summary

        /// <summary>
        /// The Summary field is used to enter a high-level description of the differentiators between this service offering and other service offerings that have already been, or could be, prepared for the same service.
        /// </summary>
        [JsonProperty("summary")]
        public string Summary
        {
            get => summary;
            set => summary = SetValue("summary", summary, value);
        }

        #endregion

        #region Remarks attachment

        /// <summary>
        /// Write-only. Add a reference to an uploaded remarks attachment. Use <see cref="Attachments"/> to get the existing attachments.
        /// </summary>
        /// <param name="key">The attachment key.</param>
        /// <param name="fileSize">The attachment file size.</param>
        /// <param name="inline">True if this an in-line attachment; otherwise false.</param>
        public void ReferenceSummaryAttachment(string key, long fileSize, bool inline = false)
        {
            if (summaryAttachments == null)
                summaryAttachments = new List<AttachmentReference>();

            summaryAttachments.Add(new AttachmentReference()
            {
                Key = key,
                FileSize = fileSize,
                Inline = inline
            });

            base.PropertySerializationCollection.Add("remarks_attachments");
        }

        [JsonProperty("remarks_attachments"), Sdk4meIgnoreInFieldSelection()]
        internal List<AttachmentReference> SummaryAttachments
        {
            get => summaryAttachments;
        }

        #endregion

        #region Support hours high

        /// <summary>
        /// This Support hours field is used to select a calendar that defines the support hours for a request with the impact “High – Service Degraded for Several Users” when it affects an active SLA that is based on the service offering.
        /// </summary>
        [JsonProperty("support_hours_high")]
        public Calendar SupportHoursHigh
        {
            get => supportHoursHigh;
            set => supportHoursHigh = SetValue("support_hours_high_id", supportHoursHigh, value);
        }

        [JsonProperty("support_hours_high_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? SupportHoursHighID => supportHoursHigh?.ID;

        #endregion

        #region Support hours low

        /// <summary>
        /// This Support hours field is used to select a calendar that defines the support hours for a request with the impact “Low – Service Degraded for One User” when it affects an active SLA that is based on the service offering.
        /// </summary>
        [JsonProperty("support_hours_low")]
        public Calendar SupportHoursLow
        {
            get => supportHoursLow;
            set => supportHoursLow = SetValue("support_hours_low_id", supportHoursLow, value);
        }

        [JsonProperty("support_hours_low_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? SupportHoursLowID => supportHoursLow?.ID;

        #endregion

        #region Support hours medium

        /// <summary>
        /// This Support hours field is used to select a calendar that defines the support hours for a request with the impact “Medium – Service Down for One User” when it affects an active SLA that is based on the service offering.
        /// </summary>
        [JsonProperty("support_hours_medium")]
        public Calendar SupportHoursMedium
        {
            get => supportHoursMedium;
            set => supportHoursMedium = SetValue("support_hours_medium_id", supportHoursMedium, value);
        }

        [JsonProperty("support_hours_medium_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? SupportHoursMediumID => supportHoursMedium?.ID;

        #endregion

        #region Support hours rfc

        /// <summary>
        /// This Support hours field is used to select a calendar that defines the support hours for a request with the category “RFC – Request for Change” when it affects an active SLA that is based on the service offering.
        /// </summary>
        [JsonProperty("support_hours_rfc")]
        public Calendar SupportHoursRfc
        {
            get => supportHoursRfc;
            set => supportHoursRfc = SetValue("support_hours_rfc_id", supportHoursRfc, value);
        }

        [JsonProperty("support_hours_rfc_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? SupportHoursRfcID => supportHoursRfc?.ID;

        #endregion

        #region Support hours rfi

        /// <summary>
        /// This Support hours field is used to select a calendar that defines the support hours for a request with the category “RFI – Request for Information” when it affects an active SLA that is based on the service offering.
        /// </summary>
        [JsonProperty("support_hours_rfi")]
        public Calendar SupportHoursRfi
        {
            get => supportHoursRfi;
            set => supportHoursRfi = SetValue("support_hours_rfi_id", supportHoursRfi, value);
        }

        [JsonProperty("support_hours_rfi_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? SupportHoursRfiID => supportHoursRfi?.ID;

        #endregion

        #region Support hours top

        /// <summary>
        /// This Support hours field is used to select a calendar that defines the support hours for a request with the impact “Top – Service Down for Several Users” when it affects an active SLA that is based on the service offering.
        /// </summary>
        [JsonProperty("support_hours_top")]
        public Calendar SupportHoursTop
        {
            get => supportHoursTop;
            set => supportHoursTop = SetValue("support_hours_top_id", supportHoursTop, value);
        }

        [JsonProperty("support_hours_top_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? SupportHoursTopID => supportHoursTop?.ID;

        #endregion

        #region Termination

        /// <summary>
        /// The Termination field is used to describe the length of notice required for changing or terminating the service level agreement.
        /// </summary>
        [JsonProperty("termination")]
        public string Termination
        {
            get => termination;
            set => termination = SetValue("termination", termination, value);
        }

        #endregion

        #region Termination attachment

        /// <summary>
        /// Write-only. Add a reference to an uploaded termination attachment. Use <see cref="Attachments"/> to get the existing attachments.
        /// </summary>
        /// <param name="key">The attachment key.</param>
        /// <param name="fileSize">The attachment file size.</param>
        /// <param name="inline">True if this an in-line attachment; otherwise false.</param>
        public void ReferenceTerminationAttachment(string key, long fileSize, bool inline = false)
        {
            if (terminationAttachments == null)
                terminationAttachments = new List<AttachmentReference>();

            terminationAttachments.Add(new AttachmentReference()
            {
                Key = key,
                FileSize = fileSize,
                Inline = inline
            });

            base.PropertySerializationCollection.Add("termination_attachments");
        }

        [JsonProperty("termination_attachments"), Sdk4meIgnoreInFieldSelection()]
        internal List<AttachmentReference> TerminationAttachments
        {
            get => terminationAttachments;
        }

        #endregion

        #region Time zone

        /// <summary>
        /// The Time zone field is used to select the time zone that applies to the selected service hours.
        /// </summary>
        [JsonProperty("time_zone")]
        public string TimeZone
        {
            get => timeZone;
            set => timeZone = SetValue("time_zone", timeZone, value);
        }

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            supportHoursHigh?.ResetPropertySerializationCollection();
            supportHoursLow?.ResetPropertySerializationCollection();
            supportHoursMedium?.ResetPropertySerializationCollection();
            supportHoursRfc?.ResetPropertySerializationCollection();
            supportHoursRfi?.ResetPropertySerializationCollection();
            supportHoursTop?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
