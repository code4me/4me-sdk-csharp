using System.Collections.Generic;

namespace Sdk4me
{
    public class RequestTemplateHandler : BaseHandler<RequestTemplate, PredefinedRequestTemplateFilter>
    {
        public RequestTemplateHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/request_templates",  authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public RequestTemplateHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/request_templates",  authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region requests

        public List<Request> GetRequests(RequestTemplate requestTemplate, params string[] attributeNames)
        {
            DefaultHandler<Request> handler = new DefaultHandler<Request>($"{URL}/{requestTemplate.ID}/requests", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion
    }
}
