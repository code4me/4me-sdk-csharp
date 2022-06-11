using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/surveys/">survey</see> API endpoint.
    /// </summary>
    public class SurveyHandler : BaseHandler<Survey, PredefinedEnabledDisabledFilter>
    {
        /// <summary>
        /// Create a new instance of the 4me survey handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public SurveyHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/surveys", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me survey handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public SurveyHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/surveys", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Survey questions

        /// <summary>
        /// Get all survey questions.
        /// </summary>
        /// <param name="survey">The survey.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of survey questions.</returns>
        public List<SurveyQuestion> GetQuestions(Survey survey, params string[] fieldNames)
        {
            return GetChildHandler<SurveyQuestion>(survey, "survey_questions").Get(fieldNames);
        }

        /// <summary>
        /// Add a survey question.
        /// </summary>
        /// <param name="survey">The survey.</param>
        /// <param name="surveyQuestion">The survey question to add.</param>
        /// <returns>An updated survey question.</returns>
        public SurveyQuestion AddQuestion(Survey survey, SurveyQuestion surveyQuestion)
        {
            return GetChildHandler<SurveyQuestion>(survey, "survey_questions").Insert(surveyQuestion);
        }

        /// <summary>
        /// Update a survey question.
        /// </summary>
        /// <param name="survey">The survey.</param>
        /// <param name="surveyQuestion">The survey question to update.</param>
        /// <returns>An updated survey question.</returns>
        public SurveyQuestion UpdateQuestion(Survey survey, SurveyQuestion surveyQuestion)
        {
            return GetChildHandler<SurveyQuestion>(survey, "survey_questions").Update(surveyQuestion);
        }

        /// <summary>
        /// Delete a survey question.
        /// </summary>
        /// <param name="survey">The survey.</param>
        /// <param name="surveyQuestion">The survey question to delete.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeleteQuestion(Survey survey, SurveyQuestion surveyQuestion)
        {
            return GetChildHandler<SurveyQuestion>(survey, "survey_questions").Delete(surveyQuestion);
        }

        /// <summary>
        /// Delete all survey questions.
        /// </summary>
        /// <param name="survey">The survey.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeleteAllQuestions(Survey survey)
        {
            return GetChildHandler<SurveyQuestion>(survey, "survey_questions").DeleteAll();
        }

        #endregion
    }
}
