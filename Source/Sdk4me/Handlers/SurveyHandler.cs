using System.Collections.Generic;

namespace Sdk4me
{
    public class SurveyHandler : BaseHandler<Survey, PredefinedEnabledDisabledFilter>
    {
        public SurveyHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/surveys", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public SurveyHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/surveys", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Survey questions

        public List<SurveyQuestion> GetQuestions(Survey survey, params string[] fieldName)
        {
            return GetChildHandler<SurveyQuestion>(survey, "survey_questions").Get(fieldName);
        }

        public SurveyQuestion AddQuestion(Survey survey, SurveyQuestion surveyQuestion)
        {
            return GetChildHandler<SurveyQuestion>(survey, "survey_questions").Insert(surveyQuestion);
        }

        public SurveyQuestion UpdateQuestion(Survey survey, SurveyQuestion surveyQuestion)
        {
            return GetChildHandler<SurveyQuestion>(survey, "survey_questions").Update(surveyQuestion);
        }

        public bool DeleteQuestion(Survey survey, SurveyQuestion surveyQuestion)
        {
            return GetChildHandler<SurveyQuestion>(survey, "survey_questions").Delete(surveyQuestion);
        }

        public bool DeleteAllQuestions(Survey survey)
        {
            return GetChildHandler<SurveyQuestion>(survey, "survey_questions").DeleteAll();
        }

        #endregion
    }
}
