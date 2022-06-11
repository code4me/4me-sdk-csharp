using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/survey_responses/">survey response</see> API endpoint.
    /// </summary>
    public class SurveyResponseHandler : DefaultBaseHandler<SurveyResponse>
    {
        /// <summary>
        /// Create a new instance of the 4me survey response handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public SurveyResponseHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/survey_responses", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me survey response handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public SurveyResponseHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/survey_responses", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Survey answers

        /// <summary>
        /// Get all survey responses.
        /// </summary>
        /// <param name="response">The survey response.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of survey responses.</returns>
        public List<SurveyAnswer> GetAnswers(SurveyResponse response, params string[] fieldNames)
        {
            return GetChildHandler<SurveyAnswer>(response, "survey_answers").Get(fieldNames);
        }

        /// <summary>
        /// Add an answer.
        /// </summary>
        /// <param name="response">The survey response.</param>
        /// <param name="answer">The answer to the add.</param>
        /// <returns>An updated survey answer.</returns>
        public SurveyAnswer AddAnswer(SurveyResponse response, SurveyAnswer answer)
        {
            return GetChildHandler<SurveyAnswer>(response, "survey_answers").Insert(answer);
        }

        /// <summary>
        /// Update an answer.
        /// </summary>
        /// <param name="response">The survey response.</param>
        /// <param name="answer">The answer to the update.</param>
        /// <returns>An updated survey answer.</returns>
        public SurveyAnswer UpdateAnswer(SurveyResponse response, SurveyAnswer answer)
        {
            return GetChildHandler<SurveyAnswer>(response, "survey_answers").Update(answer);
        }

        /// <summary>
        /// Delete an answer.
        /// </summary>
        /// <param name="response">The survey response.</param>
        /// <param name="answer">The answer to delete.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeleteAnswer(SurveyResponse response, SurveyAnswer answer)
        {
            return GetChildHandler<SurveyAnswer>(response, "survey_answers").Delete(answer);
        }

        /// <summary>
        /// Delete all answers.
        /// </summary>
        /// <param name="response">The survey response.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeleteAllAnswer(SurveyResponse response)
        {
            return GetChildHandler<SurveyAnswer>(response, "survey_answers").DeleteAll();
        }

        #endregion

        #region Service level agreement

        /// <summary>
        /// Get all service level agreements..
        /// </summary>
        /// <param name="response">The survey response..</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of service level agreements.</returns>
        public List<ServiceLevelAgreement> GetServiceLevelAgreements(SurveyResponse response, params string[] fieldNames)
        {
            return GetChildHandler<ServiceLevelAgreement>(response, "slas").Get(fieldNames);
        }

        #endregion
    }
}
