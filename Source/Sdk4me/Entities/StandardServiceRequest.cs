using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/service_offerings/standard_service_requests/">standard service request</see> object.
    /// </summary>
    public class StandardServiceRequest : BaseItem
    {

        private ChargeType? chargeType;
        private float? rate;
        private string rateCurrency;
        private RequestTemplate requestTemplate;
        private TimeSpan? responseTarget;
        private bool? responseTargetBestEffort;
        private TimeSpan? resolutionTarget;
        private bool? resolutionTargetBestEffort;
        private Calendar supportHours;
        private ServiceLevelAgreementNotificationScheme slaNotificationScheme;

        #region Charge type

        /// <summary>
        /// Defines how the standard service request must be charged: as a Fixed Price or in Time and Materials.
        /// </summary>
        [JsonProperty("charge_type")]
        public ChargeType? ChargeType
        {
            get => chargeType;
            set => chargeType = SetValue("charge_type", chargeType, value);
        }

        #endregion

        #region Rate

        /// <summary>
        /// Defines the fixed price rate for the standard service request.
        /// </summary>
        [JsonProperty("rate")]
        public float? Rate
        {
            get => rate;
            set => rate = SetValue("rate", rate, value);
        }

        #endregion

        #region Rate currency

        /// <summary>
        /// Defines the currency for the fixed price rate of the standard service request.
        /// </summary>
        [JsonProperty("rate_currency")]
        public string RateCurrency
        {
            get => rateCurrency;
            set => rateCurrency = SetValue("rate_currency", rateCurrency, value);
        }

        #endregion

        #region Request template

        /// <summary>
        /// The ID of the request template related to the service offering. Only the request templates that are linked to the same service as the service offering can be selected.
        /// </summary>
        [JsonProperty("request_template")]
        public RequestTemplate RequestTemplate
        {
            get => requestTemplate;
            set => requestTemplate = SetValue("request_template_id", requestTemplate, value);
        }

        [JsonProperty("request_template_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? RequestTemplateID => requestTemplate?.ID;

        #endregion

        #region Response target

        /// <summary>
        /// Number of minutes within which a response needs to have been provided for a request to which the request template has been applied and which requester is covered by an SLA that is based on the service offering.
        /// </summary>
        public TimeSpan? ResponseTarget
        {
            get => responseTarget;
            set => responseTarget = SetValue("response_target", responseTarget, value);
        }

        [JsonProperty("response_target")]
        internal int? ResponseTargetInMinutes
        {
            get => responseTarget != null ? Convert.ToInt32(responseTarget.Value.TotalMinutes) : (int?)null;
            set => responseTarget = value != null ? TimeSpan.FromMinutes(value.Value) : (TimeSpan?)null;
        }

        #endregion

        #region Response target best effort

        /// <summary>
        /// Response target is Best Effort when the request template has been applied to the request and the requester is covered by an SLA that is based on the service offering.
        /// </summary>
        [JsonProperty("response_target_best_effort")]
        public bool? ResponseTargetBestEffort
        {
            get => responseTargetBestEffort;
            set => responseTargetBestEffort = SetValue("response_target_best_effort", responseTargetBestEffort, value);
        }

        #endregion

        #region Resolution target

        /// <summary>
        /// Number of minutes within which a request needs to have been completed when the request template has been applied to the request and the requester is covered by an SLA that is based on the service offering.
        /// </summary>
        public TimeSpan? ResolutionTarget
        {
            get => resolutionTarget;
            set => resolutionTarget = SetValue("resolution_target", resolutionTarget, value);
        }

        [JsonProperty("resolution_target")]
        internal int? ResolutionTargetInMinutes
        {
            get => resolutionTarget != null ? Convert.ToInt32(resolutionTarget.Value.TotalMinutes) : (int?)null;
            set => resolutionTarget = value != null ? TimeSpan.FromMinutes(value.Value) : (TimeSpan?)null;
        }

        #endregion

        #region Resolution target best effort

        /// <summary>
        /// Resolution target is Best Effort when the request template has been applied to the request and the requester is covered by an SLA that is based on the service offering.
        /// </summary>
        [JsonProperty("resolution_target_best_effort")]
        public bool? ResolutionTargetBestEffort
        {
            get => resolutionTargetBestEffort;
            set => resolutionTargetBestEffort = SetValue("resolution_target_best_effort", resolutionTargetBestEffort, value);
        }

        #endregion

        #region Support hours

        /// <summary>
        /// The ID of the calendar that defines the support hours for a request to which the request template has been applied and which requester is covered by an SLA that is based on the service offering.
        /// </summary>
        [JsonProperty("support_hours")]
        public Calendar SupportHours
        {
            get => supportHours;
            set => supportHours = SetValue("support_hours_id", supportHours, value);
        }

        [JsonProperty("support_hours_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? SupportHoursID => supportHours?.ID;

        #endregion

        #region SLA notification scheme

        /// <summary>
        /// The ID of the SLA notification scheme for a request when it affects an active SLA that is based on the service offering. Only enabled SLA notification schemes that are linked to the same account as the service offering can be selected.
        /// </summary>
        [JsonProperty("sla_notification_scheme")]
        public ServiceLevelAgreementNotificationScheme SlaNotificationScheme
        {
            get => slaNotificationScheme;
            set => slaNotificationScheme = SetValue("sla_notification_scheme_id", slaNotificationScheme, value);
        }

        [JsonProperty("sla_notification_scheme_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? SlaNotificationSchemeID => slaNotificationScheme?.ID;

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            requestTemplate?.ResetPropertySerializationCollection();
            supportHours?.ResetPropertySerializationCollection();
            slaNotificationScheme?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
