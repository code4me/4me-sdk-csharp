using System.Collections.Generic;

namespace Sdk4me
{
    public class TeamHandler : BaseHandler<Team, PredefinedTeamFilter>
    {
        public TeamHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/teams",  authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public TeamHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/teams",  authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region service instances

        public List<ServiceInstance> GetServiceInstances(Team team, params string[] attributeNames)
        {
            DefaultHandler<ServiceInstance> handler = new DefaultHandler<ServiceInstance>($"{URL}/{team.ID}/service_instances", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region members

        public List<Person> GetMembers(Team team, params string[] attributeNames)
        {
            DefaultHandler<Person> handler = new DefaultHandler<Person>($"{URL}/{team.ID}/members", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
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
