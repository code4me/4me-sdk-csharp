using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    public class ConfigurationItemRelation : BaseItem
    {
        private ConfigurationItem ci;
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

        #region ci and related_ci_id

        [JsonProperty("ci"), Sdk4meIgnoreInFieldSelection()]
        public ConfigurationItem CI
        {
            get => ci;
            set
            {
                if (ci?.ID != value?.ID)
                    AddIncludedDuringSerialization("related_ci_id");
                ci = value;
            }
        }

        [JsonProperty(PropertyName = "related_ci_id"), Sdk4meIgnoreInFieldSelection()]
        private long? CIID
        {
            get => (ci != null ? ci.ID : (long?)null);
        }

        #endregion

        #region relation_type

        [JsonProperty("relation_type"), Sdk4meIgnoreInFieldSelection()]
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
