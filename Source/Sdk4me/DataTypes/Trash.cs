using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sdk4me
{
    public class Trash : BaseItem
    {
        [JsonExtensionData]
        private Dictionary<string, JToken> trashedDetails = null;
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

        #region trashed

        [JsonProperty(PropertyName = "trashed")]
        public string Trashed
        {
            get => trashed;
            internal set => trashed = value;
        }

        #endregion

        #region trashed details
    

        [JsonIgnore, Sdk4meIgnoreInFieldSelection()]
        public TrashDetails TrashedDetails
        {
            get => JsonConvert.DeserializeObject<TrashDetails>(trashedDetails.First().Value.ToString());
        }

        #endregion

        #region trashed_by

        [JsonProperty(PropertyName = "trashed_by")]
        public Person TrashedBy
        {
            get => trashedBy;
            internal set => trashedBy = value;
        }

        #endregion

        internal override void ResetIncludedDuringSerialization()
        {
            trashedBy?.ResetIncludedDuringSerialization();
            base.ResetIncludedDuringSerialization();
        }
    }
}
