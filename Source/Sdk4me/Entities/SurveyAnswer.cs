using Newtonsoft.Json;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/survey_responses/survey_answers/">survey response</see> object.
    /// </summary>
    public class SurveyAnswer : BaseItem
    {
        private float? rating;
        private string source;
        private string sourceID;
        private SurveyQuestion surveyQuestion;
        private string text;

        #region Rating

        /// <summary>
        /// Only present for rating questions. The answer provided by the user.
        /// </summary>
        [JsonProperty("rating")]
        public float? Rating
        {
            get => rating;
            set => rating = SetValue("rating", rating, value);
        }

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

        #region Survey question

        /// <summary>
        /// Survey question this answer is for.
        /// </summary>
        [JsonProperty("survey_question")]
        public SurveyQuestion SurveyQuestion
        {
            get => surveyQuestion;
            set => surveyQuestion = SetValue("survey_question_id", surveyQuestion, value);
        }

        [JsonProperty("survey_question_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? SurveyQuestionID => surveyQuestion?.ID;

        #endregion

        #region Text

        /// <summary>
        /// Only present for text questions. The answer provided by the user.
        /// </summary>
        [JsonProperty("text")]
        public string Text
        {
            get => text;
            set => text = SetValue("text", text, value);
        }

        #endregion
    }
}
