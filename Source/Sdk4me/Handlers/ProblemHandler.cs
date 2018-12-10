using System.Collections.Generic;

namespace Sdk4me
{
    public class ProblemHandler : BaseHandler<Problem>
    {
        private static readonly string qualityUrl = "https://api.4me.qa/v1/problems";
        private static readonly string productionUrl = "https://api.4me.com/v1/problems";

        public ProblemHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ProblemHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region configuration items

        public List<ConfigurationItem> GetConfigurationItems(Problem problem, params string[] attributeNames)
        {
            BaseHandler<ConfigurationItem> handler = new BaseHandler<ConfigurationItem>($"{URL}/{problem.ID}/cis", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region notes

        public List<Note> GetNotes(Problem problem, params string[] attributeNames)
        {
            BaseHandler<Note> handler = new BaseHandler<Note>($"{URL}/{problem.ID}/notes", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            handler.SortOrder = SortOrder.CreatedAtAndID;
            return handler.Get(attributeNames);
        }

        #endregion

        #region requests

        public List<Request> GetRequests(Problem problem, params string[] attributeNames)
        {
            BaseHandler<Request> handler = new BaseHandler<Request>($"{URL}/{problem.ID}/requests", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region service instances

        public List<ServiceInstance> GetServiceInstances(Problem problem, params string[] attributeNames)
        {
            BaseHandler<ServiceInstance> handler = new BaseHandler<ServiceInstance>($"{URL}/{problem.ID}/service_instances", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion
    }
}
