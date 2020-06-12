using Newtonsoft.Json;
using System;
using System.Diagnostics;

namespace Sdk4me
{
    public class SearchResult : BaseItem
    {
        [JsonProperty("type")]
        public SearchType Type { get; internal set; }

        [JsonProperty("title")]
        public string Title { get; internal set; }

        [JsonProperty("details")]
        public string Details { get; internal set; }

        [JsonProperty("url")]
        public string URL { get; internal set; }

        [JsonProperty("avatar_url")]
        public string AvatarURL { get; internal set; }

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
    }
}
