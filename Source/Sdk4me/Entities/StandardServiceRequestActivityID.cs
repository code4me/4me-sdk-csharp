using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/service_level_agreements/standard_service_request_activityIDs/">Service Level Agreements - Standard Service Request Activity ID</see> object.
    /// </summary>
    public class StandardServiceRequestActivityID : BaseItem
    {
        private string activityID;
        private StandardServiceRequest standardServiceRequest;

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

        #region ActivityID

        /// <summary>
        /// The Activity ID is the unique identifier by which an activity that is performed in the context of a service offering is known in the billing system of the service provider.
        /// </summary>
        [JsonProperty("activityID")]
        public string ActivityID
        {
            get => activityID;
            set => activityID = SetValue("activityID", activityID, value);
        }

        #endregion

        #region Standard service request

        /// <summary>
        /// The standard service request related to the standard service request activity ID.
        /// </summary>
        [JsonProperty("standard_service_request")]
        public StandardServiceRequest StandardServiceRequest
        {
            get => standardServiceRequest;
            set => standardServiceRequest = SetValue("standard_service_request_id", standardServiceRequest, value);
        }

        [JsonProperty("standard_service_request_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? StandardServiceRequestID => standardServiceRequest?.ID;

        #endregion
    }
}