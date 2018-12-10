using System.Collections.Generic;

namespace Sdk4me
{
    public class RequestTemplateHandler : BaseHandler<RequestTemplate>
    {
        private static readonly string qualityUrl = "https://api.4me.qa/v1/request_templates";
        private static readonly string productionUrl = "https://api.4me.com/v1/request_templates";

        public RequestTemplateHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public RequestTemplateHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region requests

        public List<Request> GetRequests(RequestTemplate requestTemplate, params string[] attributeNames)
        {
            BaseHandler<Request> handler = new BaseHandler<Request>($"{URL}/{requestTemplate.ID}/requests", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion
    }
}
