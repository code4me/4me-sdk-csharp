using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    public class TeamHandler : BaseHandler<Team, PredefinedEnabledDisabledFilter>
    {
        public TeamHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/teams", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public TeamHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/teams", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Members

        public List<Person> GetMembers(Team team, params string[] fieldNames)
        {
            return GetChildHandler<Person>(team, "members").Get(fieldNames);
        }

        public List<Person> GetMembers(PredefinedTeamMemberFilter filter, Team team, params string[] fieldNames)
        {
            return GetChildHandler<Person>(team, $"members/{filter.To4meString()}").Get(fieldNames);
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

        #region Services instances

        public List<ServiceInstance> GetServiceInstances(Team team, params string[] fieldNames)
        {
            return GetChildHandler<ServiceInstance>(team, "service_instances").Get(fieldNames);
        }

        public List<ServiceInstance> GetServiceInstances(PredefinedActiveInactiveFilter filter, Team team, params string[] fieldNames)
        {
            return GetChildHandler<ServiceInstance>(team, $"service_instances/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion
    }
}
