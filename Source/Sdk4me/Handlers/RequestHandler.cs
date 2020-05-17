using System.Collections.Generic;

namespace Sdk4me
{
    public class RequestHandler : BaseHandler<Request, PredefinedRequestFilter>
    {
        public RequestHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/requests", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public RequestHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/requests", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region  affected SLAs

        public List<AffectedServiceLevelAgreement> GetAffectedServiceLevelAgreements(Request request, params string[] attributeNames)
        {
            DefaultHandler<AffectedServiceLevelAgreement> handler = new DefaultHandler<AffectedServiceLevelAgreement>($"{URL}/{request.ID}/affected_slas", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region notes

        public List<Note> GetNotes(Request request, params string[] attributeNames)
        {
            DefaultHandler<Note> handler = new DefaultHandler<Note>($"{URL}/{request.ID}/notes", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests)
            {
                SortOrder = SortOrder.CreatedAt
            };
            return handler.Get(attributeNames);
        }

        #endregion

        #region configuration items

        public List<ConfigurationItem> GetConfigurationItems(Request request, params string[] attributeNames)
        {
            DefaultHandler<ConfigurationItem> handler = new DefaultHandler<ConfigurationItem>($"{URL}/{request.ID}/cis", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
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
            DefaultHandler<Request> handler = new DefaultHandler<Request>($"{URL}/{request.ID}/grouped_requests", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion
    }
}
