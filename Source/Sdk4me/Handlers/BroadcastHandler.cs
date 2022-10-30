using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/broadcasts/">broadcast</see> API endpoint.
    /// </summary>
    public class BroadcastHandler : BaseHandler<Broadcast, PredefinedActiveInactiveFilter>
    {
        /// <summary>
        /// Create a new instance of the 4me broadcast handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public BroadcastHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/broadcasts", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me broadcast handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public BroadcastHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/broadcasts", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Customers

        /// <summary>
        /// Get all customers of a broadcast.
        /// </summary>
        /// <param name="broadcast">The broadcast.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A list of organizations.</returns>
        public List<Organization> GetCustomers(Broadcast broadcast, params string[] fieldNames)
        {
            return GetChildHandler<Organization>(broadcast, "customers").Get(fieldNames);
        }

        /// <summary>
        /// Get all customers of a broadcast.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="broadcast">The broadcast.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A list of organizations.</returns>
        public List<Organization> GetCustomers(PredefinedOrganizationFilter filter, Broadcast broadcast, params string[] fieldNames)
        {
            return GetChildHandler<Organization>(broadcast, $"customers/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add a customer to a broadcast.
        /// </summary>
        /// <param name="broadcast">The broadcast.</param>
        /// <param name="organization">The customer to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddCustomer(Broadcast broadcast, Organization organization)
        {
            return CreateRelation(broadcast, "customers", organization);
        }

        /// <summary>
        /// Remove a customer from a broadcast.
        /// </summary>
        /// <param name="broadcast">The broadcast.</param>
        /// <param name="organization">The customer to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveCustomer(Broadcast broadcast, Organization organization)
        {
            return DeleteRelation(broadcast, "customers", organization);
        }

        #endregion

        #region Service instances

        /// <summary>
        /// Get all related service instances.
        /// </summary>
        /// <param name="broadcast">The broadcast.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A list of service instances.</returns>
        public List<ServiceInstance> GetServiceInstances(Broadcast broadcast, params string[] fieldNames)
        {
            return GetChildHandler<ServiceInstance>(broadcast, "service_instances").Get(fieldNames);
        }

        /// <summary>
        /// Get all related service instances.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="broadcast">The broadcast.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A list of service instances.</returns>
        public List<ServiceInstance> GetServiceInstances(PredefinedActiveInactiveFilter filter, Broadcast broadcast, params string[] fieldNames)
        {
            return GetChildHandler<ServiceInstance>(broadcast, $"service_instances/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add a service instance.
        /// </summary>
        /// <param name="broadcast">The broadcast.</param>
        /// <param name="serviceInstance">The service instance to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddServiceInstance(Broadcast broadcast, ServiceInstance serviceInstance)
        {
            return CreateRelation(broadcast, "service_instances", serviceInstance);
        }

        /// <summary>
        /// Remove a service instance.
        /// </summary>
        /// <param name="broadcast">The broadcast.</param>
        /// <param name="serviceInstance">The service instance to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveServiceInstance(Broadcast broadcast, ServiceInstance serviceInstance)
        {
            return DeleteRelation(broadcast, "service_instances", serviceInstance);
        }

        #endregion

        #region Teams

        /// <summary>
        /// Get all related teams.
        /// </summary>
        /// <param name="broadcast">The broadcast.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A list of teams.</returns>
        public List<Team> GetTeams(Broadcast broadcast, params string[] fieldNames)
        {
            return GetChildHandler<Team>(broadcast, "teams").Get(fieldNames);
        }

        /// <summary>
        /// Get all related teams.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="broadcast">The broadcast.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A list of teams.</returns>
        public List<Team> GetTeams(PredefinedActiveInactiveFilter filter, Broadcast broadcast, params string[] fieldNames)
        {
            return GetChildHandler<Team>(broadcast, $"teams/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add a team.
        /// </summary>
        /// <param name="broadcast">The broadcast.</param>
        /// <param name="team">The team to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddTeams(Broadcast broadcast, Team team)
        {
            return CreateRelation(broadcast, "teams", team);
        }

        /// <summary>
        /// Remove a team.
        /// </summary>
        /// <param name="broadcast">The broadcast.</param>
        /// <param name="team">The team to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveTeams(Broadcast broadcast, Team team)
        {
            return DeleteRelation(broadcast, "teams", team);
        }

        #endregion

        #region Translations

        /// <summary>
        /// Get all broadcast translations.
        /// </summary>
        /// <param name="broadcast">The broadcast.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A list of broadcast translations.</returns>
        public List<BroadcastTranslation> GetTranslations(Broadcast broadcast, params string[] fieldNames)
        {
            return GetChildHandler<BroadcastTranslation>(broadcast, "translations").Get(fieldNames);
        }

        /// <summary>
        /// Add a broadcast translation.
        /// </summary>
        /// <param name="broadcast">The broadcast.</param>
        /// <param name="translation">The translation to add.</param>
        /// <returns>The updated broadcast translation.</returns>
        public BroadcastTranslation AddTranslation(Broadcast broadcast, BroadcastTranslation translation)
        {
            return GetChildHandler<BroadcastTranslation>(broadcast, "translations").Insert(translation);
        }

        /// <summary>
        /// update a broadcast translation.
        /// </summary>
        /// <param name="broadcast">The broadcast.</param>
        /// <param name="translation">The translation to update.</param>
        /// <returns>The updated broadcast translation.</returns>
        public BroadcastTranslation UpdateTranslation(Broadcast broadcast, BroadcastTranslation translation)
        {
            return GetChildHandler<BroadcastTranslation>(broadcast, "translations").Update(translation);
        }

        /// <summary>
        /// Delete a broadcast translation.
        /// </summary>
        /// <param name="broadcast">The broadcast.</param>
        /// <param name="translation">The translation to delete.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveTranslation(Broadcast broadcast, BroadcastTranslation translation)
        {
            return GetChildHandler<BroadcastTranslation>(broadcast, "translations").Delete(translation);
        }

        #endregion
    }
}
