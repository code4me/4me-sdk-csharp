using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    public class Holiday : BaseItem
    {
        private DateTime? endAt;
        private string name;
        private string pictureUri;
        private string source;
        private string sourceID;
        private DateTime? startAt;

        #region end_at

        [JsonProperty("end_at")]
        public DateTime? EndAt
        {
            get => endAt;
            set
            {
                if (endAt != value)
                    AddIncludedDuringSerialization("end_at");
                endAt = value;
            }
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

        #region start_at

        [JsonProperty("start_at")]
        public DateTime? StartAt
        {
            get => startAt;
            set
            {
                if (startAt != value)
                    AddIncludedDuringSerialization("start_at");
                startAt = value;
            }
        }

        #endregion
    }
}
