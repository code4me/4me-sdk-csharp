using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/affected_slas/">affected service level agreement</see> object.
    /// </summary>
    public class AffectedServiceLevelAgreement : BaseItem
    {
        private AffectedServiceLevelAgreementAccountability? accountability;
        private DateTime? actualResolutionAt;
        private TimeSpan? actualResolutionDuration;
        private int? maximumResolutionDurationInDays;
        private DateTime actualResponseAt;
        private TimeSpan? actualResponseDuration;
        private int? maximumResponseDurationInDays;
        private DateTime? desiredCompletionAt;
        private TimeSpan? downtimeDuration;
        private DateTime? downtimeEndAt;
        private DateTime? downtimeStartAt;
        private Team firstLineTeam;
        private AffectedServiceLevelAgreementImpact? impact;
        private TimeSpan? maximumResolutionDuration;
        private TimeSpan? maximumResponseDuration;
        private string nextTargetAt;
        private Request request;
        private DateTime? resolutionTargetAt;
        private DateTime? responseTargetAt;
        private Calendar serviceHours;
        private ServiceInstance serviceInstance;
        private ServiceLevelAgreement sla;
        private StandardServiceRequest standardServiceRequest;
        private DateTime? startedAt;
        private DateTime? stoppedClockAt;
        private TimeSpan? stoppedClockDuration;
        private Organization supplier;
        private Calendar supportHours;
        private Team supportTeam;
        private string timeZone;

        #region Accountability

        /// <summary>
        /// The Accountability field is set to provider when the service instance of the affected SLA is the same as the service instance of the request to which the affected SLA is linked. It is set to supplier when the service instance of the request is situated lower in the service hierarchy than the service instance of the affected SLA. It is set to sla_not_affected when the provider of the service instance that is linked to the affected SLA no longer has a responsibility for completing the request. 
        /// </summary>
        [JsonProperty("accountability")]
        public AffectedServiceLevelAgreementAccountability? Accountability
        {
            get => accountability;
            internal set => accountability = value;
        }

        #endregion

        #region Actual resolution at

        /// <summary>
        /// The current date and time is filled out in the Actual resolution field when the status of the request has been set to “Completed”.
        /// </summary>
        [JsonProperty("actual_resolution_at")]
        public DateTime? ActualResolutionAt
        {
            get => actualResolutionAt;
            internal set => actualResolutionAt = value;
        }

        #endregion

        #region Actual resolution duration

        /// <summary>
        /// The Actual resolution duration field value is automatically calculated using the date and time in the Started field, the date and time in the Actual resolution field, and the calendar selected in the Support hours field of the affected SLA.
        /// </summary>
        public TimeSpan? ActualResolutionDuration => actualResolutionDuration;

        [JsonProperty("actual_resolution_duration")]
        internal int? ActualResolutionDurationInMinutes
        {
            get => actualResolutionDuration != null ? Convert.ToInt32(actualResolutionDuration.Value.TotalMinutes) : (int?)null;
            set => actualResolutionDuration = value != null ? TimeSpan.FromMinutes(value.Value) : (TimeSpan?)null;
        }

        #endregion

        #region Maximum resolution duration in days

        /// <summary>
        /// The Maximum resolution duration in days field is automatically set to the number of business days that were specified, at the time the impact level was assigned to the affected SLA, in the Resolution target field for this impact level in the service offering of the related service level agreement.
        /// </summary>
        [JsonProperty("maximum_resolution_duration_in_days")]
        public int? MaximumResolutionDurationInDays
        {
            get => maximumResolutionDurationInDays;
            internal set => maximumResolutionDurationInDays = value;
        }

        #endregion

        #region Actual response at

        /// <summary>
        /// The Actual response field is empty when the service instance (SI) that is selected in the request is the same as the related SI, and the request has not yet been saved with one of the following status values since this SI was linked to it:
        /// </summary>
        [JsonProperty("actual_response_at")]
        public DateTime ActualResponseAt
        {
            get => actualResponseAt;
            internal set => actualResponseAt = value;
        }

        #endregion

        #region Actual response duration

        /// <summary>
        /// The Actual response duration field value is automatically calculated using the date and time in the Started field, the date and time in the Actual response field, and the calendar selected in the Support hours field of the affected SLA.
        /// </summary>
        public TimeSpan? ActualResponseDuration => actualResponseDuration;

        [JsonProperty("actual_response_duration")]
        internal int? ActualResponseDurationInMimutes
        {
            get => actualResponseDuration != null ? Convert.ToInt32(actualResponseDuration.Value.TotalMinutes) : (int?)null;
            set => actualResponseDuration = value != null ? TimeSpan.FromMinutes(value.Value) : (TimeSpan?)null;
        }

        #endregion

        #region Maximum response duration in days

        /// <summary>
        /// The Maximum response duration in days field is automatically set to the number of business days that were specified, at the time the impact level was assigned to the affected SLA, in the Response target field for this impact level in the service offering of the related service level agreement.
        /// </summary>
        [JsonProperty("maximum_response_duration_in_days")]
        public int? MaximumResponseDurationInDays
        {
            get => maximumResponseDurationInDays;
            internal set => maximumResponseDurationInDays = value;
        }

        #endregion

        #region Desired completion at

        /// <summary>
        /// The Desired completion field is the desired completion of the request that the affected SLA is linked to.
        /// </summary>
        [JsonProperty("desired_completion_at")]
        public DateTime? DesiredCompletionAt
        {
            get => desiredCompletionAt;
            internal set => desiredCompletionAt = value;
        }

        #endregion

        #region Downtime duration

        /// <summary>
        /// The Downtime duration field value is automatically calculated using the date and time in the Downtime start field, the date and time in the Downtime end field, and the calendar selected in the Service hours field of the affected SLA.
        /// </summary>
        public TimeSpan? DowntimeDuration => downtimeDuration;

        [JsonProperty("downtime_duration")]
        internal int? DowntimeDurationInMinutes
        {
            get => downtimeDuration != null ? Convert.ToInt32(downtimeDuration.Value.TotalMinutes) : (int?)null;
            set => downtimeDuration = value != null ? TimeSpan.FromMinutes(value.Value) : (TimeSpan?)null;
        }

        #endregion

        #region Downtime end at

        /// <summary>
        /// The Downtime end field is automatically set to the value in the Downtime end field of the request to which the affected SLA is linked.
        /// </summary>
        [JsonProperty("downtime_end_at")]
        public DateTime? DowntimeEndAt
        {
            get => downtimeEndAt;
            internal set => downtimeEndAt = value;
        }

        #endregion

        #region Downtime start at

        /// <summary>
        /// The Downtime start field is automatically set to the value in the Downtime start field of the request to which the affected SLA is linked.
        /// </summary>
        [JsonProperty("downtime_start_at")]
        public DateTime? DowntimeStartAt
        {
            get => downtimeStartAt;
            internal set => downtimeStartAt = value;
        }

        #endregion

        #region First line team

        /// <summary>
        /// The First line team field is automatically set to the team that, at the time the affected SLA was created, was selected in the First line team field of the related service instance.
        /// </summary>
        [JsonProperty("first_line_team")]
        public Team FirstLineTeam
        {
            get => firstLineTeam;
            internal set => firstLineTeam = value;
        }

        #endregion

        #region Impact

        /// <summary>
        /// The Impact field is automatically set to the impact selected in the request, provided that the service instance (SI) that is selected in the request is the same as the related SI. 
        /// </summary>
        [JsonProperty("impact")]
        public AffectedServiceLevelAgreementImpact? Impact
        {
            get => impact;
            internal set => impact = value;
        }

        #endregion

        #region Maximum resolution duration

        /// <summary>
        /// The Maximum resolution duration field is automatically set to the number of minutes that were specified, at the time the impact level was assigned to the affected SLA, in the Resolution target field for this impact level in the service offering of the related service level agreement.
        /// </summary>
        public TimeSpan? MaximumResolutionDuration => maximumResolutionDuration;

        [JsonProperty("maximum_resolution_duration")]
        internal int? MaximumResolutionDurationInMinutes
        {
            get => maximumResolutionDuration != null ? Convert.ToInt32(maximumResolutionDuration.Value.TotalMinutes) : (int?)null;
            set => maximumResolutionDuration = value != null ? TimeSpan.FromMinutes(value.Value) : (TimeSpan?)null;
        }

        #endregion

        #region Maximum response duration

        /// <summary>
        /// The Maximum response duration field is automatically set to the number of minutes that were specified, at the time the impact level was assigned to the affected SLA, in the Response target field for this impact level in the service offering of the related service level agreement.
        /// </summary>
        public TimeSpan? MaximumResponseDuration => maximumResponseDuration;

        [JsonProperty("maximum_response_duration")]
        internal int? MaximumResponseDurationInMinutes
        {
            get => maximumResponseDuration != null ? Convert.ToInt32(maximumResponseDuration.Value.TotalMinutes) : (int?)null;
            set => maximumResponseDuration = value != null ? TimeSpan.FromMinutes(value.Value) : (TimeSpan?)null;
        }

        #endregion

        #region Next target at

        /// <summary>
        /// The Next target field value is empty when the Accountability field is set to sla_not_affected or when the Actual resolution field contains a value. It is set to clock_stopped when the clock has been stopped for the affected SLA. The next target equals the response target when a response target exists and the Actual response field is still empty. Otherwise, the next target equals the desired completion when a desired completion exists and a resolution target exists and the desired completion is greater than the resolution target. Otherwise the next target is the resolution target when a resolution target exists. In all other cases, the next target is best_effort.
        /// </summary>
        [JsonProperty("next_target_at")]
        public string NextTargetAt
        {
            get => nextTargetAt;
            internal set => nextTargetAt = value;
        }

        #endregion

        #region Request

        /// <summary>
        /// The Request field is automatically set to the request for which the affected SLA was generated.
        /// </summary>
        [JsonProperty("request")]
        public Request Request
        {
            get => request;
            internal set => request = value;
        }

        #endregion

        #region Resolution target at

        /// <summary>
        /// The Resolution target field value is automatically calculated using the date and time in the Started field, the value in Maximum resolution duration field, and the calendar selected in the Support hours field of the affected SLA.
        /// </summary>
        [JsonProperty("resolution_target_at")]
        public DateTime? ResolutionTargetAt
        {
            get => resolutionTargetAt;
            internal set => resolutionTargetAt = value;
        }

        #endregion

        #region Response target at

        /// <summary>
        /// The Response target field value is automatically calculated using the date and time in the Started field, the value in the Maximum response duration field, and the calendar selected in the Support hours field of the affected SLA.
        /// </summary>
        [JsonProperty("response_target_at")]
        public DateTime? ResponseTargetAt
        {
            get => responseTargetAt;
            internal set => responseTargetAt = value;
        }

        #endregion

        #region Service hours

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("service_hours")]
        public Calendar ServiceHours
        {
            get => serviceHours;
            internal set => serviceHours = value;
        }

        #endregion

        #region Service instance

        /// <summary>
        /// The Service instance field is automatically set to the Service Instance that, at the time the affected SLA was created, was selected in the Service instance field of the related service level agreement.
        /// </summary>
        [JsonProperty("service_instance")]
        public ServiceInstance ServiceInstance
        {
            get => serviceInstance;
            internal set => serviceInstance = value;
        }

        #endregion

        #region Service level agreement

        /// <summary>
        /// The Service level agreement field is automatically set to the service level agreement that is considered affected.
        /// </summary>
        [JsonProperty("sla")]
        public ServiceLevelAgreement ServiceLevelAgreement
        {
            get => sla;
            internal set => sla = value;
        }

        #endregion

        #region Standard service request

        /// <summary>
        /// The Standard service request field is automatically set to the standard service request that is linked to the service offering of the service level agreement and which response and resolution targets were used to calculate the response_target_at and resolution_target_at for the affected SLA.
        /// </summary>
        [JsonProperty("standard_service_request")]
        public StandardServiceRequest StandardServiceRequest
        {
            get => standardServiceRequest;
            internal set => standardServiceRequest = value;
        }

        #endregion

        #region Started at

        /// <summary>
        /// The date and time at which the clock was started for the calculation of the affected SLA’s response and resolution targets and durations.
        /// </summary>
        [JsonProperty("started_at")]
        public DateTime? StartedAt
        {
            get => startedAt;
            internal set => startedAt = value;
        }

        #endregion

        #region Stopped clock at

        /// <summary>
        /// The date and time at which the clock was stopped for the calculation of the affected SLA’s response and resolution durations.
        /// </summary>
        [JsonProperty("stopped_clock_at")]
        public DateTime? StoppedClockAt
        {
            get => stoppedClockAt;
            internal set => stoppedClockAt = value;
        }

        #endregion

        #region Stopped clock duration

        /// <summary>
        /// The Stopped clock duration field value is automatically calculated using the date and time at which the clock was stopped, the date and time at which the clock was started again, the calendar selected in the Support hours field of the affected SLA, and the previous value to which this field was set.
        /// </summary>
        public TimeSpan? StoppedClockDuration => stoppedClockDuration;

        [JsonProperty("stopped_clock_duration")]
        internal int? StoppedClockDurationInMinutes
        {
            get => stoppedClockDuration != null ? Convert.ToInt32(stoppedClockDuration.Value.TotalMinutes) : (int?)null;
            set => stoppedClockDuration = value != null ? TimeSpan.FromMinutes(value.Value) : (TimeSpan?)null;
        }

        #endregion

        #region Supplier

        /// <summary>
        /// The Supplier field is automatically set to the Organization that, at the time the affected SLA was created, was selected in the Service provider field of the related service instance. This field is only filled out, however, if this service provider is an external organization.
        /// </summary>
        [JsonProperty("supplier")]
        public Organization Supplier
        {
            get => supplier;
            internal set => supplier = value;
        }

        #endregion

        #region Support hours

        /// <summary>
        /// The Support hours field is automatically set to the support hours Calendar that was selected for the impact level specified above in the service offering of the related service level agreement.
        /// </summary>
        [JsonProperty("support_hours")]
        public Calendar SupportHours
        {
            get => supportHours;
            internal set => supportHours = value;
        }

        #endregion

        #region Support team

        /// <summary>
        /// The Support team field is automatically set to the team that, at the time the affected SLA was created, was selected in the Support team field of the related service instance.
        /// </summary>
        [JsonProperty("support_team")]
        public Team SupportTeam
        {
            get => supportTeam;
            internal set => supportTeam = value;
        }

        #endregion

        #region Time zone

        /// <summary>
        /// The Time zone field is automatically set to the value that was specified, at the time the affected SLA was created, in the service offering of the related service level agreement.
        /// </summary>
        [JsonProperty("time_zone")]
        public string TimeZone
        {
            get => timeZone;
            internal set => timeZone = value;
        }

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            firstLineTeam?.ResetPropertySerializationCollection();
            request?.ResetPropertySerializationCollection();
            serviceHours?.ResetPropertySerializationCollection();
            serviceInstance?.ResetPropertySerializationCollection();
            sla?.ResetPropertySerializationCollection();
            standardServiceRequest?.ResetPropertySerializationCollection();
            supplier?.ResetPropertySerializationCollection();
            supportHours?.ResetPropertySerializationCollection();
            supportTeam?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
