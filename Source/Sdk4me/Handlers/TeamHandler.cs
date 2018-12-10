using System.Collections.Generic;

namespace Sdk4me
{
    public class TeamHandler : BaseHandler<Team>
    {
        private static readonly string qualityUrl = "https://api.4me.qa/v1/teams";
        private static readonly string productionUrl = "https://api.4me.com/v1/teams";

        public TeamHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public TeamHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region service instances

        public List<ServiceInstance> GetServiceInstances(Team team, params string[] attributeNames)
        {
            BaseHandler<ServiceInstance> handler = new BaseHandler<ServiceInstance>($"{URL}/{team.ID}/service_instances", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region members

        public List<Person> GetMembers(Team team, params string[] attributeNames)
        {
            BaseHandler<Person> handler = new BaseHandler<Person>($"{URL}/{team.ID}/members", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        public bool AddMember(Team team, Person person)
        {
            return CreateRelation(team, "members", person);
        }

        public bool RemoveMember(Team team, Person person)
        {
            return DeleteRelation(team, "members", person);
        }

        public bool RemoveAllMembers(Team team)
        {
            return DeleteAllRelations(team, "members");
        }

        #endregion
    }
}
