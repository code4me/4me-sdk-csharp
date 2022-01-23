using System.Collections.Generic;

namespace Sdk4me
{
    public class RequestHandler : BaseHandler<Request, PredefinedRequestFilter>
    {
        public RequestHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/requests", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public RequestHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/requests", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region  affected SLAs

        public List<AffectedServiceLevelAgreement> GetAffectedServiceLevelAgreements(Request request, params string[] attributeNames)
        {
            DefaultHandler<AffectedServiceLevelAgreement> handler = new DefaultHandler<AffectedServiceLevelAgreement>($"{this.URL}/{request.ID}/affected_slas", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region notes

        public List<Note> GetNotes(Request request, params string[] attributeNames)
        {
            DefaultHandler<Note> handler = new DefaultHandler<Note>($"{this.URL}/{request.ID}/notes", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests)
            {
                SortOrder = SortOrder.CreatedAt
            };
            return handler.Get(attributeNames);
        }

        #endregion

        #region configuration items

        public List<ConfigurationItem> GetConfigurationItems(Request request, params string[] attributeNames)
        {
            DefaultHandler<ConfigurationItem> handler = new DefaultHandler<ConfigurationItem>($"{this.URL}/{request.ID}/cis", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
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
            DefaultHandler<Request> handler = new DefaultHandler<Request>($"{this.URL}/{request.ID}/grouped_requests", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region archive, trash and restore

        public Request Archive(Request request)
        {
            return CustomWebRequest($"{request.ID}/archive", "POST");
        }

        public Request Trash(Request request)
        {
            return CustomWebRequest($"{request.ID}/trash", "POST");
        }

        public Request Restore(Archive archive)
        {
            return CustomWebRequest($"{archive.Details.ID}/restore", "POST");
        }

        public Request Restore(Trash trash)
        {
            return CustomWebRequest($"{trash.Details.ID}/restore", "POST");
        }

        #endregion
    }
}
