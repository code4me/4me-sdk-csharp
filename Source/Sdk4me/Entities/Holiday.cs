using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/holidays/">holiday</see> object.
    /// </summary>
    public class Holiday : BaseItem
    {
        private DateTime endAt;
        private string name;
        private string pictureUri;
        private string source;
        private string sourceID;
        private DateTime startAt;

        #region End at

        /// <summary>
        /// Required date time.
        /// </summary>
        [JsonProperty("end_at")]
        public DateTime EndAt
        {
            get => endAt;
            set => endAt = SetValue("end_at", endAt, value);
        }

        #endregion

        #region Name

        /// <summary>
        /// The Name field is used to enter the name of the holiday.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get => name;
            set => name = SetValue("name", name, value);
        }

        #endregion

        #region Picture uri

        /// <summary>
        /// The hyperlink to the image file for the holiday.
        /// </summary>
        [JsonProperty("picture_uri")]
        public string PictureUri
        {
            get => pictureUri;
            set => pictureUri = SetValue("picture_uri", pictureUri, value);
        }

        #endregion

        #region Source

        /// <summary>
        /// See source.
        /// </summary>
        [JsonProperty("source")]
        public string Source
        {
            get => source;
            set => source = SetValue("source", source, value);
        }

        #endregion

        #region SourceID

        /// <summary>
        /// See source.
        /// </summary>
        [JsonProperty("sourceID")]
        public string SourceID
        {
            get => sourceID;
            set => sourceID = SetValue("sourceID", sourceID, value);
        }

        #endregion

        #region Start at

        /// <summary>
        /// Required datetime.
        /// </summary>
        [JsonProperty("start_at")]
        public DateTime StartAt
        {
            get => startAt;
            set => startAt = SetValue("start_at", startAt, value);
        }

        #endregion
    }
}
