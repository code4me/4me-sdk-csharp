using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/service_offerings/standard_service_requests/">standard service request</see> object.
    /// </summary>
    public class StandardServiceRequest : BaseItem
    {
        private RequestTemplate requestTemplate;
        private TimeSpan? responseTarget;
        private TimeSpan? resolutionTarget;
        private Calendar supportHours;

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

        internal override void ResetPropertySerializationCollection()
        {
            requestTemplate?.ResetPropertySerializationCollection();
            supportHours?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
