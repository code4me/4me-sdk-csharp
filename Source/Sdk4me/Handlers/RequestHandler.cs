using System.Collections.Generic;

namespace Sdk4me
{
    public class RequestHandler : BaseHandler<Request>
    {
        private static readonly string qualityUrl = "https://api.4me.qa/v1/requests";
        private static readonly string productionUrl = "https://api.4me.com/v1/requests";

        public RequestHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public RequestHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region  affected SLAs

        public List<AffectedServiceLevelAgreement> GetAffectedServiceLevelAgreements(Request request, params string[] attributeNames)
        {
            BaseHandler<AffectedServiceLevelAgreement> handler = new BaseHandler<AffectedServiceLevelAgreement>($"{URL}/{request.ID}/affected_slas", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region notes

        public List<Note> GetNotes(Request request, params string[] attributeNames)
        {
            BaseHandler<Note> handler = new BaseHandler<Note>($"{URL}/{request.ID}/notes", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            handler.SortOrder = SortOrder.CreatedAtAndID;
            return handler.Get(attributeNames);
        }

        #endregion

        #region configuration items

        public List<ConfigurationItem> GetConfigurationItems(Request request, params string[] attributeNames)
        {
            BaseHandler<ConfigurationItem> handler = new BaseHandler<ConfigurationItem>($"{URL}/{request.ID}/cis", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        public bool AddConfigurationItem(Request request, ConfigurationItem configurationItem)
        {
            return CreateRelation(request, "cis", configurationItem);
        }

        public bool RemoveConfigurationItem(Request request, ConfigurationItem configurationItem)
        {
            return DeleteRelation(request, "cis", configurationItem);
        }

        public bool RemoveAllConfigurationItems(Request request)
        {
            return DeleteAllRelations(request, "cis");
        }

        #endregion

        #region grouped requests

        public List<Request> GetGroupedRequests(Request request, params string[] attributeNames)
        {
            BaseHandler<Request> handler = new BaseHandler<Request>($"{URL}/{request.ID}/grouped_requests", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion
    }
}
