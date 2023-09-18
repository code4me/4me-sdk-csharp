using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/service_level_agreements/effort_class_rateIDs/">Service Level Agreements - Effort Class Charge ID</see> object.
    /// </summary>
    public class EffortClassRateID : BaseItem
    {
        private string rateID;
        private EffortClass effortClass;

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

        #region RateID

        /// <summary>
        /// The Rate ID is the unique identifier by which an effort class that is linked to a time entry when an activity was performed through the coverage of the SLA is known in the billing system of the service provider.
        /// </summary>
        [JsonProperty("rateID")]
        public string RateID
        {
            get => rateID;
            set => rateID = SetValue("rateID", rateID, value);
        }

        #endregion

        #region Effort class ID

        /// <summary>
        /// The effort class related to the effort class charge ID.
        /// </summary>
        [JsonProperty("effort_class")]
        public EffortClass EffortClass
        {
            get => effortClass;
            set => effortClass = SetValue("effort_class_id", effortClass, value);
        }

        [JsonProperty("effort_class_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? EffortClassID => effortClass?.ID;

        #endregion
    }
}