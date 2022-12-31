using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/service_level_agreements/service_instances/">service instance relation</see> object.
    /// </summary>
    public class ServiceLevelAgreementServiceInstanceRelation : BaseItem
    {
        private ServiceLevelAgreementServiceInstanceRelationStatus impactRelation;
        private ServiceInstance serviceInstance;

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

        #region Impact relation

        /// <summary>
        /// The type of the relation.
        /// </summary>
        [JsonProperty("impact_relation"), Sdk4meIgnoreInFieldSelection()]
        public ServiceLevelAgreementServiceInstanceRelationStatus ImpactRelation
        {
            get => impactRelation;
            set => impactRelation = SetValue("impact_relation", impactRelation, value);
        }

        #endregion

        #region Service instance

        /// <summary>
        /// The linked service instance.
        /// </summary>
        [JsonProperty("service_instance"), Sdk4meIgnoreInFieldSelection()]
        public ServiceInstance ServiceInstance
        {
            get => serviceInstance;
            set => serviceInstance = SetValue("service_instance_id", serviceInstance, value);
        }

        [JsonProperty("service_instance_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ServiceInstanceID => serviceInstance?.ID;

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
