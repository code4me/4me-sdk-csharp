using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/skill_pools/">skill pool</see> API endpoint.
    /// </summary>
    public class SkillPoolHandler : BaseHandler<SkillPool, PredefinedEnabledDisabledFilter>
    {
        /// <summary>
        /// Create a new instance of the 4me skill pool handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public SkillPoolHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/skill_pools", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me skill pool handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public SkillPoolHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/skill_pools", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Members

        /// <summary>
        /// Get all skill pool members.
        /// </summary>
        /// <param name="skillPool">The skill pool.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of people.</returns>
        public List<Person> GetMembers(SkillPool skillPool, params string[] fieldNames)
        {
            return GetChildHandler<Person>(skillPool, "members").Get(fieldNames);
        }

        /// <summary>
        /// Get all skill pool members.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="skillPool">The skill pool.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of people.</returns>
        public List<Person> GetMembers(PredefinedPeopleFilter filter, SkillPool skillPool, params string[] fieldNames)
        {
            return GetChildHandler<Person>(skillPool, $"members/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add a member.
        /// </summary>
        /// <param name="skillPool">The skill pool.</param>
        /// <param name="person">The person to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddMember(SkillPool skillPool, Person person)
        {
            return CreateRelation(skillPool, "members", person);
        }

        /// <summary>
        /// Remove a member.
        /// </summary>
        /// <param name="skillPool">The skill pool.</param>
        /// <param name="person">The person to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveMember(SkillPool skillPool, Person person)
        {
            return DeleteRelation(skillPool, "members", person);
        }

        /// <summary>
        /// Remove all members.
        /// </summary>
        /// <param name="skillPool">The skill pool.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveMembers(SkillPool skillPool)
        {
            return DeleteAllRelations(skillPool, "members");
        }

        #endregion
    }
}
