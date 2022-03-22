using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    public class SkillPoolHandler : BaseHandler<SkillPool, PredefinedEnabledDisabledFilter>
    {
        public SkillPoolHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/skill_pools", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public SkillPoolHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/skill_pools", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Members

        public List<Person> GetMembers(SkillPool request, params string[] fieldNames)
        {
            return GetChildHandler<Person>(request, "members").Get(fieldNames);
        }

        public List<Person> GetMembers(PredefinedPeopleFilter filter, SkillPool request, params string[] fieldNames)
        {
            return GetChildHandler<Person>(request, $"members/{filter.To4meString()}").Get(fieldNames);
        }

        public bool AddMember(SkillPool request, Person person)
        {
            return CreateRelation(request, "members", person);
        }

        public bool RemoveMember(SkillPool request, Person person)
        {
            return DeleteRelation(request, "members", person);
        }

        public bool RemoveMembers(SkillPool request)
        {
            return DeleteAllRelations(request, "members");
        }

        #endregion
    }
}
