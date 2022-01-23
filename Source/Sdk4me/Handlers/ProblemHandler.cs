using System.Collections.Generic;

namespace Sdk4me
{
    public class ProblemHandler : BaseHandler<Problem, PredefinedProblemFilter>
    {
        public ProblemHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/problems", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ProblemHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/problems", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region configuration items

        public List<ConfigurationItem> GetConfigurationItems(Problem problem, params string[] attributeNames)
        {
            DefaultHandler<ConfigurationItem> handler = new DefaultHandler<ConfigurationItem>($"{this.URL}/{problem.ID}/cis", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region notes

        public List<Note> GetNotes(Problem problem, params string[] attributeNames)
        {
            DefaultHandler<Note> handler = new DefaultHandler<Note>($"{this.URL}/{problem.ID}/notes", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests)
            {
                SortOrder = SortOrder.CreatedAt
            };
            return handler.Get(attributeNames);
        }

        #endregion

        #region requests

        public List<Request> GetRequests(Problem problem, params string[] attributeNames)
        {
            DefaultHandler<Request> handler = new DefaultHandler<Request>($"{this.URL}/{problem.ID}/requests", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region service instances

        public List<ServiceInstance> GetServiceInstances(Problem problem, params string[] attributeNames)
        {
            DefaultHandler<ServiceInstance> handler = new DefaultHandler<ServiceInstance>($"{this.URL}/{problem.ID}/service_instances", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region archive, trash and restore

        public Problem Archive(Problem problem)
        {
            return CustomWebRequest($"{problem.ID}/archive", "POST");
        }

        public Problem Trash(Problem problem)
        {
            return CustomWebRequest($"{problem.ID}/trash", "POST");
        }

        public Problem Restore(Archive archive)
        {
            return CustomWebRequest($"{archive.Details.ID}/restore", "POST");
        }

        public Problem Restore(Trash trash)
        {
            return CustomWebRequest($"{trash.Details.ID}/restore", "POST");
        }

        #endregion
    }
}
