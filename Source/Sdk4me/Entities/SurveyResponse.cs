using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/survey_responses/">survey response</see> object.
    /// </summary>
    public class SurveyResponse : BaseItem
    {
        private bool completed;
        private float? rating;
        private string ratingCalculationJson;
        private DateTime respondedAt;
        private Service service;
        private string source;
        private string sourceID;
        private Survey survey;

        #region Completed

        /// <summary>
        /// The completed flag is used to indicate whether the user completed the survey.
        /// </summary>
        [JsonProperty("completed")]
        public bool Completed
        {
            get => completed;
            set => completed = SetValue("completed", completed, value);
        }

        #endregion

        #region Rating

        /// <summary>
        /// Rating calculated based on the answers of this response.
        /// </summary>
        [JsonProperty("rating")]
        public float? Rating
        {
            get => rating;
            set => rating = SetValue("rating", rating, value);
        }

        #endregion

        #region Rating calculation json

        /// <summary>
        /// How the individual answers were combined to calculate the rating. (String can be parsed to JSON).
        /// </summary>
        [JsonProperty("rating_calculation_json")]
        public string RatingCalculationJson
        {
            get => ratingCalculationJson;
            internal set => ratingCalculationJson = value;
        }

        #endregion

        #region Responded at

        /// <summary>
        /// The date and time at which the user started the survey.
        /// </summary>
        [JsonProperty("responded_at")]
        public DateTime RespondedAt
        {
            get => respondedAt;
            internal set => respondedAt = value;
        }

        #endregion

        #region Service

        /// <summary>
        /// Service this response is about.
        /// </summary>
        [JsonProperty("service")]
        public Service Service
        {
            get => service;
            set => service = SetValue("service_id", service, value);
        }

        [JsonProperty("service_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ServiceID => service?.ID;

        #endregion

        #region Source

        /// <summary>
        /// See source
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
        /// See source
        /// </summary>
        [JsonProperty("sourceID")]
        public string SourceID
        {
            get => sourceID;
            set => sourceID = SetValue("sourceID", sourceID, value);
        }

        #endregion

        #region Survey

        /// <summary>
        /// Survey this response is for.
        /// </summary>
        [JsonProperty("survey")]
        public Survey Survey
        {
            get => survey;
            set => survey = SetValue("survey_id", survey, value);
        }

        [JsonProperty("survey_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? SurveyID => survey?.ID;

        #endregion
    }
}
