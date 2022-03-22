using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    public class BroadcastHandler : BaseHandler<Broadcast, PredefinedActiveInactiveFilter>
    {
        public BroadcastHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/broadcasts", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public BroadcastHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/broadcasts", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Customers

        public List<Organization> GetCustomers(Broadcast broadcast, params string[] fieldNames)
        {
            return GetChildHandler<Organization>(broadcast, "customers").Get(fieldNames);
        }

        public List<Organization> GetCustomers(PredefinedOrganizationFilter filter, Broadcast broadcast, params string[] fieldNames)
        {
            return GetChildHandler<Organization>(broadcast, $"customers/{filter.To4meString()}").Get(fieldNames);
        }

        public bool AddCustomer(Broadcast broadcast, Organization organization)
        {
            return CreateRelation(broadcast, "customers", organization);
        }

        public bool RemoveCustomer(Broadcast broadcast, Organization organization)
        {
            return DeleteRelation(broadcast, "customers", organization);
        }

        #endregion

        #region Service instances

        public List<ServiceInstance> GetServiceInstances(Broadcast broadcast, params string[] fieldNames)
        {
            return GetChildHandler<ServiceInstance>(broadcast, "service_instances").Get(fieldNames);
        }

        public List<ServiceInstance> GetServiceInstances(PredefinedActiveInactiveFilter filter, Broadcast broadcast, params string[] fieldNames)
        {
            return GetChildHandler<ServiceInstance>(broadcast, $"service_instances/{filter.To4meString()}").Get(fieldNames);
        }

        public bool AddServiceInstance(Broadcast broadcast, ServiceInstance serviceInstance)
        {
            return CreateRelation(broadcast, "service_instances", serviceInstance);
        }

        public bool RemoveServiceInstance(Broadcast broadcast, ServiceInstance serviceInstance)
        {
            return DeleteRelation(broadcast, "service_instances", serviceInstance);
        }

        #endregion

        #region Teams

        public List<Team> GetTeams(Broadcast broadcast, params string[] fieldNames)
        {
            return GetChildHandler<Team>(broadcast, "teams").Get(fieldNames);
        }

        public List<Team> GetTeams(PredefinedActiveInactiveFilter filter, Broadcast broadcast, params string[] fieldNames)
        {
            return GetChildHandler<Team>(broadcast, $"teams/{filter.To4meString()}").Get(fieldNames);
        }

        public bool AddTeams(Broadcast broadcast, Team team)
        {
            return CreateRelation(broadcast, "teams", team);
        }

        public bool RemoveTeams(Broadcast broadcast, Team team)
        {
            return DeleteRelation(broadcast, "teams", team);
        }

        #endregion

        #region Translations

        public List<BroadcastTranslation> GetTranslations(Broadcast broadcast, params string[] fieldNames)
        {
            return GetChildHandler<BroadcastTranslation>(broadcast, "translations").Get(fieldNames);
        }

        public BroadcastTranslation AddTranslation(Broadcast broadcast, BroadcastTranslation translation)
        {
            return GetChildHandler<BroadcastTranslation>(broadcast, "translations").Insert(translation);
        }

        public BroadcastTranslation UpdateTranslation(Broadcast broadcast, BroadcastTranslation translation)
        {
            return GetChildHandler<BroadcastTranslation>(broadcast, "translations").Update(translation);
        }

        public bool RemoveTranslation(Broadcast broadcast, BroadcastTranslation translation)
        {
            return GetChildHandler<BroadcastTranslation>(broadcast, "translations").Delete(translation);
        }

        #endregion
    }
}
