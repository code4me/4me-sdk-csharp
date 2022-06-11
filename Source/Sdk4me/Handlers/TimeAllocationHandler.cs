using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/time_allocations/">time allocation</see> API endpoint.
    /// </summary>
    public class TimeAllocationHandler : BaseHandler<TimeAllocation, PredefinedEnabledDisabledFilter>
    {
        /// <summary>
        /// Create a new instance of the 4me time allocation handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public TimeAllocationHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/time_allocations", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me time allocation handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public TimeAllocationHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/time_allocations", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Customers

        /// <summary>
        /// Get all related customers.
        /// </summary>
        /// <param name="timeAllocation">The time allocation.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of organizations.</returns>
        public List<Organization> GetCustomers(TimeAllocation timeAllocation, params string[] fieldNames)
        {
            return GetChildHandler<Organization>(timeAllocation, "customers").Get(fieldNames);
        }

        /// <summary>
        /// Get all related customers.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="timeAllocation">The time allocation.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of organizations.</returns>
        public List<Organization> GetCustomers(PredefinedEnabledDisabledFilter filter, TimeAllocation timeAllocation, params string[] fieldNames)
        {
            return GetChildHandler<Organization>(timeAllocation, $"customers/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add a customer.
        /// </summary>
        /// <param name="timeAllocation">The time allocation.</param>
        /// <param name="customer">The organization to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddCustomer(TimeAllocation timeAllocation, Organization customer)
        {
            return CreateRelation(timeAllocation, "customers", customer);
        }

        /// <summary>
        /// Remove a customer.
        /// </summary>
        /// <param name="timeAllocation">The time allocation.</param>
        /// <param name="customer">The organization to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveCustomer(TimeAllocation timeAllocation, Organization customer)
        {
            return DeleteRelation(timeAllocation, "customers", customer);
        }

        /// <summary>
        /// Remove all customers.
        /// </summary>
        /// <param name="timeAllocation">The time allocation.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveAllCustomers(TimeAllocation timeAllocation)
        {
            return DeleteAllRelations(timeAllocation, "customers");
        }

        #endregion

        #region Services

        /// <summary>
        /// Get all related services.
        /// </summary>
        /// <param name="timeAllocation">The time allocation.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of services.</returns>
        public List<Service> GetServices(TimeAllocation timeAllocation, params string[] fieldNames)
        {
            return GetChildHandler<Service>(timeAllocation, "services").Get(fieldNames);
        }

        /// <summary>
        /// Get all related services.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="timeAllocation">The time allocation.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of services.</returns>
        public List<Service> GetServices(PredefinedEnabledDisabledFilter filter, TimeAllocation timeAllocation, params string[] fieldNames)
        {
            return GetChildHandler<Service>(timeAllocation, $"services/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add a service.
        /// </summary>
        /// <param name="timeAllocation">The time allocation.</param>
        /// <param name="service">The service to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddService(TimeAllocation timeAllocation, Service service)
        {
            return CreateRelation(timeAllocation, "services", service);
        }

        /// <summary>
        /// Remove a service.
        /// </summary>
        /// <param name="timeAllocation">The time allocation.</param>
        /// <param name="service">The service to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveService(TimeAllocation timeAllocation, Service service)
        {
            return DeleteRelation(timeAllocation, "services", service);
        }

        /// <summary>
        /// Remove all services.
        /// </summary>
        /// <param name="timeAllocation">The time allocation.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveAllServices(TimeAllocation timeAllocation)
        {
            return DeleteAllRelations(timeAllocation, "services");
        }

        #endregion

        #region Organizations

        /// <summary>
        /// Get all related organization.
        /// </summary>
        /// <param name="timeAllocation">The time allocation.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of organizations.</returns>
        public List<Organization> GetOrganizations(TimeAllocation timeAllocation, params string[] fieldNames)
        {
            return GetChildHandler<Organization>(timeAllocation, "organizations").Get(fieldNames);
        }

        /// <summary>
        /// Get all related organization.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="timeAllocation">The time allocation.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of organizations.</returns>
        public List<Organization> GetOrganizations(PredefinedEnabledDisabledFilter filter, TimeAllocation timeAllocation, params string[] fieldNames)
        {
            return GetChildHandler<Organization>(timeAllocation, $"organizations/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add an organization.
        /// </summary>
        /// <param name="timeAllocation">The time allocation.</param>
        /// <param name="organization">The organization to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddOrganization(TimeAllocation timeAllocation, Organization organization)
        {
            return CreateRelation(timeAllocation, "organizations", organization);
        }

        /// <summary>
        /// Remove an organization.
        /// </summary>
        /// <param name="timeAllocation">The time allocation.</param>
        /// <param name="organization">The organization to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveOrganization(TimeAllocation timeAllocation, Organization organization)
        {
            return DeleteRelation(timeAllocation, "organizations", organization);
        }

        /// <summary>
        /// Remove all organizations.
        /// </summary>
        /// <param name="timeAllocation">The time allocation.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveAllOrganizations(TimeAllocation timeAllocation)
        {
            return DeleteAllRelations(timeAllocation, "organizations");
        }

        #endregion
    }
}
