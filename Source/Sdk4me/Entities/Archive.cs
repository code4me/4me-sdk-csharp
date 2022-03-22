using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me archive object.
    /// </summary>
    public class Archive : BaseItem
    {
        [JsonExtensionData]
        private readonly Dictionary<string, JToken> archivedDetails = new Dictionary<string, JToken>();
        private Person archivedBy;
        private string archived;

        #region updated_at (override)

        [JsonProperty("updated_at"), Sdk4meIgnoreInFieldSelection()]
        public override DateTime? UpdatedAt
        {
            get => base.CreatedAt;
            internal set => base.UpdatedAt = null;
        }

        #endregion

        #region Archived

        [JsonProperty("archived")]
        public string Archived
        {
            get => archived;
            internal set => archived = value;
        }

        #endregion

        #region Archive details

        [JsonIgnore, Sdk4meIgnoreInFieldSelection()]
        public ActionDetails Details
        {
            get => archivedDetails.ContainsKey(archived) ? JsonConvert.DeserializeObject<ActionDetails>(archivedDetails[archived].ToString(Formatting.None)) : null;
        }

        #endregion

        #region Archived by

        [JsonProperty("archived_by")]
        public Person ArchivedBy
        {
            get => archivedBy;
            internal set => archivedBy = value;
        }

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            archivedBy?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
