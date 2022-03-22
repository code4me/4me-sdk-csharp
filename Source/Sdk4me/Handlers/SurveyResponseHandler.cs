using System.Collections.Generic;

namespace Sdk4me
{
    public class SurveyResponseHandler : DefaultBaseHandler<SurveyResponse>
    {
        public SurveyResponseHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/survey_responses", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public SurveyResponseHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/survey_responses", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Survey answers

        public List<SurveyAnswer> GetAnswers(SurveyResponse response, params string[] fieldNames)
        {
            return GetChildHandler<SurveyAnswer>(response, "survey_answers").Get(fieldNames);
        }

        public SurveyAnswer AddAnswer(SurveyResponse response, SurveyAnswer answer)
        {
            return GetChildHandler<SurveyAnswer>(response, "survey_answers").Insert(answer);
        }

        public SurveyAnswer UpdateAnswer(SurveyResponse response, SurveyAnswer answer)
        {
            return GetChildHandler<SurveyAnswer>(response, "survey_answers").Update(answer);
        }

        public bool DeleteAnswer(SurveyResponse response, SurveyAnswer answer)
        {
            return GetChildHandler<SurveyAnswer>(response, "survey_answers").Delete(answer);
        }

        public bool DeleteAllAnswer(SurveyResponse response)
        {
            return GetChildHandler<SurveyAnswer>(response, "survey_answers").DeleteAll();
        }

        #endregion

        #region Service level agreement

        public List<Person> GetServiceLevelAgreements(SurveyResponse response, params string[] fieldNames)
        {
            return GetChildHandler<Person>(response, "slas").Get(fieldNames);
        }

        #endregion
    }
}
