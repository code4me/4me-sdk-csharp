using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/teams/">team</see> API endpoint.
    /// </summary>
    public class TeamHandler : BaseHandler<Team, PredefinedEnabledDisabledFilter>
    {
        /// <summary>
        /// Create a new instance of the 4me team handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public TeamHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/teams", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me team handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public TeamHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/teams", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Members

        /// <summary>
        /// Get all team members.
        /// </summary>
        /// <param name="team">The team.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of people.</returns>
        public List<Person> GetMembers(Team team, params string[] fieldNames)
        {
            return GetChildHandler<Person>(team, "members").Get(fieldNames);
        }

        /// <summary>
        /// Get all team members.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="team">The team.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of people.</returns>
        public List<Person> GetMembers(PredefinedTeamMemberFilter filter, Team team, params string[] fieldNames)
        {
            return GetChildHandler<Person>(team, $"members/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add a team member.
        /// </summary>
        /// <param name="team">The team.</param>
        /// <param name="person">The person to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddMember(Team team, Person person)
        {
            return CreateRelation(team, "members", person);
        }

        /// <summary>
        /// Remove a team member.
        /// </summary>
        /// <param name="team">The team.</param>
        /// <param name="person">The person to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveMember(Team team, Person person)
        {
            return DeleteRelation(team, "members", person);
        }

        /// <summary>
        /// Remove all team members.
        /// </summary>
        /// <param name="team">The team.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveAllMembers(Team team)
        {
            return DeleteAllRelations(team, "members");
        }

        #endregion

        #region Services instances

        /// <summary>
        /// Get all related service instances.
        /// </summary>
        /// <param name="team">The team.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of service instances.</returns>
        public List<ServiceInstance> GetServiceInstances(Team team, params string[] fieldNames)
        {
            return GetChildHandler<ServiceInstance>(team, "service_instances").Get(fieldNames);
        }

        /// <summary>
        /// Get all related service instances.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="team">The team.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of service instances.</returns>
        public List<ServiceInstance> GetServiceInstances(PredefinedActiveInactiveFilter filter, Team team, params string[] fieldNames)
        {
            return GetChildHandler<ServiceInstance>(team, $"service_instances/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion
    }
}
