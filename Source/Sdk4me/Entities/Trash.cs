using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me trash object.
    /// </summary>
    public class Trash : BaseItem
    {
        [JsonExtensionData]
        private readonly Dictionary<string, JToken> trashedDetails = new Dictionary<string, JToken>();
        private Person trashedBy;
        private string trashed;

        #region updated_at (override)

        [JsonProperty("updated_at"), Sdk4meIgnoreInFieldSelection()]
        public override DateTime? UpdatedAt
        {
            get => base.CreatedAt;
            internal set => base.UpdatedAt = null;
        }

        #endregion

        #region Trashed

        [JsonProperty("trashed")]
        public string Trashed
        {
            get => trashed;
            internal set => trashed = value;
        }

        #endregion

        #region Trashed details

        [JsonIgnore, Sdk4meIgnoreInFieldSelection()]
        public ActionDetails Details
        {
            get => trashedDetails.ContainsKey(trashed) ? JsonConvert.DeserializeObject<ActionDetails>(trashedDetails[trashed].ToString()) : null;
        }

        #endregion

        #region Trashed by

        [JsonProperty("trashed_by")]
        public Person TrashedBy
        {
            get => trashedBy;
            internal set => trashedBy = value;
        }

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            trashedBy?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
