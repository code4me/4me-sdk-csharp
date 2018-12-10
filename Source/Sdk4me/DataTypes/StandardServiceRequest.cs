using Newtonsoft.Json;

namespace Sdk4me
{
    public class StandardServiceRequest : BaseItem
    {
        private RequestTemplate requestTemplate;
        private int? responseTarget;
        private int? resolutionTarget;
        private Calendar supportHours;

        #region request_template

        [JsonProperty("request_template")]
        public RequestTemplate RequestTemplate
        {
            get => requestTemplate;
            set
            {
                if (requestTemplate?.ID != value?.ID)
                    AddIncludedDuringSerialization("request_template_id");
                requestTemplate = value;
            }
        }

        [JsonProperty(PropertyName = "request_template_id"), Sdk4meIgnoreInFieldSelection()]
        private long? RequestTemplateID
        {
            get => (requestTemplate != null ? requestTemplate.ID : (long?)null);
        }

        #endregion

        #region response_target

        [JsonProperty("response_target")]
        public int? ResponseTarget
        {
            get => responseTarget;
            set
            {
                if (responseTarget != value)
                    AddIncludedDuringSerialization("response_target");
                responseTarget = value;
            }
        }

        #endregion

        #region resolution_target

        [JsonProperty("resolution_target")]
        public int? ResolutionTarget
        {
            get => resolutionTarget;
            set
            {
                if (resolutionTarget != value)
                    AddIncludedDuringSerialization("resolution_target");
                resolutionTarget = value;
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

        internal override void ResetIncludedDuringSerialization()
        {
            requestTemplate?.ResetIncludedDuringSerialization();
            supportHours?.ResetIncludedDuringSerialization();
            base.ResetIncludedDuringSerialization();
        }
    }
}
