using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Sdk4me
{
    public class ServiceCategory : BaseItem
    {
        private string description;
        private string localizedDescription;
        private string localizedName;
        private string name;
        private string pictureUri;
        private string source;
        private string sourceID;

        #region description

        [JsonProperty("description")]
        public string Description
        {
            get => description;
            set
            {
                if (description != value)
                    AddIncludedDuringSerialization("description");
                description = value;
            }
        }

        #endregion

        #region localized_description

        [JsonProperty("localized_description"), Sdk4meIgnoreInFieldSelection()]
        public string LocalizedDescription
        {
            get => localizedDescription;
            internal set => localizedDescription = value;
        }

        #endregion

        #region localized_name

        [JsonProperty("localized_name"), Sdk4meIgnoreInFieldSelection()]
        public string LocalizedName
        {
            get => localizedName;
            internal set => localizedName = value;
        }

        #endregion

        #region name

        [JsonProperty("name")]
        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                    AddIncludedDuringSerialization("name");
                name = value;
            }
        }

        #endregion

        #region picture_uri

        [JsonProperty("picture_uri")]
        public string PictureUri
        {
            get => pictureUri;
            set
            {
                if (pictureUri != value)
                    AddIncludedDuringSerialization("picture_uri");
                pictureUri = value;
            }
        }

        #endregion

        #region source

        [JsonProperty("source")]
        public string Source
        {
            get => source;
            set
            {
                if (source != value)
                    AddIncludedDuringSerialization("source");
                source = value;
            }
        }

        #endregion

        #region sourceID

        [JsonProperty("sourceID")]
        public string SourceID
        {
            get => sourceID;
            set
            {
                if (sourceID != value)
                    AddIncludedDuringSerialization("sourceID");
                sourceID = value;
            }
        }

        #endregion
    }
}
