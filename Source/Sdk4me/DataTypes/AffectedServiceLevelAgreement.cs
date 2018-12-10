using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    public class AffectedServiceLevelAgreement : BaseItem
    {
        private AffectedServiceLevelAgreementAccountabilityType? accountability;
        private DateTime? actualResolutionAt;
        private int? actualResolutionDuration;
        private DateTime? actualResponseAt;
        private int? actualResponseDuration;
        private DateTime? desiredCompletionAt;
        private int? downtimeDuration;
        private DateTime? downtimeEndAt;
        private DateTime? downtimeStartAt;
        private Team firstLineTeam;
        private AffectedServiceLevelAgreementImpactType? impact;
        private int? maximumResolutionDuration;
        private int? maximumResponseDuration;
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
        private int? stoppedClockDuration;
        private Organization supplier;
        private Calendar supportHours;
        private Team supportTeam;
        private string timeZone;

        #region accountability

        [JsonProperty("accountability")]
        public AffectedServiceLevelAgreementAccountabilityType? Accountability
        {
            get => accountability;
            internal set => accountability = value;
        }

        #endregion

        #region actual_resolution_at

        [JsonProperty("actual_resolution_at")]
        public DateTime? ActualResolutionAt
        {
            get => actualResolutionAt;
            internal set => actualResolutionAt = value;
        }

        #endregion

        #region actual_resolution_duration

        [JsonProperty("actual_resolution_duration")]
        public int? ActualResolutionDuration
        {
            get => actualResolutionDuration;
            internal set => actualResolutionDuration = value;
        }

        #endregion

        #region actual_response_at

        [JsonProperty("actual_response_at")]
        public DateTime? ActualResponseAt
        {
            get => actualResponseAt;
            internal set => actualResponseAt = value;
        }

        #endregion

        #region actual_response_duration

        [JsonProperty("actual_response_duration")]
        public int? ActualResponseDuration
        {
            get => actualResponseDuration;
            internal set => actualResponseDuration = value;
        }

        #endregion

        #region desired_completion_at

        [JsonProperty("desired_completion_at")]
        public DateTime? DesiredCompletionAt
        {
            get => desiredCompletionAt;
            internal set => desiredCompletionAt = value;
        }

        #endregion

        #region downtime_duration

        [JsonProperty("downtime_duration")]
        public int? DowntimeDuration
        {
            get => downtimeDuration;
            internal set => downtimeDuration = value;
        }

        #endregion

        #region downtime_end_at

        [JsonProperty("downtime_end_at")]
        public DateTime? DowntimeEndAt
        {
            get => downtimeEndAt;
            internal set => downtimeEndAt = value;
        }

        #endregion

        #region downtime_start_at

        [JsonProperty("downtime_start_at")]
        public DateTime? DowntimeStartAt
        {
            get => downtimeStartAt;
            internal set => downtimeStartAt = value;
        }

        #endregion

        #region first_line_team

        [JsonProperty("first_line_team")]
        public Team FirstLineTeam
        {
            get => firstLineTeam;
            internal set => firstLineTeam = value;
        }

        #endregion

        #region impact

        [JsonProperty("impact")]
        public AffectedServiceLevelAgreementImpactType? Impact
        {
            get => impact;
            internal set => impact = value;
        }

        #endregion

        #region maximum_resolution_duration

        [JsonProperty("maximum_resolution_duration")]
        public int? MaximumResolutionDuration
        {
            get => maximumResolutionDuration;
            internal set => maximumResolutionDuration = value;
        }

        #endregion

        #region maximum_response_duration

        [JsonProperty("maximum_response_duration")]
        public int? MaximumResponseDuration
        {
            get => maximumResponseDuration;
            internal set => maximumResponseDuration = value;
        }

        #endregion

        #region next_target_at

        [JsonProperty("next_target_at")]
        public string NextTargetAt
        {
            get => nextTargetAt;
            internal set => nextTargetAt = value;
        }

        #endregion

        #region request

        [JsonProperty("request")]
        public Request Request
        {
            get => request;
            internal set => request = value;
        }

        #endregion

        #region resolution_target_at

        [JsonProperty("resolution_target_at")]
        public DateTime? ResolutionTargetAt
        {
            get => resolutionTargetAt;
            internal set => resolutionTargetAt = value;
        }

        #endregion

        #region response_target_at

        [JsonProperty("response_target_at")]
        public DateTime? ResponseTargetAt
        {
            get => responseTargetAt;
            internal set => responseTargetAt = value;
        }

        #endregion

        #region service_hours

        [JsonProperty("service_hours")]
        public Calendar ServiceHours
        {
            get => serviceHours;
            internal set => serviceHours = value;
        }

        #endregion

        #region service_instance

        [JsonProperty("service_instance")]
        public ServiceInstance ServiceInstance
        {
            get => serviceInstance;
            internal set => serviceInstance = value;
        }

        #endregion

        #region sla

        [JsonProperty("sla")]
        public ServiceLevelAgreement Sla
        {
            get => sla;
            internal set => sla = value;
        }

        #endregion

        #region standard_service_request

        [JsonProperty("standard_service_request")]
        public StandardServiceRequest StandardServiceRequest
        {
            get => standardServiceRequest;
            internal set => standardServiceRequest = value;
        }

        #endregion

        #region started_at

        [JsonProperty("started_at")]
        public DateTime? StartedAt
        {
            get => startedAt;
            internal set => startedAt = value;
        }

        #endregion

        #region stopped_clock_at

        [JsonProperty("stopped_clock_at")]
        public DateTime? StoppedClockAt
        {
            get => stoppedClockAt;
            internal set => stoppedClockAt = value;
        }

        #endregion

        #region stopped_clock_duration

        [JsonProperty("stopped_clock_duration")]
        public int? StoppedClockDuration
        {
            get => stoppedClockDuration;
            internal set => stoppedClockDuration = value;
        }

        #endregion

        #region supplier

        [JsonProperty("supplier")]
        public Organization Supplier
        {
            get => supplier;
            internal set => supplier = value;
        }

        #endregion

        #region support_hours

        [JsonProperty("support_hours")]
        public Calendar SupportHours
        {
            get => supportHours;
            internal set => supportHours = value;
        }

        #endregion

        #region support_team

        [JsonProperty("support_team")]
        public Team SupportTeam
        {
            get => supportTeam;
            internal set => supportTeam = value;
        }

        #endregion

        #region time_zone

        [JsonProperty("time_zone")]
        public string TimeZone
        {
            get => timeZone;
            internal set => timeZone = value;
        }

        #endregion

        internal override void ResetIncludedDuringSerialization()
        {
            firstLineTeam?.ResetIncludedDuringSerialization();
            request?.ResetIncludedDuringSerialization();
            serviceHours?.ResetIncludedDuringSerialization();
            serviceInstance?.ResetIncludedDuringSerialization();
            sla?.ResetIncludedDuringSerialization();
            standardServiceRequest?.ResetIncludedDuringSerialization();
            supplier?.ResetIncludedDuringSerialization();
            supportHours?.ResetIncludedDuringSerialization();
            supportTeam?.ResetIncludedDuringSerialization();
            base.ResetIncludedDuringSerialization();
        }
    }
}
