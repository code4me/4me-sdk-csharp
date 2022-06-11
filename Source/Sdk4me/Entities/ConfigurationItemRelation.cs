using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/configuration_items/ci_relations/">related configuration item</see> object.
    /// </summary>
    public class ConfigurationItemRelation : BaseItem
    {
        private ConfigurationItem configurationItem;
        private ConfigurationitemRelationType relationType;

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

        #region Configuration item

        /// <summary>
        /// The related configuration item.
        /// </summary>
        [JsonProperty("ci"), Sdk4meIgnoreInFieldSelection()]
        public ConfigurationItem ConfigurationItem
        {
            get => configurationItem;
            set => configurationItem = SetValue("related_ci_id", configurationItem, value);
        }

        [JsonProperty("related_ci_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? RelatedConfigurationItemID => configurationItem?.ID;

        #endregion

        #region Relation type

        /// <summary>
        /// The type of the relation.
        /// </summary>
        [JsonProperty("relation_type"), Sdk4meIgnoreInFieldSelection()]
        public ConfigurationitemRelationType RelationType
        {
            get => relationType;
            set => relationType = SetValue("relation_type", relationType, value);
        }

        #endregion

        /// <summary>
        /// Create a new instance of <see cref="ConfigurationItemRelation"/>.
        /// </summary>
        public ConfigurationItemRelation()
        {
        }

        /// <summary>
        /// Create a new instance of <see cref="ConfigurationItemRelation"/>.
        /// </summary>
        /// <param name="configurationItem">The related configuration item.</param>
        /// <param name="relationType">The type of the relation.</param>
        public ConfigurationItemRelation(ConfigurationItem configurationItem, ConfigurationitemRelationType relationType)
        {
            ConfigurationItem = configurationItem;
            RelationType = relationType;
        }

        internal override HashSet<string> PropertySerializationCollection
        {
            get => HasChanged ? new HashSet<string>() { "related_ci_id", "relation_type", } : base.PropertySerializationCollection;
        }
    }
}
