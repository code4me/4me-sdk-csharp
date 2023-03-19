using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/service_offerings/effort_class_rates/">effort class rate</see> object.
    /// </summary>
    public class EffortClassRate : BaseItem
    {
        private EffortClass effortClassID;
        private float rate;
        private string rateCurrency;

        #region Created at (override)

        /// <summary>
        /// The creation date and time; which is obsolete for this object.
        /// </summary>
        [JsonProperty("created_at"), Sdk4meIgnoreInFieldSelection()]
        public override DateTime? CreatedAt
        {
            get => base.CreatedAt;
            internal set => base.CreatedAt = null;
        }

        #endregion

        #region Effort class ID

        /// <summary>
        /// The ID of the effort class related to the effort class rate.
        /// </summary>
        [JsonProperty("effort_class")]
        public EffortClass EffortClassID
        {
            get => effortClassID;
            set => effortClassID = SetValue("effort_class_id", effortClassID, value);
        }

        [JsonProperty("effort_class_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? EffortClassIDID => effortClassID?.ID;

        #endregion

        #region Rate

        /// <summary>
        /// The rate per hour for the effort class.
        /// </summary>
        [JsonProperty("rate")]
        public float Rate
        {
            get => rate;
            set => rate = SetValue("rate", rate, value);
        }

        #endregion

        #region Rate currency

        /// <summary>
        /// The currency of the rate per hour for the effort class.
        /// </summary>
        [JsonProperty("rate_currency")]
        public string RateCurrency
        {
            get => rateCurrency;
            set => rateCurrency = SetValue("rate_currency", rateCurrency, value);
        }

        #endregion

        #region Updated at (override)

        /// <summary>
        /// The updated date and time; which is obsolete for this object.
        /// </summary>
        [JsonProperty("updated_at"), Sdk4meIgnoreInFieldSelection()]
        public override DateTime? UpdatedAt
        {
            get => base.UpdatedAt;
            internal set => base.UpdatedAt = null;
        }

        #endregion
    }
}
