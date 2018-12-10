using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    public class ConfigurationItemRelation : BaseItem
    {
        private ConfigurationItem relatedConfigurationItemID;
        private ConfigurationitemRelationType? relationType;

        #region created_at (override)

        [JsonProperty("created_at"), Sdk4meIgnoreInFieldSelection()]
        public override DateTime? CreatedAt
        {
            get => base.CreatedAt;
            internal set => base.CreatedAt = null;
        }

        #endregion

        #region updated_at (override)

        [JsonProperty("updated_at"), Sdk4meIgnoreInFieldSelection()]
        public override DateTime? UpdatedAt
        {
            get => base.UpdatedAt;
            internal set => base.UpdatedAt = null;
        }

        #endregion

        #region related_ci_id

        [JsonProperty("related_ci_id"), Sdk4meIgnoreInFieldSelection()]
        public ConfigurationItem RelatedConfigurationItemID
        {
            get => relatedConfigurationItemID;
            set
            {
                if (relatedConfigurationItemID?.ID != value?.ID)
                    AddIncludedDuringSerialization("related_ci_id_id");
                relatedConfigurationItemID = value;
            }
        }

        [JsonProperty(PropertyName = "related_ci_id_id"), Sdk4meIgnoreInFieldSelection()]
        private long? RelatedCiIdID
        {
            get => (relatedConfigurationItemID != null ? relatedConfigurationItemID.ID : (long?)null);
        }

        #endregion

        #region relation_type

        [JsonProperty("relation_type")]
        public ConfigurationitemRelationType? RelationType
        {
            get => relationType;
            set
            {
                if (relationType != value)
                    AddIncludedDuringSerialization("relation_type");
                relationType = value;
            }
        }

        #endregion
    }
}
